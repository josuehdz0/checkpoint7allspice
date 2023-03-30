<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-10 foodcover ">
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-md-6 d-flex flex-column justify-content-center fixed-bottom sticky-md-top py-3 overflow">

        <div class="btn-group btn-group-lg shadow-md-lg shadow-lg " role="group" aria-label="Large button group">
          <button @click="getAll" type="button" class="btn btn-light">Home</button>
          <button @click="getMyRecipes" type="button" class="btn btn-light">My Recipes</button>
          <button @click="filterFavorites" type="button" class="btn btn-light">Favorites</button>
        </div>

      </div>
    </div>

    <div class="row justify-content-evenly otheroverflow">
      <div @click="Modal" v-for="r in recipes" :key="r.id"
        class="col-5 col-md-4 p-0 mt-2 mt-md-4  d-flex justify-content-center cardsize">
        <!-- NOTE RECIPE CARD HERE! -->
        <RecipeCard :recipe="r" />
      </div>


    </div>
  </div>

  <!-- <Modal id="exampleModal" modal-title="Recipe">

  </Modal> -->
</template>

<script>
import { ref, onMounted, computed } from "vue";
// import { Modal } from "../components/Modal.vue";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    // const filterType = ref('')
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        Pop.error(error, "Getting all Recipes");
      }
    }
    onMounted(() => {
      getAllRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),

      async filterFavorites() {
        try {
          await recipesService.getFavorites();
        } catch (error) {
          Pop.error(error, "Getting Favorite Recipes")
        }
      },

      async getAll() {
        try {
          await recipesService.getAllRecipes();
        }
        catch (error) {
          Pop.error(error, "Getting all Recipes");
        }
      },
      async getMyRecipes() {
        try {
          await recipesService.getMyRecipes();
        }
        catch (error) {
          Pop.error(error, "Getting all Recipes");
        }
      }

    };
  },
  components: { RecipeCard }
}


</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

.foodcover {
  background-image: url(foodcover1.png);
  height: 30vh;
  // width: 100%;
  background-size: cover;
  background-position: center;
}

.overflow {
  translate: 0% 0%;
}

.otheroverflow {
  translate: 0% 0%;
}

.coverimage {
  height: 30vh;
  width: 100%;
  object-fit: cover;
  top: vh;
}

.cardsize {
  height: 25vh;
  width: 25vh;
}

@media screen and (min-width: 789px) {
  .overflow {
    translate: 0% -50%;
  }

  .otheroverflow {
    translate: 0% -1%;
  }

  .cardsize {
    height: 35vh;
    width: 35vh;
  }
}
</style>
