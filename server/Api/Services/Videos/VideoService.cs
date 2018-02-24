using Api.Services.Base;
using Api.ViewModels.Videos;
using AutoMapper;
using Data.Context;
using Domain.Entities.Videos;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services.Users
{
    public class VideoService : IScopedServiceBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private StatusResponse _statusResponse;

        public VideoService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _statusResponse = new StatusResponse();
        }

        public StatusResponse Add(VideoRequest videoRequest)
        {
            if (videoRequest == null)
            {
                _statusResponse.AddErrorMessage("O objeto não está correto");
                return _statusResponse;
            }

            var video = MontaVideo(videoRequest);

            if (video.IsFailure)
            {
                _statusResponse.AddErrorsMessages(video.Errors);
                return _statusResponse;
            }

            if (_context.Videos.Any(x => x.Id == video.Id))
            {
                _statusResponse.AddErrorMessage("Vídeo já existente");
                return _statusResponse;
            }

            _context.Videos.Add(video);
            _context.SaveChanges();

            return _statusResponse;
        }

        public StatusResponse Delete(Guid id)
        {
            var video = _context.Videos.Find(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();
            }
            else
            {
                _statusResponse.AddErrorMessage("Vídeo não encontrado");
            }

            return _statusResponse;
        }

        public VideosStatusResponse GetAll()
        {
            var videos = _context.Videos.ToList();
            var videosResponse = _mapper.Map<IEnumerable<VideoResponse>>(videos);
            return new VideosStatusResponse { Videos = videosResponse };
        }

        public VideoResponse GetById(Guid id)
        {
            var video = _context.Videos.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<VideoResponse>(video);
        }

        public StatusResponse Update(VideoRequest videoRequest)
        {
            if (videoRequest == null)
            {
                _statusResponse.AddErrorMessage("O objeto não está correto");
                return _statusResponse;
            }

            var video = MontaVideo(videoRequest);

            if (video.IsFailure)
            {
                _statusResponse.AddErrorsMessages(video.Errors);
                return _statusResponse;
            }

            if (!_context.Videos.Any(x => x.Id == video.Id))
            {
                _statusResponse.AddErrorMessage("Vídeo não encontrado");
                return _statusResponse;
            }

            _context.Videos.Update(video);
            _context.SaveChanges();

            return _statusResponse;
        }

        private Video MontaVideo(VideoRequest videoRequest)
        {
            var video = new Video(videoRequest.Id, videoRequest?.Titulo, videoRequest?.UrlDoVideo);

            if (video.IsFailure) return video;

            video.SetDescricao(videoRequest?.Descricao);
            video.SetUrlDaImagem(videoRequest?.UrlDaImagem);

            return video;
        }
    }
}