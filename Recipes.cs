using System;
using System.Collections.Generic;

namespace ST10045251_PROG_POE
{
    public class Recipes
    {
        public string Name { get; set; }
        private List<Ingredients> Ingredients { get; set; }
        private List<Ingredients> initialQuantities;
        private List<string> steps;
        public delegate void CalorieExceededHandler(string message); // Defining delegate
        public event CalorieExceededHandler OnCalorieExceeded; // Defining event

        public Recipes(string name)
        {
            Name = name;
            Ingredients = new List<Ingredients>();
            initialQuantities = new List<Ingredients>();
            steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Ingredients.Add(new Ingredients { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            if (calories > 300)
            {
                OnCalorieExceeded?.Invoke($"Warning: High calorie ingredient added ({calories} calories).");
            }
        }

        public List<Ingredients> GetIngredients()
        {
            return Ingredients;
        }

        public void AddStep(string description)
        {
            steps.Add(description);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                if (i < initialQuantities.Count)
                {
                    Ingredients[i].Quantity = initialQuantities[i].Quantity;
                }
            }
        }

        public void ClearRecipe()
        {
            Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                Ingredients.Clear();
                initialQuantities.Clear();
                steps.Clear();
                Console.WriteLine("Recipe cleared.");
            }
            else
            {
                Console.WriteLine("Clear recipe operation cancelled.");
            }
        }
    }
}
