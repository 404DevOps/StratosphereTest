<template>
    <app-header />
    <div class="content-wrapper">
        <router-view />
    </div>
</template>


<script>
    import AppHeader from './components/AppHeader.vue'
    
    export default {
        name: 'App',
        components: {
            "app-header": AppHeader,
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
    }

    .content-wrapper {
        margin: 0px auto;
        margin-top: 10px;
    }
    .centered {
        text-align: left;
        margin: 0px auto;
    }
    nav {
        margin-right: 128px;
    }
    td, th {
        min-width: 80px;
        border: 1px solid grey;
    }
</style>
