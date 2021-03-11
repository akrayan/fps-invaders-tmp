# General Documentation

## How does the probability system work ?
Some features like the Spawn of an enemy or the loot of a power up require a probability variable and here is how to use them. For ``EnemySpawn`` for example, you have a list of potential enemies and the probability of spawning each enemy that is defined in the``Enemy`` script, the probability variable is a simple float and the chance of an enemy spawning will be equal to : the probability variable divided by the sums of probability variables of each enemy in the list, so if in the ``EnemySpawn`` list we have 2 enemies with {(Enemy1 probability = 1), (Enemy2 probability = 2)}, the chance of Enemy1 to spawn will be 1/3 and the chance of Enemy2 will be 2/3.

## How to create an enemy ?
On your Prefab, simply add the Enemy and Health script, and possibly the LootOnDie script if you want your enemy to be able to drop something when he dies.

## How to configure the Enemy Spawn ?
To allow enemies to appear, you will need two scripts on the stage, first the script ``BoundariesArea`` to define a play area and then the script ``EnemySpawn``.
After that you just need to call the method ``EnemySpawn.StartSpawn()`` in your Level Manager.

## How can the UI access weapons statistics and upgrades?
From your script, retrieve the ``Weapons`` script on the player, then register to the ``Weapons.onStatsChange`` event and use the methods: ``Weapons.GetCurrentStat``, ``Weapons.GetTemporaryUpgrades`` and ``Weapons.GetPermanentUpgrades`` to retrieve data and update your user interface.

## How to upgrade weapons from the UI ?
From your script, retrieve the Weapons script on the player, then call the method ``Weapons.UpgradeWeapons`` and pass in parameter a list of Upgrades you want to add.

## How do I create a new Upgrade pickup?
On your Prefab, just add the ``Pickup`` and ``UpgradePickup`` scripts and configure them.


### Refer to the scripting documentation to see how to configure the scripts.
