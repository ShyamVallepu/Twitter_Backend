using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Twitter_Backend.Models
{
    public class Retweet
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Re-Tweet ID is required")]
        public int retweetid { get; set; }

        [Required(ErrorMessage = "Re-Tweet  is required")]
        public string reTweet { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Tweet ID is required")]
        public int tweetid { get; set; }

        [Required(ErrorMessage = "Re-Tweet Time is required")]
        public DateTime reTweetTime { get; set; }
    }
}
