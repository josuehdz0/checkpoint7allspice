namespace checkpoint7allspice.Services
{
  public class FavoritesService
  {

    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
      Favorite favorite = _repo.CreateFavorite(favoriteData);
      return favorite;
    }

    internal List<FavoritedRecipe> GetMyFavoritedRecipes(string accountId)
    {
      List<FavoritedRecipe> favoritedRecipes = _repo.GetMyFavoritedRecipes(accountId);
      return favoritedRecipes;
    }

    internal string removeFavorite(int id, string userId)
    {
      Favorite favorite = _repo.GetOne(id);
      if (favorite == null) throw new Exception($"Not a Favorite at id {id}");
      if (favorite.AccountId != userId) throw new UnauthorizedAccessException(" you cant do that. Its not your favorite recipe to change. goofy.");
      _repo.RemoveFavorite(id);
      return $"This recipe is no longer favorited";
    }
  }
}