<template>
    <v-app>
        <topbar></topbar>
        <div id="mainContent">
            <router-view></router-view>
        </div>
    </v-app>
</template>

<script>
import Topbar from './Topbar'
import EditRealtor from './EditRealtor'
import NewRealtor from './NewRealtor'
import AreYouSureAboutThat from './AreYouSureAboutThat'

export default {
    data() { 
        return {
        }
    },
    methods: {

    },
    components: {
        Topbar, EditRealtor, NewRealtor, AreYouSureAboutThat
    }
}
</script>

<style>
    #mainContent {
        width: 1200px;
        margin:auto;
        margin-top: 40px;
    }
</style>
