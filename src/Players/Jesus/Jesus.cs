using System;
using System.Collections.Generic; 
using Domain;

namespace JesusNS
{
    public class Jesus : IPlayable
    { 
        public PlayType Action(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            return PlayType.Cooperate;
        }
    }
}
