<template>
    <div class="box">
        <h1>Kutya!</h1>
        <div class="card-group">
            <div class="row row-cols-3 row-cols-md-3"> 
                <advert-card v-for="pet in dogs" :key="pet.id" :id="pet.id" :pet="pet"/>
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
            const response = await axios.get('http://localhost:8881/api/dogs')
            this.dogs = response.data
        }
    },
    mounted(){
        this.getDogs()
    }
}
</script>