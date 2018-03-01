<template>
    <div class="row">
        <div class="col-sm-8">
            <div class="video-frame">
                <iframe width="100%" height="405" :src="video.urlDoVideo" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
            </div>
        </div>
        <div class="col-sm-4">
            <h2>{{ video.titulo }}</h2>
            <div class="box">
                {{ video.descricao }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
  data() {
      return {
          video: {}
      }
  },
  async mounted() {
      this.fetch(this.$route.params.id)
  },
  methods: {
      async fetch(id) {
          this.video = (await this.$http.get(`http://localhost:49972/videos/${id}`)).body
      }
  }
}
</script>

<style scoped>

</style>


