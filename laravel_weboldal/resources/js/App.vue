<template>
  <nav-bar />
  <router-view />
  <v-footer />
</template>

<script setup>
import { RouterView } from 'vue-router';
import NavBar from '@/components/layout/BSNavBar.vue';
import VFooter from '@/components/layout/BSFooter.vue';
</script>