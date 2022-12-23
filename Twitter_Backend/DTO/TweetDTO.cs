namespace Twitter_Backend.DTO
{
    public class TweetDTO
    {
        public int Id { get; set; }
        public string Tweet { get; set; }
        public DateTime TweetDate { get; set; }
        public int likeCount { get; set; }

    }
}
