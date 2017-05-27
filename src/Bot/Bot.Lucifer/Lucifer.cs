using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuciferNamespace
{
    /// <summary>
    /// stragity: always attack
    /// </summary>
    public class Lucifer : IPlayable
    { 
        public Domain.Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            return Domain.Action.Attack;
        }
    }
}
