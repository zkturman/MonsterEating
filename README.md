# You've Changed - Popped Corn Bytes Jam, January 2025
## About
*You've Changed* is a monster-collecting arcade game. In the game, the player takes the role of a monster who eats food that falls from the sky. As they eat food, they will grow into new monsters. Different food means different monsters. Play the game to discover them all.

Final jam version can be played [here](https://www500.itch.io/youve-changed).

## Controls
Input is receeived through Unity's Input System, and Unity events are used to handle input for player movements and menu controls. Outside of menus, these controls values are passed to the [MainController](/MonsterEating/Assets/Scripts/MainController.cs). This class handles the rotation and RigidBody of the monster. The velocity of the monsters are variable, and is determined from the [MonsterController](MonsterEating/Assets/Scripts/MonsterController.cs), which acts as an interface for the behaviour of the current monster character.

The MonsterController acts as a parent for the current monster. When monsters transform into their next form, the [MonsterManager](MonsterEating/Assets/Scripts/MonsterManager.cs) instance class is called to instantiate a monster prefab and parent it to the MonsterController. This process allows easy access to the current monster's [MonsterData](MonsterEating/Assets/Scripts/MonsterData.cs) and consistent Transform handling.

## Food

## Eating
When a monster collides with a falling food object, the MonsterController interacts with the current monster's [MonsterConsumer](MonsterEating/Assets/Scripts/IConsumer/MonsterConsumer.cs) class. The MonsterConsumer class contains information about which food a monster can eat and what new monster that food contributes to. This consumer class is configured in a monster's prefab. The MonterController pass non-Deadlie FoodData class to MonsterConsumer. Otherwise, the monster dies, and it's game over.

When food is successfully consumed with the MonsterConsumer class, it is registered in an [EvolutionData](MonsterEating/Assets/Scripts/EvolutionData.cs) class. This class utilises a Dictionary and Linq to keep track of the monsters current progress towards the next monster. Once the designated total is met, as set in the serialised data, the monster will transform.

## Collecting
