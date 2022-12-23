using Microsoft.IdentityModel.Tokens;
using Twitter_Backend.Data;
using Twitter_Backend.DTO;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Repository
{
    public class TweetRepository : ITweetRepository
    {
        private readonly ApplicationDbContext _db;

        public TweetRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool deleteTweet(int tweetid, string username)
        {
            var tweet = _db.Tweets.FirstOrDefault(x => x.tweetid == tweetid && x.userName == username);
            if (tweet != null)
            {
                _db.Tweets.Remove(tweet);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<TweetPost> findAllDate()
        {
            return _db.Tweets.OrderBy(x => x.tweetDate).ToList();
        }

        public ICollection<TweetPost> getAllTweets()
        {
            return _db.Tweets.OrderBy(x => x.tweetid).ToList();
        }

        public ICollection<TweetPost> getAllTweetsOfUsername(string username)
        {
            List<TweetPost> tweetsOfUserName = _db.Tweets.Where(t => t.userName == username).ToList();
            if (tweetsOfUserName.Count() == 0)
            {
                return null;
            }
            return tweetsOfUserName;

        }

        public TweetPost getLikeCount(int tweetid)
        {
            TweetPost tweet = _db.Tweets.FirstOrDefault(x => x.tweetid == tweetid);
            if (tweet != null)
            {
                return tweet;
            }
            else
            {
                return null;
            }
        }

        public TweetPost getTweetsOfTweetId(int tweetid)
        {
            var tweet = _db.Tweets.FirstOrDefault(x => x.tweetid == tweetid);
            if (tweet != null)
            {
                return tweet;
            }
            else
            {
                return null;
            }

        }

        public TweetPost tweetCreate(TweetDTO createTweet, string username)
        {
            try
            {
                TweetPost tweetcontent = new TweetPost()
                {
                    //tweetid = createTweet.Id,
                    tweet = createTweet.Tweet,
                    likeCount = createTweet.likeCount,
                    tweetDate = DateTime.Now ,
                    userName = username
                };
                _db.Tweets.Add(tweetcontent);
                _db.SaveChanges();
                TweetPost tweet = _db.Tweets.FirstOrDefault(x => x.tweet == createTweet.Tweet);
                Like likecolumn = new Like
                {
                    tweetid = tweet.tweetid,
                    username = tweet.userName,
                    tweetBoolean = true
                };
                _db.Likes.Add(likecolumn);
                _db.SaveChanges();
                return tweetcontent;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public TweetPost tweetUpdate(UpdateTweet updateTweet, int tweetid, string username)
        {
            var oldtweet = _db.Tweets.FirstOrDefault(x => x.tweetid == tweetid );
            if (oldtweet != null)
            {
                if (updateTweet.tweet != null && !updateTweet.tweet.IsNullOrEmpty())
                {
                    oldtweet.tweet = updateTweet.tweet;
                }
                oldtweet.tweetDate = DateTime.Now;

                if (updateTweet.likeCount != 0)
                {
                    oldtweet.likeCount = updateTweet.likeCount;
                }
                //if (updateTweet.username_fk != null && !updateTweet.username_fk.IsNullOrEmpty())
                ////{
                //    oldtweet.userName = updateTweet.username_fk;
                //}
                _db.Tweets.Update(oldtweet);
                _db.SaveChanges();
                return oldtweet;
            }
            else
            {
                return null;
            }

        }
    }
}

