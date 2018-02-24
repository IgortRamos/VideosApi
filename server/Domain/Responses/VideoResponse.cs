using Domain.Entities.Videos;
using System;

namespace Domain.Responses
{
    public class VideoResponse
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string UrlDaImagem { get; set; }
        public string UrlDoVideo { get; set; }
    }
}