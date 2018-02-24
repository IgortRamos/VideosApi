using Domain.Base;
using System;

namespace Domain.Responses
{
    public class VideoStatusResponse : MessagePattern
    {
        public VideoResponse Video { get; set; }
    }
}