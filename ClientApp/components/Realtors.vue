<template>
    <div>
        <v-text-field v-model="search" class="lastNameFilter" name="lastNameFilter" label="Отфильтровать по фамилии:"></v-text-field>
        <v-data-table :items="realtorsList" :headers="headers" :search="search" class="elevation-1" :custom-filter="customFilter" disable-initial-sort>
        <tr slot="items" slot-scope="props" @dblclick="edit(props.item.id)">
            <td> {{ props.item.id }} </td>
            <td> {{ props.item.lastName }} </td>
            <td> {{ props.item.firstName }} </td>
            <td> {{ divisions[props.item.subDivision] }} </td>
            <td> {{ props.item.registrationDate }} </td>
        </tr>
        </v-data-table>
    
    </div>
</template>

<script>
    export default {
        data() {
            return {
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
                buttonText: 'Скрыть', 
                realtorsShow: true,
                search: '',
                headers: [
                    { text: 'Id', sortable: false },
                    { text: 'Имя', sortable: false },
                    { text: 'Фамилия', sortable: false },
                    { text: 'Подразделение', sortable: false },
                    { text: 'Дата регистрации', sortable: false }
                ],
                divisions: { 1 : 'Росич', 2: 'Урал', 3: 'Эдельвейс', 4: 'Меркурий', 5: 'Кузбасс'},

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
            filterBySearch (item, searchInput) {
                if(item.lastName.toLowerCase().includes(searchInput.toLowerCase())) {
                    return true
                }else if(item.firstName.toLowerCase().includes(searchInput.toLowerCase())) {
                    return true
                } else if(this.divisions[item.subDivision].toLowerCase().includes(searchInput.toLowerCase())) {
                         return true
                }
            },
            edit(id) {
                this.$router.push('/edit/' + id)
            },
            customFilter(items, search, filter) {
                search = search.toString().toLowerCase()
                return items.filter(row => filter(row["lastName"], search));

            }

        },
        components: { 
        },
        computed: {
            searchInput () {
                if(this.$route.params.searchString){
                    return this.$route.params.searchString
                }
                else
                    return ''
            }
        }
    }
</script>

<style scoped>
</style>
