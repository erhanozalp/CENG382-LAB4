using System;
using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Cuisine { get; set; }
    public int DifficultyLevel { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int Servings { get; set; }
    public int AuthorId { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public void printRecipe()
    {
	    Console.WriteLine("Title = " + Title);
	    Console.WriteLine("Description = " + Description);
	    Console.WriteLine("Cuisine = " + Cuisine);
	    Console.WriteLine("Difficulty = " + DifficultyLevel);
	    Console.WriteLine("PreparationTime = " + PreparationTime);
	    Console.WriteLine("CookingTime = " + CookingTime);
	    Console.WriteLine("Servings = " + Servings);
	    Console.WriteLine("Ingredients: ");
	    foreach(Ingredient ingredient in Ingredients)
	    {
		    ingredient.printIngredient();
	    }

    }

    public Recipe()
    {
	    Id = 0;
	    Title = null;
	    Description = null;
	    Cuisine = null;
	    DifficultyLevel = 0;
	    PreparationTime = 0;
	    CookingTime = 0;
	    Servings = 0;
	    AuthorId = 0;
	    Ingredients = new List<Ingredient>();
    }
}

public class Ingredient
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public string Unit { get; set; }
	public int RecipeId { get; set; }

	public void printIngredient()
    {
        Console.WriteLine("Name: " + Name);
	    Console.WriteLine("Quantity: " + Quantity);
	    Console.WriteLine("Unit: " + Unit);
    }

    public Ingredient(){
	    Id = 0;
	    Name = "";
	    Quantity = 0;
	    Unit = "";
	    RecipeId = 0;
    }
}

public class Rating
{
	public int Id { get; set; }
	public int Value { get; set; }
	public int RecipeId { get; set; }

	public void printRating()
    {
        Console.WriteLine("Value = " + Value);
    }

    public Rating(){
	    Id = 0;
	    Value = 0;
	    RecipeId = 0;
    }
}



public class RecipeCRUD
{
	public List<Recipe> recipes;

	public RecipeCRUD()
    {
        recipes = new List<Recipe>();
    }

    public Recipe createRecipe(string title, string description, string cuisine, int difficulty, int preparationTime, int cookingTime, int servings, int authorId, List<Ingredient> ingredients)
    {
        int id = recipes.Count + 1;

        Recipe recipe = new Recipe
        {
            Id = id,
            Title = title,
            Description = description,
            Cuisine = cuisine,
            DifficultyLevel = difficulty,
            PreparationTime = preparationTime,
            CookingTime = cookingTime,
            Servings = servings,
            AuthorId = authorId,
            Ingredients = ingredients
        };

        recipes.Add(recipe);
        return recipe;
    }

    public Recipe GetRecipeById(int id)
    {
        return recipes.FirstOrDefault(r => r.Id == id);
    }

    public void UpdateRecipe(int id, string title = null, string description = null, string cuisine = null, int? difficulty = null, int? preparationTime = null, int? cookingTime = null, int? servings = null, int? authorId = null, List<Ingredient> ingredients = null)
    {
        Recipe recipe = GetRecipeById(id);
        if (recipe != null)
        {
            if (title != null)
            {
                recipe.Title = title;
            }
            if (description != null)
            {
                recipe.Description = description;
            }
            if (cuisine != null)
            {
                recipe.Cuisine = cuisine;
            }
            if (difficulty != null)
            {
                recipe.DifficultyLevel = difficulty.Value;
            }
            if (preparationTime != null)
            {
                recipe.PreparationTime = preparationTime.Value;
            }
            if (cookingTime != null)
            {
                recipe.CookingTime = cookingTime.Value;
            }
            if (servings != null)
            {
                recipe.Servings = servings.Value;
            }
            if (authorId != null)
            {
                recipe.AuthorId = authorId.Value;
            }
            if (ingredients != null)
            {
                recipe.Ingredients = ingredients;
            }
        }
    }

    public void DeleteRecipe(int id)
    {
        Recipe recipe = GetRecipeById(id);

        if (recipe != null)
        {
            recipes.Remove(recipe);
        }
    }

    public void GetAllRecipes()
    {
        Console.WriteLine("Listing all recipes: ");
        foreach (Recipe recipe in recipes)
        {
            recipe.printRecipe();
        }
    }


}

public class IngredientCRUD
{
	public List<Ingredient> ingredients;

	public IngredientCRUD()
    {
	    ingredients = new List<Ingredient>();
    }

