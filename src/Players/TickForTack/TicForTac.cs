using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicForTacNS
{
    public class TicForTac : IPlayable
    { 
        public Domain.Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            if (previousRoundResults.Count == 0 )
            {
                return Domain.Action.Cooperate;
            }
            else 
            { 
                var otherPlayer = (playerNumber == PlayerNumber.Player1) ? PlayerNumber.Player2 : PlayerNumber.Player1; 
                var previousRound = previousRoundResults[previousRoundResults.Count - 1];
                if(previousRound.Players.Single(x=> x.PlayerNumber == otherPlayer).PlayType == Domain.Action.Attack)
                {
                    return Domain.Action.Attack;
                }
                return Domain.Action.Cooperate;
            }
        }
    }
}
