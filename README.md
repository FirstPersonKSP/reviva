# KSP 1.12.x - Reviva - The IVA Revival!

![Reviva Screenshot][url:Screenshot]

# KSP Reviva is the IVA Revival! For Kerbals who like to fly first person.

- Supports multiple IVA mods at once (IVA mods not included).
- Supports RPM and MAS.
- Allows IVA internal switch via B9PartSwitch:
  - Allows selecting different IVA on each command module in editor/saves.
  - Allows for on-the-fly IVA switching while in flight.

Soon :: CKAN support so you can install Reviva and all the IVA mods you ever wanted.

Currently only stock IVA and some popular IVA mods are covered, the intent is to extended
the coverage over time.

## Required Mods

- Reviva - note that this does not include any other mods below in the download.
  - [KSP Forums][url:Forum]
  - [GitHub Latest Release][url:GitHubLatest]
    - Download and extract the Reviva-x.x.x.zip file at the root of your KSP installation.
  - SpaceDock - [SpaceDock][url:SpaceDock]
  - CKAN - Available
  - Curse - Probably never
- [B9PartSwitch][url:B9PartSwitch]
- [ModuleManager][url:ModuleManager]
- [RasterPropMonitor (RPM)][url:RasterPropMonitor]

## Recommended Mods

- [DEIVAExtension][url:DEIVAExtension]

## Optional Mods

