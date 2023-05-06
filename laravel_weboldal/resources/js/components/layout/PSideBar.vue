<template>
  
    <div class="d-flex flex-column w-100">
        <ul class="nav d-block mb-auto">
            <li class="nav-item">
                <button class="nav-link fs-3" @click="loadSection('profile-data')">Adataim</button></li>
            <li class="nav-item text-center ">
                <button class="nav-link fs-3" @click="loadSection('profile-pets')">Feltöltéseim</button></li>
            <li class="nav-item text-center ">
                <button class="nav-link fs-3" @click="loadSection('profile-new-pet')">Új feltöltés</button></li>
        </ul>
    </div>
</template>
  
<script>
  export default {
    name: "PSideBar",
    methods: {
      loadSection(section) {
        this.$emit('load-section', section)
      }
    }
  }
</script>
  
<style>
li:hover{
    background-color: #F5EDD8;
    width: 100%;
    
    border-radius: 50px;
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
    
    padding: 20px;
    min-width: fit-content;
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

</style>