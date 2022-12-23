using System.ComponentModel.DataAnnotations;

namespace Twitter_Backend.Models
{
    public class TweetPost
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        [Required(ErrorMessage = "Tweet ID is required")]
        public int tweetid { get; set; }

        [Required(ErrorMessage = "Tweet is required")]
        public string tweet { get; set; }

        [Required(ErrorMessage = "Like Count is required")]
        public int likeCount { get; set; }

        [Required(ErrorMessage = "Tweet Date is required")]
        public DateTime tweetDate { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string userName { get; set; }
    }
}
