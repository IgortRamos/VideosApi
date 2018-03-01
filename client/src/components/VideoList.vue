<template>
  <div class="row">
        <div v-for="video in videos" :key="video.id" class="col-sm-4">
            <video-card
                :titulo="video.titulo"
                :id="video.id"
                :url-da-imagem="video.urlDaImagem">
            </video-card>
        </div>
    </div>
</template>

<script>

import VideoCard from '@/components/VideoCard'

export default {
  components: {
      VideoCard
  },
  data() {
      return {
          videos: []
      }
  },
  async mounted() {
      this.fetch()
  },
  methods: {
      async fetch() {
          let response = (await this.$http.get('http://localhost:49972/videos')).body
          this.videos = response.videos
      }
  }
}
</script>


