import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import {AppState} from "../AppState.js"

class RecipesService {

  async getAllRecipes(){
    const res = await api.get('api/recipes')
    logger.log('Here are the recipes', res.data)
    const recipes = res.data.map(a => new Recipe(a))
    AppState.recipes = recipes
  }
}

export const recipesService = new RecipesService()