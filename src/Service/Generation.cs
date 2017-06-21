using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

    public class BotService
    {
        private IBotFactory _playerFactory;
        public BotService(IBotFactory playerFactory)
        {
            _playerFactory = playerFactory; 
        }

    }



    public   class Generation
    { 
        private BotService _botService;

        public Generation(BotService botService)
        { 
            _botService = botService;

        }
        private IList<Domain.BotType> _players { get; set; }

        public void Run()
        {
            _players =  _botService.GetPlayers();

            var gameData = new List<GameData>();
  
            for (int i = 0; i <  _players.Count; i++)
            {
                for (int j = i + 1; j < _players.Count; j++)
                {
                    var game = new Game( _players[i], _players[j] );
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
                        , game.Bot1Name, game.Bot1Score
                        , game.Bot2Name, game.Bot2Score));

                var name = game.Bot1Name;
                if (!playersScore.ContainsKey(name))
                {
                    playersScore.Add(name, game.Bot1Score);
                }
                else
                {
                    int score = playersScore[name];
                    playersScore[name] = score + game.Bot1Score;
                }

                name = game.Bot2Name;
                if (!playersScore.ContainsKey(name))
                {
                    playersScore.Add(name, game.Bot2Score);
                }
                else
                {
                    int score = playersScore[name];
                    playersScore[name] = score + game.Bot1Score;
                }
            }
            return playersScore;
        }
    }
}
