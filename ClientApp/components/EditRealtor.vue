<template>
    <v-form v-model="valid">
        <v-text-field label="Имя"  required></v-text-field>
        <v-text-field label="Фамилия"  required></v-text-field>
        <v-text-field label="Подразделение"  required></v-text-field>
        <v-text-field label="Дата регистрации"  required></v-text-field>
    </v-form>
</template>

<script>
    export default {
        data:() => ({

        })
    }
</script>

<style scoped>

</style>
