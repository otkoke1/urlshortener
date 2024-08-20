import Vue from 'vue'
import Router from 'vue-router'
import Tasks from './views/Tasks.vue'
import New from './views/New.vue'
import Show from './views/Show.vue'
import Edit from './views/Edit.vue'

Vue.use(Router)

const router = new Router({
   mode: 'history',
   routes: [
      {
         path: '/',
         redirect: '/tasks'
      },
      {
         path: '/tasks',
         name: 'Tasks',
         component: Tasks
      },
      {
         path: '/tasks/new',
         name: 'New',
         component: New
      },
      {
         path: '/tasks/show/:id',
         name: 'Show',
         component: Show
      },
      {
         path: '/tasks/edit/:id',
         name: 'Edit',
         component: Edit
      },
   ]
})

export default router