<template>
    <div class="box">
        <h1>Kutya!</h1>
       
        <div class="container containers">
            <div class="row">
                <div class="col-12 mt-3 mb-3">
                    <div class="card-group">
            <div class="row row-cols-4 row-cols-md-6 mx-auto" style="gap: 20px; justify-content: center;"> 
                <advert-card v-for="pet in dogs" :key="pet.id" :id="pet.id" :pet="pet"/>
            </div>
        </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import AdvertCard from '../components/layout/AdvertCard.vue';


export default{

    


    name: 'KutyaPage',
    components:{
        AdvertCard,
    },
    data(){
        return{
            dogs: []
        }
    },
    methods:{
        async getDogs(){
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/dogs`)
            this.dogs = response.data
        },
    },
    mounted(){
        this.getDogs()
    }
}
</script>
<style scoped>
.containers{
    background-color: #3E1600;
    border-radius: 50px;
}

    

</style>