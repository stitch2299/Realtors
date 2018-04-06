<template>
    <div>
    <v-toolbar color="blue">
        <v-toolbar-side-icon></v-toolbar-side-icon>
        <v-toolbar-title>Риэлторы</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat>Список</v-btn>
        <v-btn flat>Новый</v-btn>
        
        
            <v-flex xs8>
                <v-text-field name="search" label="Поиск" id="searching"></v-text-field>
            </v-flex>
            <v-btn flat>Искать
            </v-btn>
        

        </v-toolbar-items>
    </v-toolbar>

    <v-data-table :items="realtorsList" hide-headers disable-initial-sort>
        <template slot="items" slot-scope="props" :filter="filter(props.item, inputText)" } >
            <td class="text-xs-center">{{ props.item.id }}</td>
            <td class="text-xs-center">{{ props.item.firstName }}</td>
            <td class="text-xs-center">{{ props.item.lastName }}</td>
            <td class="text-xs-center">{{ props.item.subDivision }}</td>
            <td class="text-xs-center">{{ props.item.registratingDate }}</td>
        </template>
    </v-data-table>

    <input type="text" placeholder="azazaza" v-model="inputText">
    </div>
</template>

<script>
    import ItemEdit from "./ItemEdit"
    export default {
        data() {
            return {
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
                buttonText: 'Скрыть',
                realtorsShow: true,
                id: "1", firstName: "2", lastName: "3", subDivision: "4", registrationDate: "5", inputText: "", input: '',
            }
        },
        methods: {
            toggleTable() {
                if(this.realtorsShow){
                    this.buttonText = 'Показать';
                    this.realtorsShow = false;
                }
                else {
                    this.buttonText = 'Скрыть';
                    this.realtorsShow = true;
                }
            },
            realtorEdit() {
                this.id = event.target.parentNode.querySelectorAll('td')[0].innerHTML
                this.firstName = event.target.parentNode.querySelectorAll('td')[1].innerHTML
                this.lastName = event.target.parentNode.querySelectorAll('td')[2].innerHTML
                this.subDivision = event.target.parentNode.querySelectorAll('td')[3].innerHTML
                this.registrationDate = event.target.parentNode.querySelectorAll('td')[4].innerHTML
            },
            filter (item, inputText) { 
                if(item.firstName.toLowerCase().includes(inputText.toLowerCase())){
                    return true
                }
            }
        },
        components: { 'itemedit': ItemEdit
        }
    }
</script>

<style>

</style>
