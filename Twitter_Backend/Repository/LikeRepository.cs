using Twitter_Backend.Data;
using Twitter_Backend.DTO;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Repository
{
    
        public class LikeRepository : ILikeRepository
        {

            private readonly ApplicationDbContext _db;
            public LikeRepository(ApplicationDbContext db)
            {
                _db = db;
            }
            public Like findByTweetidAndUsername(int tweetid, string username)
            {
                if (tweetid == 0 || username == null)
                {
                    return null;
                }
                else
                {
                    var like = _db.Likes.FirstOrDefault(x => x.tweetid == tweetid && x.username == username);
                    if (like != null)
                    {
                        return like;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public bool getTweetLike(int tweetid, string username)
            {
                if (tweetid == 0 || username == null)
                {
                    return false;
                }
                else
                {
                    Like like = findByTweetidAndUsername(tweetid, username);

                    if (like == null)
                    {
                        return false;
                    }
                    else
                    {
                        return like.tweetBoolean;
                    }
                }
            }

            public Like tweetLikeCreate(int tweetid, string username)
            {
                if (tweetid == 0 || username == null)
                {
                    return null;
                }
                else
                {
                    Like like = new Like()
                    {
                        tweetid = tweetid,
                        username = username
                    };
                    _db.Likes.Add(like);
                    _db.SaveChanges();
                    return like;
                }
            }

            public Like tweetLikeUpdate(LikeDTO createLike, int tweettid, string username)
            {
            try
            {
                Like tweetLike = _db.Likes.FirstOrDefault(x => x.tweetid == tweettid && x.username == username);
                if (tweetLike != null)
                {
                    tweetLike.tweetBoolean = createLike.tweetBoolean;
                    tweetLike.tweetid = tweettid;
                    tweetLike.username = username;
                    _db.Likes.Update(tweetLike);
                    _db.SaveChanges();
                    return tweetLike;
                }
                else
                {
                    Like tweetcreate = new Like()
                    {
                        tweetid = tweettid,
                        username = username
                    };
                    _db.Likes.Add(tweetcreate); _db.SaveChanges();
                    Like tweetLikes = _db.Likes.FirstOrDefault(x => x.tweetid == tweettid && x.username == username);
                    tweetLikes.tweetBoolean = createLike.tweetBoolean;
                    tweetLikes.tweetid = tweettid;
                    tweetLikes.username = username;
                    _db.Likes.Update(tweetLikes);
                    _db.SaveChanges();
                    return tweetLikes;

                }
            }
            catch (Exception )
            {

                return null;
            }

                }
            }
        }
    

