using Twitter_Backend.DTO;
using Twitter_Backend.Models;

namespace Twitter_Backend.Repository.IRepository
{
    public interface ITweetRepository
    {
        ICollection<TweetPost> getAllTweets();
        TweetPost tweetCreate(TweetDTO createTweet, string username);
        TweetPost tweetUpdate(UpdateTweet updateTweet, int tweetid, string username);
        bool deleteTweet(int tweetid, string username);
        ICollection<TweetPost> getAllTweetsOfUsername(string username);
        TweetPost getLikeCount(int tweetid);
        TweetPost getTweetsOfTweetId(int tweetid);
        ICollection<TweetPost> findAllDate();
    }
}
