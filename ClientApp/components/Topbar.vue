<template>
    <v-toolbar color="blue">
        <v-toolbar-side-icon></v-toolbar-side-icon>
        <v-toolbar-title>Риэлторы</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat>Список</v-btn>
        <v-btn flat>Новый</v-btn>
        
        
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

        })
    }
</script>

<style scoped>

</style>