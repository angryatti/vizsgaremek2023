<template>

    
  <div class="box">
          <Filter @filter="(v)=>values=v"/>
  </div>
</template>

<script>
import Filter from "../components/layout/Filter.vue"
export default{

 




data(){
    return{
        
        cities: [],
        
    }
},
components:{
  Filter,
},
computed:{
  
},

methods:{
   
    async getSettlement(){
        const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/settlement`)
        this.cities = response2.data
       
    },
    submit(){
      
    }
},

mounted(){
    
    this.getSettlement();
}
}
</script>

