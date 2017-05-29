using Domain; 
using System.Collections.Generic;
using System.Linq; 

namespace Service
{

    public class Game
    {
        private  GameData _gameData { get; set; }
        public int AttackWhenOpponetCooperates = 0;
        public int CooperateWhenOpponetCooperates = 1;
        public int AttackWhenOpponetAttacks = 2;
        public int CooperateWhenOpponetAttacks = 3;

        public int NumberOfRounds = 100;

        private IPlayable _player1 { get; set; }
        private IPlayable _player2 { get; set; }
        public Game(IPlayable player1, IPlayable player2)
        {
            _player1 =  player1;
            _player2 = player2;
            _gameData = new GameData();
            _gameData.Player1Name = player1.GetType().Name ;
            _gameData.Player2Name = player2.GetType().Name;

        }

        public GameData Play()
        {
            _gameData.RoundResults = new List<RoundResult>();
            for (int i = 0; i < NumberOfRounds; i++)
            {
                var result = new RoundResult();
                result.Player1.PlayType = _player1.Execute(_gameData.RoundResults, PlayerNumber.Player1);
                result.Player2.PlayType = _player2.Execute(_gameData.RoundResults, PlayerNumber.Player2);
                if (result.Player1.PlayType == Domain.Action.Cooperate && result.Player2.PlayType == Domain.Action.Cooperate)
                {
                    result.Player1.RoundScore = CooperateWhenOpponetCooperates;
                    result.Player2.RoundScore = CooperateWhenOpponetCooperates;
                }
                else if (result.Player1.PlayType == Domain.Action.Attack && result.Player2.PlayType == Domain.Action.Attack)
                {
                    result.Player1.RoundScore = AttackWhenOpponetAttacks;
                    result.Player2.RoundScore = AttackWhenOpponetAttacks;
                }
                else if (result.Player1.PlayType == Domain.Action.Attack && result.Player2.PlayType == Domain.Action.Cooperate)
                {
                    result.Player1.RoundScore = AttackWhenOpponetCooperates;
                    result.Player2.RoundScore = CooperateWhenOpponetAttacks;
                }
                else if (result.Player1.PlayType == Domain.Action.Cooperate && result.Player2.PlayType == Domain.Action.Attack)
                {
                    result.Player1.RoundScore = CooperateWhenOpponetAttacks;
                    result.Player2.RoundScore = AttackWhenOpponetCooperates;
                }
                _gameData.RoundResults.Add(result);
            }
            _gameData.Player1Score = _gameData.RoundResults.Sum(x => x.Player1.RoundScore);
            _gameData.Player2Score = _gameData.RoundResults.Sum(x => x.Player2.RoundScore);
             
            return _gameData;

        }

    }

}
