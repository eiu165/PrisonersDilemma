using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    
    public   class Generation
    { 
        private BotService _botService;

        public Generation(BotService botService)
        { 
            _botService = botService;

        }

        public void Run()
        {
            var players =  _botService.GetPlayers(); 
            var gameData = new List<GameData>(); 
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = i + 1; j < players.Count; j++)
                {
                    var game = new Game(players[i], players[j] );
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
