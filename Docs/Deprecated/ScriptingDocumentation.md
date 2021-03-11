# Scripting Documentation

## AircraftMovement
Place it on the player Prefab, it handle the player movement,
**members:**
-rotationSpeed: is the speed at the player can rotate (default: 30)
-maxAngle: the angle max that player can rotate (default: 90)
-tiltAngle: the angle at the player roll(rotate on X) when the input axis horizontal is at is max (default: 15)

## AreaBoundaries
Place one on the scene it will define the GameArea as in the GameDesign Document about Enemy Spawn, It will draw a cube but it will be visible only in the editor
**members:**
-EditorColor
-m_minX / minX
-m_maxX / maxX
-m_minZ / minZ
-m_maxZ / maxZ

## Bullet
Place it on the prefab of a bullet, it will be call by the weapon
**members:**
-LifeTime : the delay before the autodestruction of the bullet (default: 5)

## CameraFollowTarget
Place it on the Main Camera, it will allow this camera to follow the player movement
**members:**
-pitch = (default: 30)
-distance: (default: 20)
-cameraSpeed: (default: 1)
-rotationSpeed: (default: 2)

## Enemy
Place It on an Enemy Prefab, this will allow to create an enemy capable to move toward player and inflict damage, also it require Health Script to handle the life of this enemy
**members:**
-Speed = 5; This is the movement Speed of the enemy,
-Damages = 5; This is the amount of damage it will do if it touche the player
-Probability = 0.5f; the probabylity for this Enemy to spawn compare to the others enemies
-DeathParticle; the particle to play on death (optional)

## EnemySpawn
This Script will makes randomly spawn enemies on the Spawn Area (check the document about Spawn)
**members:**
-Enemies; the list of Enemy prefab
-SpawnDistance = 50; the distance of the spawn area from the player
-SpawnFrequency = 2; the coolDown between two spawn
**methods:**
+StartSpawn: Start the spawning of the enemies, call it at the start of the game
+StopSpawn: Stop the spawning of the enemies, call it at end the of the game in case of gameover or win

## Health
This Script allows to take damage, its used by the playerController script and the Enemy Script
**members:**
-maxHealth = 100; the health max of the object
-onDamaged; an event that is call when object take damage
-onHealed; an event that is call when object is healed
-onDie; an event that is call when the life point are at Zero

## LootOnDie
This script allow the object to drop something when it die, the object should have a Health Script 
**members:**
-probabilityToDrop; the probability to drop something on death
-LootList; the list of possible loot
### Lootable
A simple struct to represent a potential loot
**members:**
-LootObject: a prefab for a loot
-probability : the probability for this loot to be droped

## Pickup
This script manage a single pickup and allow the player to catch it, the pickup will move toward the player and call the onPickedUp event when it will touch the player, its use by UpgradePickup script
**members:**
-onPickedUp;

## PlayerController
This script should help to manage all the script on the player, but for now it can only help to detect when the player die and trigger a gameover

## Upgrade
Its represent an Upgrade Object
-upgradeName; use it if you need to differentiate an upgrade, for Expanple to display it separatly in the UI
**members:**
-formula; type of formula to use Flat will simply add value a,d PErcent will add a percent equal to value
-upgradeType; define wich stat will be upgraded
-value; 
-temporary; define if the upgrade is permanent or temporary
-duration; if the upgrade is temporary, this define the duration of the power up

## UpgradePickup
It can contains a list of upgrade that will be apply on Picked up, it require a pickup script
**members:**
-UpgradeList; the list of upgrades to add

## Weapons
Handle the Weapons of the aircraft and manage the current upgrades
**members:**
-OutPuts where the bullet will out
-BulletPrefab 
-InitialStats the weaponsStats at the start of the game
-onStatsChange An event that will be trigger when the stat change, you can use it to detect when update your UI).
### WeaponStats
**members:**
	-coolDown
	-bulletSpeed
	-bulletDamages

