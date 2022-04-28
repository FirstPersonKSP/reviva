# KSP 1.12.x - Reviva - The IVA Revival!

![Reviva Screenshot][url:Screenshot]

# KSP Reviva is the IVA Revival! For Kerbals who like to fly first person.

- Supports multiple IVA mods at once (IVA mods not included).
- Supports RPM and MAS.
- Allows IVA internal switch via B9PartSwitch:
  - Allows selecting different IVA on each command module in editor/saves.
  - Allows for on-the-fly IVA switching while in flight.

Soon :: CKAN support so you can install Reviva and all the IVA mods you ever wanted.

## Warning

This mod is *BETA*, do not use for career gameplay unless you like living on the edge.

Currently only stock IVA and some popular IVA mods are covered, the intent is to extended
the coverage over time.

## Required Mods

- Reviva - note that this does not include any other mods below in the download.
  - [KSP Forums][url:Forum]
  - [GitHub Latest Release][url:GitHubLatest]
    - Download and extract the Reviva-x.x.x.zip file at the root of your KSP installation.
  - SpaceDock - [SpaceDock][url:SpaceDock]
  - CKAN - Available
  - Curse - Soon
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

## Changes

### 0.7.3 Release (12th Apr 2022)

Fixes:

- Support QuickIVA when loading strait to IVA ([GitHub Issue #6][url:GitHubIssue6])
- Handle any configuration errors by remaining on same IVA ([GitHub Issue #5][url:GitHubIssue5])

### 0.7.2 Release (11th Mar 2022)

Fixes:

- Undocking two of same craft causing crash ([GitHub Issue #3][url:GitHubIssue3])
- Correctly switch IVA for in-flight craft where multiple similar craft present ([GitHub Issue #4][url:GitHubIssue4])

### 0.7.1 Release (28th Feb 2022)

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

- Very low overhead on performance: command modules get an extra ModuleIVASwitch, and switch
  detection only happens when changes are made.

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

| Status      | Mod                                | Style   | For                   | Status  | Provides                                   |
|-------------|------------------------------------|---------|-----------------------|---------|--------------------------------------------|
| Required    | Reviva                             | -       | Stock                 | -       | IVA switching and 1.12.x compatibility     |
| Required    | B9PartSwitch                       | -       | Stock                 | -       | General part switching mechanics           |
| Required    | ModuleManager                      | -       | Stock                 | -       | Patching mod configuration                 |
| Required    | RasterPropMonitor (RPM)            | RPM     | Stock                 | Done    | More complex IVA than stock, includes IVA  |
| Recommended | DE_IVAExtension                    | RPM     | Stock                 | Done    | High tech IVA for all of Stock             |
| Recommended | ASET IVA for Making History Pods   | RPM     | Making History        | Planned | High tech IVA for all of Making History    |
| Optional    | MOARdV's Avionics System (MAS)     | MAS     | Stock                 | Done    | Successor to RPM (1), includes low tech    |
|             |                                    |         |                       |         | Mk1, Mk1-3 and Mk1 Lander.                 |
| Optional    | ASET Mk1 Cockpit                   | RPM     | Stock                 | Done    | High tech analog Mk1 Cockpit               |
| Optional    | ASET Mk1 Lander Can                | RPM     | Stock                 | Done    | High tech Mk1 Lander                       |
| Optional    | ASET Mk1-2 Command Pod             | RPM     | Stock                 | Done    | High tech Mk1-3 Command Pod                |
| Optional    | Warbird Cockpits                   | RPM     | Stock, SXT,           | Partial | Analog avaition cockpits for several mods  |
|             |                                    |         | AirplanePlus,         |         |                                            |
|             |                                    |         | Kerbonov              |         |                                            |
| Optional    | Ultimate Shuttle IVA               | RPM+MAS | Stock                 | Done    | Retro and modern MK3 Cockpit IVA (2)       |
| Optional    | MOARdVPlus                         | MAS     | BDB                   | Planned | BDB Kane/Sarnus IVA (Apollo)               |
| Untested    | Airplane Plus IVA Pack             | RPM     | AirplanePlus          | Planned | Various plane/chopper cockpits             |
| Untested    | ASET/RPM for Falcon cockpit        | RPM     | AirplanePlus          | Planned | F-16/mk2 non-commerical IVA                |
| Optional    | Probe Control Room                 | RPM     | PBC                   | Planned | Probe control room for probes              |
| Optional    | ALCOR by ASET                      | RPM     | Alcor                 | Planned | High tech 3-man lander capsule             |
| Optional    | OPT Spaceplane                     | RPM     | Opt                   | Planned | Near and Far Future Spacecraft             |
| Optional    | Vexarp IVA                         | MAS     | NFSpacecraft          | Planned | Near Future Spacecraft improved IVA        |
| Untested    | Tundra Exploration                 | MAS     | TundraExploration     |         | Provides it's own MAS IVA alternatives (?) |
| Untested    | Kerbal Flying Saucers              | MAS     | KerbalFlyingSaucers   |         | With MAS has improved alternatives (?)     |
| Untested    | Kermantech MK3 IVA                 | RPM     | Stock                 |         | Mk3 Shuttle IVA                            |
| Untested    | Apex                               | RPM     | Stock                 |         | Mk3 Shuttle IVA                            |
| Untested    | Nice MKseries Body                 | RPM     | Nice MKseries Body    |         | Provides own RPM IVA                       |
| Untested    | Manul's Flanker IVA (Unpublished?) | MAS     | Nice MKseries Body    |         | Flanker, has rear view mirrors!            |
| Untested    | Max-Ksp MAS IVA Pack               | MAS     | Stock, Making History |         | Mk1-3, M.E.M. IVAs                         |
| Untested    | SABS\_IVA: MAS-enabled IVA         | MAS     | Stock, MH, PCR        |         | Everything                                 |
| Untested    | Mk1 Inline Cockpit Upgraded IVA    | RPM     | Stock                 |         | Mk1 Inline                                 |
| Untested    | [WIP] Mk2 Spaceplane Cockpit IVA   | RPM     | Stock                 |         | Mk2 Cockpit                                |
| Untested    | Modified MK22 IVA [ASET Avionics]  | RPM     | BDynamics             |         | Mk22 Cockpit                               |
| Untested    | Advanced Cockpit, B737 style IVA   | RPM     | Stock                 |         | Mk3 Cockpit                                |
| Untested    | MK2 Iva Work in Progress           | RPM     | Stock                 |         | Mk2 Cockpit                                |
| Untested    | [WIP] KV Pod Family IVA Repl       | RPM     | Missing History       |         | KV1 Capsule                                |
| Untested    | MK3 Space Shuttle IVA              | RPM     | Stock                 |         | Mk3 Cockpit                                |
| Untested    | Firespitter Apache IVA Upgrade     | MAS     | Firespitter           |         | Apache Cockpit                             |
| Untested    | ColdwarAerospace (?)               | ?       | ColdwareAerospace     |         | ?                                          |
| Untested    | HorizonsIVA-Project                | RPM     | KAX, BDB              |         | C2B Cockpit, BDB LM                        |
|             |                                    |         |                       |         |                                            |

- (1) :: You can have either RPM or MAS, or in fact both at the same time. MAS includes upgrade
scripts that render some existing RPM IVAs at a high quality and performance (in my
experience).

- (2) :: Only copy UltimateShuttleIVA into GameData, ignore the top level USIVA-xxx.cfg files.

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


| Name               | CFG Name             | From  | IVA              | Tech   | Support Status |
|--------------------|----------------------|-------|------------------|--------|----------------|
| Mk1 Cockpit        | Mark1Cockpit         | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | ASET             | High   | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk1 Command Pod    | mk1pod\_v2           | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | Warbirds         | Med    | Done           |
|                    |                      |       | MAS              | Low    | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk1 Inline Cockpit | Mark2Cockpit         | Stock | Stock            | Low    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | Warbirds         | Medium | Done           |
|                    |                      |       | WarbirdsSI       | Medium | Done (1)       |
|                    |                      |       | WarbirdsRetro    | Low    | Done           |
|                    |                      |       | WarbirdsRetroSI  | Low    | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk1 Lander Can     | landerCabinSmall     | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | ASET             | Low    | Done           |
|                    |                      |       | MAS              | Low    | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk1-3 Command Pod  | mk1-3pod             | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | ASET             | High   | Done           |
|                    |                      |       | MAS              | Low    | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk2 Cockpit        | mk2Cockpit\_Standard | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk2 Inline Cockpit | mk2Cockpit\_Inline   | Stock | Stock            | Low    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | WarbirdsSI       | High   | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk2 Lander Can     | mk2LanderCabin\_v2   | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| Mk3 Cockpit        | mk3Cockpit\_Shuttle  | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
|                    |                      |       | UltimateRetro    | Med    | Done (2)       |
|                    |                      |       | UltimateGlass    | High   | Done           |
|                    |                      |       | DE+MAS           | Near   | Done           |
| PPD-12 Cupola      | cupola               | Stock | Stock            | Low    | Done           |
|                    |                      |       | RPM              | Med    | Done           |
|                    |                      |       | DE\_IVAExtension | High   | Done           |
| KV-1               | kv1Pod               | MH    | MH               | Low    | Done           |
|                    |                      |       | ASET for MH      | High   | Done           |
| KV-2               | kv2Pod               | MH    | MH               | Low    | Done           |
|                    |                      |       | ASET for MH      | High   | Done           |
| KV-3               | kv3Pod               | MH    | MH               | Low    | Done           |
|                    |                      |       | ASET for MH      | High   | Done           |
| Mk2 Command Pod    | Mk2Pod               | MH    | MH               | Low    | Done           |
|                    |                      |       | ASET for MH      | High   | Done           |
|                    |                      |       | ASET for MH+MAS  | Near   | Done           |
| M.E.M.             | MEMLander            | MH    | MH               | Low    | Done           |
|                    |                      |       | ASET for MH      | High   | Done           |
|                    |                      |       | ASET for MH+MAS  | Near   | Done           |
| Probe Control Room |                      | PCR   | PCR              | Med    |                |
|                    |                      |       | DE\_IVAExtension | High   |                |
| Alcor              |                      | Alcor | Alcor            | High   |                |
|                    |                      |       | Alcor+MAS        | Near   |                |

- (1) :: Mk1 Inline WarbirdsSI variant display "INITIALIZATION ERROR", but seems benign.
  Will eventually try to fix.
- (2) :: Mk3 Ultimate Retro variant CRT do not seem to work. Will eventually try to fix.

# Building

If you want to build the DLL and packages, just be aware that the provided source assume
use of Unix make and mono.

I personally work on Ubuntu 20.04 (running on WSL2 in Windows 10). You will need to
install mono-complete and know how to use make and Unix. If not, it's likely you could
generate a Visual Studio project and fill in some sensible details.

The Makefile "build" target will build the DLL.

The "install" target will copy the DLL and GameData to the KSP directory specified in the
Makefile, you should modify that (the default Steam install on WSL2 on Windows is
commented out).

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
[kspf:blowfish]: https://forum.kerbalspaceprogram.com/index.php?/profile/119688-blowfish/
[kspf:Electrocutor]: https://forum.kerbalspaceprogram.com/index.php?/profile/109593-electrocutor/
[kspf:sarbian]: https://forum.kerbalspaceprogram.com/index.php?/profile/57146-sarbian/
[kspf:alexustas]: https://forum.kerbalspaceprogram.com/index.php?/profile/78632-alexustas/
[kspf:MOARdV]: https://forum.kerbalspaceprogram.com/index.php?/profile/60950-moardv/
[kspf:DemonEin]: https://forum.kerbalspaceprogram.com/index.php?/profile/199038-demonein/
[kspf:HonkHogan]: https://forum.kerbalspaceprogram.com/index.php?/profile/199383-honkhogan/
[kspf:theonegalen]: https://forum.kerbalspaceprogram.com/index.php?/profile/71012-theonegalen/
[kspf:Gth]: https://forum.kerbalspaceprogram.com/index.php?/profile/98595-gth/
[kspf:linuxgurugamer]: https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/
