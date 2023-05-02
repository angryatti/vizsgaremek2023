<template>
    <div>
        <h1 class="text-center mb-5 text-decoration-underline">Az Adataim</h1>
        <Form>

    <h2>Felhasználónév: </h2>
    <br> 
    <Field name="user_name" :placeholder="user.user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
    
    
    <h2 class="mx-auto mb-3">Email: </h2>  
    <br>
    <Field name="email" :placeholder="user.email" class="form-control mb-3" style="justify-content: center;"/> 
    
    <h2 class="mx-auto mb-3">Telefonszám: </h2>  
    <br>
    <Field name="phone" :placeholder="user.phone_number" class="form-control mb-3" style="justify-content: center;"/> 

    
    <button class="btn btn-warning d-block w-100 p-3 mx-auto mt-3">Mentés</button>

    </Form>
        
    </div>

</template>

<script>
import axios from 'axios'
import {Form, Field} from 'vee-validate'

export default{
    name: "ProfileData",
    data(){
        return{
        user_token : null,
        user:{}
    }},
    components:{
        Form,
        Field
    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
            this.user = response.data
        }
    },
    mounted(){
        this.getUserInfo()
    }
}
</script>