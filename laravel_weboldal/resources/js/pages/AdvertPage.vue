<template>
    <div class="box">
        <h1>Egy adott hirdetés</h1>
        {{$route.params.id}}
        {{allat}}

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