namespace checkpoint7allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
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



  }
}