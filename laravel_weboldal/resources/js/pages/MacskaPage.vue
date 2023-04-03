<template>

    
    <div class="box">
        <h1>Macska!</h1>
        <div class="card-group">
            <div class="row row-cols-3 row-cols-md-3"> 
                <advert-card v-for="pet in pets" :key="pet.id" :id="pet.id" :pet="pet"/>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    name: 'MacskaPage',
    components:{},
    data(){
        return{
            pets: []
        }
    },
    methods:{
        async getCats(){
            const response = await axios.get('http://localhost:8881/api/cats')
            this.pets = response.data
        }
    },
    mounted(){
        this.getCats()
    }
}
</script>