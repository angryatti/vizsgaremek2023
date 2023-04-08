<template>
    <div class="box">
        {{ allat.nev }}
        <div class="img">
            <img :src="`${allat.img}`" alt="">
        </div>
        <div>
            <h3>Faj:    {{ allat.breed }}</h3>
            <h3>Nem:    {{ allat.gender }}</h3>
            <h3 v-if="allat.castrated === 1">Ivartalanítva</h3>
            <h3 v-else>Nincs Ivartalanítva</h3>
            <h3>Született: </h3>
            <h3>Leírás</h3>
            <p>{{ allat.description }}</p>
        </div>

    <div id="map">    

</div></div>
</template>


<script>
import axios from 'axios';
export default{
    name: "AdvertPage",
   data(){
   return{
        allat: {}

    }
    },
    methods:{
        async fetchData(){
            const resp = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/allat/${this.$route.params.id}`)
            this.allat = await resp.data
        }
    },
    mounted(){
        this.fetchData()
    }
}
</script>