using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    partial class RandomHelper
    {
        public static string RandomNumber()
        {
            Random r = new Random();
            int genRand = r.Next(10, 50);
            string randomNum = genRand.ToString();

            return randomNum;
        }
    }
}
