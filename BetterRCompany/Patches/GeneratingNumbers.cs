using System;

namespace BetterRCompany.Patches
{
    internal class GeneratingNumbers
    {
        public static Random GenRandomNumber = new Random();

        public static double EventChanceRoll()
        {
            return GenRandomNumber.NextDouble();
        }
    }
}
