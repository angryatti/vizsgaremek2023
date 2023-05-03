<template>
        <h1 class="text-center text-decoration-underline">Feltöltéseim</h1>

        <div class="container">
            <div class="row">
                <div class="col-12 mt-3 mb-3">
                    <div class="card-group">
            <div class="row d-flex mx-auto text-center" style="gap: 20px; justify-content: center;"> 
                <advert-card v-for="pet in pets" :key="pet.id" :id="pet.id" :pet="pet"/>
            </div>
        </div>
                </div>
            </div>
    </div>
</template>


<script>
import AdvertCard from './AdvertCard.vue'
export default{
    name: "ProfilePets",
    components:{
        AdvertCard
    },
    data(){
        return{
            pets: {}
        }
    },
    methods:{
        async getPets(){
            const user_id = localStorage.getItem('user_id')
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user/${user_id}`)
            this.pets = response.data
            console.log(this.pets)
        }
    },
    mounted(){
        this.getPets()
    }
}

</script>