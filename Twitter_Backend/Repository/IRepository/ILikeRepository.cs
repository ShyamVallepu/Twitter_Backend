using Twitter_Backend.DTO;
using Twitter_Backend.Models;

namespace Twitter_Backend.Repository.IRepository
{
    public interface ILikeRepository
    {
        Like tweetLikeCreate(int tweetid, string username);
        Like tweetLikeUpdate(LikeDTO createLike, int tweettid, string username);

        bool getTweetLike(int tweetid, string username);

        Like findByTweetidAndUsername(int tweetid, string username);
    }
}
