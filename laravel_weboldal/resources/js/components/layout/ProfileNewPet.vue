<template>
    <div>
                <h1 class="text-center text-decoration-underline">Új állat feltöltése</h1>
        
            <div >
                <Form @submit="submitForm" :validation-schema="schema">

        <h2>Állat neve:</h2>  
        <br> 
        <Field name="pet_name" v-model="pet_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
        <ErrorMessage name="pet_name" class="alert alert-danger" role="alert"/>

        <h2>Született:</h2>  
        <br> 
        <Field name="born" v-model="born" type="text" class="form-control mb-3" style="justify-content: center;"/>
        <ErrorMessage name="born" class="alert alert-danger" role="alert"/>

        <h2>Állat:</h2>  
        <br> 
        <Field name="species" v-model="species" as="select">
            <option v-for="pet in pets" :value="pet" :key="pet" >{{ pet }}</option>
        </Field>
        <ErrorMessage name="species" class="alert alert-danger" role="alert"/>

        <h2>Fajtak:</h2> 
        <br> 
        <Field name="breed" v-model="breed" type="text" class="form-control mb-3" style="justify-content: center;"/>
        <ErrorMessage name="breed" class="alert alert-danger" role="alert"/>

        <h2>Neme:</h2>  
        <br> 
        <Field name="gender" v-model="gender" as="select">
            <option v-for="gender in genders" :value="gender" :key="gender">{{ gender }}</option>
        </Field>
        <ErrorMessage name="gender" class="alert alert-danger" role="alert"/>

        <h2>Kasztált:
        
        <Field name="castrated" value="1" v-model="castrated" type="checkbox" /></h2> 
        

        <h2>kép feltöltése:</h2>  
        <div>
      <img src="pet_imgs/navbar.png" class="uploading-image" />
      <input @change="onFileChange"  name="image" type="file" accept="image/jpeg,image/png,image/gif">
     
   </div>
   
        

        <h2>Leírás:</h2>  
        <br> 
        <Field name="description" v-model="description" type="text" class="form-control mb-3" style="justify-content: center;"/>
        <ErrorMessage name="description" class="alert alert-danger" role="alert"/>

        <h2>Megye:</h2>  
        <br> 
        <Field name="state_id" v-model="state_id" as="select">
                <option selected v-for="settlement in states" :value="settlement.id" :key="settlement.id">{{ settlement.name }}</option>
        </Field>
        <ErrorMessage name="state_id" class="alert alert-danger" role="alert"/>


        <h2 data-bs-toggle="tooltip" data-bs-placement="top" title="segítség: Mikor keressenek,
               pontosabb cím meghatározás">Kontakt Infó:</h2>  
        <br> 
        <Field name="contact_info" v-model="contact_info" type="text" class="form-control mb-3 pb-5"  style="justify-content: center;"/>
        <ErrorMessage name="contact_info" class="alert alert-danger" role="alert"/>

        <button type="submit" class="btn btn-custom d-block w-100 p-3 mx-auto mt-3 fs-4">Feltöltés</button>

        </Form> 
            </div>
    </div>
</template>

<script>
import {Form, Field, ErrorMessage } from 'vee-validate';
import axios from 'axios';   


import * as yup from 'yup';

  
  



export default{
    name:'imageUpload',
        data(){
            return{
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
                file:{},
                pet_name: '',
                born: '',
                species: '',
                breed: '',
                gender: '',
                castrated: '0',
                img: '',
                description: '',
                state_id: '',
                contact_info: '',

                required: "kötelező kitölteni!",
                select: "válasszon a lehetőségek közül!",
                number: "csak szám lehet!",
                string: "csak szöveg lehet!"
            }
        },
        components:{
            Form,
            Field,
            ErrorMessage
        },
        computed:
        {
            schema(){

            return yup.object({
            pet_name: yup.string().required(this.required).matches(/^[a-zA-ZöÖüÜóÓőŐúÚűŰáÁéÉ]*$/, this.string),
            born: yup.string().matches(/^[0-9]+$/, this.number).required("kötelező kitölteni!"),
            species: yup.string().required(this.select),
            breed: yup.string().required(this.required),
            gender: yup.string().required(this.required),
            description: yup.string().required(this.required),
            state_id: yup.string().required(this.select),
            contact_info: yup.string().required(this.required),

            
    
    
           
  })},   
        },
        methods:{
         

            onFileChange(event){
                this.file =  event.target.files[0];
                this.img=this.file.name;
                const reader = new FileReader();
                reader.readAsDataURL(this.file);
                reader.onload = e =>{
                    this.previewImage = e.target.result;
                }
                console.log(this.file)
            },
            async getStates(){
                const response2 = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/states`)
                this.states = response2.data
            },
            async submitForm(){
                const user_id = localStorage.getItem('user_id')
                const formData = new FormData();
      
                formData.append('user_id', user_id);
                formData.append('pet_name', this.pet_name);
                formData.append('born', this.born);
                formData.append('breed', this.breed);
                formData.append('species', this.species);
                formData.append('gender', this.gender);
                formData.append('castrated', this.castrated);
                formData.append('description', this.description);
                formData.append('state_id', this.state_id);
                formData.append('contact_info', this.contact_info);
                formData.append('img', this.img);
                formData.append('imagepreview',this.file)

                try {
                    const response = await axios.post(`${import.meta.env.VITE_LARAVEL_URL}/api/user/newpet`, formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                    });
                    console.log(response.data)
                    alert(response.data.message)
                }
                
                catch(error){
                console.warn(error)
                }
            },
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
.alert{
    display: block;
   text-align: center;
    
}
</style>