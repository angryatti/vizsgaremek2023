<template>
    <div>
                <h1 class="text-center text-decoration-underline">Új állat feltöltése</h1>
        
            <div>
                <Form @submit="submitForm">

        <h2>Állat neve:</h2>  
        <br> 
        <Field name="pet_name" v-model="pet_name" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Született:</h2>  
        <br> 
        <Field name="born" v-model="born" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Állat:</h2>  
        <br> 
        <Field name="species" v-model="species" as="select">
            <option v-for="pet in pets" :key="pet" >{{ pet }}</option>
        </Field>

        <h2>Fajta:</h2> 
        <br> 
        <Field name="breed" v-model="breed" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Neme:</h2>  
        <br> 
        <Field name="gender" v-model="gender" as="select">
            <option v-for="gender in genders" :key="gender">{{ gender }}</option>
        </Field>

        <h2>Kasztált:
        
        <Field name="castrated" v-model="castrated" type="checkbox" /></h2> 

        <h2>kép feltöltése:</h2>  
        <div>
      <img src="pet_imgs/navbar.png" class="uploading-image" />
      <input type="file" accept="image/jpeg" @change=uploadImage>
   </div>
        
        

        <h2>Leírás:</h2>  
        <br> 
        <Field name="description" v-model="description" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Megye:</h2>  
        <br> 
        <Field name="state_id" v-model="state_id" as="select">
                <option selected v-for="settlement in states" :key="settlement.id">{{ settlement.name }}</option>
        </Field>
      

        <h2 data-bs-toggle="tooltip" data-bs-placement="top" title="segítség: Mikor keressenek,
               pontosabb cím meghatározás">Kontakt Infó:</h2>  
        <br> 
        <Field name="contact_info" v-model="contact_info" type="text" class="form-control mb-3 pb-5"  style="justify-content: center;"/>

        <button type="submit" class="btn btn-custom d-block w-100 p-3 mx-auto mt-3 fs-4">Feltöltés</button>

        <button type="button" >
  Tooltip on top
</button>
        </Form> 
            </div>
    </div>
</template>

<script>
import {Form, Field} from 'vee-validate';
import axios from 'axios';    
export default{
    name:'imageUpload',
        data(){
            return{
               previewImage:null,
               states: [],
               pets:[
                "kutya",
                "macska",
                "egyéb"
               ],
               genders:[
                "Hím",
                "Nőstény"
               ],
                pet_name: '',
                born: '',
                species: '',
                breed: '',
                gender: '',
                castrated: '',
                img: '',
                description: '',
                state_id: '',
                contact_info: ''
            }
        },
        methods:{
            uploadImage(e){
                const image = e.target.files[0];
                const reader = new FileReader();
                reader.readAsDataURL(image);
                reader.onload = e =>{
                    this.previewImage = e.target.result;
                    console.log(this.previewImage);
                };
                
            },
                async getStates(){
                const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/states`)
                this.states = response2.data
            },
            async submitForm(){
                const user_id = localStorage.getItem('user_id')
                try{
                        const response = await axios.post(`${import.meta.env.VITE_LARAVEL_URL}/user/newpet`,{
                        user_id: user_id,
                        pet_name: this.pet_name,
                        born: this.born,
                        breed:this.breed,
                        species:this.species,
                        gender:this.gender,
                        castrated:this.castrated,
                        img:this.img,
                        description: this.description,
                        state_id:this.state_id,
                        contact_info:this.contact_info,
                    })
                    console.log(response.data)
                }
                
                catch(error){
                console.alert(error)
                }
            }
        },
        components:{
            Form,
            Field
        },

        mounted(){
        this.getStates();
    }
        
}


    


</script>
<style scoped>
img{
    width: 8%;
    height: auto;
}
button{
    background-color: #B85B2F;
    color: white;
    font-weight: bolder;
}
button:hover{
    background-color: #198754;
    color: white;
    
}
</style>