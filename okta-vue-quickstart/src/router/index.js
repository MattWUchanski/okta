import { LoginCallback, navigationGuard } from '@okta/okta-vue'
import { createRouter, createWebHistory } from 'vue-router'
import ProfileComponent from '@/components/Profile-vue'
import Authcomponent from '@/components/Auth-component'
import List2137 from '@/components/List-2137'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home-vue',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/login/callback',
    component: LoginCallback
  },
  {
    path: '/profile',
    component: ProfileComponent,
  },
  {
    path: '/auth-component',
    name: 'auth-component',
    component: Authcomponent,
  },
  {
    path: '/List-2137',
    name: 'List-2137',
    component: List2137,
    
  } 
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach(navigationGuard)

export default router
