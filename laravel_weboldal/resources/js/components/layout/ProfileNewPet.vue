<template>
    <div class="overflow-scroll">
                <h1 class="text-center text-decoration-underline">Új állat feltöltése</h1>
        
            <div>
                <Form @submit="submitForm" >

        <h2>Állat neve:</h2>  
        <br> 
        <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Született:</h2>  
        <br> 
        <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Állat:</h2>  
        <br> 
        <Field name="field" as="select">
            <option>Kutya</option>
            <option>Macska</option>
            <option>Egyéb</option>
        </Field>

        <h2>Fajta:</h2> 
        <br> 
        <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Neme:</h2>  
        <br> 
        <Field name="field" as="select">
            <option>Hím</option>
            <option>Nőstény</option>
        </Field>

        <h2>Kasztált:
        
        <Field name="drink" type="checkbox" /></h2> 

        <h2>kép feltöltése:</h2>  
        <div>
      <img src="pet_imgs/navbar.png" class="uploading-image" />
      <input type="file" accept="image/jpeg" @change=uploadImage>
   </div>
        
        

        <h2>Leírás:</h2>  
        <br> 
        <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>

        <h2>Megye:</h2>  
        <br> 
        <Field name="field" as="select">
                <option selected v-for="settlement in states" :key="settlement.id">{{ settlement.name }}</option>
        </Field>
      

        <h2>Kontakt Infó:</h2>  
        <br> 
        <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
        </Form> 
            </div>
    </div>
</template>

<script>
import {Form, Field} from 'vee-validate';
    
export default{
    name:'imageUpload',
        data(){
            return{
               previewImage:null,
               states: [],
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
</style>