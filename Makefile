CSC	= csc

# KSP	= /mnt/c/Program Files (x86)/Steam/steamapps/common/Kerbal Space Program
KSP	= /mnt/c/Games/KSP Dev
MANAGED	= $(KSP)/KSP_x64_Data/Managed

ROOT	= .
SRC	= $(ROOT)/plugin
BUILD	= $(ROOT)/build
GAMEDATA= $(ROOT)/GameData
SRCS	= $(SRC)/IVASwitchPart.cs
DLL	= $(BUILD)/Reviva.dll

build: $(DLL)

$(DLL): $(SRCS)
	mkdir -p "$(BUILD)"
	$(CSC) /noconfig /target:library /platform:AnyCPU \
		/reference:"$(MANAGED)/Assembly-CSharp.dll" \
		/reference:"$(MANAGED)/Assembly-CSharp-firstpass.dll" \
		/reference:"$(MANAGED)/mscorlib.dll" \
		/reference:"$(MANAGED)/System.Core.dll" \
		/reference:"$(MANAGED)/System.dll" \
		/reference:"$(MANAGED)/UnityEngine.CoreModule.dll" \
		/recurse:"plugin/*.cs" \
		-out:$@


install: build
	rm -rf "$(KSP)/GameData/Reviva"
	find "$(GAMEDATA)/Reviva" -name '*~' -print0 | xargs -0 rm -f
	cp -a "$(GAMEDATA)/Reviva" "$(KSP)/GameData"
	cp "$(DLL)" "$(KSP)/GameData/Reviva"

# find "$(KSP)/GameData/JSI/RPMPodPatches" -name '*.cfg' -print0 | xargs -0 egrep -n '^[ \\t]*[@+]?INTERNAL'

list-internals:
	@find "$(KSP)/GameData" -name '*.cfg' -print0 | xargs -0 cat | unix2dos |	\
	awk '/^[ 	]*[@+]?INTERNAL/						\
	{										\
		internal = 1;								\
	}										\
	/name =/ && internal {								\
		internal = 0;								\
		print $$3;								\
	}' | sort -u

list-parts:
	@find "$(KSP)/GameData" -name '*.cfg' -print0 | xargs -0 cat | unix2dos |	\
	awk '/^[	 ]*PART/							\
	{										\
		part = 1;								\
	}										\
	/name =/ && part == 1 {								\
		part = 2;								\
		name = $$3;								\
	}										\
	/^[ 	]*[@+]?INTERNAL/ && part == 2 {						\
		part = 0;								\
		print name;								\
	}' | sort -u
