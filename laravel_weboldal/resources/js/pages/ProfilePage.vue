<template>

     <div class="box">
            <h1 v-if="logged===null">Jelentlezz be!!</h1>

            <div v-else>
                
                <div class=" sidebar d-flex flex-column flex-shrink-0 " style="width: 25%; ;
    color: white; ">
    
      
      <span class="fs-2 text-center">Profilom</span>
    
    <hr>
    <ul class="nav  flex-column mb-auto">
      <li class="nav-item">
        <a href="#" class="nav-link fs-3" aria-current="page">
          
          Adataim
        </a>
      </li>
      <li>
        <a href="#" class="nav-link fs-3">
          
          Feltöltéseim
        </a>
      </li>
      <li>
        <a href="#" class="nav-link fs-3">
          
          Új állat feltöltése
        </a>
      </li>
      
    </ul>

    
  </div>

  <div class="content" style="margin-left:30%">

<div >
  <h1>Az Adataim</h1>
</div>



<div>
<h2>Adatok</h2>
<h3>Az adataimról később</h3>
<h3>most még nem tartunk ott</h3>
</div>

</div>
</div>

<div>
    
</div>
     </div>


</template>


<script>
import axios from 'axios'
export default{
    data(){
        return{
            user_token : null,
            user : {}
        }
    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const logged = localStorage.getItem('logged_in')
            console.log(logged)
            if(logged===null){
                alert('Hahó, te itt nem lehetsz, először jelentkezz be!!!!!!!!!!!!')
            }else{
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
            this.user = response.data}
        },
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
.nav-link:hover{
   color:#3E1600; 
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
    height: 50%; 
    padding: 10px;
    border-color: black;
    border-style: solid;
    border-radius: 50px;
    color: #3E1600;
}
</style>