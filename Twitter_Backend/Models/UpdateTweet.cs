namespace Twitter_Backend.Models
{
    public class UpdateTweet
    {
        public int tweetId { get; set; }

        public string tweet { get; set; }

        public DateTime tweetDate { get; set; }

        public int likeCount { get; set; }
    }
}
