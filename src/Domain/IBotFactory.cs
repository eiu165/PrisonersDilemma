using Domain; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IBotFactory
    {
        Domain.IPlayable GetPlayer(Domain.BotType type);
    }
}
