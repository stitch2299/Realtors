<template>
    <div>
    <v-form class="new-form" ref="form" >
        <v-text-field label="Фамилия" v-model="lastName" :rules="[lastNameRules.required, lastNameRules.regCheck]" required></v-text-field>
        <v-text-field label="Имя" v-model="firstName" :rules="[firstNameRules.required, firstNameRules.regCheck]" required></v-text-field>
        <v-select v-model="subDivision" label="Подразделение" :rules="[subDivisionRules.required]" :items="subDivisions" item-text="name" item-value="id" autocomplete required></v-select>
        <v-menu>
            <v-text-field slot="activator" label="Дата регистрации" v-model="registrationDate" append-icon="event" readonly></v-text-field>
            <v-date-picker locale="Cyrl" v-model="registrationDate" no-title scrollable></v-date-picker>
        </v-menu>
        <v-layout justify-space-between>
            <v-btn @click="addRealtor" color="success">Сохранить запись</v-btn>
            <v-btn @click="cancel">Отмена</v-btn>
        </v-layout>
    </v-form>
    {{ this.subDivision }}
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        created() {
            this.getSubDivisions()
        },
        data:() => ({
            lastName: '',
            firstName: '',
            subDivision: '',
            registrationDate: '',
            subDivisions: [],
            postBody: {
                LastName: '',
                FirstName: '',
                SubDivision: Number,
                RegistrationDate: new Date()
            },
            Realtor: [],
            errors: [],
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
                this.postBody.LastName = this.lastName
                this.postBody.FirstName = this.firstName
                this.postBody.SubDivision = this.subDivision
                this.postBody.RegistrationDate = new Date(this.registrationDate)
                var value = this.postBody
                console.log(value)
                axios.post('api/Realtor', value)
                .then(response => {})
                .catch(e => {
                    this.errors.push(e)
                }),
                this.$router.push('/')
            },
            cancel() {
                this.$router.push('/')
            },
            getSubDivisions() {
                axios.get('/api/SubDivision')
                .then(response => {
                    let data = response.data
                    this.subDivisions = data
                })
                .catch(e => {
                    this.errors.push(e)
                })                
            },
        },
    }
</script>

<style scoped>
</style>
