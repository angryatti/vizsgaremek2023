<template>

    
    <div class="box">
        <div class="container bg-opacity-50">
            <div class="row mx-auto mb-3 mt-3">
                <div class="col-12">
                    <form action="">
                        <label for="bejelentkezes" class="mb-4"><h1>Bejelentkezés</h1></label><br>
                        <label for="email"><h2>E-mail:</h2></label>
                        <div class="col-6 mx-auto">
                            <input type="text" class="form-control">
                        </div>
                        
                         <label for="password"><h2>Jelszó</h2></label>
                         <div class="col-6 mx-auto">
                            <input type="password" name="password" id="password" class="form-control">
                         </div>
                         
                         <button type="submit" class="mx-auto mt-3 mb-3 btn btn-success">Bejelentkezés</button>
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
.container{
    background-color: #3E1600;
    color: white
}
</style>