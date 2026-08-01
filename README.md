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
see below spoilers section for exact list

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
- Total added and updated variant count across all types: 1430 Inner Sphere, 464 Clan, 25 special
- Added a total of 23 Unique mech variants some of which are based on existing mechs, others are using specific models.  See below spoilers section for details

# Flashpoints

- Updated Yang's Big Score flashpoint to give much more useful and interesting reward mechs, this also makes it possible to reliably complete the final mission of it when elite arsenal is active because it gives mechs that are actually able to fight effectively.
- Added 32 repeatable flashpoints covering difficulty 3-10 (1.5-5 skulls) which are setup to spawn either standard, elite forces, elite arsenal x grade, and elite arsenal s grade mechs allowing for more customizable difficulty (and also making it easier to find specific mechs and chassis you want).  
- Added 6 story flashpoints about a new group causing problems for the Periphery. Each of these flashpoints also rewards a unique mech.

# TODO

- More flashpoints for remaining unique mechs.
  - 17 unique mechs do not have flashpoints for rewarding them yet and so can be found as random spawns for now so they can be aquired and tested.

# Spoilers

<details>
  <summary>Spoilers</summary>
  
  There are 23 new unique mechs added beyond the original mod which had the Monster as a reward from the Superheavies flashpoint and the Valkyrie Ghost as a reward for the LAMs flashpoint.
  The below list includes all 25 unique mechs

  ## Light Mechs
  - Assault Cougar - Cougar with an assault weapons package from a Dire Wolf X which increases all damage and reduces heat. Equipped with 5 Micro PPC EX and 5 Clan SRM 6 EX - Additional weight capacity provided by using XXL engine and XL gyro. Strongest raw firepower potential for any light mech.
  - Fireball XFC (eXtra Fast Combat) - Based on the canon Fireball XF (eXtra Fast) but with a reduced engine to allow for enough tonnage for decent weaponry. Fastest mech in the game with MASC and 2X Engine and it comes with a COIL M EX and a COIL S EX. Has evasion baffles that increase max evasion charges allowing for extra coil damage.
  - Nyx Obscura - A RISC Nyx using an XXL engine to allow for additional weaponry. Mounts 2 VSM Laser EX and 2 MML3 EX. Extremely fast mech, but relatively low firepower for a unique mech.
  - Urbanemech - An uptonned Urbanmech designed to have similar firepower layout to a Bane. Mounts two RAC 2 EX, 1 Clan ER Medium Laser EX and 2 Clan ER Small Laser EX. Has limited ammo but high firepower. Based on the Urbanmech R100 so it has twice the base speed of a standard Urbanmech.
  - Basilisk LAM - Uses the gripgerwalk model. Basically a lighter Valkyrie Ghost with the same built in stealth. Fitted with 2 LBX 2 (C) EX and 2 VSS Laser EX. Good if you want to be underweight for a mission, very difficult to hit just like the Valkyrie Ghost, so it's very good for sending forward to scout and then pull back.

  ## Medium Mechs
  - BrightNova - A Nova using a combination of fixed mount laser insulators and 12 Clan ER Medium Laser EX to allow it to fire a full alpha strike without overheating. No other weapons, very straightforward.
  - Hollander II EX - Based on the Hollander, but uptonned all the way to 55 tons. Same basic concept as a standard Hollander II but using an XMD 40 EX instead of a regular gauss. Has two Medium X-Pulse Lasers and two IATM 3 EX as support and comes with a rangefinder suite like a rifleman. Most powerful medium sniper mech in the game.
  - Osprey Talon - A RISC redesigned Osprey built to bring a Silver Bullet Special EX into the field. Has two MRM 10 EX, two Light Blazer +++ and two Clan ER Small Laser EX as support weaponry. Very fast for its level of firepower, but very ammo dependent.
  - Volleyfire Naja - An old clan design based on the kintaro. Modernized by mounting a set of 8 Clan Stream SRM 6 EX for heavy volleys and fixed mount launch rails for extended range. Has 3 Clan ER Medium Laser ++ as backup weaponry. Massive volley damage, but runs out of ammo fast.
  - Valkyrie Ghost - Rewarded by LAMs flashpoint from Expanded Arsenal. A LAM with a built in Void Signature System ++ and C3I ++, Very limited hardpoints so it needs high damage single hardpoint weaponry. Very difficult for enemies to hit which makes it excellent as a spotter/distraction, vulnerable to enemies sensor locking.

  ## Heavy Mechs
  - Lament Wail - RISC designed mech mounting a mix of 2 RISC Hyper Laser EX and 2 Improved Heavy Large Laser EX - Mounts an XXL engine to free enough tonnage for mounting enough D-CC Heat Sinks to get the heat output under control. Able to snipe with the Hyper Lasers far beyond the heavy laser range.
  - Perseus Smasher - Society designed heavy sniper mech mounting 2 Light Gauss Rifle EX, 2 VSL Laser EX and MML 7 EX. Good at all ranges, but not very fast just like other Orion based designs. Comes with Optimized Capacitors and Annihilator Siege Module. Good as a heavy brawler as well
  - Sidewinder Glow - Society designed heavy brawler built around a Hyper Gauss Rifle EX. Has two Binary Laser Cannon EX and two IATM 9 EX as support and built in Gauss Capacitator for boosting the Hyper Gauss crit rate. Good at all ranges, but bad at catching fast mechs.
  - Woodsman Blazer - Rewarded by the first Cus's Cutlasses flashpoint. Unnamed Clan built mech with an advanced Laser Optimization Weapon System to boost laser damage and reduce heat in one module. Has twin RISC Hyper Laser EX and twin FLSPT Laser EX and two Clan ER Small Laser ++ as minor backup. Similar to the Lament Wail, but with more close range firepower. 
  - Super LAM - Rewarded by the second Cus's Cutlasses Flashpoint. Unnamed Clan built 75 ton LAM. Comes with twin Thunderbolt 5x4 EX and 6 Micro PPC EX. Heavy firepower and very maneuverable, but does not have the stealth power of the lighter LAMs so it is much less suitable as a scout.

  ## Assault Mechs
  - Dire Wolf Ultra - Society designed ultimate assault mech. Built with an improved assault package that has the full power damage boost that S class direwolfs get, but to all weapon types. Has 4 Clan ER PPC EX, 4 Clan UAC/2 EX and 2 IATM 9 EX supported by a ppc capacitator and lrm follow the leader seekers to improve power. Highest raw firepower assault mech in the game, good at destruction that doesn't require being speedy.
  - Iron Cheetah Tempered - RISC designed fast assault mech. Fitted with HAG 40 EX for long range power, and 2 Clan Large Pulse Laser EX and 2 FLSPT Laser EX and a MASC for maximum speed. Slightly light firepower for a 100ton assault, but very effective at getting around the map for something this heavy.
  - Pulverizer Command - Rewarded by fourth Cus's Cutlasses Flashpoint. Unnamed Clan designed command mech. Fitted with every piece of buffing gear in the game (that doesn't completely overlap) Company Command Mod, Dual Cockpit Battle Computer, C31++, Nova CEWS++, Bloodhound AP++ and Angel ECM ++. Most powerful lance buffing unit in the game and all buff gear is built in so can never be permanently destroyed. Comes with two Refined Plasma PPC EX, an odd mix of LRMs to deal with the large amounts of occupied torso space and a Shotgauss 10 ++.
  - Scylla Jumpman - Rewarded by third Cus's Cutlasses flashpoint. Unnamed Clan designed DFA focused mech. Takes heavily reduced DFA damage due to built in reinforcements, has no hard points other than support weapons and mounts 4 Clan ER Small Laser Array ++, 2 Clan Small Pulse Laser Array ++, 6 Clan Heavy Machine Gun ++ and 2 Clan ER Small Laser EX. The laser arrays are identical to 3x of whatever laser they are arrays of, to avoid exceeding the 14 weapons limit. Since all weapons are anti-personnel type, they can all fire after melee or DFA allowing for absurd damage. Has vulcan CQC array to improve melee defense and support weapon range.
  - Cockatrice LAM - 100 ton WOB assault LAM. Comes with a massive Clan UAC/20 EX, two Heavy PPC EX and one MML 7 EX. Very heavy firepower and able to move around the battlefield fast, but easily hit and not particularly well armored.
  
  ## Superheavy Mechs
  - Alpha Cus - Rewarded by the fifth Cus's Cutlasses flashpoint. Unnamed Clan built 150t Superheavy devastator. Has 12 of every non-support hardpoint and they are evenly distributed on the arms and side torsos allowing for unmatched build flexibility. Comes with 4 Shotgauss 5++, 4 FLSPT Laser EX, 4 ATM 3++ and 2 ATM 6 ++. Can reach absurd firepower with the right combination of weaponry. Massive amount of free tonnage. One of the strongest mechs for raw power in game.
  - Hammerblow Custom - Rewarded by the sixth Cus's Cutlasses Flashpoint. Jade Falcon built 150t Superheavy devastator. Somewhat odd hardpoint layout, but comes with 4 Bose Einstein Plasma Rifle EX, 2 Thunderbolt 5x4 EX, two assault cannons and two ER Large Pulse Laser ++. Heavy firewpower and big free tonnage, but not as layout flexible as the Alpha.
  - Monster - Rewarded by superheavy flashpoint from expanded arsenal. Supposedly a modified omega, but actually based on the monster from macross. Has been upgraded compared to base expanded arsenal to now mount 2 XMD40 EX, 5 C ERPPC EX (one in each arm and every torso to properly match the visual external weapon mounts) and two ER Medium Pulse ++
  - Snowflame Malice - RISC designed Superheavy Brawler. Based on design concept of the quad hyper laser Malice. Uses two RISC Hyper Laser EX and two FLSPT Hyper Lasers for massive long range laser destruction, with 4 Stream SRM 4 EX to defend at close range. Has absurd heat output and needs 6 exchanger ++ and a laser insulator ++ to be viable. 
  - Warthog LAM - WOB designed 150 ton LAM. Absurdly overweight lam, only jump capable super heavy in game (other super heavies have jet slots but no jump jets are available). Has unusual loadout slots, unfortunately vanilla cannot render this correctly in the mechbay, but it does correctly handle it. Mech is built around a Rotary Autocannon 20 EX and has only two thunderbolt 5x4 ex and two ER medium Laser ++ as support.

  ## EX Ballistic Weapons
  -

</details>
