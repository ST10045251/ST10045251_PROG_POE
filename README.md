# Recipe Manager

## Introduction
This is a simple recipe manager application written in C#.

## Instructions
To compile and run the software, follow these steps:

1. Clone the repository to your local machine:
2. Open the solution file in Visual Studio.
3. Build the solution by selecting `Build > Build Solution` from the menu.
4. Set the startup project to `RecipeManager`.
5. Press `Ctrl + F5` to run the application without debugging, or press `F5` to run with debugging.
6. Follow the on-screen instructions to interact with the recipe manager.

## GitHub Repository
You can find the GitHub repository for this project https://github.com/ST10045251/ST10045251_PROG_POE.git.

## Changes and Additions to the Recipe Journal Code
### Introduction of File Saving and Loading
- The ability to load and save recipes to and from JSON files has been added.

### Added Methods in Recipes Class
- included a way to store the active recipe in a designated file.
- included a way to import a recipe from a given file.

### Changes in Program.cs
#### Main Menu
- Included options to save and load recipes in the main menu.

### SaveRecipe Method
- Added a feature where saving the recipe requires the user to provide a filename.

### LoadRecipe Method
- Added a method that prompts the user to enter a filename to load the recipe.

### New Methods in the Recipes Class
#### SaveRecipe Method
- Implemented JSON serialization to save the current recipe to a file.
#### LoadRecipe Method
- Implemented JSON deserialization to load a recipe from a file.

### Error Handling
- Handled potential null reference exceptions when loading and saving files by adding validation checks.

### Integration with Main Program
- Integrated the save and load methods with the main program workflow.

### Sample Data for Demonstration
- To show functionality, example ingredients and steps have been added to the SaveRecipe and LoadRecipe methods.

### Improved User Input Handling
- Better processing of user input to guarantee that filenames are supplied when loading and storing recipes.

### User Feedback
- gave users unambiguous feedback messages indicating whether save and load activities were successful or unsuccessful.
