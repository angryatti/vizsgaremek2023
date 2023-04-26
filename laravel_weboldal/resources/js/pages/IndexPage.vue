<template>

    
  <div class="box">
    <div class="inbox">
        <h1 class="text-center ">Üdvözöljük!</h1>

        <p class="fs-3"> Az állatok örökbefogadáásért jött létre ez az oldal. 
            Amennyiben érdeklődne az állatok iránt, abban az esetben be kell regisztrálnia!
            A mi feladatunk a közvetítés , ezért felelősséget nem vállalunk /*ide nem tudom mit kéne írni*/!
            Amennyiben problémát tapasztal az oldallal kapcsolatban , akkor írjon a KAPCSOLAT menüpontban.
        </p>
    </div>
         

  </div>
</template>

<script>

import { onMounted, reactive, computed } from "vue";
export default{

 




data(){
    return{
        
        cities: [],
        
    }
},


methods:{
   
    async getSettlement(){
        const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/settlement`)
        this.cities = response2.data
       
    },
    submit(){
      this.$emit("filter", this.values);
    }
},

mounted(){
    
    this.getSettlement();
}
}
</script>

<style scoped>
    .inbox{
    Top:300px;
    left:5%;
    border-radius:50px;
    right:5%;
    width: 97.5%;
    height: 100%;
    padding: 50px;
    margin: 20px;
        background-color: #F5EDD8;

        color: #3E1600;
    }
    p{
        text-align: justify;
        margin: 2px;
    }
</style>

