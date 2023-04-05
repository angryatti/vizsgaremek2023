<template>
    <div class="box">
        <h1>Macska!</h1>

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
</template>

<script>
import axios from 'axios';
import AdvertCard from '../components/layout/AdvertCard.vue';
export default{
    name: 'MacskaPage',
    components:{
        AdvertCard,
    },
    data(){
        return{
            cats: []
        }
    },
    methods:{
        async getCats(){
            const response = await axios.get('http://localhost:8881/api/cats')
            this.cats = response.data
        }
    },
    mounted(){
        this.getCats()
    }
}
</script>
<style scoped>
.containers{
    background-color: #3E1600;
    border-radius: 50px;
}
</style>