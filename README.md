# Expanded Arsenal Expanded

This expansion mod for Expanded Arsenal adds more than a thousand more mech variations, new weapons and more flashpoints (not yet finished). 
It also does many bugfixes, updates to improve standardization and base tonnage fixes to improve existing mech consistency.

# Installation
To install the mod, just download the latest release (or the most recent code version as a clone) and place all the code directories seen on
github directly into the mod directory for modtek. Note, the mech affinity directly is included for ease of installing the newly added affinities,
but it does also adjust how long affinities take to fade because of the additional unique mechs making it hard to master two of them.
If you don't want that change, don't replace the settings.json file inside of the mech affinity folder when installing.

# Fixes

- Updated space taken by UAC 20 (C) to be 4 slots instead of 8 (which fixes the Kodiak layout where it was going outside of the bounds as well)
- Updated all LB X 5 (C)s to have the same size as the inner sphere models (2 slots) instead of 3 slots
- Updated several weapons (clan small pulse laser ++, clan streak srm 6 ++ and a few others) to make their listed bonuses and stats line up correctly
- Updated many mechs base tonnages to match cannon numbers for their engine and chassis type without equipment like CASE, C3 Slaves (notably owens) or engine mounted heatsinks that aren't factored in to mech cooling (notably turkina)
- Updated mech tag elite_forces to remove the small number of mechs (9) that were using Elite_Forces instead
- Updated corresponding WOB lance defs to use elite_forces as well
- Fixed Max Armor numbers for Fire Moth standard variants
- Fixed hardpointdatadef for Wasp Lam X and S which was set to phawklegacylamlam instead of the correct phawklegacylam
- Fixed missing antipersonnel hardpoints for gargoyle e
- fixed strider using cicada hardpoints

# Balance Changes

- Updated damage from XMD 40 to have higher structure damage to make sure it is properly worth the weight, heat and poor accuracy
- Updated MRMs to have double damage but half missile count to make the ammo efficiency properly match tabletop 
	- this makes the highest grade MRMs actually viable compared to clan LRMs on a tonnage per overall damage rate
	- It also makes them not take forever to actually fire their full set of missiles
- Increased HAG40 structure damage by 5 to make it scale better as an upgrade from the HAG30 compared to the upgrade from the HAG20 to the HAG30
- Doubled heat damage from the Plasma PPC to make sure it is at all worth using compared to the plasma rifles

# Added Upgrade Weapons

- Added + and ++ versions of APGauss which increase range to 180 and 240 respectively
- Added + and ++ versions of Assault Cannon which reduce number of bullets but increase damage to match and then also increase accuracy
- Added + and ++ versions of Light Gauss that reduce weight and increase damage, particularly structure damage, to make them more viable compared to clan gauss.
- Added + and ++ versions of ER Micro Laser that increase damage and then also increase range
- Added + and ++ versions of Micro Pulse Laser that increase damage and then also reduce heat
- Added ++ and +++ versions of Plasma Cannon (and also renamed the + version to actually have + in the name) that increase power
- Added + and ++ versions of Plasma PPC that increase the number of shots fired, but reduce per shot damage

# Added Weapons and equipment

## Weapons
- Small X Pulse Laser (and upgrade + and ++) - as with all x pulses, it has a longer range than normal pulse, but shorter than clan and similar damage but higher heat
- Micro PPC (and upgrade + and ++) - Clan tech based version of Light PPC, lighter, but with less range.
- Light Binary Laser - Based on Battletech Gothic concept, weighs 1.5 and behaves like the regular binary laser, efficient compared to standard medium lasers, but inferior to clan tech equipment.
- Magshot (and upgrades) - Inner Sphere version of AP Gauss, longer ranged in base form but bulkier and slightly less damage.
- Hyper Gauss Rifle - Not the same thing as a Hyper Assault Gauss, this is a Clan/Draconis Combine designed version of the Heavy Gauss Rifle made with Clan-Tech. Higher damage but shorter range than regular Heavy Gauss.
- Bose-Einstein Plasma Rifle - A Clan-Tech derived version of the Plasma Rifle, this weapon is much heavier and does basically no heat damage, but does much higher regular and structure damage instead (counts as a PPC for capacitator purposes like all plasma cannons and rifles)
- FLSPT Laser (Fire Linked Short Pulse Trinary Laser) - A Clan take on the Blazer, the Traser fires a very heavy barrage of blasts, but weighs more than the equivalent number of ER medium pulse lasers, though it does generate somewhat less heat and take up fewer hardpoints.
- RISC Hyper Laser - The production ready version of the prototype, so it generates somewhat less heat at 72 instead of the 96 that the table top version would generate using the conversion math for lasers in vanilla of 4xtabletop heat, but still very heavy relative to its damage and heat
- Refined Plasma PPC - A Clan-tech take on the Heavy PPC, lighter than the heavy, does minor heat damage, but less stagger damage, and has a slightly shorter range.
- Shotgauss 5/10/20 - A cross between an LBX and a Gauss that works like how the tabletop silver bullet does. The silver bullet in this mod doesn't work like that because of how ammo consumption for spread guns works in vanilla (every projectile actually consumes one piece of ammo internally so lbx ammo bins actually have way more ammo than you think), so the shotgauss uses LBX ammo bins instead. Spreads daamge out compared to a HAG and does slightly less damage, but weighs slightly less and has better crit opportunity (though it does not have the HAG boosted crits).
- Thunderbolt 5x4 - The Clans wanted to duplicate the Thunderbolt, and succeeded at cutting the launcher and ammo weight in half, but failed to quite understand the concept, and so they made a thunderbolt "20" by duct taping 4 of the 5s together, hence the name. Lighter than regular thunderbolts, but generates the most heat of any missile weapon.

