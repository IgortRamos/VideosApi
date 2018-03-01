<template>
    <div class="video-card" :style="`background-image: url(${ urlDaImagem })`">
        <div class="content">
            <h3 class="title">{{ titulo }}</h3>
            <a @click="assistir(id)" class="btn btn-primary btn-block">Assistir</a>
        </div>
    </div>
</template>

<script>
export default {
  props: {
      titulo: String,
      id: String,
      urlDaImagem: String
  },
  methods: {
      assistir(id) {
          this.$router.push({ name: "VideoPage", params: { id: id } })
      }
  }
}
</script>


<style scoped>

        .video-card {
            position: relative;
            border-radius: 15px;
            color: #fff;
            overflow: hidden;
            min-height: 300px;
            max-height: 300px;
            margin-bottom: 50px;
            
            background-repeat: no-repeat;
            background-position: center;
            background-size: cover;

            box-shadow: 0 4px 7px #999;
        }

        .video-card:before {
            content: "";
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: #000;
            opacity: .2;
        }

        .video-card .title {    
            text-align: left;
            font-size: 1.3em;
            margin-top: 0;
            font-family: Montserrat, 'sans-serif';
            font-weight: 700;
            line-height: 1em;
            color: #333;    
        }

        .video-card .content {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            padding: 20px;
            background: #fff;
        }

    </style>


