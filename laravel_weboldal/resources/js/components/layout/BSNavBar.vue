<template>
  
  <nav class="navbar navbar-expand-xxl navbar-dark text-md-center text-sm-center text-xs-center" style="background-color: #3E1600; font-size: 26px; text-transform: uppercase;">
    <div class="container-fluid">
      <a class="navbar-brand" href="#" style="font-size: 32px; margin-left: 5px; margin-right: 5px;"><img class="rounded float-left" src="pet_imgs/navbar.png" alt="Navbar" style="height: 120px; width: 144px; margin-bottom: 0px;"></a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse " id="navbarSupportedContent">
      <ul class="navbar-nav me-auto  mb-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-for="link in routes.slice(4, 7)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link>
        </li>
      </ul>
      <ul class="navbar-nav d-flex me-2  mb-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;"  v-for="link in routes.slice(7, 9)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link></li>
        <li class="nav-item" style="margin-left: 24px; margin-right: 24px; border-radius: 0.375rem; background-color:#198754;" v-show="logged===false"  v-for="link in routes.slice(9,11)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link></li>
          <li class="nav-item  hovering" style="margin-left: 24px; margin-right: 24px; border-radius: 0.375rem; background-color: #0d6efd; " v-show="logged===true">
          <router-link class="nav-link active" aria-current="page" :to="{ name: 'profil'}">Profilom</router-link></li>
           <li class="nav-link active mx-4" v-show="logged===true" @click="logout" style="border-radius: 0.375rem; background-color: #dc3545; color: #fff">Kijelentkezés</li>
      </ul>
  </div>
        
      </div>
    
  </nav>
  
</template>

<script setup>
import {useRouter, RouterLink} from "vue-router";
import { router } from '../../router';
import { defineAsyncComponent } from 'vue';
var logged_in = localStorage.getItem('logged_in')
var logged = false
if (logged_in === null){
  logged = false
}else{
  logged = true
}
const routes = useRouter().getRoutes(); 
const user_id = localStorage.getItem('user_id')
const logout = () => {
  localStorage.clear();
  location.replace(`#/belepes`);
  router.go(0);
}

</script>

<style scoped>
 li:hover{
  border-radius: 50px;
    transform: scale(1.1);
 }


</style>