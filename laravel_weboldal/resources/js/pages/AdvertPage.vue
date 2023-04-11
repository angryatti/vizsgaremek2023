<template>
    <div class="box">
        <section class="py-5">
            <div class="container px-4 px-lg-5 my-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6"><img class="card-img-top mb-5 mb-md-0" src="https://dummyimage.com/600x700/dee2e6/6c757d.jpg" alt="..." /></div>
                    <div class="col-md-6">
                        <h1 class="display-5 fw-bolder">{{ allat.pet_name }}</h1>
                        <div class="medium mb-1">{{ allat.pet_name }}</div>
                        <div class="medium mb-1">Faj: {{ allat.breed }}</div>
                        <div class="medium mb-1">Fajta (ide petbreed)</div>
                        <div class="medium mb-1">Született (ide születés)</div>
                        <div class="medium mb-1" v-if="allat.castrated===1">Ivartalanított</div>
                        <div class="medium mb-1" v-else>Nincs Ivartalanítva</div>
                        <div class="fs-5 mb-5">
                            <span></span>
                        </div>
                        <p class="lead">{{ allat.description }}</p>
                        <div class="d-flex">
                            <button class="btn btn-outline-dark flex-shrink-0" type="button">
                                <i class="bi-cart-fill me-1"></i>
                                Jelentkezés Örökbefogadásra
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
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