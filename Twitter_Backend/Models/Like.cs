using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Twitter_Backend.Models
{
    public class Like
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Tweet Like ID is required")]
        public int tweetLikeId { get; set; }


        [Required(ErrorMessage = "User Name is required")]
        public string username { get; set; }



        [Required(ErrorMessage = "Tweet ID is required")]
        public int tweetid { get; set; }


        [Required(ErrorMessage = "Tweet Check is required")]
        public bool tweetBoolean { get; set; }
    }
}
