<template>
    <div class="header-bg">
        <img class="logo" alt="Vue logo" src="../assets/logo.png">
        <nav>
            <ul>
                <li> <router-link to="/leaderboard">Leaderboard</router-link></li>
                <li> <router-link to="/activity">Activity</router-link></li>
                <li> <router-link to="/test">Test</router-link></li>    
            </ul>
        </nav>
    </div>

</template>

<script>
</script>

<style scoped>
    .logo{
        height: 40px;
        float: left;
        margin-top: 5px;
        margin-left: 5px;
    }
    .header-bg {
        height: 50px;
        width: 100%;
        background-color: black;
    }
    ul {
        list-style-type: none;
        text-align: center;
        margin: 0px auto;
    }
    li {
        display: inline-block;
        margin: 3px 2px;
        background-color: white;
        color: black;
        padding: 12px;
    }
    
    li:hover {
        display: inline-block;
        margin: 0, 10px;
        background-color: lightgray;
        color: black;
    }
    header {
        background: lightgreen;
        padding: 10px;
    }
    h1 {
        color: #222;
        text-align: center;
    }
    a, a:visited, a:hover {
        text-decoration: none;
        color: black;
    }
</style>