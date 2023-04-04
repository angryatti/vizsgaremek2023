<template>

    
    <div class="box">
        <div class="container bg-primary bg-opacity-25">
            <div class="row">
                <div class="col-12 mx-auto mb-3 mt-3">
                   
                   <div>
    <input name="fieldName" v-model="value" />
    <span v-if="errorMessage && meta.touched">
      {{ errorMessage }}
    </span>
  </div>

           <!-- <form @submit="sendData">
                <label for="info" class="mb-4" ><h1>Adja meg az adatokat!</h1></label><br>

            <label for="username"><h2>Felhasználónév</h2></label>
            <div class="col-6 mx-auto">
                <input type="text" name="username" id="username" class="form-control">
            </div>

            <label for="email"><h2>E-mail</h2></label>
            <div class="col-6 mx-auto">
                <input type="text" name="email" id="email" class="form-control">
            </div>
            

            <label for="password"><h2>Jelszó</h2></label>
            <div class="col-6 mx-auto">
               <input type="password" name="password" id="password" class="form-control "> 
            </div>
            <label for="password"><h2>Jelszó megerősítés</h2></label>
            <div class="col-6 mx-auto">
               <input type="password" name="password2" id="password2" class="form-control "> 
            </div>
            

            <button type="submit" class="btn btn-primary mt-3">Regisztráció</button>
<ErrorComponent v-if="error" :error="error" /> {{error}}

        </form> -->

        
                </div>
            </div>
        </div>
       

    </div>
</template>

<script>
import { object, string } from 'yup';
import { useField } from 'vee-validate';

const { errorMessage, meta, value } = useField('fieldName');
export default{
    data(){
        const schema = yup.object({
      email: yup.string().required().email(),
      password: yup.string().required().min(8)});

       return{
        error:null,
        schema,
        
       }
    },
    
   /* methods:{
        sendData(values){
        try{
            const resp = axios.post("http://localhost:8881/api/user", values)
        }catch(e){
            this.error = e
        }
        }
    },*/
  setup() {
    // Non-reactive because it was not explicitly defined with `reactive` or `ref`
    const schema = yup.object({
      email: yup.string().required().email(),
      password: yup.string().required().min(8),
    });

    return {
      schema,
    };
  },

   
}
</script>

<style scoped>
    .row{

        text-align: center;
        
        
    }
    .col-12{
        justify-content: center;
        
    }
    
</style>