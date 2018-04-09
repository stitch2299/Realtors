<template>
    <div>
    <v-form ref="form">
        <v-text-field label="Фамилия" v-model="lastName" :rules="[lastNameRules.required, lastNameRules.regCheck]" required></v-text-field>
        <v-text-field label="Имя" v-model="firstName" :rules="[firstNameRules.required, firstNameRules.regCheck]"  required></v-text-field>
        <v-select label="Подразделение" v-model="subDivision" :rules="[subDivisionRules.required]" :items="divisions" required autocomplete></v-select>
        <v-menu>
            <v-text-field slot="activator" label="Дата регистрации" v-model="registrationDate" append-icon="event" readonly></v-text-field>
            <v-date-picker v-model="registrationDate" no-title scrollable></v-date-picker>
        </v-menu>
        <v-layout justify-space-between >
            <!-- <v-date-picker v-model="registrationDate" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" first-day-of-week=1 ></v-date-picker> -->
            <v-btn @click="submit" color="success">Сохранить изменения</v-btn>
            <v-btn color="error" dark @click.stop="dialog=true">Удалить риэлтора</v-btn>
        </v-layout>
        <v-dialog v-model="dialog" max-width="500px">
            <v-card>
                <v-card-title>Данное действие необратимо. Вы уверены, что хотите удалить запись о выбранном риэлторе?
                </v-card-title>
                <v-card-text>
                    <v-btn color="primary" @click.stop="confirmDelete" dark>Уверен</v-btn>
                    <v-btn color="error" @click.stop="cancelDelete">Нет</v-btn>
                </v-card-text>
            </v-card>
        </v-dialog>
    </v-form>
    </div>
</template>

<script>
    export default {
        data:() => ({
                divisions: [
                    { value:1, text: 'Росич'},
                    { value:2, text: 'Урал'},
                    { value:3, text: 'Эдельвейс'},
                    { value:4, text: 'Меркурий'},
                    { value:5, text: 'Кузбасс'},

                ],
                dialog: false,
                lastName: '',
                firstName: '',
                subDivision: '',
                registrationDate: '',

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
                },
        }),
        created() {
            this.realtorsList.forEach(el => {
                if(el.id==this.$route.params.id) {
                    this.firstName = el.firstName;
                    this.lastName = el.lastName;
                    this.subDivision = el.subDivision;
                    this.registrationDate = el.registrationDate;
                }
            })
        },
        methods: {
            submit() {
                if (this.$refs.form.validate()){
                    this.$router.push('/')
                }
            },
            cancelDelete () {
                this.dialog=false;
            },
            confirmDelete () {
                this.dialog=false;
                this.$router.push('/')
            }
        },
        computed: {
            isOnlyWords() {
                return /^[А-Яа-я]+$/.test(this.LastName)
            }
        }

    }
</script>

<style scoped>

</style>
