namespace Quizmester.Models
{
    public class SpeedQuizResult
    {
        public int SpeedQuizResultId { get; set; }

        public int UserId { get; set; }

        public int CompletionTimeMs { get; set; }

        public DateTime PlayedAt { get; set; }
    }
}