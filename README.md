The demons of Hell have encroached the land of MythOS, and there is only one man who can stop them. You. Fight the endless onslaught of demons in BONELAB, and put an end to the hell spawn.
# Overview
DOOMLAB is a ***partial source port,*** and it requires a copy of these IWADS to work:

- Doom 1, Doom Shareware, or Ultimate Doom
- Doom 2: Hell on Earth (BFG Edition, DOOM (2016), or Doom Eternal)
- The Plutonia Experiment
- TNT Evilution
- FreeDoom 1, or FreeDoom 2
- Heretic (planned)
- Hexen (planned)
- Chex Quest

Some PWAD files will load, and others will not. This is because WADs use DeHACKEd lumps, ZDOOM lumps, or GZDOOM specific lumps and/or structure.

# Installation
### PCVR
1. Navigate to the DOOMLAB folder in the ZIP
2. Drag and drop both the Mods folder and the UserData folder into your game directory.
3. Next, navigate to where you install your custom maps and avatars.
4. Drag the "NotEnoughPhotons.DOOMLAB" folder into the folder where you install your maps and avatars
5. Place an IWAD (see above) inside of UserData/Not Enough Photons/DOOMLAB/IWADS, so that the mod works properly
6. You're done!

### Meta Quest 2
1. Navigate to the DOOMLAB folder in the ZIP
2. Drag and drop both the Mods folder and the UserData folder into your game directory.
3. Next, navigate to where you install your custom maps and avatars.
4. Drag the "NotEnoughPhotons.DOOMLAB" folder into the folder where you install your maps and avatars
5. Place an IWAD (see above) inside of UserData/Not Enough Photons/DOOMLAB/IWADS, so that the mod works properly
6. You're done!

# Port Overview

## Features

Currently, DOOMLAB has support for loading both IWADs and PWADS, **but as of now, the range of supported PWADS is limited. This will change in the future!**
### Support Table
| Feature | Supported | Notes |
| ------- | - | ----- |
| WAD loading | ✅ | None |
| Custom WAD loading | ⚠️ | DeHACKEd lumps, and ZDOOM lumps may not be loaded/recognized yet. However, simple DOOM WADs that replace base game content may function. |
| PK3 loading | ❌ | Not implemented, and not recognized by the loader. |
| Map loading | ❌ | Not implemented, but may come in a future update. |
| Custom monsters | ❌ | Not implemented due to DECORATE, but also may come in the future. |
### WAD Compatibility
| WAD | Compatible | Notes |
| ------- | - | ----- |
| Ultimate Simpsons Doom | ✅ | PWAD uses a ZDOOM lump for custom sounds. Will work fine, but may sound... weird.
| Fistful of Doom | ✅ | None
| DOOM 3: Mr Smiley's Head Safari (1995) | ✅ | None
| Chex Quest | ✅ | A couple of the enemies: the Cyberdemon and the Spider Mastermind, don't show up.
| Ghostbusters Doom 2 | ⚠️ | Because of the lack of DeHACKEd support, enemies flicker between different sprites.
| Batman Doom | ⚠️ | Lack of DeHACKEd support causes weird sprite artifacts.
| myhouse.pk3 | ❌ | Has GZDOOM lumps, tags, and other unsupported features. Will not run (yet)
| do_not_play.wad | ❌ |

# Credits
- iD Software - DOOM source code
- decino - Extensive research into DOOM logic from his amazing videos
- sinshu - Frame builder algorithm from Managed Doom

# Links
- Source Code
- Release Trailer
- Not Enough Photons TikTok

