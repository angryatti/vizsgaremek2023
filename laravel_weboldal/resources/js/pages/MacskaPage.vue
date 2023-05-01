<template>
<div class="container-fluid">
    <div class="box">
        
        <div class="container mb-3" style="background-color: #F5EDD8; border-radius: 50px;">
        <div class="row">
            <div class="col-12">   
              <Filter @filter="(v)=>values=v"/>
</div>
        </div>
     </div>     

        <div class="container containers">
            <div class="row">
                <div class="col-12 mt-3 mb-3">
        <div class="card-group">
            <div class="row row-cols-4 row-cols-md-6 mx-auto" style="gap: 20px; justify-content: center;"> 
                <advert-card v-for="pet in cats" :key="pet.id" :id="pet.id" :pet="pet"/>
            </div>
            </div>
            </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import Filter from "../components/layout/Filter.vue";
import axios from 'axios';
import AdvertCard from '../components/layout/AdvertCard.vue';
export default{
    
    components:{
        AdvertCard,
        Filter
    },
    data(){
        return{
            cats: [],
            cities: []
        }
    },
    methods:{
        async getCats(){
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/cats`)
            this.cats = response.data
        },
        async getStates(){
            const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/states`)
            this.states = response2.data
            
        }
    },
    mounted(){
        this.getCats()
        this.getStates()
    }
}
</script>
<style scoped>
.containers{
    background-color: #3E1600;
    border-radius: 50px;
}



</style>