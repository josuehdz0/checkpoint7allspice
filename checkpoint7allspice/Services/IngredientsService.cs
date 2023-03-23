namespace checkpoint7allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
    {
      _repo = repo;
      _recipesService = recipesService;
    }



    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      Ingredient ingredient = _repo.CreateIngredient(ingredientData);
      return ingredient;
    }

    internal List<Ingredient> FindByRecipe(int recipeId)
    {
      List<Ingredient> ingredients = _repo.FindByRecipe(recipeId);
      return ingredients;
    }

    internal string DeleteIngredient(int id, string userId)
    {
      Ingredient ingredient = this.Get(id);
      Recipe recipe = _recipesService.Get(ingredient.RecipeId);
      if (userId != recipe.CreatorId) throw new Exception("You cant delete this ingredient. ITS NOT YOUR RECIPE");
      bool result = _repo.Remove(id);
      if (!result) throw new Exception($"Couldnt delete ingredient with id: {ingredient.Id}");
      return $"DELETED {ingredient.Name}";

    }


    internal Ingredient Get(int id)
    {
      Ingredient ingredient = _repo.GetOne(id);
      if (ingredient == null) throw new Exception("it's not there");
      return ingredient;
    }



  }
}