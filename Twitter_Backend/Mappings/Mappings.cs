using AutoMapper;
using Twitter_Backend.DTO;
using Twitter_Backend.Models;

namespace Twitter_Backend.Mappings
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<RegisterDTO, User>().ReverseMap();
            CreateMap<LikeDTO, Like>().ReverseMap();
            CreateMap<TweetDTO, TweetPost>().ReverseMap();
            CreateMap<ReTweetDTO, Retweet>().ReverseMap();
        }
    }
}
