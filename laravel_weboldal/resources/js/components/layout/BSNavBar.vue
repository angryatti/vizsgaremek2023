<template>
  <nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #3E1600; font-size: 32px; text-transform: uppercase;">
    <div class="container-fluid">
      <a class="navbar-brand" href="#" style="font-size: 32px; margin-left: 5px; margin-right: 5px;"><img class="rounded float-left" src="pet_imgs/navbar.png" alt="Navbar" style="height: 120px; width: 144px; margin-bottom: 0px;"></a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto  mb-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-for="link in routes.slice(2, 5)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link>
        </li>
      </ul>
      <ul class="navbar-nav me-2  mb-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;"  v-for="link in routes.slice(5, 7)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link></li>
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-if="logged===false"  v-for="link in routes.slice(7,9)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link></li>
          <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-else-if="logged===true" v-for="links in routes.slice(9)" :key="links.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: links.name}">{{links.meta.title}}</router-link></li>
      </ul>
  </div>
        
      </div>
    
  </nav>
</template>

<script setup>
import {useRouter, RouterLink} from "vue-router";
var logged_in = localStorage.getItem('logged_in')
var logged = false
if (logged_in === null){
  logged = false
}else{
  logged = true
}
const routes = useRouter().getRoutes(); 
</script>