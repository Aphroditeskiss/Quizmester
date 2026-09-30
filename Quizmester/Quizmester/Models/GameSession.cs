namespace Quizmester.Models
{
    public class GameSession
    {
        public int GameSessionId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}