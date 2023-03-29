<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-10 foodcover ">
      </div>
    </div>
    <div class="row justify-content-center ">
      <div class="col-md-6 d-flex justify-content-center fixed-bottom sticky-md-top py-3 overflow">

        <div class="btn-group btn-group-lg shadow-md-lg shadow" role="group" aria-label="Large button group">
          <button type="button" class="btn btn-light">Home</button>
          <button type="button" class="btn btn-light">My Recipes</button>
          <button type="button" class="btn btn-light">Favorites</button>
        </div>

      </div>
    </div>

    <div class="row justify-content-center">
      <div class="col-5 col-md-4">
        <div class="row justify-content-between">
          <div class="col-4 text-center">Type</div>
          <div class="col-4 text-center">Like</div>
        </div>
        <div class="row"> Name</div>
        <div class="row"> Descriptions</div>
      </div>
      <div class="col-5 col-md-4"> box 2</div>
      <!-- <div class="col-5 col-md-4"> box 3</div>
      <div class="col-5 col-md-4"> box 4</div> -->

    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {}
  }
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

.coverimage {
  height: 30vh;
  width: 100%;
  object-fit: cover;
  top: vh;
}

@media screen and (min-width: 768px) {
  .overflow {
    translate: 0% -50%;
  }
}
</style>
