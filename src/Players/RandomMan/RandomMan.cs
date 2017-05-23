using Domain;
using System.Collections.Generic;
using System;

namespace RandomManNamespace
{
    public class RandomMan : IPlayable
    {
        //Function to get random number
        private   readonly Random getrandom = new Random();
        private   readonly object syncLock = new object();
        private int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public Domain.Action Execute(IList<RoundResult> previousRoundResults, PlayerNumber playerNumber)
        { 
            int randomNumber = GetRandomNumber(1, 100); 
            if (randomNumber % 2 == 0)
            {
                Console.WriteLine(string.Format("the random number is: {0}    the action is {1}", randomNumber, Domain.Action.Cooperate.ToString()));
                return Domain.Action.Cooperate;
            }
            else
            {
                Console.WriteLine(string.Format("the random number is: {0}    the action is {1}", randomNumber, Domain.Action.Attack.ToString()));
                return Domain.Action.Attack;
            }

        }
          
    }
}
