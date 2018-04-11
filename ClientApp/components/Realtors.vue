<template>
    <div>
        <v-card @test="test1">
            <v-card-title>
                <v-layout>
                <v-flex xs3>
                    <v-text-field class="v-text-field-filter-by-lastname" append-icon="search" v-model="lastNameFilter" 
                    single-line hide-details name="lastNameFilter" label="Фильтр по фамилии:"></v-text-field>
                </v-flex>
                <v-flex>
                    <el-date-picker style="float:right" v-model="dates" type="daterange" format="dd.MM.yyyy" range-separator="до" 
                    start-placeholder="Начало" end-placeholder="Конец" >
                    </el-date-picker>
                </v-flex>
                </v-layout>
            </v-card-title>
            <v-data-table :items="realtorsList" :headers="headers" :filter="filter" :search="lastNameFilter" class="elevation-1" 
            :custom-filter="customFilter" disable-initial-sort>
            <tr slot="items" slot-scope="props" @dblclick="edit(props.item.id)">
                <td> {{ props.item.id }} </td>
                <td> {{ props.item.guid }} </td>
                <td> {{ props.item.lastName }} </td>
                <td> {{ props.item.firstName }} </td>
                <td> {{ props.item.subDivision }} </td>
                <td> {{ props.item.registrationDate | dateFormat }} </td>
            </tr>
            </v-data-table>
        </v-card>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        created() {
            this.getTable()
            // this.getDateInterval(this.dateInterval)
        },
        data: () => ({
                realtorsList: [],
                buttonText: 'Скрыть', 
                realtorsShow: true,
                searchString: '',
                lastNameFilter: '',
                errors: [],
                dateInterval: [ null, null ],
                headers: [
                    { text: 'Id', sortable: false },
                    { text: 'Guid', sortable: false },
                    { text: 'Фамилия', sortable: false },
                    { text: 'Имя', sortable: false },
                    { text: 'Подразделение', sortable: false },
                    { text: 'Дата регистрации', sortable: false }
                ],                 
        }),
        computed: {
            dates: {
                get: function()  {
                    if(this.dateInterval == null) {
                        this.dateInterval = [null, null]
                    }
                    return this.dateInterval
                },
                set: function(value) {
                    this.dateInterval = value
                    if(this.dateInterval != null) {
                        this.dateInterval[0] = new Date(this.dateInterval[0].setHours(0)+10800000)
                        this.dateInterval[1] = new Date(this.dateInterval[1].setHours(0)+10800000)
                    }
                }
            },
            search: function () {
                return this.$route.params.searchString
            }
        },
        methods: {
            edit(id) {
                this.$router.push('/edit/' + id)
            },
            
            customFilter(items, search, filter) {
                return items.filter(row => filter(
                    row["lastName"], 
                    row["firstName"], 
                    row["subDivision"], 
                    new Date(row["registrationDate"]), 
                    this.search, 
                    this.lastNameFilter, 
                    this.dateInterval ))
            },
            filter(lastName, firstName, subDivision, registrationDate, searchString, lastNameFilter, dateInterval) {
                if(lastName.toLowerCase().includes(lastNameFilter.toLowerCase()) && 
                    this.checkDate(dateInterval, registrationDate) &&
                    this.checkSearch(lastName, firstName, subDivision, searchString))
                    return true
            },
            checkDate(dateInterval, registrationDate) {
                if(dateInterval[0] != null && dateInterval[1] != null) {
                    return dateInterval[0] <= registrationDate && 
                        dateInterval[1] >= registrationDate
                }
                return true
            },
            checkSearch(lastName, firstName, subDivision, search) {
                if(search != undefined) {
                    return lastName.toLowerCase().includes(search.toLowerCase()) || 
                        firstName.toLowerCase().includes(search.toLowerCase()) ||
                        subDivision.toLowerCase().includes(search.toLowerCase())
                }
                return true
            },
            getTable() {
                axios.get('/api/Realtor')
                .then(response => {
                    let data = response.data
                    this.realtorsList = data
                })
                .catch(e => {
                    this.errors.push(e)
                })
            },
            getDateInterval() {
                axios.get('/GetDateInterval')
                .then(response => {
                    let data = response.data[0]
                    this.dateInterval.push(new Date(data['min']))
                    this.dateInterval.push(new Date(data['max']))
                })
                .catch(e => {
                    this.errors.push(e)
                })
            },
            test1() {
                console.log('пиймав')
            }
        },
        filters: {
            dateFormat: function (value) {
                if (!value) return ''
                return new Date(value).toLocaleDateString()
            }
        },
    }
</script>

<style>
    .v-text-field-filter-by-lastname {
        padding:0px;
    }
    .v-text-field-filter-by-lastname label {
        top: 0px;
    }
</style>
