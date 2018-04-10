<template>
    <div>
        <v-card>
            <v-card-title>
                <v-layout>
                <v-flex xs3>
                    <v-text-field class="v-text-field-filter-by-lastname" append-icon="search" v-model="search" single-line hide-details name="lastNameFilter" label="Фильтр по фамилии:"></v-text-field>
                </v-flex>
                <v-flex>
                    <el-date-picker style="float:right" v-model="dateInterval" type="datetimerange" format="dd.MM.yyyy" range-separator="до" start-placeholder="Начало" end-placeholder="Конец" :clearable="false">
                    </el-date-picker>
                </v-flex>
                </v-layout>
            </v-card-title>
        <v-data-table :items="realtorsList" :headers="headers" :filter="filter" :search="search" class="elevation-1" :custom-filter="customFilter" disable-initial-sort>
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
        {{ dateInterval }}
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        created() {
            this.getTable()
            this.getDateInterval(this.dateInterval)
        },
        data() {
            return {
                realtorsList: [],
                buttonText: 'Скрыть', 
                realtorsShow: true,
                searchString: '',
                search: [],
                test: [],
                errors: [],
                dateInterval: [],
                headers: [
                    { text: 'Id', sortable: false },
                    { text: 'Guid', sortable: false },
                    { text: 'Фамилия', sortable: false },
                    { text: 'Имя', sortable: false },
                    { text: 'Подразделение', sortable: false },
                    { text: 'Дата регистрации', sortable: false }
                ],                
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
            edit(id) {
                this.$router.push('/edit/' + id)
            },
            customFilter(items, search, filter) {
                return items.filter(row => filter(row["lastName"], new Date(row["registrationDate"]), search, this.dateInterval ))
                    
            },
            filter(val1, val2, search, dateInterval) {
                if(!search) {
                    return val1 != null && typeof val1 !== 'boolean' && (dateInterval[0] <= val2) && (val2 <= dateInterval[1])
                }
                return val1 != null && typeof val1 !== 'boolean' && (val1.toString().toLowerCase().indexOf(search) !== -1) && (dateInterval[0] <= val2) && (val2 <= dateInterval[1])
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
