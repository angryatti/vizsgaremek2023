<template>
  <div>
    <div class="box">
        <div class="container bg-primary bg-opacity-25">              
            <div class="row"> 
              <div class="col-12 mb-3 mt-3">
                <h1 class="mb-5" style="text-decoration: underline;">Regisztráció</h1>
                  <Form @submit="submitForm" :validation-schema="schema">

                    <h2>Felhasználónév:</h2>  <br> <Field name="user_name" v-model="user_name" type="text" class="form-control mb-3" style="justify-content: center;"/>
                      <ErrorMessage name="text" class="alert alert-danger" role="alert"/>
                      
                    <h2 class="mx-auto mb-3">Email:</h2>  <br><Field name="email" v-model="email" class="form-control mb-3" style="justify-content: center;"/> 
                      <ErrorMessage name="email" class="alert alert-danger" role="alert"/>

                    <h2>Jelszó:</h2>  <br> <Field name="password" v-model="password" type="password" class="form-control mb-3" style="justify-content: center;"/>
                      <ErrorMessage name="password" class="alert alert-danger" role="alert"/>

                    <h2>Jelszó megerősítése:</h2>  <br> <Field name="password2" type="password" class="form-control mb-3" style="justify-content: center;"/>
                      <ErrorMessage name="password2" class="alert alert-danger" role="alert"/>
                    <button class="btn btn-primary mx-auto mt-3">Regisztráció</button>
    
                   </Form>
                </div>        
              </div>
            </div>
        </div>
        </div>
</template>
  
<script setup>

  import { Form, Field, ErrorMessage } from 'vee-validate';
  import {ref} from 'vue'
  import axios from 'axios';

  import * as yup from 'yup';

  const schema = yup.object({
    email: yup.string().required("kötelező kitölteni!").email("valós E-mail címnek kell lennie!"),
    password: yup.string().required("kötelező kitölteni!").min(8, "minimum 8 karakternek kell lennie!"),
    password2: yup.string().oneOf([yup.ref('password'), null], 'A jelszavaknak meg kell egyezniük!'),
    user_name: yup.string().required("kötelező kitölteni!").min(2, "minimum 2 karakternek kell lennie!"),
  });
  
const email = ref('')
const user_name = ref('')
const password = ref('')

const submitForm = async() =>{
  try{
    const response = await axios.post(`${import.meta.env.VITE_LARAVEL_URL}/api/register`,{
      user_name:user_name.value,
      email:email.value,
      password:password.value,
      
    })
    console.log(response)
    alert('sikeres regisztráció')
  }catch(error){
    alert(error.response.data.message)
  }
}
</script>

<style scoped>
    .row{

        text-align: center;
        
        
    }
    .col-12{
        justify-content: center;
        
    }
    span {
  display: block;
  margin: 10px 0;
}

button, input {
  display: block;
}

.container{
  border-radius: 50px;
}
</style>