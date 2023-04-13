<template>

    
    <div class="box">
<div class="container mb-3" style="background-color: #F5EDD8; border-radius: 50px;">
        <div class="row">
            <div class="col-12">   
        <table class="table m-0 mx-auto text-center">
  <thead>
    <tr>
      
      <th class="fs-3" scope="col" style="text-decoration: underline;">Ivar</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;">Termet</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;">Kor</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;">Helyszín</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;"></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      
      <td>
        </td>

      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    kicsi
  </label>
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
</div></td>
      <td></td>
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Hím
  </label>
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
</div></td>
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Közepes
  </label>
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
</div></td>
      <td>
<input type="range" class="form-range" min="0" max="10" step="1" id="customRange3">
</td>
<td><div class="dropdown">
  <button class="btn bg-white dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Megye
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Action</a>
    <a class="dropdown-item" href="#">Another action</a>
    <a class="dropdown-item" href="#">Something else here</a>
  </div>
</div></td>
<td><button class="submit btn btn-primary" style="background-color: #B85B2F; font-weight: bold;">szűrés</button></td>
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Nőstény
  </label>
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
</div></td>
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Nagy
  </label>
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
</div></td>
      <td><div class="d-flex justify-content-between"><span>0</span><span>10+</span> </div></td>
    </tr>
  </tbody>
</table>
</div>
        </div>
</div>


<div class="container containers">
            <div class="row">
                <div class="col-12 mt-3 mb-3">
                    <div class="card-group">
            <div class="row d-flex mx-auto text-center" style="gap: 20px; justify-content: center;"> 
                <advert-card v-for="pet in others" :key="pet.id" :id="pet.id" :pet="pet"/>
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
    name: 'EgyebPage',
    components:{
        AdvertCard,
    },
    data(){
        return{
            others: []
        }
    },
    methods:{
        async getOthers(){
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/others`)
            this.others = response.data
            console.log(this.others)
        }
    },
    mounted(){
        this.getOthers()
    }
}
</script>

<style scoped>
input[type='range']::-webkit-slider-thumb {
      
      
      background: #3E1600;
      
    }
    input[type='range']::-webkit-slider-runnable-track{
        background-color: white;
    }
</style>