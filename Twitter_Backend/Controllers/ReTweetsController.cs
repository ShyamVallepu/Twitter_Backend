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
   // [Authorize]
  
    public class ReTweetsController : ControllerBase
    {
        private readonly IReTweetRepository _retweetRepo;
        private ILogger<ReTweetsController> _logger;

        public ReTweetsController(IReTweetRepository reTweetRepo, ILogger<ReTweetsController> logger)
        {
            _logger = logger;
            _retweetRepo = reTweetRepo;
        }

        [HttpGet("allRetweets/{tweetId}")]
        public IActionResult getAllReTweets(int tweetId)
        {
            List<Retweet> reTweetsList = _retweetRepo.getAllRetweetsBytweetId(tweetId).ToList();
            if (reTweetsList != null)
            {
                _logger.LogInformation("Retweets Fetched Successfully");
                return Ok(reTweetsList);
                //return await reTweetsList
            }
            else
            {
                _logger.LogError("unable to fetch Retweets");
                return NotFound();
            }

        }


        [HttpPost("{username}/addRetweet/{tweetId}")]
        public IActionResult addReTweet(string username, int tweetId, [FromBody] ReTweetDTO createReTweet)
        {
            Retweet reTweet = _retweetRepo.createRetweet(createReTweet, username, tweetId);
            if (reTweet != null)
            {
                _logger.LogInformation("Retweet Created ");
                return Ok(reTweet);
            }
            else
            {
                _logger.LogError("Unable to add retweet");
                return NotFound();
            }
        }

        [HttpPut("{username}/updateRetweet/{retweetId}")]
        public IActionResult updateReTweet(string username, int retweetId, [FromBody] ReTweetDTO createReTweet)
        {
            Retweet changeTweet = _retweetRepo.updateRetweet(createReTweet, retweetId, username);
            if (changeTweet != null)
            {
                _logger.LogInformation("Retweet updated ");
                return Ok(changeTweet);
            }
            else
            {
                _logger.LogError("Unable to update retweet");
                return NotFound();
            }
        }

        [HttpDelete("{username}/deleteRetweet/{retweetId}")]
        public IActionResult deleteReTweet(string username, int retweetId)
        {
            bool result = _retweetRepo.deleteRetweet(retweetId);
            if (result)
            {
                _logger.LogInformation("Retweet deleted ");
                return Ok(result);
            }
            else
            {
                _logger.LogError("Unable to delete retweet");
                return NotFound();
            }
        }

    }
}
