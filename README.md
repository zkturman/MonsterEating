# You've Changed - Popped Corn Bytes Jam, January 2025
## About
*You've Changed* is a monster-collecting arcade game. In the game, the player takes the role of a monster who eats food that falls from the sky. As they eat food, they will grow into new monsters. Different food means different monsters. Play the game to discover them all.

Final jam version can be played [here](https://www500.itch.io/youve-changed).

## Controls
Input is receeived through Unity's Input System, and Unity events are used to handle input for player movements and menu controls. Outside of menus, these controls values are passed to the [MainController](/MonsterEating/Assets/Scripts/MainController.cs). This class handles the rotation and RigidBody of the monster. The velocity of the monsters are variable, and is determined from the [MonsterController](MonsterEating/Assets/Scripts/MonsterController.cs), which acts as an interface for the behaviour of the current monster character.

The MonsterController acts as a parent for the current monster. When monsters transform into their next form, the [MonsterManager](MonsterEating/Assets/Scripts/MonsterManager.cs) instance class is called to instantiate a monster prefab and parent it to the MonsterController. This process allows easy access to the current monster's [MonsterData](MonsterEating/Assets/Scripts/MonsterData.cs) and consistent Transform handling.

## Food
In the game, there are four different categories of food: Veggie, Carnie, Junkie, and Deadlie. Each food GameObject has a [FoodData](MonsterEating/Assets/Scripts/FoodData.cs) class to identify it. A [FoodSpawner](MonsterEating/Assets/Scripts/FoodSpawner.cs) is used to spawn food into the game scene. This class utilises serialised properties for food spawning: one for food Prefabs and another for the spawn location, which is represented by an empty GameObject's Transform. A random food and spawn point is selected within a specified spawn frequency. When placing a FoodSpawner in a scene, an OnGizmosSelected method is used to visualise all the possible spawn locations. If multiple FoodSpawners exist under a single parent GameObject, developers can quickly adjust the spawn points based on gameplay needs.

Each food object has an attached RigidBody that allows the food to fall towards the ground. A special script is attached to give a random rotation to the object, which enhances the idea that the food object is raining from the sky. To adjust the fall-speed, the RigidBody's drag can be adjusted. For future development, a managing object or script could contain a value that aumatically adjusts the drag on all GameObjects with a FoodData component. In one such implementation, this value could be stored in the FoodSpawner and set when the food objects are instantiated.

Optionally, a visual effect object can be specified in the FoodData component, which is triggered when the monster eats a food. This feature is used only for Deadlie foods to give variety to the player's death.

## Eating
When a monster collides with a falling food object, the MonsterController interacts with the current monster's [MonsterConsumer](MonsterEating/Assets/Scripts/IConsumer/MonsterConsumer.cs) class. The MonsterConsumer class contains information about which food a monster can eat and what new monster that food contributes to. This consumer class is configured in a monster's prefab. The MonterController pass non-Deadlie FoodData class to MonsterConsumer. Otherwise, the monster dies, and it's game over.

When food is successfully consumed with the MonsterConsumer class, it is registered in an [EvolutionData](MonsterEating/Assets/Scripts/EvolutionData.cs) class. This class utilises a Dictionary and Linq to keep track of the monsters current progress towards the next monster. Once the designated total is met, as set in the serialised data, the monster will transform.

## Collecting
