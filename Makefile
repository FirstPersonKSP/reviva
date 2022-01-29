CSC	= csc

KSP	= /mnt/c/Program Files (x86)/Steam/steamapps/common/Kerbal Space Program
MANAGED	= $(KSP)/KSP_x64_Data/Managed

ROOT	= .
SRC	= $(ROOT)/plugin
BUILD	= $(ROOT)/build
SRCS	= $(SRC)/IVASwitchPart.cs
DLL	= $(BUILD)/Reviva.dll

build: $(DLL)

$(DLL): $(SRCS)
	mkdir -p $(BUILD)
	$(CSC) /noconfig /target:library /platform:AnyCPU \
		/reference:"$(MANAGED)/Assembly-CSharp.dll" \
		/reference:"$(MANAGED)/Assembly-CSharp-firstpass.dll" \
		/reference:"$(MANAGED)/mscorlib.dll" \
		/reference:"$(MANAGED)/System.Core.dll" \
		/reference:"$(MANAGED)/System.dll" \
		/reference:"$(MANAGED)/UnityEngine.CoreModule.dll" \
		/recurse:"plugin/*.cs" \
		-out:$@
