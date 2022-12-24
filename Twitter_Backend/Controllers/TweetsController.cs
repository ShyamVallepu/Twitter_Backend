using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Twitter_Backend.DTO;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Controllers
{
    [Route("api/v1/tweets")]
    [EnableCors]
    [ApiController]
    [Authorize]
    
    public class TweetsController : ControllerBase
    {
        private readonly ILogger<TweetsController> _logger;
        private readonly ITweetRepository _tweetRepo;

        public TweetsController(ILogger<TweetsController> logger, ITweetRepository tweetRepo)
        {
            _logger = logger;
            _tweetRepo = tweetRepo;
        }

        [HttpGet("all")]
        public IActionResult getAllTweets()
        {
            var tweets = _tweetRepo.getAllTweets();
            if (tweets != null)
            {
                _logger.LogInformation("Tweets Fetched Successfully");
                return Ok(tweets);
            }
            else
            {
                _logger.LogError("Unable to Fetch Tweets");
                return BadRequest();
            }
        }

        [HttpGet("{username}")]
        public IActionResult getAllTweetsOfUsername(string username)
        {
            try
            {
                List<TweetPost> tweetsOfUser = _tweetRepo.getAllTweetsOfUsername(username).ToList();
                if (tweetsOfUser != null)
                {
                    _logger.LogInformation("Tweets of {0} fetched successfully", username);
                    return Ok(tweetsOfUser);
                }
                return NotFound("Invalid Username");
            }
            catch (Exception)
            {

                return NotFound("Invalid Username");
            }

        }

        [HttpGet("getTweet/{tweetid}")]
        public IActionResult getTweetsOfTweetId(int tweetid)
        {
            var tweetsOfID = _tweetRepo.getTweetsOfTweetId(tweetid);
            //List<TweetPost> tweetsOfUser = _tweetRepo.getAllTweetsOfUsername(username).ToList();
            if (tweetsOfID != null)
            {
                _logger.LogInformation("Tweets of {0} fetched successfully", tweetid);
                return Ok(tweetsOfID);
            }
            else
            {
                _logger.LogError("Unable to Fecth the tweets");
                return NotFound("Unable to Fecth the tweets");
            }

        }

        [HttpGet("likeCount/{tweetId}")]
        public IActionResult getLikeCount(int tweetId)
        {
            TweetPost likeCount = _tweetRepo.getLikeCount(tweetId);
            if (likeCount != null)
            {
                _logger.LogInformation("Tweets of {0} fetched successfully", tweetId);
                return Ok(likeCount);
            }
            else
            {
                _logger.LogError("Unable to Fecth the tweets");
                return NotFound("Unable to Fecth the tweets");
            }

        }

        [HttpPost("{username}/add")]
        public IActionResult CreateTweet(string username, [FromBody] TweetDTO createTweet)
        {
            TweetPost tweetcreate = _tweetRepo.tweetCreate(createTweet, username);
            if (tweetcreate != null)
            {
                _logger.LogInformation("TweetAdded Successfully");
                return Ok(tweetcreate);
            }
            else
            {
                _logger.LogError("Unable to Add Tweets");
                return NotFound("Unable to Add Tweets");
            }
        }


        [HttpPut("{username}/update/{tweetId}")]
        public IActionResult updateTweet(string username, int tweetId, UpdateTweet updateTweet)
        {
            TweetPost UpdateTweet = _tweetRepo.tweetUpdate(updateTweet, tweetId, username);
            if (UpdateTweet != null)
            {
                _logger.LogInformation($"Tweet Updated: {tweetId}");
                return Ok(UpdateTweet);
            }
            else
            {
                _logger.LogError("Unable to Update Tweet");
                return NotFound("Unable to Update Tweet");
            }
        }


        [HttpDelete("{username}/delete/{tweetId}")]
        public IActionResult deleteTweet(string username, int tweetId)
        {
            bool result = _tweetRepo.deleteTweet(tweetId, username);
            if (result)
            {
                _logger.LogInformation($"Tweet deleted: {tweetId}");
                return Ok(result);
            }

            else
            {
                _logger.LogError("Unable to delete Tweet");
                return NotFound("Unable to delete Tweet");
            }
        }


    }
}
