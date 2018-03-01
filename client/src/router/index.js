import Vue from 'vue'
import Router from 'vue-router'
import VideoList from '@/components/VideoList'
import VideoPage from '@/components/VideoPage'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'VideoList',
      component: VideoList
    },
    {
      path: '/video/:id',
      name: 'VideoPage',
      component: VideoPage
    }
  ]
})
