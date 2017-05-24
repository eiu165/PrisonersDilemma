using Domain;
using System.Collections.Generic;

namespace Arena
{
    public class GameData
    {
        public GameData()
        {
            RoundResults = new List<RoundResult>();
        }
        public List<RoundResult> RoundResults { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

    }

}
