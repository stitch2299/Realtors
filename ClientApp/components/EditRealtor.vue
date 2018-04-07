<template>
    <div>
    <v-form v-model="valid" ref="form" validation>
        <v-text-field label="Фамилия" v-model="rLastName" :rules="lastNameRules" required></v-text-field>
        <v-text-field label="Имя" v-model="rFirstName" :rules="firstNameRules"  required></v-text-field>
        <v-select label="Подразделение" v-model="rSubDivision" :rules="subDivisionRules" :items="divisions" required autocomplete></v-select>
        <v-text-field label="Дата регистрации" v-model="rRegistrationDate" :rules="registrationDateRules" required></v-text-field>
        <v-date-picker v-model="rRegistrationDate" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" first-day-of-week=1 ></v-date-picker>
        <v-btn @click="submit" :disabled="!valid" color="success">Сохранить изменения</v-btn>
    </v-form>
    </div>
</template>

<script>
    export default {
        data:() => ({
            realtorsList: [
                    { id: 1, firstName:'Кирилл', lastName:'Чечвыркин', subDivision:1, registrationDate:'2013-01-02'},
                    { id: 2, firstName:'Михаил', lastName:'Пепуркин', subDivision:2, registrationDate:'2014-02-17'},
                    { id: 3, firstName:'Антон', lastName:'Логвинов', subDivision:2, registrationDate:'2015-03-09'},
                    { id: 4, firstName:'Сергей', lastName:'Шейкель', subDivision:3, registrationDate:'2016-04-04'},
                    { id: 5, firstName:'Марина', lastName:'Любцова', subDivision:1, registrationDate:'2015-05-08'},
                    { id: 6, firstName:'Валерия', lastName:'Енотова', subDivision:1, registrationDate:'2014-06-16'},
                    { id: 7, firstName:'Алексей', lastName:'Шприц', subDivision:3, registrationDate:'2016-07-20'},
                    { id: 8, firstName:'Максим', lastName:'Шалюта', subDivision:2, registrationDate:'2013-08-02'},
                    { id: 9, firstName:'Евгений', lastName:'Пек', subDivision:2, registrationDate:'2016-09-05'},
                    { id: 10, firstName:'Олег', lastName:'Краснов', subDivision:3, registrationDate:'2014-07-24'},
                    { id: 11, firstName:'Евтихий', lastName:'Попов', subDivision:4, registrationDate:'2016-08-14'},
                    { id: 12, firstName:'Эдуард', lastName:'Лебовски', subDivision:5, registrationDate:'2016-02-13'},
                    { id: 13, firstName:'Антон', lastName:'Картон', subDivision:5, registrationDate:'2017-03-29'},
                    { id: 14, firstName:'Алексей', lastName:'Харов', subDivision:5, registrationDate:'2013-01-27'},
                    { id: 15, firstName:'Магамед', lastName:'Магамедов', subDivision:4, registrationDate:'2014-03-25'},
                    { id: 16, firstName:'Константин', lastName:'Шишка', subDivision:4, registrationDate:'2015-12-21'},
                ],

                divisions: [
                    { value:1, text: 'Росич'},
                    { value:2, text: 'Урал'},
                    { value:3, text: 'Эдельвейс'},
                    { value:4, text: 'Меркурий'},
                    { value:5, text: 'Кузбасс'},

                ],
                valid: false,
                rLastName: '',
                rFirstName: '',
                rSubDivision: '',
                rRegistrationDate: '',

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
                ],
        }),
        created() {
            this.realtorsList.forEach(el => {
                if(el.id==this.$route.params.id) {
                    this.rFirstName = el.firstName;
                    this.rLastName = el.lastName;
                    this.rSubDivision = el.subDivision;
                    this.rRegistrationDate = el.registrationDate;
                }
            })
        },
        methods: {
            submit() {
                if (this.$refs.form.validate()){
                    console.log(this)
                }
            },
        },
        computed: {
            isOnlyWords() {
                return /^[А-Яа-я]+$/.test(this.rLastName)
            }
        }

    }
</script>

<style scoped>
    .btn {
        float:right;
    }
</style>
