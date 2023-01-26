# KSP_ROOT	= /mnt/c/Program Files (x86)/Steam/steamapps/common/Kerbal Space Program
KSP_ROOT	= /mnt/c/Games/KSP-Dev
KSP_VER		= 1.12.4
MANAGED		= $(KSP_ROOT)/KSP_x64_Data/Managed

ROOT		= .
SRC		= $(ROOT)/plugin
BUILD		= $(ROOT)/build
GAMEDATA	= $(ROOT)/GameData
SRCS		= $(SRC)/AssemblyInfo.cs \
		  $(SRC)/ModuleIVASwitch.cs \
		  $(SRC)/BaseComputer.cs \
		  $(SRC)/RPMComputer.cs \
		  $(SRC)/MASComputer.cs
CFGS		= $(shell find $(GAMEDATA) -type f -print)

PKG		= $(BUILD)/GameData/Reviva
DLL		= $(SRC)/bin/$(CONFIG)/net48/Reviva.dll
CONFIG		= Release
# CONFIG		= Debug

VER_GIT		:= $(shell git describe --tags --long --always HEAD)
VER		= $(subst -, ,$(subst ., ,$(VER_GIT)))
VER_MAJOR	= $(word 1,$(VER))
VER_MINOR	= $(word 2,$(VER))
VER_PATCH	= $(word 3,$(VER))
VER_BUILD	= $(word 4,$(VER))
VER_SHA		= $(word 5,$(VER))
GIT_TAG		= $(VER_MAJOR).$(VER_MINOR).$(VER_PATCH)
PKG_ZIP		= Reviva-$(GIT_TAG).zip

CHANGES		= $(BUILD)/Changes-$(GIT_TAG).md
SD_COOKIES	= $(BUILD)/cookies
SD_USER		= 610yesnolovely
SD_MODID	= 2990

build: assembly $(DLL)

version:
	@echo VER_GIT=$(VER_GIT) \
	VER_MAJOR=$(VER_MAJOR) \
	VER_MINOR=$(VER_MINOR) \
	VER_PATCH=$(VER_PATCH) \
	VER_BUILD=$(VER_BUILD)

$(DLL): $(SRCS)
	mkdir -p "$(BUILD)"
	KSP_ROOT=$(KSP_ROOT) dotnet build -c $(CONFIG) Reviva.sln

assembly:
	sed -e 's/%%VER_GIT%%/$(VER_GIT)/g' \
	    -e 's/%%VER_MAJOR%%/$(VER_MAJOR)/g' \
	    -e 's/%%VER_MINOR%%/$(VER_MINOR)/g' \
	    -e 's/%%VER_PATCH%%/$(VER_PATCH)/g' \
	    < $(SRC)/AssemblyInfo.cs.in > $(SRC)/AssemblyInfo.cs

clean:
	rm -rf "$(BUILD)"

clobber: clean
	rm -rf plugin/obj
	rm -rf plugin/bin

package: build
	rm -rf $(PKG)
	mkdir -p $(BUILD)/GameData
	cp -a $(GAMEDATA)/Reviva $(BUILD)/GameData
	cp $(DLL) $(PKG)
	find "$(PKG)" -name '*~' -print0 | xargs -0 rm -f
	rm -f $(BUILD)/$(PKG_ZIP)
	cd $(BUILD); zip $(PKG_ZIP) -r GameData

install: package
	rm -rf "$(KSP_ROOT)/GameData/Reviva"
	cp -a "$(PKG)" "$(KSP_ROOT)/GameData"

list-internals:
	@find "$(KSP_ROOT)/GameData" -name '*.cfg' -print0 | xargs -0 cat | unix2dos |	\
	awk '/^[ 	]*[@+]?INTERNAL/						\
	{										\
		internal = 1;								\
	}										\
	/name =/ && internal {								\
		internal = 0;								\
		print $$3;								\
	}' | sort -u

list-parts:
	@find "$(KSP_ROOT)/GameData" -name '*.cfg' -print0 | xargs -0 cat | unix2dos |	\
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

build-changes:
	@sed -E -n -e '/^### $(GIT_TAG) Release/,/^###.*/p' < $(ROOT)/README.md | \
		head -n -1 | \
		sed -E -e 's/\[([^]]*)\]\[[^]]*\]/\1/g' > $(CHANGES)

github-release: build-changes
	gh auth status
	gh release create $(GIT_TAG) --title "$(GIT_TAG)" --notes-file $(CHANGES)
	gh release upload $(GIT_TAG) $(BUILD)/$(PKG_ZIP)

spacedock-login:
	curl -F username=$(SD_USER) \
		-F password=`op item get --fields label=password SpaceDock` \
		-c $(SD_COOKIES) "https://spacedock.info/api/login"

spacedock-release: build-changes
	curl -c $(SD_COOKIES) -b $(SD_COOKIES) -F "version=$(GIT_TAG)" \
		-F "changelog=$$(sed -E -e 's/$$/\r/g' < $(CHANGES))" \
		-F "game-version=$(KSP_VER)" \
		-F "notify-followers=yes" \
		-F "zipball=@$(BUILD)/$(PKG_ZIP)" \
		"https://spacedock.info/api/mod/$(SD_MODID)/update"

release:
	$(MAKE) package
	$(MAKE) github-release
	$(MAKE) spacedock-login
	$(MAKE) spacedock-release
