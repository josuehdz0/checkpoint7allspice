namespace checkpoint7allspice.Services;

public class RecipesService
{

  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repo.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> Get(string id)
  {
    List<Recipe> recipes = _repo.GetAll();
    return recipes;
  }
}
