import {createApp} from 'vue';
import {createPinia} from 'pinia';
import {router} from '@/router/index.js'
import BSAlert from '@/components/layout/BSAlert.vue'
import App from '@/App.vue';

var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
  return new bootstrap.Tooltip(tooltipTriggerEl)
})

const app = createApp(App);
app.use(createPinia());
app.use(router);
app.component('ErrorComponent', BSAlert);

app.mount("#app");