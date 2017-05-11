using Domain;
using JesusNS;
using LuciferNS;
using System.Collections.Generic;
using TicForTacNS; 
using System.Linq;

namespace Arena
{

    public class Arena
    {
        private IPlayerFactory _playerFactory;
         
        public Arena(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        public IList<PlayerType> Players { get; set; }

        public void Run()
        {
            Players = new List<PlayerType> {
                PlayerType.Jesus
                , PlayerType.Lucifer
                , PlayerType.TicForTac
                , PlayerType.MassiveRetaliation
            };

            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = i + 1; j < Players.Count; j++)
                {
                    var game = new Game(_playerFactory.GetPlayer(Players[i]), _playerFactory.GetPlayer(Players[j]));
                    game.Play();
                }
            }

        }
    }
}
