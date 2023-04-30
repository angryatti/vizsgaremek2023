<template>
    <div>
        <h1 class="text-center mb-5 text-decoration-underline">Az Adataim</h1>
        <Form @submit="submitForm" >

    <h2>Felhasználónév: </h2>
    <br> 
    <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
    
    
    <h2 class="mx-auto mb-3">Email: </h2>  
    <br>
    <Field name="email" v-model="email" class="form-control mb-3" style="justify-content: center;"/> 
    
    <h2 class="mx-auto mb-3">Telefonszám: </h2>  
    <br>
    <Field name="phone" v-model="phone" class="form-control mb-3" style="justify-content: center;"/> 

    
    <button class="btn btn-warning d-block w-100 p-3 mx-auto mt-3">Mentés</button>

    </Form>
        
    </div>

</template>

<script>
import axios from 'axios'
import {Form, Field} from 'vee-validate'

export default{
    name: "ProfileData",
    props:{
        user:{
            type:Object,
            required: true
        }
    },
    components:{
        Form,
        Field
    }
}
</script>