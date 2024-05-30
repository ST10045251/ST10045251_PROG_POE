using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10045251_PROG_POE
{
    class Program
    {
        static List<Recipes> recipeBook = new List<Recipes>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Recipe Journal!");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. View a recipe");
                Console.WriteLine("3. List all recipes");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddANewRecipe();
                        break;
                    case "2":
                        ViewRecipe();
                        break;
                    case "3":
                        ListRecipes();
                        break;
                    case "4":
                        Console.WriteLine("Exiting Recipe Journal. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        // Method to add a new recipe
        static void AddANewRecipe()
        {
            Console.WriteLine("\nAdding a new recipe");
            string recipeName = GetInput("Enter the recipe name:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
            Recipes recipe = new Recipes(recipeName);
            recipe.OnCalorieExceeded += message => Console.WriteLine(message);

            int numIngredients = (int)GetValidDoubleInput("Please enter the number of ingredients:");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Change color
                string name = GetInput("Name:");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                double quantity = GetValidDoubleInput("Quantity:");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                string unit = GetInput("Unit:");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                int calories = (int)GetValidDoubleInput("Calories:");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                string foodGroup = GetInput("Food Group:");

                recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
            }

            int numSteps = (int)GetValidDoubleInput("Please enter the number of steps:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line

            for (int i = 0; i < numSteps; i++)
            {
                string description = GetInput($"Enter description for step {i + 1}:");
                recipe.AddStep(description);

            }

            recipeBook.Add(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        // Method to view an existing recipe
        static void ViewRecipe()
        {
            if (recipeBook.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            ListRecipes();

            int index = (int)GetValidDoubleInput("Enter the number of the recipe to view:") - 1;
            Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line

            if (index >= 0 && index < recipeBook.Count)
            {
                recipeBook[index].DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
            }
        }

        // Method to list all recipes in alphabetical order
        static void ListRecipes()
        {
            if (recipeBook.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                return;
            }

            Console.WriteLine("Recipes:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
            foreach (var recipe in recipeBook.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to get user input
        static string GetInput(string prompt)
        {
            Console.Write(prompt + " "); // Write prompt inline
            return Console.ReadLine();
        }

        // Method to get valid double input from user
        static double GetValidDoubleInput(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt + " ");
                if (double.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
                Console.WriteLine(new string('-', Console.WindowWidth - 1)); // Add a line
                Console.ResetColor();
            }
            return result;
        }
    }
}
