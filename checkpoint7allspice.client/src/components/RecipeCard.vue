<template>
  <div class=" cardstuff d-flex flex-column justify-content-between img-fluid rounded"
    :style="{ backgroundImage: `url(${recipe.img})` }">


    <div class="row justify-content-between mx-1 mt-1">
      <div class="col-4 text-center">
        {{ recipe.category }}
      </div>
      <div class="col-4 text-center">Like</div>
    </div>

    <div class="row mx-1 mb-1">

      <div class="col-12 titlecard rounded">
        <b>
          {{ recipe.title }}
        </b>
      </div>
      <!-- <div class="col-12 ">
        {{ recipe.description }}
      </div> -->

    </div>

  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: { type: Recipe, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.cardsize {
  height: 45vh;
  width: 45vh;
  background-size: cover;
  background-position: center;
  color: aliceblue;
}

.cardstuff {
  width: 100%;
  background-size: cover;
  background-position: center;
  color: aliceblue;
}



.titlecard {
  background-color: rgba(181, 181, 181, 0.372);
  backdrop-filter: blur(2.4px);
}


@media screen and (min-width: 768px) {
  .cardsize {
    height: 25vh;
    width: 25vh;
    background-size: cover;
    background-position: center;
    color: aliceblue;
  }
}
</style>