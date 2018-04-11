<template>
    <div>
        <v-form v-model="valid" ref="form" class="new-form" validation>
            <v-text-field label="Фамилия" v-model="lastName" :rules="[lastNameRules.required, lastNameRules.regCheck]" required></v-text-field>
            <v-text-field label="Имя" v-model="firstName" :rules="[firstNameRules.required, firstNameRules.regCheck]" required></v-text-field>
            <v-select label="Подразделение" v-model="subDivision" :rules="[subDivisionRules.required]" :items="subDivisions" 
            item-text="name" item-value="id" autocomplete required></v-select>
            <v-menu ref="menu" lazy :close-on-content-click="false" v-model="menu" transition="scale-transition" offset-y full-width
            :nudge-right="40" max-width="290px" min-width="290px" :return-value.sync="registrationDate">
                <v-text-field slot="activator" label="Дата регистрации" v-model="registrationDate" append-icon="event" readonly></v-text-field>
                <v-date-picker locale="Cyrl" v-model="registrationDate" no-title scrollable></v-date-picker>
                <v-spacer></v-spacer>
                <v-btn flat color="primary" @click="menu = false">Отмена</v-btn>
                <v-btn flat color="primary" style="float:right" @click="$refs.menu.save(registrationDate)">ОК</v-btn>
            </v-menu>
            <v-layout justify-space-between>
                <v-btn @click="addRealtor" :disabled="!valid" color="success">Сохранить запись</v-btn>
                <v-btn @click="cancel">Отмена</v-btn>
            </v-layout>
        </v-form>
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
            registrationDate: new Date().toISOString().slice(0,10),
            subDivisions: [],
            errors: [],
            menu: false,
            valid: true,
            realtor: {
                LastName: '',
                FirstName: '',
                SubDivision: Number,
                RegistrationDate: new Date()
            },
            lastNameRules: {
                required: v => !!v ||
                    'Укажите фамилию',
                regCheck: v => {
                    const pattern = /^[а-яА-Яa-zA-ZёЁ ]*$/
                    return !!v && 
                    pattern.test(v)  ||
                    'Фамилия содержит недопустимые символы'
                }
            },
            firstNameRules: {
                required: v => !!v || 
                    'Укажите имя',
                regCheck: v => {
                    const pattern = /^[а-яА-Яa-zA-ZёЁ ]*$/
                    return !!v && 
                    pattern.test(v)  || 
                    'Имя содержит недопустимые символы'
                }
            },
            subDivisionRules: {
                required: v => !!v || 
                    'Выберите подразделение'
            },
            registrationDateRules: {
                required: v => !!v || 
                    'Укажите дату регистрации'
            }
        }),
        methods: {
            addRealtor() {
                if(this.$refs.form.validate()) {
                    this.realtor.LastName = this.lastName
                    this.realtor.FirstName = this.firstName
                    this.realtor.SubDivision = this.subDivision
                    this.realtor.RegistrationDate = new Date(this.registrationDate)
                    var value = this.realtor
                    axios.post('api/Realtor', value)
                    .then(response => {})
                    .catch(e => {
                        this.errors.push(e)
                    }),
                    this.$router.push('/')
                }
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
            }
        }
    }
</script>

<style scoped>

</style>
