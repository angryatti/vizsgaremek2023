<template>

    
  <div class="box">
    <div class="inbox">
        <h1 v-if="logged===false" class="text-center">Üdvözöljük!</h1>
        <h1 v-else class="text-center">Üdvözöljük {{ user.full_name }}!</h1>

        
        <p class="fs-3"> Az állatok örökbefogadásásért jött létre ez az oldal. 
            Amennyiben érdeklődne az állatok iránt, abban az esetben be kell regisztrálnia!
            A mi feladatunk a közvetítés , ezért csak az oldallal kapcsolatos problémákban tudunk segíteni, másért felelősséget nem vállalunk!
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
        
        user_token : null,
            user : {},
    }
},


methods:{
        async userdata(){
            var logged_in = localStorage.getItem('logged_in')
            var logged = false
            if (logged_in === null){
             logged = false
            }
            else{
                logged = true
                const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
              this.user = response.data
            }
            
        }
},

mounted(){
    this.userdata()
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
        height: 100%;
        overflow: scroll;
        scroll-margin-left: 1px;
    }
</style>

