using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    // create class for ingredients to get and set (Name, Quantity, Unit, Caloriesand Food groups)
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
    // class recipe for set and get (Name, ingredient, steps)
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }
        // create class for EnterRecipe
        public void EnterRecipe()
        {
            Console.Write("Enter the recipe name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            // use "for" stateement to get the name, ingredient, quantity, units, calories and food group
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Ingredient ingredient = new Ingredient();

                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write("Quantity: ");
                ingredient.Quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write("Calories: ");
                ingredient.Calories = double.Parse(Console.ReadLine());

                Console.Write("Food group: ");
                ingredient.FoodGroup = Console.ReadLine();

                Ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            // use "for" statement to get the steps
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                Steps.Add(Console.ReadLine());
            }
        }
        // getting info about the recipe name, ingredients and steps

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}, {ingredient.Quantity} {ingredient.Unit}");
            }
            // use "for" stateement to get the steps
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }
        // calculating calories
        public double CalculateTotalCalories()
        {
            double totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
            return totalCalories;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("\nRecipe Application");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe to display");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Recipe recipe = new Recipe();
                        recipe.EnterRecipe();
                        recipes.Add(recipe);
                        break;
                    case 2:
                        DisplayAllRecipes(recipes);
                        break;
                    case 3:
                        Console.WriteLine("Select a recipe to display:");
                        DisplayAllRecipes(recipes);
                        Console.Write("Enter the index of the recipe: ");
                        int recipeIndex = int.Parse(Console.ReadLine());
                        if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                        {
                            Recipe selectedRecipe = recipes[recipeIndex];
                            selectedRecipe.DisplayRecipe();
                            double totalCalories = selectedRecipe.CalculateTotalCalories();
                            Console.WriteLine("Total calories: " + totalCalories);
                            if (totalCalories > 300)
                            {
                                Console.WriteLine("Warning: Total calories exceed 300!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid recipe index.");
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            // use the "if" statement to get the recipe
            Console.WriteLine("\nAll Recipes:");
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            recipes = recipes.OrderBy(recipe => recipe.Name).ToList();
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i}. {recipes[i].Name}");
            }
        }
    }
}