- [MOARdV's Avionics System (MAS)][url:AvionicsSystems]
- [ASET Mk1 Cockpit][url:ASETMk1Cockpit]
- [ASET Mk1 Lander Can][url:ASETMk1LanderCan]
- [ASET Mk1-2 Command Pod][url:ASETMk1-2CommandPod]
- [Warbird Cockpits][url:WarbirdCockpits]
- [Ultimate Shuttle IVA][url:UltimateShuttleIVA]
- [ASET IVA for Making History Pods][url:ASETIVAforMakingHistoryPods]
- Many more, see [Support Progress][url:SupportProgress] and [Dependency Summary][url:DependencySummary]
  for the full list as more are supported. Some IVA mods require downloading from GitHub, Dropbox or
  even Zip files in GitHub issues and must be installed in their suggestion locations for Reviva to
  work correctly (directory names under GameData are very important).

## Changes

### 1.0.0 Release - Major Updates by JonnyOThan

[JonnyOThan][kspf:JonnyOThan] is awesome! He's now a co-contributor for Reviva on
GitHub, so he has full power and authority to do anything with the mod.

This release is mostly due to his hard work to really make this mod shine.

- Giant refactoring of patches to make it easier to add support for mods and parts
- Fixed bugs regarding RPM variable persistence and action group memos being lost
- Fixed bugs that prevented ProbeControlRoom from working properly with Reviva
- Added Apex and Kermantech options for mk3 cockpit
- Fixed some configuration bugs


### 0.8.1 Release - Bug fixing (2nd Jan 2023)

Fixes:

- Added support for AirplanePlus Mk1/0 Caged Inline (same as Mk1 Caged Inline).
  - Note that the part does not fit exactly and has the wrong interior window structure, but
    is better than nothing.

### 0.8.0 Release - Bug fixing (16th Dec 2022)

Fixes:

- [Fix GitHub Issue 9][url:GitHubIssue9]: Thanks to [JonnyOThan][kspf:JonnyOThan]:
  - Clone the partInfo so that changes to the internal config don't affect all instances of the same
    part.
- Extra fix from [Fix GitHub Issue 9][url:GitHubIssue9], again thanks to [JonnyOThan][kspf:JonnyOThan]:
  - Fix an issue with internals that don't have crew capacity, exposed by FreeIva.

### 0.7.7 Release - BDB 1.11 Support (22nd Oct 2022)

Adds:

- Slightly improved support for BDB 1.11 Release.
  - Hermes/Mercury: Added Placeholder (empty) and BDBAlternate (super minimal, non-functional)
  - Vinci/Gemini: Added Placeholder (empty) and BDBAlternate (old FASA, non-functional)
  - Kane/Apollo: Added Placeholder (empty) and BDBRPM (functional RPM variant of non-functional BDB)
  - Sina/LEM: Added Placeholder (empty) and BDB2 (new BDB non-functional IVA), the older BDB remains
    unchanged for compatibility.

NOTES:
- Previous Reviva 0.7.6, 0.7.5, 0.7.4 will still work fine with BDB 1.11 - though the new
  non-functional LEM IVA will not be selectable.
- Currently no LEM variants have IVA switching: ie. no engine cover, Taxi, Lab, Shelter. You get the
  BDB default only.
- Similarly any Mercury, Gemini or Apollo variants (eg. Big Gemini or Apollo 5-Crew) do not have IVA
  switching, BDB default only.

### 0.7.6 Release - Moar IVA and BDB (24th Sep 2022)

Adds:

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
  
### 0.7.5 Release - Airplane Plus (28th Apr 2022)

Adds:

- Support for Airplane Plus:
  - Warbirds (Bell Heli, Citation, Old Fighter Inline, X1 Supersonic, B29 Bomber)
    - [Warbird Cockpits][url:WarbirdCockpits]
  - Airplane Plus IVA Pack (Bell Heli, Bombardier Jet, Cessna, F-18 Fighter, Huey Heli)
    - [Airplane Plus IVA Pack][url:APIP]
    - Airplane Plus F-16 
    - [ASET/RPM for Falcon cockpit][url:APF16]
    - Needs to be installed in GameData/AirplanePlusFalcon.

### 0.7.4 Release - BDB experimental (28th Apr 2022)

Adds:

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

Fixes:

- Fix MASFlightComputer support to correctly update config data.
  - This was required to get the MOARdVPlus special action groups to work.
  - Probably helps make other IVA a little more accurate.
- Updated README.md with more IVAs, and links to completed mods.

### 0.7.3 Release - Bug fixes (12th Apr 2022)

Fixes:

- Support QuickIVA when loading strait to IVA ([GitHub Issue #6][url:GitHubIssue6])
- Handle any configuration errors by remaining on same IVA ([GitHub Issue #5][url:GitHubIssue5])

### 0.7.2 Release - Bug fixes (11th Mar 2022)

Fixes:

- Undocking two of same craft causing crash ([GitHub Issue #3][url:GitHubIssue3])
- Correctly switch IVA for in-flight craft where multiple similar craft present ([GitHub Issue #4][url:GitHubIssue4])

### 0.7.1 Release - Stock and Missing History (28th Feb 2022)

- Support Missing History KV-1, KV-2, KV-3, MK2 command pod and M.E.M. lander.
- Configurations for Stock, ASET IVA for Making History Pods, and MAS alternatives for Mk2
  and M.E.M (the KV pods are meant to be low to medium tech only).
  
### 0.7.0 Pre-Release (3rd Feb 2022)

- Support for RasterPropMonitor (RPM) and/or Avionics System (MAS) IVA.
- Covers stock command pods, cockpits, landers and cuppola only.
- Configurations for Stock, RPM, MAS, ASET, DE_IVAExtension, Warbird Cokcpits and Ultimate
  Shuttle IVA variants.

## For Players

If you like flying in first-person from the in-vehicle crewed cockpit, either in stock or
using [RPM][url:RasterPropMonitor] and/or [MAS][url:AvionicsSystems], then this mod is for you.

Features:

- Allow switching of IVA from stock to different alternates (if needed mods are loaded) using
  [B9PartSwitch][url:B9PartSwitch]
  
  - This can be done from the editor, and the settings are saved with the ship design.
  - This can *also* be done live from flight! Use the PAW right-click menu on the
    command module when not in IVA (yup, not realistic, but this is KSP). This allows for the
    player to load this mod on existing saves and change IVAs on already flying craft, or
    to try out different IVA.
  - Without Reviva, only the "last" IVA mod for each command module would be available.

- Links together stock and modded IVA into one place and provides limited patches to
  ensure they work in 1.12.x.
  
  - Note that this mod doesn't include the IVAs, but provides links for recommended or
    optional IVA mods, plus patches to allow them to run and be switched dynamically.

- Very low overhead on in-game CPU/GPU performance: command modules get an extra ModuleIVASwitch, and switch
  detection only happens when changes are made.

  - Note however that all the Internal modules are loaded into memory, so load times will be a little
    slower, and memory usage a little higher for each IVA pack you install. Don't go too crazy. The
    best way is to look at all the different IVA mods for a particular command pod or cockpit, try
    them out and pick one or two.

  - Note that the first option is usually the non-functional stock or original mod IVA, these
    typically have less performance impact.

- The different IVA selection does not change the characteristics, mass, cost or other
  data on the actual command pod: it's all visual for IVA. This means you can change at
  any time without penalty, by design.

## Thanks

- [blowfish][kspf:blowfish] :: For B9PartSwitch which provides all the clever part switching and UI.
- [Electrocutor][kspf:Electrocutor] :: For ideas in WPF and KSP forum that inspired idea.
- [sarbian][kspf:sarbian] :: For Module Manager which provides ways to reconfigure everything.
- [alexustas][kspf:alexustas] :: For the amazing ASET IVAs and props.
- [MOARdV][kspf:MOARdV], [JonnyOThan][kspf:JonnyOThan] :: For Raster Prop Monitor (RPM), making IVAs look all fancy.
- [MOARdV][kspf:MOARdV] :: For Avionics System (MAS), making IVAs look even more fancy.
- [DemonEin][kspf:DemonEin] :: For DE_IVAExtension which provides decent IVA for all of stock.
- [Honk Hogan][kspf:HonkHogan] :: For IVA_ASET_MAKING_HISTORY which provides decent IVA for Missing History.
- [theonegalen][kspf:theonegalen] :: For Warbird Cockpits IVA, and forum posts that inspired that this is
  possible.
- [G'th][kspf:Gth] :: For the Ultimate Shuttle IVA.
- [linuxgurugamer][kspf:linuxgurugamer] :: For the hopeful adoption of this mod if I wander off in the future.

## License

MIT License - (C) 2022 Harvey Thompson

## Source

Repository on [GitHub][url:GitHub]

## For More Information

See the [GitHub README][url:GitHubREADME]

## For Modders

You can provide multiple IVAs for your modded crewed command modules: this might allow for
an empty (low resource) IVA and a more complex (heavy resource) IVA as an option, or tech
level upgrades from lower tech to higher tech (using B9PartSwitch part upgrades).

The only requirement is that there are seperately named INTERNAL definitions for each
selection. Module Manager is your friend, see the provided examples in Reviva and follow
the pattern.

- If Reviva already has support for the command module mod and provides other IVAs, it is
  preferable that additional SUBTYPE are added to the standard ModuleIVASwitch provided
  by Reviva.
- If there's no existing support in Reviva, you should copy the similar part style whole for
  Reviva itself in your own mod (eg. Stock/mk1Cockpit.cfg).
- You could alternatively clone Reviva and make changes there and push them, or if you're
  really lazy ask me to do it.

Feel free to ask questions in the forum, I'm not super experienced with KSP modding, but I
know game development well enough to be dangerous/helpful.

# Detailed Installation

## Required Mods

For Reviva to be enabled there's a mimimum set of required mods (and their dependencies):

- Reviva :: obviously, but this provides a small DLL that remembers the IVA selection and
  handles switching the IVA dynamically in the editor or in flight.
- [B9PartSwitch][url:B9PartSwitch] :: this provides mod authors with a generalized way to describe part switching.
  This is used by Reviva to switch definitions in Reviva's ModuleIVASwitch: this small DLL
  does the magic of actually switching the IVA in the editor or in-flight.
- ModuleManager :: this is pretty much always required for modded KSP. Used to provide
  configuration for Reviva and B9PartSwitch depending on what other modules you
  install.
- RasterPropMonitor :: most IVA (other than stock) use this to provide the more complex
  IVA dials and switches. Technically you could install just MAS, though this isn't well
  tested.

Note that each mod here (and below) may itself have required and optional mods (not listed
here), check each mod's link carefully, or I recommend using CKAN. You may have to allow
earlier game versions in CKAN to load older IVA mod packs.

If you only install these you'll only see the stock and some basic IVAs with
multi-function displays (MFD) provided by RasterPropMonitor, you should probably install
the recommended and optional mods to get even more. More IVA do take up memory resources,
and slow down loading.

## Recommended and Optional Mods

Recommended mods and optional mods that can be installed to provide more complex IVAs for
stock and other mods. Reviva also provides the links and possibly patches to ensure they
work when installed.

The first recommended mod (MAS) can be installed as well as RPM, it actually upgrades
most IVA to use the MAS system, and RPM is a backup. MAS also allows for much more complex
IVA and MFDs, some part and IVA mods take advantage of this.

The other recommend mods will provide enough IVA for stock KSP and the Missing History
expansion (if installed) for stock or vanilla/lightly modded games.

This table tries to link to all the known functional (ie. for command/flying) IVA mods in
existence that can work on KSP 1.12.x - if you know of more let the mod author know.

## Dependency Summary

| Status      | Mod                                                                 | DL        | Style   | For                   | Status   | Provides                                   |
|-------------|---------------------------------------------------------------------|-----------|---------|-----------------------|----------|--------------------------------------------|
| Required    | [Reviva][url:Forum]                                                 | CKAN      | -       | Stock                 | -        | IVA switching and 1.12.x compatibility     |
| Required    | [B9PartSwitch][url:B9PartSwitch]                                    | CKAN      | -       | Stock                 | -        | General part switching mechanics           |
| Required    | [ModuleManager][url:ModuleManager]                                  | CKAN      | -       | Stock                 | -        | Patching mod configuration                 |
| Required    | [RasterPropMonitor (RPM)][url:RasterPropMonitor]                    | CKAN      | RPM     | Stock                 | Done     | More complex IVA than stock, includes IVA  |
| Recommended | [DE_IVAExtension][url:DEIVAExtension]                               | CKAN      | RPM     | Stock                 | Done     | High tech IVA for all of Stock             |
| Recommended | [ASET IVA for Making History Pods][url:ASETIVAforMakingHistoryPods] | GitHub    | RPM     | Making History        | Done     | High tech IVA for all of Making History    |
| Optional    | [MOARdV's Avionics System (MAS)][url:AvionicsSystems]               | CKAN      | MAS     | Stock                 | Done     | Successor to RPM (1), includes low tech    |
|             |                                                                     |           |         |                       |          | Mk1, Mk1-3 and Mk1 Lander.                 |
| Optional    | [ASET Mk1 Cockpit][url:ASETMk1Cockpit]                              | CKAN      | RPM     | Stock                 | Done     | High tech analog Mk1 Cockpit               |
| Optional    | [ASET Mk1 Lander Can][url:ASETMk1LanderCan]                         | CKAN      | RPM     | Stock                 | Done     | High tech Mk1 Lander                       |
| Optional    | [ASET Mk1-2 Command Pod][url:ASETMk1-2CommandPod]                   | CKAN      | RPM     | Stock                 | Done     | High tech Mk1-3 Command Pod                |
| Optional    | [Warbird Cockpits][url:WarbirdCockpits]                             | SpaceDock | RPM     | Stock,SXT,AP,Kerbonov | Partial  | Analog avaition cockpits for several mods  |
| Optional    | [Ultimate Shuttle IVA][url:UltimateShuttleIVA]                      | SpaceDock | RPM+MAS | Stock                 | Done     | Retro and modern MK3 Cockpit IVA (2)       |
| Optional    | [MOARdVPlus][url:MOARdVPlus]                                        | GitHub    | MAS     | BDB                   | Done     | BDB Kane/Sarnus IVA (Apollo)               |
| Optional    | [Airplane Plus IVA Pack][url:APIP]                                  | GitHub    | RPM     | AirplanePlus          | Done     | Various plane/chopper cockpits             |
| Optional    | [ASET/RPM for Falcon cockpit][url:APF16]                            | Dropbox   | RPM     | AirplanePlus          | Done     | F-16/mk2 non-commerical IVA                |
| Optional    | [Bluedog Design Bureau][url:BDB]                                    | CKAN      | RPM     | BDB                   | Done     | Mercury, Gemini, Apollo, LEM               |
| Provides    | [KSA IVA Upgrade][url:KSAIVA]                                       | GitHub    | RPM     | Stock                 | Provides | Stock, MH, BDB (V1.5.0 provides Reviva)    |
| Provides    | [Starilex Intra-Vehicular Solutions][url:SIVSIVA]                   | SpaceDock | RPM     | Stock                 | Provides | Mk1 CM, (V1.1 provides Reviva)             |
| Optional    | [Max-Ksp MAS IVA Pack][url:MaxKspIVA]                               | GitHub    | MAS     | Stock, Making History | Done     | Mk1-3 CM, M.E.M. IVAs                      |
| Optional    | [SABS\_IVA: MAS-enabled IVA][url:SABSIVA]                           | GitHub    | MAS     | Stock, MH, PCR        | Partial  | Stock, MH                                  |
| Optional    | [Snakeru's Mk2 Pod IVA (MAS Issue 264)][url:SnakeruIVA]             | GitHub    | MAS     | Stock                 | Done     | Mk1 / Gemini IVA                           |
| Optional    | Probe Control Room                                                  | CKAN      | RPM     | PBC                   | Planned  | Probe control room for probes              |
| Optional    | ALCOR by ASET                                                       | CKAN      | RPM     | Alcor                 | Planned  | High tech 3-man lander capsule             |
| Optional    | OPT Spaceplane                                                      | CKAN      | RPM     | Opt                   | Planned  | Near and Far Future Spacecraft             |
| Optional    | Vexarp IVA                                                          | CKAN      | MAS     | NFSpacecraft          | Planned  | Near Future Spacecraft improved IVA        |
| Untested    | Tundra Exploration                                                  | CKAN      | MAS     | TundraExploration     |          | Provides it's own MAS IVA alternatives (?) |
| Untested    | Kerbal Flying Saucers                                               | CKAN      | MAS     | KerbalFlyingSaucers   |          | With MAS has improved alternatives (?)     |
| Untested    | Kermantech MK3 IVA                                                  | GitHub    | RPM     | Stock                 |          | Mk3 Shuttle IVA                            |
| Untested    | Apex                                                                | SpaceDock | RPM     | Stock                 |          | Mk3 Shuttle IVA                            |
| Untested    | Nice MKseries Body                                                  | SpaceDock | RPM     | Nice MKseries Body    |          | Provides own RPM IVA                       |
| Untested    | Manul's Flanker IVA (Unpublished?)                                  | ?         | MAS     | Nice MKseries Body    |          | Flanker, has rear view mirrors!            |
| Untested    | Mk1 Inline Cockpit Upgraded IVA                                     | SpaceDock | RPM     | Stock                 |          | Mk1 Inline                                 |
| Untested    | [WIP] Mk2 Spaceplane Cockpit IVA                                    | ?         | RPM     | Stock                 |          | Mk2 Cockpit                                |
| Untested    | Modified MK22 IVA [ASET Avionics]                                   | SpaceDock | RPM     | BDynamics             |          | Mk22 Cockpit                               |
| Untested    | Advanced Cockpit, B737 style IVA                                    | KSPForums | RPM     | Stock                 |          | Mk3 Cockpit                                |
| Untested    | [WIP] KV Pod Family IVA Repl                                        | KSPForums | RPM     | Missing History       |          | KV1 Capsule                                |
| Untested    | MK3 Space Shuttle IVA                                               | GitHub    | RPM     | Stock                 |          | Mk3 Cockpit                                |
| Untested    | Firespitter Apache IVA Upgrade                                      | SpaceDock | MAS     | Firespitter           |          | Apache Cockpit                             |
| Untested    | ColdwarAerospace (?)                                                | ?         | ?       | ColdwareAerospace     |          | ?                                          |
| Untested    | HorizonsIVA-Project                                                 | ?         | RPM     | KAX, BDB              |          | C2B Cockpit, BDB LM                        |
| Untested    | AeroKerbin Industries Modified IVAs                                 | ?         | RPM     | Stock, SXT            |          | ?                                          |
| Unfinished  | MK2 Iva Work in Progress                                            | ?         | RPM     | Stock                 |          | Mk2 Cockpit                                |
| Untested    | LonesomeRobots Aerospace: The Gusmobile.                            | ?         | RPM     | ?                     |          | Possible Gemini IVA                        |

- (1) :: You can have RPM or MAS, or in fact both at the same time. MAS includes upgrade scripts
that render some existing RPM IVAs at a high quality and performance (in my experience).

- (2) :: Only copy UltimateShuttleIVA into GameData, ignore the top level USIVA-xxx.cfg files.

- Provides :: The mod itself provides Reviva support.

# Detailed User Manual

Once you have installed all the mods needed, once you've restarted the game, right
clicking on supported command modules will show the PAW UI with a group called "IVA
Switch".

When in the SPH or VAB editor this will show one or more coloured box images representing
each available IVA, plus a "Select IVA" button below that if clicked displays a drop down
menu with all the possible IVA options.

When in-flight, only the "Select IVA" menu button is available: you also need to exit any
in-IVA view (press C). When changing the IVA you should see the Kerbal portraits
temporarily go to noise for a moment. You can then re-enter the IVA view with the same
crew present (hopefully, if one gets lost or changes seats, that's the price you pay for
such fast in-flight reconstruction).

With only the required mods, it's likely you'll only see a "Stock" selection on stock command
modules, which is the vanilla IVA modules. These are always the default when adding a new
stock command module, or loading a vessel for the first time after installing the mod
(yes, it will revert any existing IVA mods to stock or default setting for that mod).

For Stock and Missing History, it's best to install the "Recommended" mods shown in the
above table: these provide three or four different IVA variants (low, medium and high
tech, sometimes with an alternative high tech variant of higher quality).

You can save the selection for the ship design in the SPH/VAB editor, in which case each launch
will use that IVA selection as the new default.

For already in-flight vessels, you can change the selection (while not in the IVA), and it
will be saved along with that ship only, this includes when the ship goes on rails
(switching away to another vessel), and when saving the game.

# Support

Either respond in the forum or on GitHub. If it's a bug, you should always provide logs
with the bug report, otherwise it's even more unlikely that the author will respond or be
able to help.

- [GitHub Issues for Reviva][url:GitHubIssues]

## Support Progress

The following table lists the current progression on supporting mods and IVA mods.

Note: DE+MAS is an Reviva specialized combination of `DE_IVAExtension` where one or two MFDs
are replaced by the superb `MAS_ALCOR_MFD2` which simulates a near future avionics upgrade.

### Stock

| Name               | CFG Name             | From     | IVA              | Tech   | Style   | Quality | Support Status |
|--------------------|----------------------|----------|------------------|--------|---------|---------|----------------|
| Mk1 Cockpit        | Mark1Cockpit         | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | ASET             | High   | RPM     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | KSA      | KSA              | Mid    | RPM     | High    | Provided       |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk1 Command Pod    | mk1pod\_v2           | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | Warbirds         | Med    | RPM     | V.High  | Done           |
|                    |                      |          | MAS              | Low    | MAS     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | Starilex | Starilex         | Low    | RPM     | High    | Done           |
|                    |                      | KSA      | KSA              | Mid    | RPM     | High    | Provided       |
|                    |                      | SABS     | SABS             | High   | MAS     | Med     | Done           |
| Mk1 Inline Cockpit | Mark2Cockpit         | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | Warbirds         | Medium | RPM     | V.High  | Done           |
|                    |                      |          | WarbirdsSI       | Medium | RPM     | V.High  | Done (1)       |
|                    |                      |          | WarbirdsRetro    | Low    | RPM     | V.High  | Done           |
|                    |                      |          | WarbirdsRetroSI  | Low    | RPM     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | KSA      | KSA              | Mid    | RPM     | High    | Provided       |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk1 Lander Can     | landerCabinSmall     | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | ASET             | Low    | RPM     | V.High  | Done           |
|                    |                      |          | MAS              | Low    | MAS     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | KSA      | KSA              | Mid    | RPM     | High    | Provided       |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk1-3 Command Pod  | mk1-3pod             | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | ASET             | High   | RPM     | V.High  | Done           |
|                    |                      |          | MAS              | Low    | MAS     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      |          | Max-Ksp          | Low    | MAS     | V.High  | Done           |
|                    |                      | SABS     | SABS             | Mid    | MAS     | Med     | Done           |
| Mk2 Cockpit        | mk2Cockpit\_Standard | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk2 Inline Cockpit | mk2Cockpit\_Inline   | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | WarbirdsSI       | High   | RPM     | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk2 Lander Can     | mk2LanderCabin\_v2   | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM     | High    | Done           |
|                    |                      | KSA      | KSA              | Mid    | RPM     | High    | Provided       |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| Mk3 Cockpit        | mk3Cockpit\_Shuttle  | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | High    | Done           |
|                    |                      |          | UltimateRetro    | Med    | RPM+MAS | V.High  | Done (2)       |
|                    |                      |          | UltimateGlass    | High   | RPM+MAS | V.High  | Done           |
|                    |                      |          | DE+MAS           | Near   | RPM+MAS | High    | Done           |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |
| PPD-12 Cupola      | cupola               | Stock    | Stock            | Low    | Stock   | Low     | Done           |
|                    |                      |          | RPM              | Med    | RPM     | Med     | Done           |
|                    |                      |          | DE\_IVAExtension | High   | RPM     | Hig     | Done           |
|                    |                      | SABS     | SABS             |        |         |         | Planned        |

### Making History

| Name            | CFG Name  | From   | IVA             | Tech | Style   | Quality | Support Status |
|-----------------|-----------|--------|-----------------|------|---------|---------|----------------|
| KV-1            | kv1Pod    | MH     | MH              | Low  | Stock   | Low     | Done           |
|                 |           |        | ASET for MH     | High | RPM     | High    | Done           |
|                 |           | KSA    | KSA             | Mid  | RPM     | High    | Provided       |
|                 |           | SABS   | SABS            |      |         |         | Planned        |
| KV-2            | kv2Pod    | MH     | MH              | Low  | Stock   | Low     | Done           |
|                 |           |        | ASET for MH     | High | RPM     | High    | Done           |
|                 |           | SABS   | SABS            |      |         |         | Planned        |
| KV-3            | kv3Pod    | MH     | MH              | Low  | Stock   | Low     | Done           |
|                 |           |        | ASET for MH     | High | RPM     | High    | Done           |
|                 |           | SABS   | SABS            |      |         |         | Planned        |
| Mk2 Command Pod | Mk2Pod    | MH     | MH              | Low  | Stock   | Low     | Done           |
|                 |           |        | ASET for MH     | High | RPM     | High    | Done           |
|                 |           |        | ASET for MH+MAS | Near | RPM+MAS | High    | Done           |
|                 |           |        | MAS             | Low  | MAS     | WIP     | Done (5)       |
|                 |           | SABS   | SABS            | Mid  | MAS     | Med     | Done           |
|                 |           | Saneru | Snakeru         | Low  | MAS     | High    | Done           |
| M.E.M.          | MEMLander | MH     | MH              | Low  | Stock   | Low     | Done           |
|                 |           |        | ASET for MH     | High | RPM     | High    | Done           |
|                 |           |        | ASET for MH+MAS | Near | RPM+MAS | High    | Done           |
|                 |           |        | Max-Ksp         | Low  | MAS     | V.High  | Done           |
|                 |           |        | Max-Ksp No Hud  | Low  | MAS     | V.High  | Done           |
|                 |           | SABS   | SABS            | Mid  | MAS     | Med     | Done           |

### BDB

The main BDB command pods and LEM have most of the equivalent Stock IVAs added, they may or may not
look quite right, but means there are plenty to choose from. Additionally the Apollo/Kane CM have
both of the very excellent MAS MOARdVPlus IVA.

| Name             | CFG Name                 | From       | IVA              | Tech | Style   | Quality | Support Status |
|------------------|--------------------------|------------|------------------|------|---------|---------|----------------|
| Mercury          | ?                        | BDB        | BDB              | Low  | Stock   | Low     | Done           |
|                  | mk1pod\_v2               | Stock      | Stock            | Low  | Stock   | Low     | Done           |
|                  |                          |            | RPM              | Med  | RPM     | Med     | Done           |
|                  |                          |            | DE\_IVAExtension | High | RPM     | High    | Done           |
|                  |                          |            | Warbirds         | Med  | RPM     | High    | Done           |
|                  |                          |            | MAS              | Low  | MAS     | V.High  | Done           |
|                  |                          |            | DE+MAS           | Near | RPM+MAS | High    | Done           |
|                  |                          | Starilex   | Starilex         | Low  | RPM     | High    | Done           |
|                  |                          | SABS       | SABS             | High | MAS     | Med     | Done           |
| Gemini           | ?                        | BDB        | BDB              | Low  | Stock   | Low     | Done           |
|                  | Mk2Pod                   | Stock      | MH               | Low  | Stock   | Low     | Done           |
|                  |                          |            | ASET for MH      | High | RPM     | High    | Done           |
|                  |                          |            | ASET for MH+MAS  | Near | RPM+MAS | High    | Done           |
|                  |                          |            | MAS              | Low  | MAS     | WIP     | Done (5)       |
|                  |                          | SABS       | SABS             | Mid  | MAS     | Med     | Done           |
|                  |                          | Saneru     | Snakeru          | Low  | MAS     | High    | Done           |
| Kane Command Pod | bluedog\_Apollo\_CrewPod | BDB        | BDB              | Low  | Stock   | Low     | Done           |
|                  |                          | MOARdVPlus | Retro            | Med  | MAS     | V.High  | Done           |
|                  |                          |            | Glass            | High | MAS     | V.High  | Done           |
|                  | mk1-3pod                 | Stock      | Stock            | Low  | Stock   | Low     | Done           |
|                  |                          |            | RPM              | Med  | RPM     | Med     | Done           |
|                  |                          |            | DE\_IVAExtension | High | RPM     | High    | Done           |
|                  |                          |            | ASET             | High | RPM     | V.High  | Done           |
|                  |                          |            | MAS              | Low  | MAS     | V.High  | Done           |
|                  |                          |            | DE+MAS           | Near | RPM+MAS | High    | Done           |
|                  |                          |            | Max-Ksp          | Low  | MAS     | V.High  | Done           |
|                  |                          | SABS       | SABS             | Mid  | MAS     | Med     | Done           |
| LEM              | ?                        | BDB        | BDB              | Low  | Stock   | Low     | Done           |
|                  | MEMLander                | Stock      | MH               | Low  | Stock   | Low     | Done           |
|                  |                          |            | ASET for MH      | High | RPM     | High    | Done           |
|                  |                          |            | ASET for MH+MAS  | Near | RPM+MAS | High    | Done           |
|                  |                          |            | Max-Ksp          | Low  | MAS     | V.High  | Done           |
|                  |                          |            | Max-Ksp No Hud   | Low  | MAS     | V.High  | Done           |
|                  |                          | SABS       | SABS             | Mid  | MAS     | Med     | Done           |

### Airplane Plus

| Name                       | CFG Name          | From | IVA        | Tech | Style | Quality | Support Status |
|----------------------------|-------------------|------|------------|------|-------|---------|----------------|
| MK1 Viewer's Cockpit       | bellcockpit       | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APIP       | Med  | RPM   | V.High  | Done           |
|                            |                   |      | Warbirds   | High | RPM   | V.High  | Done           |
| Size 1.5 Cockpit           | bombardiercockpit | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APIP       | High | RPM   | High    | Done           |
| MK1 Business Cockpit       | citationcockpit   | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | Warbirds   | Med  | RPM   | WIP     | Done (3)       |
| MK3S1 Cockpit              | cessnacockpit     | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APIP       | Med  | RPM   | V.High  | Done           |
| Mk2 Non-Commercial Cockpit | falconcockpit     | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APF16 RPM  | Med  | RPM   | Med     | Done (6)       |
|                            |                   |      | APF16 ASET | Med  | RPM   | V.High  | Done (6)       |
| MK1 Non-Commerical Cockpit | fightercockpit    | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APIP       | Med  | RPM   | Med     | Done           |
| MK3S1.5 Viewer's Cockpit   | hueycockpit       | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | APIP       | Med  | RPM   | V.High  | Done           |
| MK1 Caged Inline Cockpit   | oldfightercockpit | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | Warbirds   | Med  | RPM   | V.High  | Done (4)       |
| MK1/0 Caged Inline Cockpit | zerocockpit       | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | Warbirds   | Med  | RPM   | V.High  | Done (4)       |
| MK1 Supersonic Cockpit     | x1cockpit         | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | Warbirds   | Med  | RPM   | V.High  | Done           |
|                            |                   |      | WarbirdsSI | Med  | RPM   | V.High  | Done           |
| Size 2 Viewer's Cockpit II | b29cockpit        | AP   | AP         | Low  | Stock | Low     | Done           |
|                            |                   |      | Warbirds   | Med  | RPM   | WIP     | Done (3)       |

### Kerbonov

| Name                       | CFG Name          | From  | IVA              | Tech | Style   | Quality | Support Status |
|----------------------------|-------------------|-------|------------------|------|---------|---------|----------------|
| KN2?                       | KN2CabinAnalog    | KN    | KN               |      | Stock   |         |                |
|                            |                   |       | Warbirds         |      | RPM     |         |                |
|                            |                   |       | WarbirdsSI       |      | RPM     |         |                |
| KN7?                       | KN7CAbin          | KN    | KN               |      | Stock   |         |                |
|                            |                   |       | Warbirds         |      | RPM     |         |                |

### SXT

| Name                       | CFG Name          | From  | IVA              | Tech | Style   | Quality | Support Status |
|----------------------------|-------------------|-------|------------------|------|---------|---------|----------------|
| Bonny?                     | 625mBonny         | SXT   | SXT              |      | Stock   |         |                |
|                            |                   |       | Warbirds         |      | RPM     |         |                |
|                            |                   |       | WarbirdsSI       |      | RPM     |         |                |
| Clyde?                     | SXTClyde          | SXT   | SXT              |      | Stock   |         |                |
|                            |                   |       | Warbirds         |      | RPM     |         |                |
|                            |                   |       | WarbirdsSI       |      | RPM     |         |                |
|----------------------------|-------------------|-------|------------------|------|---------|---------|----------------|

### Probe Control Room

| Name               | CFG Name | From | IVA              | Tech | Style | Quality | Support Status |
|--------------------|----------|------|------------------|------|-------|---------|----------------|
| Probe Control Room |          | PCR  | PCR              | Med  | RPM   |         |                |
|                    |          |      | DE\_IVAExtension | High | RPM   |         |                |
|                    |          | SABS | SABS             |      |       |         |                |

### Alcor

| Name  | CFG Name | From  | IVA       | Tech | Style   | Quality | Support Status |
|-------|----------|-------|-----------|------|---------|---------|----------------|
| Alcor |          | Alcor | Alcor     | High | RPM     |         |                |
|       |          |       | Alcor+MAS | Near | RPM+MAS |         |                |
|-------|----------|-------|-----------|------|---------|---------|----------------|

### Notes

- (1) :: Mk1 Inline WarbirdsSI variant display "INITIALIZATION ERROR", but seems benign.
  Will eventually try to fix.
- (2) :: Mk3 Ultimate Retro variant CRT do not seem to work. Will eventually try to fix.
- (3) :: IVA is work-in-progress or incomplete.
- (4) :: Some switches on right hand side obscured by cockpit walls.
- (5) :: This MAS Mk2 / Gemini pod for Stock and BDB can be downloaded from Mk2.20190329.zip stored
  in https://github.com/MOARdV/AvionicsSystems/issues/264
- (6) :: Installing ASET/RPM for Falcon Cockpit will overwrite AirplanePlus itself, which is not
  recommended. Reviva only supports a manual install into "GameData/AirplanePlusFalcon", see the
  falcon.cfg.
- (7) :: Only download and install the Max-Ksp-MAS-IVA-Pack-N.N.zip, the Hud/No-Hud variants are
  provided by Reviva itself.

# Best IVA

This is a very subjective decision for best IVA for both "realism" (probably nowhere near reality,
but realistic for the era the IVA would first appear) and "functionality" (the most functional,
probably high tech) IVA. All the IVA are great, but these represent my usual choice for those
scenarios. Feel free to try to change my mind!

## Stock

| Name               | Best Realistic   | Best Functional |
|--------------------|------------------|-----------------|
| Mk1 Cockpit        | ASET             | DE+MAS          |
| Mk1 Command Pod    | Starilex         | DE+MAS          |
| Mk1 Inline Cockpit | WarbirdsRetro    | DE+MAS          |
| Mk1 Lander Can     | ASET             | DE+MAS          |
| Mk1-3 Command Pod  | MOARdVPlus Retro | ASET            |
| Mk2 Cockpit        | DE+MAS           | DE+MAS          |
| Mk2 Inline Cockpit | WarbirdsSI       | DE+MAS          |
| Mk2 Lander Can     | DE+MAS           | DE+MAS          |
| Mk3 Cockpit        | UltimateRetro    | UltimateGlass   |
| PPD-12 Cupola      | DE               | DE              |

## Making History

| Name            | Best Realistic | Best Functional |
|-----------------|----------------|-----------------|
| KV-1            | KSA            | ASET for MH     |
| KV-2            | ASET for MH    | ASET for MH     |
| KV-3            | ASET for MH    | ASET for MH     |
| Mk2 Command Pod | Snakeru        | ASET for MH+MAS |
| M.E.M.          | Max-Ksp No Hud | ASET for MH+MAS |

## BDB

| Name           | Best Realistic   | Best Functional |
|----------------|------------------|-----------------|
| Hermes/Mercury | Starilex         | DE+MAS          |
| Vinci/Gemini   | Snakeru          | ASET for MH+MAS |
| Kane/Apollo    | MOARdVPlus Retro | ASET            |
| Sina/L.E.M.    | Max-Ksp No Hud   | ASET for MH+MAS |

# Building

If you want to build the DLL and packages, just be aware that the provided source assume
use of Visual Studio 22 Community Edition on Windows.

* Copy `plugin/Reviva.csproj.user-example` to `plugin/Reviva.csproj.user`
* Edit `ReferencePath` to point to your KSP game root.
  * This is where the Assemblies are taken for building.
* Open `Reviva.sln` in VS 22.
* Select `Debug` or `Release` configuration.
* Check `tools\postbuild.bat`
  * The default on a succesful build is to:
    * Copy the DLL to the repository `GameData` - so that the repo is exactly what should be packaged for release.
    * Remove and re-copy the repository GameData to `$(ReferencePath)\GameData\Reviva` - so the
      developer can restart KSP and test.
* Hit `Build` or `F6` to build.

Happy to recieve pull requests on GitHub for improvements, more IVA support, etc.

[url:Screenshot]: https://github.com/harveyt/reviva/blob/main/Reviva.png?raw=true
[url:Forum]: https://forum.kerbalspaceprogram.com/index.php?/topic/206744-wip112x-reviva-the-iva-revival-and-editorflight-switcher-070-pre-release-3rd-feb-2022/
[url:GitHub]: https://github.com/harveyt/reviva
[url:GitHubLatest]: https://github.com/harveyt/reviva/releases/latest
[url:GitHubREADME]: https://github.com/harveyt/reviva/blob/main/README.md
[url:GitHubIssues]: https://github.com/harveyt/reviva/issues
[url:GitHubIssue3]: https://github.com/harveyt/reviva/issues/3 "GitHub Issue 3"
[url:GitHubIssue4]: https://github.com/harveyt/reviva/issues/4 "GitHub Issue 4"
[url:GitHubIssue5]: https://github.com/harveyt/reviva/issues/5 "GitHub Issue 5"
[url:GitHubIssue6]: https://github.com/harveyt/reviva/issues/6 "GitHub Issue 6"
[url:GitHubIssue9]: https://github.com/harveyt/reviva/issues/9 "GitHub Issue 9"
[url:SupportProgress]: https://github.com/harveyt/reviva/blob/main/README.md#support-progress
[url:DependencySummary]: https://github.com/harveyt/reviva/blob/main/README.md#dependency-summary
[url:SpaceDock]: https://spacedock.info/mod/2990/Reviva "SpaceDock"
[url:B9PartSwitch]: https://forum.kerbalspaceprogram.com/index.php?/topic/140541-1112-b9partswitch-v2180-march-17/
[url:ModuleManager]: https://forum.kerbalspaceprogram.com/index.php?/topic/50533-18x-112x-module-manager-421-august-1st-2021-locked-inside-edition/
[url:RasterPropMonitor]: https://forum.kerbalspaceprogram.com/index.php?/topic/190737-18x-112x-rasterpropmonitor-adopted/
[url:AvionicsSystems]: https://forum.kerbalspaceprogram.com/index.php?/topic/160856-wip-111x-moardvs-avionics-systems-mas-interactive-iva-v123-21-may-2021/
[url:DEIVAExtension]: https://forum.kerbalspaceprogram.com/index.php?/topic/186715-18x-de_ivaextension-for-all-the-stock-pod-ivas/
[url:ASETMk1Cockpit]: https://forum.kerbalspaceprogram.com/index.php?/topic/156130-mk1-cockpit-iva-replacement-by-asetv11/
[url:ASETMk1LanderCan]: https://forum.kerbalspaceprogram.com/index.php?/topic/156131-mk1-lander-can-iva-replacement-by-aset11/
[url:ASETMk1-2CommandPod]: https://forum.kerbalspaceprogram.com/index.php?/topic/116440-mk1-2-pod-iva-replacement-by-asetv03/
[url:WarbirdCockpits]: https://forum.kerbalspaceprogram.com/index.php?/topic/160720-wip131-warbird-cockpits-03pre-mk1-capsule-mk1-inline-cockpit-mk2-inline-cockpit/
[url:UltimateShuttleIVA]: https://forum.kerbalspaceprogram.com/index.php?/topic/174898-14x-ultimate-shuttle-iva-10-woop-woop/
[url:ASETIVAforMakingHistoryPods]: https://forum.kerbalspaceprogram.com/index.php?/topic/187162-17xaset-iva-for-making-history-pods/
[url:MOARdVPlus]: https://github.com/MOARdV/MOARdVPlus
[url:APIP]: https://github.com/Thilen03/Airplane-Plus-IVA-Pack
[url:APF16]: https://forum.kerbalspaceprogram.com/index.php?/topic/156245-13-asetrpm-for-falcon-cockpit-from-airplane-plus-pack-feb-10-2017/
[url:BDB]: https://forum.kerbalspaceprogram.com/index.php?/topic/122020-1123-bluedog-design-bureau-stockalike-saturn-apollo-and-more-v1104-%D0%BB%D1%83%D0%BD%D0%B0-19july2022/
[url:KSAIVA]: https://forum.kerbalspaceprogram.com/index.php?/topic/208598-ksa-iva-upgrade-adopted-mk1-stock-parts-bdb-apollo/
[url:SIVSIVA]: https://forum.kerbalspaceprogram.com/index.php?/topic/209466-1123-starilex-intra-vehicular-solutions-mki-pod-needle/
[url:MaxKspIVA]: https://forum.kerbalspaceprogram.com/index.php?/topic/181392-16x-max-ksp-mas-iva-pack-development/
[url:SABSIVA]: https://forum.kerbalspaceprogram.com/index.php?/topic/189891-sabs_iva-mas-enabled-iva-configs-for-stock-command-modules/
[url:SnakeruIVA]: https://github.com/MOARdV/AvionicsSystems/issues/264
[kspf:blowfish]: https://forum.kerbalspaceprogram.com/index.php?/profile/119688-blowfish/
[kspf:Electrocutor]: https://forum.kerbalspaceprogram.com/index.php?/profile/109593-electrocutor/
[kspf:sarbian]: https://forum.kerbalspaceprogram.com/index.php?/profile/57146-sarbian/
[kspf:alexustas]: https://forum.kerbalspaceprogram.com/index.php?/profile/78632-alexustas/
[kspf:MOARdV]: https://forum.kerbalspaceprogram.com/index.php?/profile/60950-moardv/
[kspf:JonnyOThan]: https://forum.kerbalspaceprogram.com/index.php?/profile/40902-jonnyothan/
[kspf:DemonEin]: https://forum.kerbalspaceprogram.com/index.php?/profile/199038-demonein/
[kspf:HonkHogan]: https://forum.kerbalspaceprogram.com/index.php?/profile/199383-honkhogan/
[kspf:theonegalen]: https://forum.kerbalspaceprogram.com/index.php?/profile/71012-theonegalen/
[kspf:Gth]: https://forum.kerbalspaceprogram.com/index.php?/profile/98595-gth/
[kspf:linuxgurugamer]: https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/
