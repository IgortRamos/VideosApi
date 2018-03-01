using Api.Services.Users;
using Api.ViewModels.Videos;
using AutoMapper;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers.Videos
{
    [Route("[controller]")]
    public class VideosController : Controller
    {
        private static bool cargaInicialRealizada;
        private IMapper _mapper;
        private VideoService _videos;

        public VideosController(
            IMapper mapper,
            VideoService videos)
        {
            _mapper = mapper;
            _videos = videos;

            if (!cargaInicialRealizada)
            {
                var video1 = new VideoRequest 
                { 
                    Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af1"), 
                    Titulo = "Novo Canal da Hiper!", 
                    UrlDoVideo = "https://www.youtube.com/embed/-2J16V-xl5g", 
                    Descricao = "Esse é o novo canal da Hiper! <br/>Por aqui vamos compartilhar mais informações sobre o nosso produto e dicas que ajudarão você a ter mais sucesso no seu negócio!", 
                    UrlDaImagem = "https://i.ytimg.com/vi/-2J16V-xl5g/hqdefault.jpg?sqp=-oaymwEZCPYBEIoBSFXyq4qpAwsIARUAAIhCGAFwAQ==&rs=AOn4CLCgED7suQuXLGz687-avCJlwy_iGg" 
                };

                var video2 = new VideoRequest 
                { 
                    Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af3"),
                    Titulo = "Webinar #01: Como encontrar mais oportunidadebs de vendas",
                    UrlDoVideo = "https://www.youtube.com/embed/4LHDGZTaa-c",
                    Descricao = "Nosso COO, Marinho Silva e nosso Head de Expansão, Jadson Pollheim, dão dicas para você encontrar as melhores oportunidades de vendas.",
                    UrlDaImagem = "https://i.ytimg.com/vi/4LHDGZTaa-c/hqdefault.jpg?sqp=-oaymwEYCKgBEF5IVfKriqkDCwgBFQAAiEIYAXAB&rs=AOn4CLClb-th-ekP-gMT9mWk-56o4Y8I1Q"    
                };

                var video3 = new VideoRequest 
                { 
                    Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af2"), 
                    Titulo = "Webinar #02: Planejamento Financeiro", 
                    UrlDoVideo = "https://www.youtube.com/embed/7VLKE26Nxlk", 
                    Descricao = "Nosso COO, Marinho Silva e nosso Controller, Cleiton Masche, estiveram ao vivo no Facebook compartilhando dicas para você iniciar o planejamento financeiro da sua empresa.", 
                    UrlDaImagem = "https://i.ytimg.com/vi/7VLKE26Nxlk/hqdefault.jpg?sqp=-oaymwEYCKgBEF5IVfKriqkDCwgBFQAAiEIYAXAB&rs=AOn4CLDMweNn3kNTawTkiSFmwf0dhBW_0w"
                };

                Post(video1);
                Post(video2);
                Post(video3);

                cargaInicialRealizada = true;
            }
        }

        [HttpDelete("{Guid}")]
        public StatusResponse Delete(Guid guid) => _videos.Delete(guid);

        [HttpGet]
        public VideosStatusResponse Get() => _videos.GetAll();

        [HttpGet("{Guid}")]
        public VideoResponse Get(Guid guid) => _videos.GetById(guid);

        [HttpPost]
        public StatusResponse Post([FromBody]VideoRequest videoRequest) => _videos.Add(videoRequest);

        [HttpPut("{Guid}")]
        public StatusResponse Put(Guid id, [FromBody]VideoRequest videoRequest) => _videos.Update(videoRequest);
    }
}