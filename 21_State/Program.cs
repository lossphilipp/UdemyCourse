using System;

namespace Coding.Exercise
{
    public class CombinationLock
    {
        public CombinationLock(int[] combination)
        {
            this.combination = combination;
            Status = "LOCKED";
        }

        // you need to be changing this on user input
        public string Status;
        private readonly int[] combination;

        public void EnterDigit(int digit)
        {
            if (Status == "LOCKED")
            {
                if (digit == combination[0])
                {
                    Status = digit.ToString();
                }
            }
            else
            {
                if (digit == combination[Status.Length])
                {
                    Status += digit.ToString();
                }
                else
                {
                    Status = "ERROR";
                }
                if (Status != "LOCKED" && Status != "ERROR" && Status.Length == combination.Length)
                {
                    Status = "OPEN";
                }
            }
        }
    }
}