<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-10 foodcover ">
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-md-6 d-flex justify-content-center fixed-bottom sticky-md-top py-3 overflow">

        <div class="btn-group btn-group-lg shadow-md-lg shadow" role="group" aria-label="Large button group">
          <button type="button" class="btn btn-light">Home</button>
          <button type="button" class="btn btn-light">My Recipes</button>
          <button type="button" class="btn btn-light">Favorites</button>
        </div>

      </div>
    </div>

    <div class="row justify-content-evenly otheroverflow">
      <div v-for="r in recipes" :key="r.id" class="col-5 col-md-4 p-0 mt-2  d-flex justify-content-center cardsize">
        <RecipeCard :recipe="r" />
        <!-- <div class="row justify-content-between">
          <div class="col-4 text-center">Type</div>
          <div class="col-4 text-center">Like</div>
        </div>
        <div class="row"> Name</div>
        <div class="row"> Descriptions</div> -->
      </div>
      <div class="col-5 col-md-4"> box 2</div>
      <!-- <div class="col-5 col-md-4"> box 3</div>
      <div class="col-5 col-md-4"> box 4</div> -->

    </div>
  </div>
</template>

<script>
import { ref, onMounted, computed } from "vue";
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
      recipes: computed(() => AppState.recipes)
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
