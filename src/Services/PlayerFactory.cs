﻿using Domain;
using JesusNamespace;
using LuciferNamespace;
using MassiveRetaliationNamespace;
using TesterNamespace;
using RandomManNamespace;
using System;
using TicForTacNS;

namespace Arena
{
    public enum PlayerType
    {
        Jesus, 
        Lucifer,
        MassiveRetaliation,
        TicForTac,
        RandomMan,
        Tester
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
                case PlayerType.RandomMan:
                    return new RandomMan();
                case PlayerType.Tester:
                    return new Tester();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
