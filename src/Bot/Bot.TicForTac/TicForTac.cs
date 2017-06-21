using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicForTacNamespace
{
    /// <summary>
    /// Strategy: An eye for an eye ( Cooperate at first, Then respond to oppenent with 1 attack if other bot attacked in the previous round )
    /// </summary>
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
                var previousRound = previousRoundResults[previousRoundResults.Count - 1];
                var otherPlayerPreviousRound = (playerNumber == PlayerNumber.Player1) ? previousRound.Player2 : previousRound.Player1;
                if (otherPlayerPreviousRound.PlayType == Domain.Action.Attack)
                { 
                    return Domain.Action.Attack;
                }
                return Domain.Action.Cooperate; 
            }
        }
    }
}
