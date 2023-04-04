<template>
    <div class="box">
        <h1>Egy adott hirdetés</h1>
        {{$route.params.id}}
        {{kisallat.name}}
    </div>
</template>


<script>

export default{
    name: "AdvertPage",
    props:{
        kisallat:Object
    },
    mounted(){
        console.log(kisallat)
    }
}
</script>