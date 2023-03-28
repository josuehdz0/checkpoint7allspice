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