Additionally, several weapons have had EX versions added that can be found only on specific flashpoint exclusive reward units.  EX grade weapons are overpowered slightly compared to normal weapon versions but cannot be easily replaced which makes using them a gamble.

## Equipment
- Angel ECM and upgrade variants - basically a lighter version of the vanilla game's prototype EW equipment that also does some damage reduction changes like the guardian from expanded arsenal. Too many mechs have guardians for me to make them behave properly cause it causes weird ai issues if too many of them have the EW equipment, so instead I put the behavior on this new equipment.
- Bloodhound Active Probe and upgrade variants - a heavier and stronger version of the standard active probes
- Laser Insulator and upgrade variants - reduces laser heat generation, but since vanilla can't support the behavior of it breaking the lasers, it instead directly reduces damage, upgrades increase cooling.
- Gauss Capacitator and upgrade variants - Unlike the PPC capacitator, the Gauss cap instead increases crit chance while reducing base accuracy, to properly lean in to the role that Gauss weapons have in vanilla of being the only through armor damage weapon type, upgrades increase the boost while reducing the penalty (needs playtesting to adjust balance a bit)
- Autocannon Chamber Sealing and upgrade variants - Increases the projectile velocity of autocannons increasing the range, but also decreasing the accuracy due to more recoil. Upgrades increase range more with less penalty, and can allow the IS big UACs to actually be viableish compared to the clan versions early game.
- SRM Launch Rails and upgrade variants - Increases the range of SRMs while increasing the heat generated by them by 50%. makes srms especially clan streaks very lethal at distance, but is most useful on NARCs (that are considered SRMs internally) since it allows tagging enemies at longer ranges like an improved NARC beacon.
- LRM Follow The Leader Warheads and upgrade variants - normally this would be an alternate ammo type, but since vanilla already has the missilery system on the archers do this sort of effect it makes sense for it to be an upgrade. This increases the clustering of LRMs like the archery missilery system (although less powerfully) while decreasing base accuracy, to represent how tabletop FTL warheads will completely miss the target if the missile being followed fails to hit the target.

# Added Mechs

- Added all (or almost all, I probably missed one somewhere in the list) canon mechs in the CABs.
- Added super heavies using all generic SH models not already used as well as the hyperion, thunderstone, WOBSH1, aligator
- Added most of the mechs with models in the customs cab that aren't super tiny and intended to be ultralights and that don't require Custom Units.
- Added Elite Forces grade version of at least one variant for every mech that was star league era or earlier (if you spot any that are missing an elite forces variant, please let me know)
- Added at least two Elite Arsenal grade variants for every mech
- Added a bunch of additional interesting variants for existing mechs
- Total added and updated variant count across all types: 1419 Inner Sphere, 464 Clan, 6 special

# Flashpoints

- Updated Yang's Big Score flashpoint to give much more useful and interesting reward mechs, this also makes it possible to reliably complete the final mission of it when elite arsenal is active because it gives mechs that are actually able to fight effectively.
- Added 32 repeatable flashpoints covering difficulty 3-10 (1.5-5 skulls) which are setup to spawn either standard, elite forces, elite arsenal x grade, and elite arsenal s grade mechs allowing for more customizable difficulty (and also making it easier to find specific mechs and chassis you want).  
- Added 6 story flashpoints about a new group causing problems for the Periphery. Each of these flashpoints also rewards a unique mech.

# TODO

- More unique mechs and flashpoints to reward them
  - eventual goal is 4 each of light, medium, heavy, assault and superheavy allowing for a full team of unique mechs for all weight classes
- 
