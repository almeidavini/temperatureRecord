import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../views/Medicoes.vue')
    // component: () => import('../views/Home.vue')
  },
  {
    path: '/colaboradores',
    name: 'Colaboradores',
    component: () => import('../views/Colaboradores.vue')
  },
  {
    path: '/editarcolaborador/:id',
    name: 'EditarColaborador',
    component: () => import('../views/EditarColaborador.vue')
  },
  {
    path: '/medicaocolaborador/:id',
    name: 'MedicaoColaborador',
    component: () => import('../views/MedicaoColaborador.vue')
  },
  {
    path: '/novocolaborador',
    name: 'NovoColaborador',
    component: () => import('../views/NovoColaborador.vue')
  },
  {
    path: '/medicoes',
    name: 'Medicoes',
    component: () => import('../views/Medicoes.vue')
  },
  {
    path: '/novamedicao',
    name: 'NovaMedicao',
    component: () => import('../views/NovaMedicao.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
