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
        <button class="nav-link fs-3">Adataim</button>
      </li>
      <li>
        <button class="nav-link fs-3">Feltöltéseim</button>
      </li>
      <li>
        <button class="nav-link fs-3">Új állat feltöltése</button>
      </li>
      
    </ul>

    
  </div>

  <div class="content" style="margin-left:30%">

 
  <!-- ><div>
    <h1 class="text-center mb-5 text-decoration-underline">Az Adataim</h1>
    <Form @submit="submitForm" >

<h2>Felhasználónév: {{ user.user_name }}</h2>
<br> 
<Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
  
  
<h2 class="mx-auto mb-3">Email: {{ user.email }}</h2>  
<br>
<Field name="email" v-model="email" class="form-control mb-3" style="justify-content: center;"/> 
  


  
<button class="btn btn-warning d-block w-100 p-3 mx-auto mt-3">Mentés</button>

</Form>
    
</div> -->


 <!-- <div>
    <h1 class="text-center text-decoration-underline">Feltöltéseim</h1>


  </div>-->
 
<div>
  <h1 class="text-center text-decoration-underline">Új állat feltöltése</h1>
  
</div>

</div>
</div>

<div>
    
</div>
     </div>


</template>




<script >

import axios from 'axios'
import {Form, Field} from 'vee-validate'
export default{
    data(){
        return{
            user_token : null,
            user : {}
        }
    },
    components:{
      Form,
      Field
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
button{
 
  
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