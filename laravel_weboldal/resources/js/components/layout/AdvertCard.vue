<template>
    <div class="card" style="width: 18rem;">
        <img class="card-img-top" src="" alt="kép később">
        <div class="card-body">
            <h5 class="card-title">{{pet.pet_name}}</h5>
            <p class="card-text">{{pet.breed}}<br>
                                 {{pet.gender}}</p>
            <div @onclick="gotoDetails()" class="btn btn-primary">További információk</div>
        </div>
    </div>
</template>

<script>
export default{
  name: "AdvertCard",
  props:{
    pet: Object,
  },
  methods:{
    gotoDetails(){
      this.$router.push({path:"/allatok/:id"})
    }
  }
}
</script>