import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {

  async getAllRecipes(){
    const res = await api.get('api/recipes')
    logger.log('Here are the recipes', res.data)
  }
}

export const recipesService = new RecipesService()