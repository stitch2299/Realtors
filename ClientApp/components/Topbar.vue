<template>
    <v-toolbar class="toolbar">
        <v-toolbar-title @click="toMain">Риэлторы</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat @click="toList">Список</v-btn>
        <v-btn flat @click="toNew">Новый</v-btn>
        
        
        <v-flex xs8>
        <v-text-field name="search" label="Поиск" id="searching"></v-text-field>
        </v-flex>
        <v-btn flat>Искать
        </v-btn>
        

        </v-toolbar-items>
    </v-toolbar> 
</template>

<script>
    export default {
        data: () => ({

        }),
        methods: {
            toMain() {
                this.$router.push('/')
            },
            toList() {
                this.$router.push('/list')
            },
            toNew() {
                this.$router.push('/new')
            }
        }
    }
</script>

<style scoped>
    .toolbar__title {
        font-size: 24px;
    }
    .toolbar {
        font-family: "Comic Sans MS", "Comic Sans", cursive;
        background-color: rgb(98, 166, 255);
    }
</style>