namespace checkpoint7allspice.Repositories;

public class RecipesRepository
{

  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId )
    VALUES
    (@title, @instructions, @img, @category, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.Id = id;
    return recipeData;
  }

  internal List<Recipe> GetAll()
  {
    string sql = @"
      SELECT
      rec.*,
      acct.*
      FROM recipes rec
      JOIN accounts acct ON rec.creatorId = acct.id;
      ";
    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipes, prof) =>
    {
      recipes.Creator = prof;
      return recipes;
    }).ToList();
    return recipes;

  }

}


