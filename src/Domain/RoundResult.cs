namespace Domain
{
    public class RoundResult
    {
        public RoundResult()
        {
            Player1 = new PlayResult();
            Player2 = new PlayResult(); 
        }
        public PlayResult Player1 { get; set; }
        public PlayResult Player2 { get; set; }
    }
}
