<template>
    <div>
        <!-- <input type="text" name="id" id="" v-model="test1">        
        <input type="text" name="firstName" id="" v-model="test2">        
        <input type="text" name="lastName" id="" v-model="test3">       
        <input type="text" name="subDivision" id="" v-model="test4">       
        <input type="text" name="registrationDate" id="" v-model="test5"> -->
        <button @click="submitChanges"> cheburek </button>
    </div>
</template>

<script>
    export default {
        data() {
            return {
            }
        },
        methods: {
            test() {
            },

            submitChanges() {

            },
        },
        props: [ 'test1', 'test2', 'test3', 'test4', 'test5' ]
    }
</script>

<style>

</style>
