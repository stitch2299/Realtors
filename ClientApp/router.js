import Vue from 'vue'
import Router from 'vue-router'
import Realtors from './components/Realtors'
import EditRealtor from './components/EditRealtor'

Vue.use(Router)

export default new Router ({
    mode: 'history',
    base: __dirname,
    routes: [ 
        { path: '/', component: Realtors },
        { path: '/edit/:id', component: EditRealtor }
        // { path: '/edit/:id',  component: EditRealtor }
        // '/edit/' + id 
    ]
})