<template>

    
    <div class="box">
        <div class="container bg-opacity-50">
            <div class="row mx-auto mb-3 mt-3">
                <div class="col-12">
                    <h1 class="text-center mb-3" style="text-decoration: underline;">Bejelentkezés</h1>
                    <Form @submit="submitForm" :validation-schema="schema">
                      <h2 class="mx-auto mb-3">Email:</h2>  <br><Field name="email" v-model="email" class="form-control mb-3" style="justify-content: center;"/> 
                        <ErrorMessage name="email" class="alert alert-danger" role="alert"/>
                      <h2>Jelszó:</h2>  <br> <Field name="password" type="password" v-model="password" class="form-control mb-3" style="justify-content: center;"/>
                        <ErrorMessage name="password" class="alert alert-danger" role="alert"/>
                      <button class="btn btn-success mx-auto mt-3 mb-3">Bejelentkezés</button>  
                    </Form>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
 import axios from 'axios';
import { Form, Field, ErrorMessage } from 'vee-validate';
import {ref} from 'vue'
import * as yup from 'yup';
  const schema = yup.object({
    email: yup.string().required("kötelező kitölteni!").email("valós E-mail címnek kell lennie!"),
    password: yup.string().required("kötelező kitölteni!").min(8, "minimum 8 karakternek kell lennie!"),
   
  });

  const email = ref('')
  const password = ref('')

  const submitting = ref(false)
  const errors = ref({})

  const submitForm = () =>{
    submitting.value = true
    errors.value = {}

    axios.post(`${import.meta.env.VITE_LARAVEL_URL}/api/login`,{
      email:email.value,
      password:password.value
    })
    .catch(error =>{
      if(error.response.status = 422){
        errors.value = error.response.data.errors
      }else{

      }
    })
    .finally(()=>{
      submitting.value = false
      
    })
  }
</script>

<style scoped>
.row{

text-align: center;


}
.col-12{
justify-content: center;

}
.container{
    background-color: #3E1600;
    color: white
}
span {
  display: block;
  margin: 10px 0;
}

button, input {
  display: block;
}
</style>