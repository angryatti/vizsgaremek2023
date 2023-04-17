<template>
    <div class="card" style="width: 18rem;">
        <img :src="`pet_imgs/${pet.img_userdefine}`" class="card-img-top" >
        <div class="card-body">
            <h5 class="card-title">{{pet.pet_name}}</h5>
            <p class="card-text">{{pet.breed}}<br>
                                 {{pet.gender}}</p>
            <router-link :kisallat="pet" :to="'/allat/'+pet.id" class="btn btn-primary">További információk</router-link>
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