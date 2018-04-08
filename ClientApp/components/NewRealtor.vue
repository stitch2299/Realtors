<template>
    <div>
    <v-form class="new-form" ref="form" >
        <v-text-field label="Фамилия" v-model="lastName" :rules="[lastNameRules.required, lastNameRules.regCheck]" required></v-text-field>
        <v-text-field label="Имя" v-model="firstName" :rules="[firstNameRules.required, firstNameRules.regCheck]" required></v-text-field>
        <v-select label="Подразделение" v-model="subDivision" :rules="[subDivisionRules.required]" :items="divisions" autocomplete required></v-select>
        <v-menu>
            <v-text-field slot="activator" label="Дата регистрации" v-model="registrationDate" append-icon="event" readonly></v-text-field>
            <v-date-picker v-model="registrationDate" no-title scrollable></v-date-picker>
        </v-menu>
        <!-- <v-text-field label="Дата регистрации" v-model="registrationDate" :rules="[registrationDateRules.required]" required></v-text-field> -->
        <!-- <v-date-picker v-model="registrationDate" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" first-day-of-week=1 ></v-date-picker> -->
        <v-layout justify-space-between>
            <v-btn @click="addRealtor" color="success">Сохранить запись</v-btn>
            <v-btn @click="cancel">Отмена</v-btn>
        </v-layout>
    </v-form>
    </div>
</template>

<script>
    export default {
        data:() => ({
            lastName: '',
            firstName: '',
            subDivision: '',
            registrationDate: new Date().toJSON().substring(0, 10),
            
            divisions: [
                    { value:1, text: 'Росич'},
                    { value:2, text: 'Урал'},
                    { value:3, text: 'Эдельвейс'},
                    { value:4, text: 'Меркурий'},
                    { value:5, text: 'Кузбасс'},

            ],

            lastNameRules: {
                required: v => !!v || 'Укажите фамилию',
                regCheck: v => {
                    const pattern = /^[а-яА-Яa-zA-Z ]*$/
                    return !!v && pattern.test(v)  || 'Фамилия содержит недопустимые символы'
                }
            },
            firstNameRules: {
                required: v => !!v || 'Укажите имя',
                regCheck: v => {
                    const pattern = /^[а-яА-Яa-zA-Z ]*$/
                    return !!v && pattern.test(v)  || 'Имя содержит недопустимые символы'
                }
            },
            subDivisionRules: {
                required: v => !!v || 'Выберите подразделение'
            },
            registrationDateRules: {
                required: v => !!v || 'Укажите дату регистрации'
            }
        }),
        methods: {
            addRealtor() {
                if (this.$refs.form.validate()){
                    this.$router.push('/')
                }
            },
            cancel() {
                this.$router.push('/')
            }
        },
    }
</script>

<style scoped>
</style>