    public Ingredient createIngredient(string name, int quantity, string unit, int recipeId)
    {
	    int id = ingredients.Count + 1;

	    Ingredient ingredient = new Ingredient 
	    {
		    Id = id,
		    Name = name,
		    Quantity = quantity,
		    Unit = unit,
		    RecipeId = recipeId
	    };

	    ingredients.Add(ingredient);
	    return ingredient;
    }

    public Ingredient GetIngredientById(int id)
    {
	    return ingredients.Find(x => x.Id == id);
    }

    public void UpdateIngredient(int id, string name = null, int? quantity = null, string unit = null, int? recipeId = null)
    {
	    Ingredient ingredient = GetIngredientById(id);

	    if(ingredient != null)
        {
		    if(name != null)
            {
			    ingredient.Name = name;
            }
		    if(quantity != null)
            {
			    ingredient.Quantity = quantity.Value;
            }
		    if(unit != null)
            {
			    ingredient.Unit = unit;
            }
		    if(recipeId != null)
            {
			    ingredient.RecipeId = recipeId.Value;
            }
        }
    }

    public void DeleteIngredient(int id)
    {
	    Ingredient ingredient = GetIngredientById(id);

	    if(ingredient != null)
        {
		    ingredients.Remove(ingredient);
        }
    }

    public void GetAllIngredients()
    {
        Console.WriteLine("Listing all ingredients");
	    foreach(Ingredient ingredient in ingredients)
        {
            ingredient.printIngredient();
        }
    }

}

public class RatingCRUD
{
	public List<Rating> ratings;

	public RatingCRUD()
    {
		ratings = new List<Rating>();
    }

	public Rating createRating(int value, int recipeId)
    {
		int id = ratings.Count + 1;

		Rating rating = new Rating
        {
			Id = id,
			Value = value,
			RecipeId = recipeId
        };

		ratings.Add(rating);
		return rating;

    }

	public Rating GetRatingById(int id)
    {
		return ratings.FirstOrDefault(r => r.Id == id);
    }

	public void UpdateRating(int id, int? value = null, int? recipeId = null)
    {
		Rating rating = GetRatingById(id);

		if(rating != null)
        {
			if(value != null)
            {
				rating.Value = value.Value;
            }
			if(recipeId != null)
            {
				rating.RecipeId = recipeId.Value;
            }
        }
    }

	public void DeleteRating(int id)
    {
		Rating rating = GetRatingById(id);

		if(rating != null)
        {
			ratings.Remove(rating);
        }
    }

	public void GetAllRatings()
    {
        Console.WriteLine("Listing all ratings:");
		foreach(Rating rating in ratings)
        {
            rating.printRating();
        }
    }
}



namespace Programs
{
    
	class Exercise1
    {

