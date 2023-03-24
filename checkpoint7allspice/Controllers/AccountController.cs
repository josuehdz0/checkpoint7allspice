namespace checkpoint7allspice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _accountService = accountService;
    _favoritesService = favoritesService;
    _auth = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  [Authorize]

  public async Task<ActionResult<List<FavoritedRecipe>>> GetMyFavoritedRecipes()
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      List<FavoritedRecipe> favoritedRecipes = _favoritesService.GetMyFavoritedRecipes(userInfo.Id);
      return Ok(favoritedRecipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
