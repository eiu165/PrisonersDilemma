using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public   class Generation
    {
        private IPlayerFactory _playerFactory;

        public Generation(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        public IList<Domain.PlayerType> Players { get; set; }

        public void Run()
        {
            Players = new List<Domain.PlayerType> {
                 PlayerType.Lucifer
                , PlayerType.TicForTac
                //, PlayerType.Tester
                , PlayerType.MassiveRetaliation
                //, PlayerType.RandomMan
                //, PlayerType.Jesus
            };

            var gameData = new List<GameData>();
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = i + 1; j < Players.Count; j++)
                {
                    var game = new Game(_playerFactory.GetPlayer(Players[i]), _playerFactory.GetPlayer(Players[j]));
                    gameData.Add(game.Play());

                }
            }
            var playersScore = AddPlayerScores(gameData);
            Console.WriteLine(" ================================ ");
            foreach (var playerScore in playersScore)
            {
                Console.WriteLine(string.Format(" {0}:{1}  "
                    , playerScore.Key, playerScore.Value));
            }
        }

        public  Dictionary<string, int> AddPlayerScores(List<GameData> gameData)
        {
            var playersScore = new Dictionary<string, int>();
            foreach (var game in gameData)
            {
                
                Console.WriteLine(string.Format(" {0}:{1} - {2}:{3}"
                        , game.Player1Name, game.Player1Score
                        , game.Player2Name, game.Player2Score));

                var name = game.Player1Name;
                if (!playersScore.ContainsKey(name))
                {
                    playersScore.Add(name, game.Player1Score);
                }
                else
                {
                    int score = playersScore[name];
                    playersScore[name] = score + game.Player1Score;
                }

                name = game.Player2Name;
                if (!playersScore.ContainsKey(name))
                {
                    playersScore.Add(name, game.Player2Score);
                }
                else
                {
                    int score = playersScore[name];
                    playersScore[name] = score + game.Player1Score;
                }
            }
            return playersScore;
        }
    }
}
