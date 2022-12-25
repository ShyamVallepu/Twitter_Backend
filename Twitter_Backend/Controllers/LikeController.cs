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
    
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likerepo;
        private readonly ILogger<LikeController> _logger;
        public LikeController(ILikeRepository likerepo, ILogger<LikeController> logger)
        {
            _likerepo = likerepo;
            _logger = logger;
        }


        [HttpPut("{username}/like/{tweetId}")]
        public IActionResult CreateLike(string username, int tweetId)
        {
            Like like = _likerepo.tweetLikeCreate(tweetId, username);
            _logger.LogInformation("Creating Tweet Like in Database");
            return Ok(like);
        }


        [HttpGet("{username}/getlike/{tweetId}")]
        public IActionResult getLikes(string username, int tweetId)
        {
            try
            {
                bool liketweet = _likerepo.getTweetLike(tweetId, username);
                _logger.LogInformation($"Likes of {tweetId} Fetched Successfully");
                 return Ok(liketweet);
                
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }


        [HttpPost("{username}/likeupdate/{tweetId}")]
        public IActionResult UpdateLike([FromBody] LikeDTO createLike, string username, int tweetId)
        {
            Like like = _likerepo.tweetLikeUpdate(createLike, tweetId, username);
            return Ok(like);

        }
    }
}
