namespace Domain
{
    public class RoundResult
    {
        public RoundResult()
        {
            Player1 = new PlayerResult();
            Player2 = new PlayerResult(); 
        }
        public PlayerResult Player1 { get; set; }
        public PlayerResult Player2 { get; set; }
    }
}
