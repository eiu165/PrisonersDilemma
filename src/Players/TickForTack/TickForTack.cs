using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickForTackNS
{
    public class TickForTack : IPlayable
    { 
        public PlayType Action(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            if (previousRoundResults.Count == 0 )
            {
                return PlayType.Cooperate;
            }
            else 
            { 
                var otherPlayer = (playerNumber == PlayerNumber.Player1) ? PlayerNumber.Player2 : PlayerNumber.Player1; 
                var previousRound = previousRoundResults[previousRoundResults.Count - 1];
                if(previousRound.Players.Single(x=> x.PlayerNumber == otherPlayer).PlayType == PlayType.Deflect)
                {
                    return PlayType.Deflect;
                }
                return PlayType.Cooperate;
            }
        }
    }
}
