<template>

    
    <div class="box">
        <div class="container bg-primary bg-opacity-25">
            <div class="row">
                <div class="col-12 mx-auto mb-3 mt-3">
            <form action="">
                <label for="info" class="mb-4" ><h1>Adja meg az adatokat!</h1></label><br>

            <label for="email"><h2>E-mail</h2></label>
            <div class="col-6 mx-auto">
                <input type="text" name="email" id="email" class="form-control">
            </div>
            

            <label for="password"><h2>Jelszó</h2></label>
            <div class="col-6 mx-auto">
               <input type="password" name="password" id="password" class="form-control "> 
            </div>


            <label for="password2"><h2>Jelszó megint</h2></label>
            <div class="col-6 mx-auto">
               <input type="password" name="password2" id="password2" class="form-control "> 
            </div>
            

            <button type="submit" class="btn btn-primary mt-3">Regisztráció</button>
        </form> 
                </div>
            </div>
        </div>
       

    </div>
</template>

<script>
</script>

<style scoped>
    .row{

        text-align: center;
        
        
    }
    .col-12{
        justify-content: center;
        
    }
    
</style>