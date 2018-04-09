<template>
    <div>
        <v-text-field v-model="search" class="lastNameFilter" name="lastNameFilter" label="Отфильтровать по фамилии:"></v-text-field>
        <v-data-table :items="realtorsList" :headers="headers" :search="search" class="elevation-1" :custom-filter="customFilter" disable-initial-sort>
        <tr slot="items" slot-scope="props" @dblclick="edit(props.item.id)">
            <td> {{ props.item.id }} </td>
            <td> {{ props.item.guid }} </td>
            <td> {{ props.item.lastName }} </td>
            <td> {{ props.item.firstName }} </td>
            <td> {{ props.item.subDivision }} </td>
            <td> {{ props.item.registrationDate | dateFormat }} </td>
        </tr>
        </v-data-table>
        <div></div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        created() {
            this.getTable()
        },
        data() {
            return {
                realtorsList: [],
                buttonText: 'Скрыть', 
                realtorsShow: true,
                search: '',
                test: [],
                errors: [],
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
                search = search.toString().toLowerCase()
                return items.filter(row => filter(row["lastName"], search));

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
