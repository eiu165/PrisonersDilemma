using Domain;
using Services;
using System;
using System.Collections.Generic; 
using System.Linq;

namespace Arena
{

    public class Generation
    {
        private IPlayerFactory _playerFactory;

        public Generation(IPlayerFactory playerFactory)
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
                , PlayerType.RandomMan
                , PlayerType.Tester
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
            var playersScore = new List<PlayerScoreForGeneration>();
            foreach (var game in gameData)
            {
                Console.WriteLine(string.Format(" {0}:{1} - {2}:{3}"
                    , game.Player1Name, game.Player1Score
                    , game.Player2Name, game.Player2Score));

                var name = game.Player1Name;
                var playerScore = playersScore.SingleOrDefault(x => x.Name == name);
                if (playerScore == null)
                {
                    playersScore.Add(new PlayerScoreForGeneration { Name = name, Score = game.Player1Score });
                }
                else
                {
                    playerScore.Score += game.Player1Score;
                }

                name = game.Player2Name;
                playerScore = playersScore.SingleOrDefault(x => x.Name == name);
                if (playerScore == null)
                {
                    playersScore.Add(new PlayerScoreForGeneration { Name = name, Score = game.Player2Score });
                }
                else
                {
                    playerScore.Score += game.Player1Score;
                }

            }
            Console.WriteLine(  " ================================ "  );
            foreach (var playerScore in playersScore.OrderBy(x=> x.Score))
            { 
                Console.WriteLine(string.Format(" {0}:{1}  "
                    , playerScore.Name, playerScore.Score));
            }
        }

        public class PlayerScoreForGeneration
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }
    }
}
