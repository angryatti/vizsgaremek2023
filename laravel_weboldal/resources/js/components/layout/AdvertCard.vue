<template>
    <div class="card" style="width: 18rem;">
      <div class="container">
        <img :src="`pet_imgs/${pet.pet.img_userdefine}`" class="card-img-top" >
      </div>
        <div class="card-body">
            <h5 class="card-title">{{pet.pet.pet_name}}</h5>
            <p class="card-text">{{pet.pet.species}}<br>
                                 {{pet.pet.gender}}</p>
            <router-link :kisallat="pet" :to="'/allat/'+pet.id" class="btn btn-outline-primary">További információk</router-link>
        </div>
    </div>
</template>

<script>
import { RouterLink } from 'vue-router';
export default{ 
  name: "AdvertCard",
  props:{
    pet: Object,
  },
  components:{
    RouterLink
  }
}
</script>

<style scoped>
  .card-img-top{
    aspect-ratio: 1/1;
  }
</style>

