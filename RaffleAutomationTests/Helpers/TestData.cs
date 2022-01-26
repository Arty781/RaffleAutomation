using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class Endpoints
    {
        public const string websiteHost = "https://staging.rafflehouse.com";
        public const string adminHost = "https://admin-staging.rafflehouse.com";
        public const string signin = "https://staging.rafflehouse.com/sign-in";
        public const string signup = "https://staging.rafflehouse.com/sign-up";
        public const string dreamhome = "https://staging.rafflehouse.com/dreamhome";
        public const string lifestyle = "https://staging.rafflehouse.com/lifestyleprizes";
        public const string fixedodds = "https://staging.rafflehouse.com/fixedodds";
        public const string winners = "https://staging.rafflehouse.com/lifestyleprizes";
        public const string about = "https://staging.rafflehouse.com/about-us";
        public const string profile = "https://staging.rafflehouse.com/profile";
        public const string freeEntry = "https://staging.rafflehouse.com/post";
    }

    public class Credentials
    {
        public const string login = "qatester91311@gmail.com";
        public const string password = "Qaz11111";

        public const string loginAdmin = "bennospencer@gmail.com";
        public const string passwordAdmin = "1289Raffle@!CMS";
    }



    public class Categories
    {
        public const string category = "Tech";
    }

    public class SubCategories
    {
        public const string subCategory = "Phones & Tablets";
    }

    public class ChromeDriverPath
    {
        public const string path = @"chromedriver.exe";
    }
}
