﻿import Vue from 'vue'
import Router from 'vue-router'

import Frame from '@/components/layout/Frame'
import NotFound from '@/components/common/NotFound'

import Elandmall from '@/components/view/Elandmall'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: Frame,
      redirect: '/shop/elandmall'
    },
    {
        path: '/shop',
        component: Frame,
        redirect: '/shop/elandmall',
        children: [
            {
                path: 'elandmall',
                component: Elandmall
            }
        ]
    },
    { path: '*', component: NotFound }
  ]
})
