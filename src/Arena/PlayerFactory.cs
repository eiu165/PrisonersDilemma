using Domain;
using JesusNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicForTacNS;

namespace Arena
{
    public enum PlayerType
    {
        Jesus, 
        Lucifer,
        MassiveRetaliation,
        TicForTac
    }
    public class PlayerFactory
    {

        public IPlayable GetPlayer(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Jesus:
                    return new Jesus();
                case PlayerType.Lucifer:
                    return new Lucifer();
                case PlayerType.MassiveRetaliation:
                    return new MassiveRetaliation();
                case PlayerType.TicForTac:
                    return new TicForTac(); 
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
