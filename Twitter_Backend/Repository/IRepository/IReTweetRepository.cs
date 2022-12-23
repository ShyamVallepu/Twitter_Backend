using Twitter_Backend.DTO;
using Twitter_Backend.Models;

namespace Twitter_Backend.Repository.IRepository
{
    public interface IReTweetRepository
    {
        Retweet createRetweet(ReTweetDTO createReTweet, string username, int tweetid);

        Retweet updateRetweet(ReTweetDTO createReTweet, int retweetid, string username);

        bool deleteRetweet(int retweetid);

        ICollection<Retweet> getAllRetweetsBytweetId(int tweetid);
    }
}
