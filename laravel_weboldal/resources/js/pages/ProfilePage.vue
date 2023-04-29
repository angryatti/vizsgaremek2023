<template>

     <div class="box">{{ user }}</div>
</template>


<script>
import axios from 'axios'
export default{
    data(){
        return{
            user_token : null,
            user : {}
        }
    },
    methods:{
        async getUserInfo(){
            this.user_token = localStorage.getItem('user_info')
            const logged = localStorage.getItem('logged_in')
            console.log(logged)
            if(logged===null){
                alert('Hahó, te itt nem lehetsz, először jelentkezz be!!!!!!!!!!!!')
            }else{
            const response = await axios.get(`${import.meta.env.VITE_LARAVEL_URL}/api/user`,{token:this.user_token})
            this.user = response.data}
        },
    },
    mounted(){
        this.getUserInfo()
    }
}
</script>