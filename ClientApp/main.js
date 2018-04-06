import Vue from 'vue'
import App from 'components/App'
import Vuetify from 'vuetify'
import Realtors from './components/Realtors'
import router from './router'
import 'vuetify/dist/vuetify.min.css'
import 'mdi/css/materialdesignicons.css'

Vue.use(Vuetify)

Vue.component('realtors', Realtors)

new Vue({
    el: '#app',
    router,
    render: h => h(App)
})