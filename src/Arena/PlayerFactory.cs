using Domain;
using JesusNS;
using LuciferNS;
using MassiveRetaliationNs;
using System;
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

    public interface IPlayerFactory
    {
        IPlayable GetPlayer(PlayerType type);
    }

    public class PlayerFactory: IPlayerFactory
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
