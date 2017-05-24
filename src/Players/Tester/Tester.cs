using Domain;
using System.Collections.Generic;
using System;

namespace TesterNamespace 
{
    public class Tester : IPlayable
    {
        //Function to get random number
        private readonly Random getrandom = new Random();
        private readonly object syncLock = new object();
        private int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max+1);
            }
        }

        public Domain.Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        {
            if (previousRoundResults.Count == 0)
            {
                return Domain.Action.Cooperate;
            }
            else
            {
                int randomNumber = GetRandomNumber(1, 10);
                if (randomNumber > 1) // 10 % of the time  Cooperate
                {
                    Console.WriteLine(string.Format("Tester: {0}    the action is {1}", randomNumber, Domain.Action.Cooperate.ToString()));
                    return Domain.Action.Cooperate;
                }
                else
                {
                    Console.WriteLine(string.Format("Tester: {0}    the action is {1}", randomNumber, Domain.Action.Attack.ToString()));
                    return Domain.Action.Attack;
                }
            }

        }
    }
}
