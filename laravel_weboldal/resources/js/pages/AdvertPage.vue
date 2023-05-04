<template>
    <div class="box">
        <section class="py-5">
            <div class="container px-4 px-lg-5 my-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6"><img class="card-img-top mb-5 mb-md-0" :src="`pet_imgs/${pet.img_userdefine}`" :alt="pet.img_userdefine" /></div>
                    <div class="col-md-6">
                        <h1 class="display-5 fw-bolder">{{ pet.pet_name }}</h1>
                        <div class="medium mb-1">Faj: {{ pet.species }}</div>
                        <div class="medium mb-1">Fajta (ide petbreed)</div>
                     <!--   <div class="medium mb-1">Született {{pet.born}}</div>-->
                        <div>{{ currentDate()-pet.born }} éves</div>
                        <div class="medium mb-1" v-if="pet.castrated===1">Ivartalanított</div>
                        <div class="medium mb-1" v-else>Nincs Ivartalanítva</div>
                        <div class="fs-5 mb-5">
                            <span></span>
                        </div>
                        <p class="lead">{{ pet.description }}</p>
                        <h3>Kapcsolat:</h3>
                        <h5>Feladó nevei: {{ user.full_name }}</h5>
                        <p class="lead">{{ user.email }}</p>
                        <p class="lead">{{ user.phone_number }}</p>
                        <p class="lead">{{ allat.contact_info }}</p>
                        <p class="lead">Feladva: {{ state.name }} megyében</p>
                        <div class="d-flex">



                             <div v-if="logged===false">
                                <p>be kell jelentkezni az örökbefogadáshoz!</p>
                            </div>
                            <div v-else>
                                <router-link 
                                to="/allat/:id/adoption"
                                custom
                                v-slot="{ navigate }"
                                
                                >
                                <button class="btn btn-outline-dark flex-shrink-0" type="button"
                                    @click="navigate"
                                    role="link"
                                >
                                    Jelentkezés Örökbefogadásra
                                </button>
                                </router-link>
                            </div>

                           
                            <!-- logged ertek ellenorzese. Nem mukodik! neha ezt adja , neha azt ugy hogy bejelentkezve maradok -->
                            <h1 v-if="logged===false">asd</h1>
                            <h1 v-else>fgh</h1>

                            
                        
                           
                        
                        </div>
                    </div>
                </div>
            </div>
        </section>
    <div id="map">    

</div></div>
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
        
        user_token : null,
        data : {},
    }



    },
    methods:{
        async userdata(){
            var logged_in = localStorage.getItem('logged_in')
            var logged = false
            if (logged_in === null){
             logged = false

            }
            else{
                logged = true
                const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
              this.user = response.data

            }
            console.log(logged_in)
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
        this.userdata()
    }
}
</script>