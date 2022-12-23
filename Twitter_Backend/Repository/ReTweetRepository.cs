using Microsoft.IdentityModel.Tokens;
using Twitter_Backend.Data;
using Twitter_Backend.DTO;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Repository
{
    public class ReTweetRepository : IReTweetRepository
    {

        private readonly ApplicationDbContext _db;

        public ReTweetRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Retweet createRetweet(ReTweetDTO createReTweet, string username, int tweetid)
        {
            try
            {
                if (createReTweet == null || username == null || tweetid == 0)
                {
                    return null;
                }
                else
                {

                    Retweet retweet = new Retweet()
                    {
                        //retweetid = createReTweet.retweetid,
                        reTweet = createReTweet.retweet,
                        reTweetTime = createReTweet.retweettime,
                        userName = username,
                        tweetid = tweetid
                    };
                    _db.Retweets.Add(retweet);
                    _db.SaveChanges();
                    return retweet;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool deleteRetweet(int retweetid)
        {
            try
            {
                var reTweet = _db.Retweets.FirstOrDefault(x => x.retweetid == retweetid);
                if (reTweet != null)
                {
                    _db.Retweets.Remove(reTweet);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;   
            }
            
        }

        public ICollection<Retweet> getAllRetweetsBytweetId(int tweetId)
        {
            try
            {
                return _db.Retweets.Where(r => r.tweetid == tweetId).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Retweet updateRetweet(ReTweetDTO createReTweet, int retweetid, string username)
        {
            try
            {
                Retweet retweetpost = _db.Retweets.FirstOrDefault(x => x.retweetid == retweetid && x.userName == username);

                if (retweetpost != null)
                {
                    if (createReTweet.retweet != null && !createReTweet.retweet.IsNullOrEmpty())
                    {
                        retweetpost.reTweet = createReTweet.retweet;
                    }
                    retweetpost.reTweetTime = DateTime.Now;
                    if (username != null && !username.IsNullOrEmpty())
                    {
                        retweetpost.userName = username;
                    }

                    _db.Retweets.Update(retweetpost);
                    _db.SaveChanges();
                    return retweetpost;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }   
        }
    }
}
