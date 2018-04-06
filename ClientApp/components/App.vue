<template>
    <v-app>
        <topbar></topbar>
        <router-view></router-view>
    </v-app>
</template>

<script>
import Topbar from './Topbar'
import EditRealtor from './EditRealtor'

export default {
    data() { 
        return {
        }
    },
    methods: {

    },
    components: {
        Topbar, EditRealtor
    }
}
</script>

<style>

</style>
