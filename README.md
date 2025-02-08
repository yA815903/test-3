# 2D RPG Game

## Overview
This project is a 2D RPG game featuring a Viking character. The game includes character creation, quests, combat mechanics, and resource management.

## C# Scripts
The following C# scripts have been created for the game:

1. **CharacterCreation.cs**: Handles character creation logic.
2. **Quest.cs**: Defines quest properties and completion logic.
3. **QuestManager.cs**: Manages quest acceptance and completion.
4. **PlayerCombat.cs**: Handles player combat mechanics.
5. **EnemyCombat.cs**: Manages enemy combat behavior.
6. **ResourceManager.cs**: Manages resources like wood and stone.
7. **ResourcePickup.cs**: Handles resource pickups by the player.
8. **BuildingManager.cs**: Manages building mechanics in the game.

## Integration Instructions
1. **Open Unity**: Create a new Unity project or open an existing one.
2. **Add Scripts**: Place the C# scripts in the `Assets` folder of your Unity project.
3. **Create Game Objects**: Attach the scripts to appropriate GameObjects in your scene (e.g., attach `CharacterCreation.cs` to a UI GameObject).
4. **Set Up UI**: Ensure that the UI elements referenced in the scripts (like `InputField` and `Slider`) are present in your Unity scene.

## Running the Game
- Press the Play button in Unity to test the game functionality.

## HTML Page
The HTML page is used for displaying the game in a web environment. Ensure that the Unity WebGL build is properly set up to integrate with the HTML page.
