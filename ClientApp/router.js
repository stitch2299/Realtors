import Vue from 'vue'
import Router from 'vue-router'
import Realtors from './components/Realtors'
import EditRealtor from './components/EditRealtor'
import NewRealtor from './components/NewRealtor'
import AreYouSureAboutThat from './components/AreYouSureAboutThat'

Vue.use(Router)

export default new Router ({
    mode: 'history',
    base: __dirname,
    routes: [ 
        { path: '/', component: Realtors },
        { path: '/edit/:id', component: EditRealtor },
        { path: '/list', component: Realtors },
        { path: '/new', component: NewRealtor },
        { path: '/search/:searchString?', component: Realtors },
        { path: '/areyousureaboutthat', component: AreYouSureAboutThat }
        // { path: '/edit/:id',  component: EditRealtor }
        // '/edit/' + id 
    ]
})