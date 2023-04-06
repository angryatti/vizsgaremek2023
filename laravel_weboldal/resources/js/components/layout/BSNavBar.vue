<template>
  <nav class="navbar navbar-expand-lg fixed top navbar-dark" style="background-color: #3E1600; font-size: 32px; text-transform: uppercase;">
    <div class="container-fluid">
      
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-for="link in routes.slice(1, 5)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link>
        </li>
      </ul>
      <ul class="navbar-nav me-2 mb-2 mb-lg-0">
        <li class="nav-item hovering" style="margin-left: 24px; margin-right: 24px;" v-for="link in routes.slice(5, 9)" :key="link.name">
          <router-link class="nav-link active" aria-current="page" :to="{name: link.name}">{{link.meta.title}}</router-link>
        </li>
      </ul>
  </div>
        
      </div>
    
  </nav>
</template>

<script setup>
import {useRouter, RouterLink} from "vue-router";

const routes = useRouter().getRoutes(); 
</script>