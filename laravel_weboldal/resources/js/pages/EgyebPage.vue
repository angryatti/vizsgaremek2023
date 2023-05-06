<template>

    <div class="container-fluid">
    <div class="box">
<div class="container mb-3" style="background-color: #F5EDD8; border-radius: 50px;">
        <div class="row">
            <div class="col-12">   
              <Filter :pets="others" @filtered="filtered = $event"/>
</div>
        </div>
</div>



<div class="container containers">
            <div class="row">
                <div class="col-12 mt-3 mb-3">
                    <div class="card-group">
            <div class="row d-flex mx-auto text-center" style="gap: 20px; justify-content: center;"> 
                <advert-card v-show="filtered.length===0" v-for="pet in others" :key="pet.id" :id="pet.id" :pet="pet"/>
                <advert-card v-show="filtered.length>0" v-for="pet in filtered" :key="pet.id" :id="pet.id" :pet="pet"/>

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
    name: 'EgyebPage',
    components:{
        AdvertCard,
        Filter,
    },
    data(){
        return{
            others: [],
            filtered:[]

        }
    },
    methods:{
        async getOthers(){
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/others`)
            this.others = response.data
        },

    },
    mounted(){
        this.getOthers()
    }
}
</script>

<style scoped>

</style>