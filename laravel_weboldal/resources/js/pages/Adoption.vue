<template>
    <div>
    <div class="box">

        <div class="container text-center">
            <h1 class="mb-4">Kapcsolat:</h1>
            
                        <h3>Feladó neve: <p > {{ user.full_name }}</p></h3>
                        <h3>Email cím: <p > {{ user.email }}</p></h3>
                        <h3>Telefonszám: <p > {{ user.phone_number }}</p></h3>
                        <h3>Kontakt infó: <p > {{ allat.contact_info }}</p></h3>
                        
                        
        </div>
                        
    </div>
    </div>
</template>
<script>
import axios from 'axios'
export default{
    name: "AdvertPage",
    
   data(){
   return{
        allat: {},
        pet: {},
        user:{},
        state:{},
        user_token : null,
            user2 : {},
    }



    },
    methods:{
        
        
        async fetchData(){
            const resp = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/allat/${this.$route.params.id}`)
            this.allat = await resp.data
            this.pet = this.allat.pet
            this.user = this.allat.user
            this.state = this.allat.state
            console.log(this.allat)
            
        },
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const logged = localStorage.getItem('logged_in')
            console.log(logged)
            if(logged===null){
                alert('Először jelentkezz be!!!')
                location.replace(`#/belepes`);
            }
            else{
              const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
              this.user2 = response.data
            } 
        }
       

   
    },
    mounted(){
        this.fetchData(),
        this.getUserInfo()
    }
}
</script>

<style scoped>
.container{
    height: 100%;
    background-color: #3E1600;
    color: #F5EDD8;
}
h3{
    margin-bottom: 3rem;
}
</style>