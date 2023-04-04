import {createRouter, createWebHashHistory} from 'vue-router';

const routes = [
  {
    path: '/',
    name: 'index',
    component: () => import('@/pages/IndexPage.vue'),
    meta: {
      title: "Főoldal",
      requiesAuth: false
    }
  },
  {
    path: '/kutya',
    name: 'kutya',
    component: () => import('@/pages/KutyaPage.vue'),
    meta: {
      title: "Kutyák",
      requiesAuth: false
    }
  },
  {
    path: '/macska',
    name: 'macska',
    component: () => import('@/pages/MacskaPage.vue'),
    meta: {
      title: "Macskák",
      requiesAuth: false
    }
  },
  {
    path: '/egyeb',
    name: 'egyeb',
    component: () => import('@/pages/EgyebPage.vue'),
    meta: {
      title: "Egyebek",
      requiesAuth: false
    }
  },
  {
    path: '/info',
    name: 'info',
    component: () => import('@/pages/InfoPage.vue'),
    meta: {
      title: "Infó",
      requiesAuth: false
    }
  },
  {
    path: '/kapcsolat',
    name: 'kapcsolat',
    component: () => import('@/pages/KapcsolatPage.vue'),
    meta: {
      title: "Kapcsolat",
      requiesAuth: false
    }
  },
  {
    path: '/belepes',
    name: 'belepes',
    component: () => import('@/pages/BelepesPage.vue'),
    meta: {
      title: "Belépés",
      requiesAuth: false
    }
  },
  {
    path: '/regisztracio',
    name: 'regisztracio',
    component: () => import('@/pages/RegisztracioPage.vue'),
    meta: {
      title: "Regisztráció",
      requiesAuth: false
    }
  },
  {
    path: '/allat/:id',
    name: 'kisallat',
    component: () => import('@/pages/AdvertPage.vue'),
    meta: {
      title: "Egy adott kisállat",
      requiesAuth: false
    }
  },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes
});