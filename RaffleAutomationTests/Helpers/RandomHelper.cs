using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;
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
            int genRand = r.Next(1, 100);
            string randomNum = genRand.ToString();

            return randomNum;
        }

        public static int RandomWPId(WeeklyPrizesResponseModelWeb content)
        {
            Random r = new Random();
            int genRand = r.Next(0, content.Prizes.Count());

            return genRand;
        }

        public static int RandomFPId(List<string> content)
        {
            Random r = new Random();
            int genRand = r.Next(0, content.Count());

            return genRand;
        }


        public static string RandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomPhone()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




    }
}
