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

  internal string DeleteRecipe(int id, string userId)
  {
    Recipe recipe = this.Get(id);
    if (recipe.CreatorId != userId) throw new Exception("You can't delete a recipe you didnt create");
    bool result = _repo.Remove(id);
    if (!result) throw new Exception($"Couldnt delete recipe with id: {recipe.Id}");
    return $"Deleted {recipe.Title}";

  }

  internal Recipe EditRecipe(Recipe updateData)
  {
    Recipe original = this.Get(updateData.Id);
    original.Title = updateData.Title != null ? updateData.Title : original.Title;
    original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;
    original.Category = updateData.Category != null ? updateData.Category : original.Category;
    int rowsAffected = _repo.Update(original);
    if (rowsAffected == 0) throw new Exception($"Could not modify {updateData.Title} @ id {updateData.Id}");
    if (rowsAffected > 1) throw new Exception($"You just updated {rowsAffected} of recipes into {updateData.Title}");
    return original;


  }

  internal Recipe Get(int id)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null) throw new Exception("it's not there");
    return recipe;
  }

  internal List<Recipe> Get(string id)
  {
    List<Recipe> recipes = _repo.GetAll();
    return recipes;
  }
}
