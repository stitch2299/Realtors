<template>
    <div>

    <table class="realTable">
        <thead>
            <tr>
                <th class="header">Id</th>
                <th class="header">Фамилия</th>
                <th class="header">Имя</th>
                <th class="header">Код подразделения</th>
                <th class="header">Подразделение</th>
                <th class="header">Дата регистрации</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in realtorsList" :key="item.id" @dblclick="edit(item.id)">
                <td> {{ item.id }} </td>
                <td> {{ item.lastName }} </td>
                <td> {{ item.firstName }} </td>
                <td> {{ item.subDivision }} </td>
                <td> {{ divisions[item.subDivision] }} </td>
                <td> {{ item.registrationDate }} </td>
            </tr>
        </tbody>
    </table>

    <!-- <input type="text" placeholder="azazaza" v-model="inputText"> -->
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
                id: "1", firstName: "2", lastName: "3", subDivision: "4", registrationDate: "5", inputText: "", input: '',
                divisions: { 1 : 'Росич', 2: 'Урал', 3: 'Эдельвейс', 4: 'Меркурий', 5: 'Кузбасс'}
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
            filter (item, inputText) { 
                if(item.firstName.toLowerCase().includes(inputText.toLowerCase())){
                    return true
                }
            },
            edit (id) {
                this.$router.push('/edit/' + id)
            },
        },
        components: { 
        }
    }
</script>

<style scoped>
    .realTable {
    width: 1000px;
	font-family:Arial, Helvetica, sans-serif;
	color:rgb(0, 0, 0);
	font-size:14px;
	text-shadow: 1px 1px 0px rgb(245, 245, 245);
	background:rgb(131, 131, 131);
	margin:auto;
	border:#ccc 1px solid;
	border-collapse:separate;

	border-radius:3px;

	box-shadow: 0 1px 2px #d1d1d1;
}
 
.realTable th {
    font-size: 16px;
	padding:20px 25px;
	border-top:1px solid #fafafa;
	border-bottom:1px solid #e0e0e0;
 
	background: rgb(197, 224, 255);
}
.realTable th:first-child{
	text-align: center;
}
.realTable tr:first-child th:first-child{
	border-top-left-radius:3px;
}
.realTable tr:first-child th:last-child{
	border-top-right-radius:3px;
}
.realTable tr{
	text-align: center;
}
.realTable tr td:first-child{
	text-align: center;
    width: 30px;
	border-left: 0;
}
.realTable tr td {
	padding:7px 15px 7px 15px;
	border-top: 1px solid #ffffff;
	border-bottom:1px solid #e0e0e0;
	border-left: 1px solid #e0e0e0;
 
	background: #e2f1fd;
}
/* .realTable tr:nth-child(even) td{
	background: rgb(239, 253, 255);
} */
.realTable tr:last-child td{
	border-bottom:0;
}
.realTable tr:hover td{
	background: rgb(255, 200, 137);
}
 
</style>
