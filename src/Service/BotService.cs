using System;
using System.Collections.Generic;
using Domain;

namespace Service
{

    public class BotService : IBotService
    {
        private IBotFactory _playerFactory;
        public BotService(IBotFactory playerFactory)
        {
            _playerFactory = playerFactory; 
        } 

        public List<IPlayable> GetPlayers( )
        {
            var typeList = new List<Domain.BotType> {
                 BotType.Lucifer
                , BotType.TicForTac
                , BotType.MassiveRetaliation
            };

            var list = new List<Domain.IPlayable>();
            foreach (var botType in typeList)
            {
                list.Add(_playerFactory.GetPlayer(botType)); 
            }

            return list;
        }
    }
}
