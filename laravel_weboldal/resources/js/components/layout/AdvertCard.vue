<template>
    <div class="card" style="width: 18rem;">
        <img class="card-img-top" src="" alt="kép később">
        <div class="card-body">
            <h5 class="card-title">{{pet.pet_name}}</h5>
            <p class="card-text">{{pet.breed}}<br>
                                 {{pet.gender}}</p>
            <a href="#" class="btn btn-primary">További információk</a>
        </div>
    </div>
</template>

<script>
export default{
  name: "AdvertCard",
  props:{
    pet: Object
  }
}
</script>