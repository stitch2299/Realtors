<template>
    <div>
    <v-form class="new-form" v-model="valid" ref="form" validation>
        <v-text-field label="Фамилия" v-model="lastName" :rules="lastNameRules" required></v-text-field>
        <v-text-field label="Имя" v-model="firstName" :rules="firstNameRules" required></v-text-field>
        <v-select label="Подразделение" v-model="subDivision" :rules="subDivisionRules" :items="divisions" autocomplete required></v-select>
        <v-text-field label="Дата регистрации" v-model="registrationDate" :rules="registrationDateRules" required></v-text-field>
        <v-date-picker v-model="registrationDate" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" first-day-of-week=1 ></v-date-picker>
        <v-btn @click="submit" :disabled="!valid" color="success">Сохранить запись</v-btn>
    </v-form>
    </div>
</template>

<script>
    export default {
        data:() => ({
            valid:false,
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

            lastNameRules: [
            v => !!v || 'Укажите фамилию'
            ],
            firstNameRules: [
            v => !!v || 'Укажите имя'
            ],
            subDivisionRules: [
            v => !!v || 'Выберите подразделение'
            ],
            registrationDateRules: [
            v => !!v || 'Укажите дату регистрации'
            ]
        }),
        methods: {
            submit() {
                if (this.$refs.form.validate()){

                }
            }
        },
    }
</script>

<style scoped>
    .btn {
        float:right;
    }
</style>
