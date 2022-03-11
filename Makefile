# KSP	= /mnt/c/Program Files (x86)/Steam/steamapps/common/Kerbal Space Program
KSP		= /mnt/c/Games/KSP-Dev
MANAGED		= $(KSP)/KSP_x64_Data/Managed

CSC		= csc
ROOT		= .
SRC		= $(ROOT)/plugin
BUILD		= $(ROOT)/build
GAMEDATA	= $(ROOT)/GameData
SRCS		= $(SRC)/ModuleIVASwitch.cs \
		  $(SRC)/BaseComputer.cs \
		  $(SRC)/RPMComputer.cs \
		  $(SRC)/MASComputer.cs
GENS		= $(BUILD)/AssemblyInfo.cs
CFGS		= $(shell find $(GAMEDATA) -type f -print)
DEPS		= $(SRCS) $(CFGS) $(ROOT)/Makefile

PKG		= $(BUILD)/GameData/Reviva
DLL		= $(BUILD)/Reviva.dll
FLAGS		= -optimize+ -debug-
DEFS		=
# DEFS		= -define:REVIVA_DEBUG

VER_GIT		:= $(shell git describe --tags --long --always HEAD)
VER		= $(subst -, ,$(subst ., ,$(VER_GIT)))
VER_MAJOR	= $(word 1,$(VER))
VER_MINOR	= $(word 2,$(VER))
VER_PATCH	= $(word 3,$(VER))
VER_BUILD	= $(word 4,$(VER))
VER_SHA		= $(word 5,$(VER))
GIT_TAG		= $(VER_MAJOR).$(VER_MINOR).$(VER_PATCH)
PKG_ZIP		= Reviva-$(GIT_TAG).zip

build: $(DLL)

version:
	@echo VER_GIT=$(VER_GIT) \
	VER_MAJOR=$(VER_MAJOR) \
	VER_MINOR=$(VER_MINOR) \
	VER_PATCH=$(VER_PATCH) \
	VER_BUILD=$(VER_BUILD)

$(DLL): $(SRCS) $(GENS)
	mkdir -p "$(BUILD)"
	$(CSC) -noconfig -target:library -platform:AnyCPU -langversion:8.0 \
		-nostdlib+ $(FLAGS) $(DEFS) \
		-reference:"$(MANAGED)/Assembly-CSharp.dll" \
		-reference:"$(MANAGED)/Assembly-CSharp-firstpass.dll" \
		-reference:"$(MANAGED)/mscorlib.dll" \
		-reference:"$(MANAGED)/System.Core.dll" \
		-reference:"$(MANAGED)/System.dll" \
		-reference:"$(MANAGED)/UnityEngine.CoreModule.dll" \
		-out:$@ \
		$(SRCS) $(GENS)

$(BUILD)/AssemblyInfo.cs: $(SRC)/AssemblyInfo.cs.in $(DEPS)
	mkdir -p "$(BUILD)"
	sed -e 's/%%VER_GIT%%/$(VER_GIT)/g' \
	    -e 's/%%VER_MAJOR%%/$(VER_MAJOR)/g' \
	    -e 's/%%VER_MINOR%%/$(VER_MINOR)/g' \
	    -e 's/%%VER_PATCH%%/$(VER_PATCH)/g' \
	    -e 's/%%VER_BUILD%%/$(VER_BUILD)/g' \
	    -e 's/%%VER_SHA%%/$(VER_SHA)/g' \
	    < $(SRC)/AssemblyInfo.cs.in > $@

clean:
	rm -rf "$(BUILD)"

package: build
	rm -rf $(PKG)
	mkdir -p $(BUILD)/GameData
	cp -a $(GAMEDATA)/Reviva $(BUILD)/GameData
	cp $(DLL) $(PKG)
	find "$(PKG)" -name '*~' -print0 | xargs -0 rm -f
	rm -f $(BUILD)/$(PKG_ZIP)
	cd $(BUILD); zip $(PKG_ZIP) -r GameData

install: package
	rm -rf "$(KSP)/GameData/Reviva"
	cp -a "$(PKG)" "$(KSP)/GameData"

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

github-release: package
	gh release create $(GIT_TAG) --title "$(GIT_TAG)" --notes ""
	gh release upload $(GIT_TAG) $(BUILD)/$(PKG_ZIP)
