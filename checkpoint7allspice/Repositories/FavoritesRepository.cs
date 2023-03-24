namespace checkpoint7allspice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites
    (recipeId, accountId)
    VALUES
    (@recipeId, @accountId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = id;
    return favoriteData;
  }

  internal List<FavoritedRecipe> GetMyFavoritedRecipes(string accountId)
  {
    string sql = @"
    SELECT
    rec.*,
    fav.*,
    creator.*
    FROM favorites fav
    JOIN recipes rec ON fav.recipeId = rec.id
    JOIN accounts creator ON rec.creatorId = creator.id
    WHERE fav.accountId = @accountId;
    ";
    List<FavoritedRecipe> favoritedRecipes = _db.Query<FavoritedRecipe, Favorite, Profile, FavoritedRecipe>(sql, (favoritedRecipe, favorite, profile) =>
    {
      favoritedRecipe.FavoriteId = favorite.Id;
      favoritedRecipe.Creator = profile;
      return favoritedRecipe;
    }, new { accountId }).ToList();
    return favoritedRecipes;
  }

  internal Favorite GetOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM favorites
    WHERE id = @id;
    ";
    Favorite favorite = _db.Query<Favorite>(sql, new { id }).FirstOrDefault();
    return favorite;
  }

  internal void RemoveFavorite(int id)
  {
    string sql = @"
    DELETE FROM favorites
    WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }
}
