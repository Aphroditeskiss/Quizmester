namespace Quizmester.Models
{
    public class ScoreboardEntry
    {
        public int Position { get; set; }
        public int GameSessionId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}