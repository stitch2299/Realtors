<template>
    <v-form>
        <v-text-field label="Имя" v-model="rLastName" required></v-text-field>
        <v-text-field label="Фамилия" v-model="rFirstName"  required></v-text-field>
        <v-text-field label="Подразделение" v-model="rSubDivision"  required></v-text-field>
        <v-text-field label="Дата регистрации" v-model="rRegistrationDate"  required></v-text-field>
    </v-form>
</template>

<script>
    export default {
        data:() => ({
            realtorsList: [
                    { id: "1", firstName:"Кирилл", lastName:"Чечвыркин", subDivision:"Первое", registrationDate:"2013-01-02"},
                    { id: "2", firstName:"Михаил", lastName:"Пепуркин", subDivision:"Второе", registrationDate:"2014-02-17"},
                    { id: "3", firstName:"Антон", lastName:"Логвинов", subDivision:"Второе", registrationDate:"2015-03-09"},
                    { id: "4", firstName:"Сергей", lastName:"Шейкель", subDivision:"Третье", registrationDate:"2016-04-04"},
                    { id: "5", firstName:"Марина", lastName:"Любцова", subDivision:"Первое", registrationDate:"2015-05-08"},
                    { id: "6", firstName:"Валерия", lastName:"Енотова", subDivision:"Первое", registrationDate:"2014-06-16"},
                    { id: "7", firstName:"Алексей", lastName:"Шприц", subDivision:"Третье", registrationDate:"2016-07-20"},
                    { id: "8", firstName:"Максим", lastName:"Шалюта", subDivision:"Второе", registrationDate:"2013-08-02"},
                    { id: "9", firstName:"Евгений", lastName:"Пек", subDivision:"Второе", registrationDate:"2016-09-05"},
                    { id: "10", firstName:"Олег", lastName:"Краснов", subDivision:"Третье", registrationDate:"2014-07-24"},
                    { id: "11", firstName:"Евтихий", lastName:"Попов", subDivision:"Четвертое", registrationDate:"2016-08-14"},
                    { id: "12", firstName:"Эдуард", lastName:"Лебовски", subDivision:"Пятое", registrationDate:"2016-02-13"},
                    { id: "13", firstName:"Антон", lastName:"Картон", subDivision:"Пятое", registrationDate:"2017-03-29"},
                    { id: "14", firstName:"Алексей", lastName:"Харов", subDivision:"Пятое", registrationDate:"2013-01-27"},
                    { id: "15", firstName:"Магамед", lastName:"Магамедов", subDivision:"Четвертое", registrationDate:"2014-03-25"},
                    { id: "16", firstName:"Константин", lastName:"Шишка", subDivision:"Четвертое", registrationDate:"2015-12-21"},
                ],
                rLastName: '', rFirstName: '', rSubDivision: '', rRegistrationDate: ''
        }),
        created(){
            this.realtorsList.forEach(el => {
                if(el.id==this.$route.params.id) {
                    this.rFirstName = el.firstName;
                    this.rLastName = el.lastName;
                    this.rSubDivision = el.subDivision;
                    this.rRegistrationDate = el.registrationDate;
                }
            })
        }
    }
</script>

<style scoped>

</style>
