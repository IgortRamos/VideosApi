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
                var video1 = new VideoRequest { Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af1"), Titulo = "Titulo 1", UrlDoVideo = "UrlDoVideo 1", Descricao = "Descricao 1", UrlDaImagem = "UrlDaImagem 1" };
                var video2 = new VideoRequest { Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af2"), Titulo = "Titulo 2", UrlDoVideo = "UrlDoVideo 2", Descricao = "Descricao 2", UrlDaImagem = "UrlDaImagem 2" };
                var video3 = new VideoRequest { Id = Guid.Parse("60db4ee8-68ae-4e4a-8f0a-1d8386dc8af3"), Titulo = "Titulo 3", UrlDoVideo = "UrlDoVideo 3", Descricao = "Descricao 3", UrlDaImagem = "UrlDaImagem 3" };

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