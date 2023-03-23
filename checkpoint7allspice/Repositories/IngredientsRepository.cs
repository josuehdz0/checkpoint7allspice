namespace checkpoint7allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUES
      (@name, @quantity, @recipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal List<Ingredient> FindByRecipe(int recipeId)
    {
      string sql = @"
      SELECT
      ing.*,
      rec.*
      FROM ingredients ing
      JOIN recipes rec ON  ing.recipeId = rec.id
      WHERE ing.recipeId = @recipeId;
      ";
      List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ing, rec) =>
      {
        ing.RecipeId = rec.Id;
        return ing;
      }, new { recipeId }).ToList();
      return ingredients;
    }

    internal Ingredient GetOne(int id)
    {
      string sql = @"
      SELECT
      *
      FROM ingredients
      WHERE id = @id
      ";
      Ingredient ingredient = _db.Query<Ingredient>(sql, new { id }).FirstOrDefault();
      return ingredient;
    }

    internal bool Remove(int id)
    {
      string sql = @"
      DELETE FROM ingredients WHERE id =@id
      ";
      int rows = _db.Execute(sql, new { id });
      return rows == 1;
    }


    // internal List<Ingredient> FindAll()
    // {
    //   string sql = @"
    //   SELECT
    //   ing.*,
    //   rec.*
    //   FROM ingredients ing
    //   JOIN recipes rec ON  ing.recipeId = rec.id
    //   ";
    //   List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ing, rec)=>
    //   {
    //     ing.
    //   })
    // }
  }
}