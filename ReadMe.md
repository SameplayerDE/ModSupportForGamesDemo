# Structure
- **Game**: The main game code, implementing the game's mechanics and functionalities.
- **ExampleMod**: A sample mod created to show how to build and implement mods for the game.
- **Game_Mod_Interface**: The interface between the game and mods. This includes the mod API for developers to interact with the game.

# Building the Mod

1. **Build the Solution**: Use Visual Studio or your preferred build tool to build the project.

2. **Run the Game Once**: Before placing your mod in the game's mod directory, you need to run the main game at least once. This ensures that the necessary directories are created.

3. **Place the Mod in the Correct Directory**: After building your mod, you'll find the DLL file in the output directory. You must manually move this file to the game's mod directory.

# Note

Make sure to place the mod in the correct directory, as mentioned above. The game must be run once to create the appropriate directories, and this is a crucial step to ensure that your mod will be recognized and loaded by the game.
