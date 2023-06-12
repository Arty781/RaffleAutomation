namespace RaffleAutomationTests.Helpers
{
    public partial class RandomHelper
    {
        public static string RandomNumber()
        {
            Random r = new Random();
            int genRand = r.Next(3, 20);
            string randomNum = string.Empty;

            switch (genRand)
            {
                default:
                    // Handle other numbers
                    randomNum =  genRand.ToString();
                    break;
            }
            if(genRand == 6)
            {
                RandomNumber();
            }
            return randomNum;
        }

        public static int RandomIntNumber(int maxNum)
        {
            Random r = new Random();
            int genRand = r.Next(1, maxNum);

            return genRand;
        }

        public static int RandomCharityNumber(int maxNum)
        {
            Random r = new Random();
            int genRand = r.Next(3, maxNum);

            return genRand;
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


        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomPhone()
        {
            Random random = new Random();
            const string firstChar = "123456789";  // Allowed characters for the first digit
            const string chars = "0123456789";     // Allowed characters for the rest of the digits

            // Generate the first digit
            string firstDigit = firstChar[random.Next(firstChar.Length)].ToString();

            // Generate the rest of the digits
            string restOfDigits = new string(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return firstDigit + restOfDigits;
        }

        public static string RandomPhone(int charNum)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, charNum)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




    }
}
