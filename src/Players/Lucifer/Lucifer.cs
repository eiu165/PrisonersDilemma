using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuciferNS
{
    public class Lucifer : IPlayable
    { 
        public PlayType Action(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            return PlayType.Deflect;
        }
    }
}
