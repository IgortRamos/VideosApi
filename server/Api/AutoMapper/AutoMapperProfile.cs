using AutoMapper;
using Domain.Entities.Videos;
using Domain.Responses;

namespace Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapVideo();
        }

        private void MapVideo()
        {
            CreateMap<Video, VideoResponse>();
            CreateMap<VideoResponse, Video>();
        }
    }
}