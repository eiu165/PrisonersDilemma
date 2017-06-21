using Domain;
using System.Collections.Generic;

namespace Service
{
    public interface IBotService
    {
         List<IPlayable> GetPlayers( );
    }
}
