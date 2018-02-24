using Domain.Base;
using System;

namespace Domain.Entities.Videos
{
    public class Video : MessagePattern
    {
        public Video()
        { }

        public Video(Guid id, string titulo, string urlDoVideo)
        {
            SetId(id);
            SetTitulo(titulo);
            SetUrlDoVideo(urlDoVideo);
        }

        public string Descricao { get; private set; }

        public Guid Id { get; private set; }

        public string Titulo { get; private set; }

        public string UrlDaImagem { get; private set; }

        public string UrlDoVideo { get; private set; }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetId(Guid id)
        {
            Id = id;

            if (Id == null || Id == Guid.Empty)
                AddErrorMessage("Guid não pode ser nulo ou vazio");
        }

        public void SetTitulo(string titulo)
        {
            Titulo = titulo;

            if (string.IsNullOrWhiteSpace(Titulo))
                AddErrorMessage("O título é necessário");
        }

        public void SetUrlDaImagem(string urlDaImagem)
        {
            UrlDaImagem = urlDaImagem;
        }

        public void SetUrlDoVideo(string urlDoVideo)
        {
            UrlDoVideo = urlDoVideo;

            if (string.IsNullOrWhiteSpace(UrlDoVideo))
                AddErrorMessage("A URL do vídeo é necessário");
        }
    }
}