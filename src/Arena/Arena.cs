using Domain;
using JesusNS;
using LuciferNS;
using System.Collections.Generic;
using TickForTackNS;
using System.Collections.Generic;
using System.Linq;

namespace Arena
{
    public class Game
    {
        public int DeflectWhenOpponetCooperates = 0;
        public int CooperateWhenOpponetCooperates = 1;
        public int DeflectWhenOpponetDeflects = 2;
        public int CooperateWhenOpponetDeflects = 3;

        public int NumberOfRounds = 10; 

        private IPlayable _player1 { get; set; }
        private IPlayable _player2 { get; set; }
        public Game(IPlayable player1, IPlayable player2)
        {
            _player1 = _player1;
            _player2 = _player2;
        }
        
        public IList<RoundResult> Play()
        { 
            var previousRoundResults = new  List<RoundResult>();
            for (int i=0; i<NumberOfRounds; i++)
            {
                var result = new RoundResult();  
                result.Players[0].PlayType = _player1.Action(previousRoundResults, PlayerNumber.Player1);
                result.Players[1].PlayType = _player1.Action(previousRoundResults, PlayerNumber.Player2);
                if (result.Players[0].PlayType == PlayType.Cooperate && result.Players[1].PlayType == PlayType.Cooperate)
                {
                    result.Players[0].PlayerScore = CooperateWhenOpponetCooperates;
                    result.Players[1].PlayerScore = CooperateWhenOpponetCooperates;
                }
                else if (result.Players[0].PlayType == PlayType.Deflect && result.Players[1].PlayType == PlayType.Deflect)
                {
                    result.Players[0].PlayerScore = DeflectWhenOpponetDeflects;
                    result.Players[1].PlayerScore = DeflectWhenOpponetDeflects;
                }
                else if (result.Players[0].PlayType == PlayType.Deflect && result.Players[1].PlayType == PlayType.Cooperate)
                {
                    result.Players[0].PlayerScore = DeflectWhenOpponetCooperates;
                    result.Players[1].PlayerScore = CooperateWhenOpponetDeflects;
                }
                else if (result.Players[0].PlayType == PlayType.Cooperate && result.Players[1].PlayType == PlayType.Deflect)
                {
                    result.Players[0].PlayerScore = CooperateWhenOpponetDeflects;
                    result.Players[1].PlayerScore = DeflectWhenOpponetCooperates;
                }
                previousRoundResults.Add(result);
            }
            var player1Score = previousRoundResults.ForEach(x => x.Players.);
            return previousRoundResults;

        }

    }



    public class Arena
    {

        public IList<IPlayable> Players { get; set; }

        public void Run()
        {
            Players = new List<IPlayable> { new Jesus(), new Lucifer(), new TickForTack() };

            for  (int i=0; i<Players.Count; i++)
            { 
                for (int j = i+1; j < Players.Count; j++)
                {
                    var game = new Game(Players[i], Players[j]);
                    game.Play();
                }
            }

        } 
    }
}
