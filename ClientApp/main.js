import Vue from 'vue'
import App from 'components/App'
import Vuetify from 'vuetify'
import Realtors from './components/Realtors'
import router from './router'
import ElementUI from 'element-ui'
import Moment from 'moment'
import 'vuetify/dist/vuetify.min.css'
import 'mdi/css/materialdesignicons.css'
import 'element-ui/lib/theme-chalk/index.css'
import locale from 'element-ui/lib/locale/lang/ru-RU' 

Vue.use(Vuetify)
Vue.use(ElementUI, { locale })

Vue.component('realtors', Realtors)

new Vue({
    el: '#app',
    router,
    render: h => h(App)
})