		static void Main(string[] args)
        {
            RecipeCRUD allRecipes = new RecipeCRUD();
            while (true)
            {
                Console.WriteLine("Welcome to the Recipe Program!\n1.Recipe Manager\n2.Recipe Finder App\n3.Quit\nYour choice: ");
                int menuChoice = Convert.ToInt32(Console.ReadLine());

                if(menuChoice == 1)
                {
                    Console.WriteLine("Welcome to the Recipe Manager!");

                    while (true)
                    {
                        Console.WriteLine("What would you like to do?\n1-Manage recipes\n2-Manage ingredients\n3-Manage ratings\n4-Exit\nPlease enter a number: ");
				        int choice = Convert.ToInt32(Console.ReadLine());
				        IngredientCRUD ingredient = new IngredientCRUD();
				        RatingCRUD ratings = new RatingCRUD();

				        if (choice == 1)
                        {
                            bool a = true;
                            while (a)
                            {
                                Console.WriteLine("What would you like to do with recipes?\n1.View all recipes\n2.Add a recipe\n3.Update a recipe\n4.Delete a recipe\n5.Return to main menu\nPlease enter a number: ");
                                int choice1 = Convert.ToInt32(Console.ReadLine());

                                if (choice1 == 1)
                                {
                                    allRecipes.GetAllRecipes();
                                }
                                else if (choice1 == 2)
                                {
                                    Console.WriteLine("Please enter the recipe name: ");
                                    string recipeName = Console.ReadLine();
                                    Console.WriteLine("Please enter recipe description: ");
                                    string recipeDescription = Console.ReadLine();
                                    Console.WriteLine("Please enter recipe cuisine: ");
                                    string recipeCuisine = Console.ReadLine();
                                    Console.WriteLine("Please enter recipe DifficultyLevel: ");
                                    int recipeDifficultyLevel = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter recipe PreparationTime: ");
                                    int recipePreparationTime = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter recipe CookingTime: ");
                                    int recipeCookingTime = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter recipe Servings: ");
                                    int recipeServings = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter recipe AuthorId: ");
                                    int recipeAuthorId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter recipe Ingredients: ");
                                    Ingredient newIngredient = new Ingredient();
                                    Console.WriteLine("Please enter the ingredient name: ");
                                    string newIngredientName = Console.ReadLine();
                                    newIngredient.Name = newIngredientName;
                                    Console.WriteLine("Please enter ingredient quantity: ");
                                    int newIngredientQuantity = Convert.ToInt32(Console.ReadLine());;
                                    newIngredient.Quantity = newIngredientQuantity;
                                    Console.WriteLine("Please enter ingredient unit: ");
                                    string newIngredientUnit = Console.ReadLine();
                                    newIngredient.Unit = newIngredientUnit;
                                    Console.WriteLine("Please enter ingredient recipeId: ");
                                    int newIngredientRecipeId = Convert.ToInt32(Console.ReadLine());
                                    newIngredient.RecipeId = newIngredientRecipeId;
                                    List<Ingredient> ingredients = new List<Ingredient>();
                                    ingredients.Add(newIngredient);
                                    allRecipes.createRecipe(recipeName, recipeDescription, recipeCuisine, recipeDifficultyLevel, recipePreparationTime, recipeCookingTime, recipeServings, recipeAuthorId, ingredients);
                                }
                                else if (choice1 == 3)
                                {
                                    Console.WriteLine("Please enter the recipe ID");
                                    int recipeId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter the new recipe name");
                                    string recipeName = Console.ReadLine();
                                    Console.WriteLine("Please enter new recipe description: ");
                                    string recipeDescription = Console.ReadLine();
                                    Console.WriteLine("Please enter new recipe cuisine: ");
                                    string recipeCuisine = Console.ReadLine();
                                    Console.WriteLine("Please enter new recipe DifficultyLevel: ");
                                    int recipeDifficultyLevel = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new recipe PreparationTime: ");
                                    int recipePreparationTime = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new recipe CookingTime: ");
                                    int recipeCookingTime = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new recipe Servings: ");
                                    int recipeServings = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new recipe AuthorId: ");
                                    int recipeAuthorId = Convert.ToInt32(Console.ReadLine());
                                    allRecipes.UpdateRecipe(recipeId, recipeName, recipeDescription, recipeCuisine, recipeDifficultyLevel, recipePreparationTime, recipeCookingTime, recipeServings, recipeAuthorId);
                                }
                                else if (choice1 == 4)
                                {
                                    Console.WriteLine("Please enter the recipe id you want to delete: ");
                                    int recipeId = Convert.ToInt32(Console.ReadLine());
                                    allRecipes.DeleteRecipe(recipeId);
                                }
                                else if (choice1 == 5)
                                {
                                    a = false;
                                }
                                else
                                {
                                    Console.WriteLine("You have inputted an invalid value. Please try again!");
                                }
                            }
                        }
				        else if(choice == 2)
                        {
                            bool a = true;
                            while (a)
                            {
                                Console.WriteLine("What would you like to do with ingredients?\n1.View all ingredients\n2.Add an ingredient\n3.Update an ingredient\n4.Delete an ingredient\n5.Return to main menu\nPlease enter a number: ");
                                int choice1 = Convert.ToInt32(Console.ReadLine());

                                if (choice1 == 1)
                                {
                                    ingredient.GetAllIngredients();
                                }
                                else if (choice1 == 2)
                                {
                                    Console.WriteLine("Please enter the ingredient name: ");
                                    string ingredientName = Console.ReadLine();
                                    Console.WriteLine("Please enter ingredient quantity: ");
                                    int ingredientQuantity = Convert.ToInt32(Console.ReadLine());;
                                    Console.WriteLine("Please enter ingredient unit: ");
                                    string ingredientUnit = Console.ReadLine();
                                    Console.WriteLine("Please enter ingredient recipeId: ");
                                    int ingredientRecipeId = Convert.ToInt32(Console.ReadLine());
                                    ingredient.createIngredient(ingredientName, ingredientQuantity, ingredientUnit, ingredientRecipeId);
                                }
                                else if (choice1 == 3)
                                {
                                    Console.WriteLine("Please enter the ingredient Id");
                                    int ingredientId = Convert.ToInt32(Console.ReadLine());
                                   Console.WriteLine("Please enter the new ingredient name: ");
                                    string ingredientName = Console.ReadLine();
                                    Console.WriteLine("Please enter new ingredient quantity: ");
                                    int ingredientQuantity = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new ingredient unit: ");
                                    string ingredientUnit = Console.ReadLine();
                                    Console.WriteLine("Please enter new ingredient recipeId: ");
                                    int ingredientRecipeId = Convert.ToInt32(Console.ReadLine());
                                    ingredient.UpdateIngredient(ingredientId, ingredientName, ingredientQuantity, ingredientUnit, ingredientRecipeId);
                                }
                                else if (choice1 == 4)
                                {
                                    Console.WriteLine("Please enter the ingredient id you want to delete: ");
                                    int ingredientId = Convert.ToInt32(Console.ReadLine());
                                    ingredient.DeleteIngredient(ingredientId);
                                }
                                else if (choice1 == 5)
                                {
                                    a = false;
                                }
                                else
                                {
                                    Console.WriteLine("You have inputted an invalid value. Please try again!");
                                }
                        
                            }
                        
                        }
				        else if(choice == 3)
                        {
                            bool a = true;
                            while (a)
                            {
                                Console.WriteLine("What would you like to do with ratings?\n1.View all ratings\n2.Add a rating\n3.Update a rating\n4.Delete a rating\n5.Return to main menu\nPlease enter a number: ");
                                int choice1 = Convert.ToInt32(Console.ReadLine());

                                if (choice1 == 1)
                                {
                                    ratings.GetAllRatings();
                                }
                                else if (choice1 == 2)
                                {
                                    Console.WriteLine("Please enter the rating value: ");
                                    int ratingValue = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter rating recipeId: ");
                                    int ratingRecipeId = Convert.ToInt32(Console.ReadLine());
                                    ratings.createRating(ratingValue, ratingRecipeId);
                                }
                                else if (choice1 == 3)
                                {
                                    Console.WriteLine("Please enter the new rating value: ");
                                    int ratingValue = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Please enter new rating recipeId: ");
                                    int ratingRecipeId = Convert.ToInt32(Console.ReadLine());
                                    ratings.UpdateRating(ratingValue, ratingRecipeId);
                                }
                                else if (choice1 == 4)
                                {
                                    Console.WriteLine("Please enter the rating id you want to delete: ");
                                    int ratingId = Convert.ToInt32(Console.ReadLine());
                                    ratings.DeleteRating(ratingId);
                                }
                                else if (choice1 == 5)
                                {
                                    a = false;
                                }
                                else
                                {
                                    Console.WriteLine("You have inputted an invalid value. Please try again!");
                                }
                            }
                        }
                
				        else if(choice == 4)
                        {
                            Console.WriteLine("Goodbye");
					        break;
                        }
                        else
                        {
                            Console.WriteLine("You have inputted an invalid value. Please try again!");
                        }
            
                    }
                    }
                else if(menuChoice == 2)
                {
                    Console.WriteLine("Welcome to the Recipe Finder App!!!");
                    Console.WriteLine("Please enter the cuisine you're interested in (e.g. Italian, Mexican, Chinese):");
			        string choice = Console.ReadLine();
                    Programs.Exercise1 program = new Programs.Exercise1();


                    List<Recipe> recipes = program.SearchRecipesByCuisine(choice);

                    Console.WriteLine("Here are the recipes we find for you");
			        foreach (Recipe recipe in recipes)
                    {
				        recipe.printRecipe();
                    }

                    Console.WriteLine("Thanks for using recipe finder :)");
                }
                else if(menuChoice == 3)
                {
                    Console.WriteLine("Bye!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("You have inputted an invalid value. Please try again!");
                }
            }


        }

        public List<Recipe> SearchRecipesByCuisine(string cuisine)
		{
			List<Recipe> matchingRecipes = new List<Recipe>();
			foreach (Recipe recipe in allRecipes)
			{
				if (recipe.Cuisine == cuisine)
				{
					matchingRecipes.Add(recipes);
				}
			}
			return matchingRecipes;
		}
    
    }
	
}




