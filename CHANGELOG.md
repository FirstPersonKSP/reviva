# Changelog

## Unreleased

- Fix issues with mk3 shuttle mid-deck
- Add FASA as an option for BDB apollo command pod
- Remove option for ASET mk1-2 from BDB apollo CM if it's not installed
- Fix some issues when MAS is installed but a part doesn't have a MASFlightComputer

## 1.0.0 Release - Major Updates by JonnyOThan

[JonnyOThan][kspf:JonnyOThan] is awesome! He's now a co-contributor for Reviva on
GitHub, so he has full power and authority to do anything with the mod.

This release is mostly due to his hard work to really make this mod shine.

- Giant refactoring of patches to make it easier to add support for mods and parts
- Fixed bugs regarding RPM variable persistence and action group memos being lost
- Fixed bugs that prevented ProbeControlRoom from working properly with Reviva
- Added Apex and Kermantech options for mk3 cockpit
- Fixed some configuration bugs


## 0.8.1 Release - Bug fixing (2nd Jan 2023)

### Fixes:

- Added support for AirplanePlus Mk1/0 Caged Inline (same as Mk1 Caged Inline).
  - Note that the part does not fit exactly and has the wrong interior window structure, but
	is better than nothing.


## 0.8.0 Release - Bug fixing (16th Dec 2022)

### Fixes:

- [Fix GitHub Issue 9][url:GitHubIssue9]: Thanks to [JonnyOThan][kspf:JonnyOThan]:
  - Clone the partInfo so that changes to the internal config don't affect all instances of the same
	part.
- Extra fix from [Fix GitHub Issue 9][url:GitHubIssue9], again thanks to [JonnyOThan][kspf:JonnyOThan]:
  - Fix an issue with internals that don't have crew capacity, exposed by FreeIva.


## 0.7.7 Release - BDB 1.11 Support (22nd Oct 2022)

### Adds:

- Slightly improved support for BDB 1.11 Release.
  - Hermes/Mercury: Added Placeholder (empty) and BDBAlternate (super minimal, non-functional)
  - Vinci/Gemini: Added Placeholder (empty) and BDBAlternate (old FASA, non-functional)
  - Kane/Apollo: Added Placeholder (empty) and BDBRPM (functional RPM variant of non-functional BDB)
  - Sina/LEM: Added Placeholder (empty) and BDB2 (new BDB non-functional IVA), the older BDB remains
	unchanged for compatibility.

### Notes:

- Previous Reviva 0.7.6, 0.7.5, 0.7.4 will still work fine with BDB 1.11 - though the new
  non-functional LEM IVA will not be selectable.
- Currently no LEM variants have IVA switching: ie. no engine cover, Taxi, Lab, Shelter. You get the
  BDB default only.
- Similarly any Mercury, Gemini or Apollo variants (eg. Big Gemini or Apollo 5-Crew) do not have IVA
  switching, BDB default only.


## 0.7.6 Release - Moar IVA and BDB (24th Sep 2022)

### Adds:

- Support for:
  - [Starilex Intra-Vehicular Solutions][url:SIVSIVA] - an excellent retro Mk1
	pod. Available for Stock Mk1 and BDB Hermes / Mercury CM. Uses RPM.
  - [Max-Ksp MAS IVA Pack][url:MaxKspIVA] - excellent retro Mk1-3 and MEM pods. Available for Stock
	Mk1-3, Making History MEM, BDB Kane / Apollo,  Sina / LEM. Uses MAS.
  - [SABS\_IVA: MAS-enabled IVA][url:SABSIVA] - partial support (it provides a full set of Stock and
	Making History pods using MAS) for Mk1, Mk2, Mk1-3, MEM and BDB equivalents. Uses MAS. These
	are work-in-progress, I may add configs for everything else later.
  - [Snakeru's Mk2 Pod IVA][url:SnakeruIVA] - excelent retro style Mk2. Available for Stock and BDB
	Vinci / Gemini. Note that this is a ZIP file in a GitHub issue and is Beta, but to me is the
	best retro MAS style IVA for the Mk2.


## 0.7.5 Release - Airplane Plus (28th Apr 2022)

### Adds:

- Support for Airplane Plus:
  - Warbirds (Bell Heli, Citation, Old Fighter Inline, X1 Supersonic, B29 Bomber)
	- [Warbird Cockpits][url:WarbirdCockpits]
  - Airplane Plus IVA Pack (Bell Heli, Bombardier Jet, Cessna, F-18 Fighter, Huey Heli)
	- [Airplane Plus IVA Pack][url:APIP]
	- Airplane Plus F-16 
	- [ASET/RPM for Falcon cockpit][url:APF16]
	- Needs to be installed in GameData/AirplanePlusFalcon.


## 0.7.4 Release - BDB experimental (28th Apr 2022)

### Adds:

- Added "Experimental" support for MOARdvPlus BDB Kane (Apollo) CM:
  - [MOARdV's Avionics System (MAS)][url:AvionicsSystems]
  - Only covers the standard 3 crew Kane/Apollo CM.
  - Original MOARdVPlus FASA variants still present and unmodified,
	they're hidden, don't use them as they won't work as well.
  - Reviva MM config changed to support BDB 1.10.x naming
  - Specialized action group switches work (eg. EVA Light)
  - Glass variant also seems to work.
  - Interior model does not match exterior so "Interior Overlay" will not look great.
  - Will improve when BDB updates the interior.
  - Also even more "Experimental", all Mk1-3 IVA interiors also available and seem to be functional,
	but definitely look even more silly with "Interior Overlay". Will not ever fix this.

### Fixes:

- Fix MASFlightComputer support to correctly update config data.
  - This was required to get the MOARdVPlus special action groups to work.
  - Probably helps make other IVA a little more accurate.
- Updated README.md with more IVAs, and links to completed mods.


## 0.7.3 Release - Bug fixes (12th Apr 2022)

### Fixes:

- Support QuickIVA when loading strait to IVA ([GitHub Issue #6][url:GitHubIssue6])
- Handle any configuration errors by remaining on same IVA ([GitHub Issue #5][url:GitHubIssue5])


## 0.7.2 Release - Bug fixes (11th Mar 2022)

### Fixes:

- Undocking two of same craft causing crash ([GitHub Issue #3][url:GitHubIssue3])
- Correctly switch IVA for in-flight craft where multiple similar craft present ([GitHub Issue #4][url:GitHubIssue4])


## 0.7.1 Release - Stock and Missing History (28th Feb 2022)

- Support Missing History KV-1, KV-2, KV-3, MK2 command pod and M.E.M. lander.
- Configurations for Stock, ASET IVA for Making History Pods, and MAS alternatives for Mk2
  and M.E.M (the KV pods are meant to be low to medium tech only).


## 0.7.0 Pre-Release (3rd Feb 2022)

- Support for RasterPropMonitor (RPM) and/or Avionics System (MAS) IVA.
- Covers stock command pods, cockpits, landers and cuppola only.
- Configurations for Stock, RPM, MAS, ASET, DE_IVAExtension, Warbird Cokcpits and Ultimate
  Shuttle IVA variants.