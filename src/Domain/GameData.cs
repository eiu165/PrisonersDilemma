using Domain;
using System.Collections.Generic;

namespace Domain
{
    public class GameData
    {
        public GameData()
        {
            RoundResults = new List<RoundResult>();
        }
        public List<RoundResult> RoundResults { get; set; }
        public string Bot1Name { get; set; }
        public string Bot2Name { get; set; }
        public int Bot1Score { get; set; }
        public int Bot2Score { get; set; }

    }

}
