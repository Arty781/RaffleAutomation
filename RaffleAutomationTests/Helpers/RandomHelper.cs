namespace RaffleAutomationTests.Helpers
{
    public partial class RandomHelper
    {
        public static string RandomNumber()
        {
            Random r = new Random();
            int genRand = r.Next(1, 20);
            string randomNum = string.Empty;

            switch (genRand)
            {
                case 6:
                    // Handle excluded numbers
                    RandomNumber();
                    break;
                default:
                    // Handle other numbers
                    randomNum =  genRand.ToString();
                    break;
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
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
