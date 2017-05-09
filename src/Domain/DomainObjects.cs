using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IPlayable
    {
        PlayType Action(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber);
    }

    public enum PlayType
    {
        Deflect = 0,
        Cooperate = 1
    }
    public enum PlayerNumber
    {
        Player1 = 1,
        Player2 = 2
    }


    public class PlayerResult
    {
        public PlayerNumber PlayerNumber { get; set; }
        public int PlayerScore { get; set; }
        public PlayType PlayType { get; set; }
    }

    public class RoundResult
    {
        public IList<PlayerResult> Players { get; set; } 
    }
}
