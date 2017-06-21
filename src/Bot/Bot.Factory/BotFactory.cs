using System;
using Domain; 


namespace Bot.Factory
{

    public class BotFactory: IBotFactory
    {
        public IPlayable GetPlayer(BotType type)
        {
            switch (type)
            {
                case BotType.Jesus:
                    return new JesusNamespace.Jesus();
                case BotType.Lucifer:
                    return new LuciferNamespace.Lucifer();
                case BotType.MassiveRetaliation:
                    return new  MassiveRetaliationNamespace.MassiveRetaliation();
                case BotType.TicForTac:
                    return new  TicForTacNamespace.TicForTac();
                case BotType.RandomMan:
                    return new  RandomManNamespace.RandomMan();
                case BotType.Tester:
                    return new  TesterNamespace.Tester();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
