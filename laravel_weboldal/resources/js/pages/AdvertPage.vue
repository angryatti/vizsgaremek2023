<template>
    <div>
    <div class="box">
        <section class="my-2">
            <div class="container px-4 px-lg-5 my-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6"><img class="card-img-top mb-5 mb-md-0" :src="`pet_imgs/${pet.img_userdefine}`" :alt="pet.img_userdefine" /></div>
                    <div class="col-md-6" id="contents">
                        <h1 class="display-5 fw-bolder">{{ pet.pet_name }}</h1>
                        <div class="medium mb-1">Faj: {{ pet.species }}</div>
                        <div class="medium mb-1">Fajta: {{pet.breed}}</div>
                        <div class="medium mb-1">Neme: {{pet.gender}}</div>
                     <!--   <div class="medium mb-1">Született {{pet.born}}</div>-->
                        <div>{{ currentDate()-pet.born }} éves</div>
                        <div class="medium mb-1" v-if="pet.castrated===1">Ivartalanított</div>
                        <div class="medium mb-1" v-else>Nincs Ivartalanítva</div>
                        <div class="medium mb-1"> {{state.name}} vármegye</div>
                        <div class="fs-5 mb-5">
                            <span></span>
                        </div>
                        <p class="lead">{{ pet.description }}</p>
                        
                        <div>

                            
                            <router-link v-if="logged==='true'" :kisallat="pet" :to="'/allat/'+pet.id + '/adoption'" class="btn btn-outline-dark" style="width: 75%;">örökbefogadás</router-link>
                           
                             
                            
                           
                            

                            
                        
                           
                        
                        </div>
                    </div>
                </div>
            </div>
        </section>
    <div id="map">    

</div>

</div>
</div>
</template>


<script>
import axios from 'axios';

export default{
    name: "AdvertPage",
    
   data(){
   return{
        allat: {},
        pet: {},
        user:{},
        state:{},
        logged:"",
        user_token : null,
        data : {},
    }



    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            this.logged = localStorage.getItem('logged_in')
            
        },
        
        async fetchData(){
            const resp = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/allat/${this.$route.params.id}`)
            this.allat = await resp.data
            this.pet = this.allat.pet
            this.user = this.allat.user
            this.state = this.allat.state
            
        },
        currentDate() {
      const current = new Date();
      const date = `${current.getFullYear()}`;
      return date;
    },

   
    },
    mounted(){
        this.fetchData(),
        this.getUserInfo()
    }
}
</script>

<style scoped>
    
    .box #contents{
        
        overflow: scroll;
    }
</style>