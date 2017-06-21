using System;
using Domain; 


namespace Bot.Factory
{

    public class BotFactory: IBotFactory
    {
        public IPlayable GetPlayer(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Jesus:
                    return new JesusNamespace.Jesus();
                case PlayerType.Lucifer:
                    return new LuciferNamespace.Lucifer();
                case PlayerType.MassiveRetaliation:
                    return new  MassiveRetaliationNamespace.MassiveRetaliation();
                case PlayerType.TicForTac:
                    return new  TicForTacNamespace.TicForTac();
                case PlayerType.RandomMan:
                    return new  RandomManNamespace.RandomMan();
                case PlayerType.Tester:
                    return new  TesterNamespace.Tester();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
