<template>
    <div class="box">
        <h1>Macska!</h1>
        <div class="card-group">
            <div class="row row-cols-3 row-cols-md-3"> 
                <advert-card v-for="pet in cats" :key="pet.id" :id="pet.id" :pet="pet"/>
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