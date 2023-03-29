export class Recipe {

  constructor(data){
    this.id = data.id
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.favoriteId = data.favoriteId
  }

}
export class FavoriteRecipe extends Recipe {
  constructor(data){
    super(data.recipe)
      this.favoriteId = data.favoriteId
  
  }

}