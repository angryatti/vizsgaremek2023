<template>
<div class="container mb-3" style="background-color: #F5EDD8; border-radius: 50px;">
        <div class="row">
            <div class="col-12">   



        <table class="table table-borderless m-0 mx-auto text-center">
  <thead>
    <tr>
      
      <th class="fs-3" scope="col" style="text-decoration: underline;">Nem</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;">Kor</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;">Helyszín</th>
      <th class="fs-3" scope="col" style="text-decoration: underline;"></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row"><div class="form-check">
  
  
  
</div></th>
            
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Hím
  </label>
  <input class="form-check-input" :value="gender[1]" type="checkbox" v-model="selectgender" id="flexCheckDefault">
</div></td>
      <td>
<input type="range" v-model="age" class="form-range" min="0" :max="currentDate()-maxAge"  step="1" id="customRange3">
</td>
<td><div class="dropdown">
  <select class="form-select" v-model="state_id" aria-label="Default select example">
    <option selected v-for="settlement in states" :value="settlement.id" :key="settlement.id">{{ settlement.name }}</option>
</select>
</div></td>
<td><button @click="applyFilter" class="submit btn btn-primary" style="background-color: #B85B2F; font-weight: bold; height:40pt; width:100px;">szűrés</button></td>
    </tr>
    <tr>
      
      <td><div class="form-check">
  
  <label class="form-check-label" for="flexCheckDefault">
    Nőstény
  </label>
  <input class="form-check-input" type="checkbox" :value="gender[0]"  v-model="selectgender" id="flexCheckDefault">
</div></td>
      
      <td><div class="d-flex justify-content-between"><span>0</span><span>{{ this.age }}</span>{{ currentDate()-maxAge }} </div></td>
    </tr>
  </tbody>
</table>
</div>
        </div>
     </div>  
</template>

<script>
export default{
  props:{
    pets: Array
  },
  data(){
    return{
      states: [],
      gender:['Nőstény','Hím'],
      selectgender:[],
      age:'',
      state_id: ''
      
    }
  },
  computed:{
    maxAge(){
      var min = 2500
          this.pets.forEach(pet => {
           if(pet.pet.born < min){
              min = pet.pet.born}
          });
          console.log(min)
          return min;
        }
  },
  methods:{
      async getStates(){
            const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/states`)
            this.states = response2.data
            console.log(this.states)
            console.log(this.state_id)
      },
      applyFilter(){
        let filtered = this.pets
        if(this.selectgender.length > 0)
        {
          filtered = this.filterGender(filtered)
        }
        if(this.age)
        {
          filtered = this.filterAge(filtered)
        }
        if(this.state_id)
        {
          filtered = this.filterState(filtered)
        }
        console.log(filtered)
        this.$emit('filtered',filtered)
        if(filtered.length === 0){alert('Ilyen állat nem létezik!')}
      },
      filterGender(pets){
        return pets.filter((pet)=>{
          return this.selectgender.includes(pet.pet.gender)
        })
      },
      filterAge(pets){
        console.log(this.age)
        return pets.filter((pet)=>{
          return   this.age >= (this.currentDate()-pet.pet.born)
        })
      },
      filterState(pets){
        return pets.filter((pet)=>{
          return pet.state_id === this.state_id
        })
      },
      currentDate() {
        const current = new Date();
        const date = `${current.getFullYear()}`;
        return date;
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