using Domain; 
using System.Collections.Generic; 

namespace MassiveRetaliationNamespace
{

    /// <summary>
    /// Strategy: Cooperate until oppenent Attacks, once oppenent attacks once, never cooperate
    /// </summary>
    public class MassiveRetaliation : IPlayable
    {
        private bool HasOppententAttacked = false;

        public Domain.Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            if (previousRoundResults.Count == 0)
            {
                return Domain.Action.Cooperate;
            }
            else
            {
                if (HasOppententAttacked)
                {
                    return Domain.Action.Attack;
                } 
                var previousRound = previousRoundResults[previousRoundResults.Count - 1];
                var otherPlayerPreviousRound = (playerNumber == PlayerNumber.Player1) ? previousRound.Player2 : previousRound.Player1;
                if (otherPlayerPreviousRound.PlayType == Domain.Action.Attack)
                {
                    HasOppententAttacked = true;
                    return Domain.Action.Attack;
                } 
                return Domain.Action.Cooperate;
            }
        }
    }
}
