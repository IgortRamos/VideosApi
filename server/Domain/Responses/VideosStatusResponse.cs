using Domain.Base;
using System.Collections.Generic;

namespace Domain.Responses
{
    public class VideosStatusResponse : MessagePattern
    {
        public IEnumerable<VideoResponse> Videos { get; set; }
    }
}