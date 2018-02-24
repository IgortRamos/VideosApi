using System;

namespace Api.ViewModels.Videos
{
    public class VideoRequest
    {
        public string Descricao { get; set; }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string UrlDaImagem { get; set; }
        public string UrlDoVideo { get; set; }
    }
}