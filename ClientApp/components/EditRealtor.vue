<template>
    <div>
    <v-form ref="form">
        <v-text-field label="Фамилия" v-model="lastName" :rules="[lastNameRules.required, lastNameRules.regCheck]" required></v-text-field>
        <v-text-field label="Имя" v-model="firstName" :rules="[firstNameRules.required, firstNameRules.regCheck]"  required></v-text-field>
        <v-select label="Подразделение" v-model="subDivision" :rules="[subDivisionRules.required]" :items="subDivisions" item-text="name" item-value="id" required autocomplete></v-select>
        <v-menu>
            <v-text-field slot="activator" label="Дата регистрации" v-model="registrationDate" append-icon="event" readonly></v-text-field>
            <v-date-picker v-model="registrationDate" no-title scrollable></v-date-picker>
        </v-menu>
        <v-layout justify-space-between >
            <!-- <v-date-picker v-model="registrationDate" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" first-day-of-week=1 ></v-date-picker> -->
            <v-btn @click="saveChanges($route.params.id)" color="success">Сохранить изменения</v-btn>
            <v-btn color="error" dark @click.stop="dialog=true">Удалить риэлтора</v-btn>
        </v-layout>
        <v-dialog v-model="dialog" max-width="500px">
            <v-card>
                <v-card-title>Данное действие необратимо. Вы уверены, что хотите удалить запись о выбранном риэлторе?
                </v-card-title>
                <v-card-text>
                    <v-btn color="primary" @click.stop="confirmDelete($route.params.id)" dark>Уверен</v-btn>
                    <v-btn color="error" @click.stop="cancelDelete">Нет</v-btn>
                </v-card-text>
            </v-card>
        </v-dialog>
    </v-form>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        created() {
            this.getSubDivisions();
            this.getRealtor(this.$route.params.id)
        },
        data:() => ({
                subDivisions: [],
                realtor: [],
                errors: [],
                dialog: false,
                lastName: '',
                firstName: '',
                subDivision: '',
                registrationDate: '',

                lastNameRules: {
                    required: v => !!v || 'Укажите фамилию',
                    regCheck: v => {
                        const pattern = /^[а-яА-Яa-zA-ZёЁ ]*$/
                        return !!v && pattern.test(v)  || 'Фамилия содержит недопустимые символы'
                    }
                },
                firstNameRules: {
                    required: v => !!v || 'Укажите имя',
                    regCheck: v => {
                        const pattern = /^[а-яА-Яa-zA-ZёЁ ]*$/
                        return !!v && pattern.test(v)  || 'Имя содержит недопустимые символы'
                    }
                },
                subDivisionRules: {
                    required: v => !!v || 'Выберите подразделение'
                },
                registrationDateRules: {
                    required: v => !!v || 'Укажите дату регистрации'
                },
        }),
        methods: {
            getRealtor(idRealtor) {
                axios.get('/api/Realtor/' + idRealtor)
                .then(response => {
                    let data = response.data
                    this.realtor = data
                    
                    this.lastName = data.lastName,
                    this.firstName = data.firstName,
                    this.subDivision = data.subDivision,
                    this.registrationDate = data.registrationDate.slice(0,10);
                })
                .catch(e => {
                    this.errors.push(e)
                })
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
            saveChanges(idRealtor) {
                this.realtor.lastName = this.lastName,
                this.realtor.firstName = this.firstName,
                this.realtor.subDivision = this.subDivision,
                this.realtor.registrationDate = new Date(this.registrationDate)
                axios.put('/api/Realtor/' + idRealtor, this.realtor)
                .then(response => {
                    this.$router.push('/')
                })
                .catch(e => {
                    this.errors.push(e)
                })
            },
            cancelDelete () {
                this.dialog=false;
            },
            confirmDelete (idRealtor) {
                axios.delete('/api/Realtor/' + idRealtor)
                .then(response => {
                    this.$router.push('/')
                })
                .catch(e => {
                    this.errors.push(e)
                })
            }
        },
        filters: {
            dateFormat: function (value) {
                if (!value) return ''
                return new Date(value).toLocaleDateString()
            }
        }

    }
</script>

<style scoped>

</style>
