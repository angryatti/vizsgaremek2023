<template>
    <div>
        <h1 class="text-center mb-5 text-decoration-underline">Az Adataim</h1>
        <Form @submit="UserUpdate" :validation-schema="schema">

    <h2>Felhasználónév: </h2>
    <br> 
    <Field v-model="user_name" name="user_name" :placeholder="user.user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
    <ErrorMessage name="user_name" class="alert alert-danger" role="alert"/>
    
    <h2 class="mx-auto mb-3">Email: </h2>  
    <br>
    <Field v-model="email" name="email" :placeholder="user.email" class="form-control mb-3" style="justify-content: center;"/> 
    <ErrorMessage name="email" class="alert alert-danger" role="alert"/>

    <h2 class="mx-auto mb-3">Név: </h2>  
    <br>
    <Field v-model="full_name" name="full_name" :placeholder="user.full_name" class="form-control mb-3" style="justify-content: center;"/> 
    <ErrorMessage name="full_name" class="alert alert-danger" role="alert"/>

    <h2 class="mx-auto mb-3">Telefonszám: </h2>  
    <br>
    <Field v-model="phone" name="phone" :placeholder="user.phone_number" class="form-control mb-3" style="justify-content: center;"/> 
    <ErrorMessage name="phone" class="alert alert-danger" role="alert"/>
    
    <button type="submit" class="btn btn-warning d-block w-100 p-3 mx-auto mt-3">Mentés</button>

    </Form>
        
    </div>

</template>

<script>
import axios from 'axios'
import {Form, Field, ErrorMessage} from 'vee-validate'

import * as yup from 'yup';

export default{
    name: "ProfileData",
    data(){
        return{
        user_token : null,
        user:{},
        user_id: localStorage.getItem('user_id'),
        user_name:'',
        email:'',
        full_name:'',
        phone:'', 
    }},
    components:{
        Form,
        Field,
        ErrorMessage
    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
            this.user = response.data
        },
        async UserUpdate(){
            const userinfo = {'user_name': this.user_name, 'email':this.email,'full_name':this.full_name,'phone_number':this.phone}
            let formdata = new FormData()

            for(let key in userinfo){
                let value = userinfo[key]

                if (value !== null && value !== '') {
                    formdata.append(key, value);
  }
            }
            console.log(formdata)
            try{
                const resp = await axios.post(`${import.meta.env.VITE_LARAVEL_URL}/api/users/${this.user_id}`,formdata,{
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                })

                alert(resp.data.message)
            }
            catch(error){
                console.log(error.data)
            }
            
        }
    },
    computed:
        {
            schema(){

            return yup.object({
            user_name: yup.string(),
            email: yup.string().email("valós E-mail címnek kell lennie!"),
            full_name: yup.string(),
            phone: yup.string().matches(/^[\+]\+?\d{10,14}$/, "valós telefonszámnak kell lennie!"), 
           
  })}
}, 
    mounted(){
        this.getUserInfo()
    }
}
</script>