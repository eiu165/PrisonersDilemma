using Domain;
using JesusNS;
using LuciferNS;
using System.Collections.Generic;
using TicForTacNS; 
using System.Linq;

namespace Arena
{
    public class Game
    {
        public int AttackWhenOpponetCooperates = 0;
        public int CooperateWhenOpponetCooperates = 1;
        public int AttackWhenOpponetAttacks = 2;
        public int CooperateWhenOpponetAttacks = 3;

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
            var roundResults = new  List<RoundResult>(); 
            for (int i=0; i<NumberOfRounds; i++)
            {
                var result = new RoundResult();  
                result.Player1.PlayType = _player1.Execute(roundResults, PlayerNumber.Player1);
                result.Player2.PlayType = _player2.Execute(roundResults, PlayerNumber.Player2);
                if (result.Player1.PlayType == Action.Cooperate && result.Player2.PlayType == Action.Cooperate)
                {
                    result.Player1.RoundScore = CooperateWhenOpponetCooperates;
                    result.Player2.RoundScore = CooperateWhenOpponetCooperates;
                }
                else if (result.Player1.PlayType == Action.Attack && result.Player2.PlayType == Action.Attack)
                {
                    result.Player1.RoundScore = AttackWhenOpponetAttacks;
                    result.Player2.RoundScore = AttackWhenOpponetAttacks;
                }
                else if (result.Player1.PlayType == Action.Attack && result.Player2.PlayType == Action.Cooperate)
                {
                    result.Player1.RoundScore = AttackWhenOpponetCooperates;
                    result.Player2.RoundScore = CooperateWhenOpponetAttacks;
                }
                else if (result.Player1.PlayType == Action.Cooperate && result.Player2.PlayType == Action.Attack)
                {
                    result.Player1.RoundScore = CooperateWhenOpponetAttacks;
                    result.Player2.RoundScore = AttackWhenOpponetCooperates;
                }
                roundResults.Add(result);
            }
            var player1Score = roundResults.ForEach(x => x.Player1.RoundScore);
            return roundResults;

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
