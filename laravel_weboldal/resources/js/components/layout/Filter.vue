<template>
<div class="container mb-3" style="background-color: #F5EDD8; border-radius: 50px;">
        <div class="row">
            <div class="col-12">   



        <table class="table table-borderless m-0 mx-auto text-center">
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
      <th scope="row"><div class="form-check">
  
  
  
</div></th>
      

      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    kicsi
  </label>
  <input class="form-check-input" type="checkbox"  v-model="values.kicsi" value="" id="flexCheckDefault">
</div></td>
      
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Hím
  </label>
  <input class="form-check-input" type="checkbox"  v-model="values.him" value="" id="flexCheckDefault">
</div></td>
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Közepes
  </label>
  <input class="form-check-input" type="checkbox"  v-model="values.kozepes" value="" id="flexCheckDefault">
</div></td>
      <td>
<input type="range" class="form-range" min="0" max="10" step="1" id="customRange3">
</td>
<td><div class="dropdown">
  <select class="form-select" aria-label="Default select example">
    <option selected v-for="settlement in states" :key="settlement.id">{{ settlement.name }}</option>
</select>
</div></td>
<td><button class="submit btn btn-primary" style="background-color: #B85B2F; font-weight: bold; height:40pt; width:100px;">szűrés</button></td>
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Nőstény
  </label>
  <input class="form-check-input" type="checkbox"  v-model="values.nosteny" value="" id="flexCheckDefault">
</div></td>
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Nagy
  </label>
  <input class="form-check-input" type="checkbox"  v-model="values.nagy" value="" id="flexCheckDefault">
</div></td>
      <td><div class="d-flex justify-content-between"><span>0</span><span>10+</span> </div></td>
    </tr>
  </tbody>
</table>
</div>
        </div>
     </div>  
</template>

<script>
export default{

  data(){
    return{
        
      states: [],
      values:{
        kutya: false,
        macska: false,
        egyeb: false,
        him: false,
        nosteny: false,
        kicsi: false,
        kozepes: false,
        nagy: false,
        }
    }
  },
  methods:{
    submit(){
      this.$emit("filter", this.values)
    },
      async getStates(){
            const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/states`)
            this.states = response2.data
            console.log(this.states)
        }
    },
    mounted(){
        
        this.getStates();
    }
  ,
  
}
</script>

<style scoped>
  
</style>