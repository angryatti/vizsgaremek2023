<template>

     <div class="box">
            <h1 v-if="logged===null">Jelentlezz be!!</h1>
            <div v-else>  
                <div class=" sidebar d-flex flex-column flex-shrink-0 " style="width: 25%; color: white; ">
                  <pside-bar @load-section="loadSection"/>
                </div>
  <div class="content" style="margin-left:30%">
      <component :is="currentSection"></component>
  
</div>
</div>
</div>
</template>


<script >

import axios from 'axios'
import ProfileData from '../components/layout/ProfileData.vue'
import PsideBar from '../components/layout/PSideBar.vue'
import ProfileNewPet from '../components/layout/ProfileNewPet.vue'
import ProfilePets from '../components/layout/ProfilePets.vue'
export default{
    data(){
        return{
            user_token : null,
            user : {},
            currentSection: 'profile-data'
        }
    },
    components:{
      ProfileData,
      PsideBar,
      ProfileNewPet,
      ProfilePets
    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const logged = localStorage.getItem('logged_in')
            console.log(logged)
            if(logged===null){
                alert('Hahó, te itt nem lehetsz, először jelentkezz be!!!!!!!!!!!!')
            }
            else{
              const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
              this.user = response.data
              console.log(this.user)
            } 
        },
        loadSection(section){
          if(section==='profile-data'){
            this.currentSection = {
              component: ProfileData,
              props:{
                user: this.user
              }
            }
          }else{
            this.currentSection = section
          }
        }
    },
    mounted(){
        this.getUserInfo()
    }
}
</script>



<style scoped>

a{
    color: white;
}


li:hover{
    background-color: #F5EDD8;
    border-radius: 10px;
    transform: scale(1.1);
    
}
.nav-link{
  color: white;
  border: none;
  background-color: transparent;
}
.nav-link:hover{
   color:#3E1600; 
}
.nav-link:focus{
  color:white; 
}
span{
    text-decoration: underline;
}

.sidebar {
    position: absolute;
    padding: 20px;
    height: 50%;
    border-radius: 50px;
    background-color: #3E1600;
}
.content {
    position: absolute;
    background-color: #F5EDD8;
    width: 60%;
    height: 75%; 
    padding: 10px;
    border-color: black;
    border-style: solid;
    border-radius: 50px;
    color: #3E1600;
}

.form-control{
  
  margin-right: 10px;
}
</style>