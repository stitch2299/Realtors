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
            <v-layout justify-space-between >
                <v-btn @click="saveChanges($route.params.id)" color="success">Сохранить изменения</v-btn>
                <v-btn color="error" dark @click.stop="dialog=true">Удалить риэлтора</v-btn>
            </v-layout>
            <v-dialog v-model="dialog" max-width="500px">
            <v-card>
                <v-card-title>Данное действие необратимо. Вы уверены, что хотите удалить запись о выбранном риэлторе?
                </v-card-title>
                <v-card-text>
                    <v-btn color="primary" @click.stop="confirmDelete($route.params.id)" dark>Уверен</v-btn>
                    <v-btn color="error" @click.stop="dialog=false">Нет</v-btn>
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
            menu: false,
            valid : true,
            dialog: false,
            lastName: '',
            firstName: '',
            subDivision: '',
            registrationDate: '',
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
