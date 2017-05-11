using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IPlayable
    {
        Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber);
    }

    public enum Action
    {
        Attack = 0,
        Cooperate = 1
    }

    public enum PlayerNumber
    {
        Player1 = 1,
        Player2 = 2
    }

    public class PlayerResult
    {
        public int RoundScore { get; set; }
        public int Total { get; set; }
        public Action PlayType { get; set; }
    }

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
