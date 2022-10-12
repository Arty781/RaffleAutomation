using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class Endpoints
    {
        public const string WebsiteHost = "https://staging.rafflehouse.com";
        public const string AdminHost = "https://admin-staging.rafflehouse.com";
        public const string Signin = WebsiteHost + "/sign-in";
        public const string Signup = WebsiteHost + "/sign-up";
        public const string Dreamhome = WebsiteHost + "/dreamhome";
        public const string Lifestyle = WebsiteHost + "/lifestyleprizes";
        public const string Fixedodds = WebsiteHost + "/fixedodds";
        public const string Winners = WebsiteHost + "/winners";
        public const string About = WebsiteHost + "/about-us";
        public const string Profile = WebsiteHost + "/profile";
        public const string FreeEntry = WebsiteHost + "/post";

        #region API

        public const string ApiHost = "https://staging-api.rafflehouse.com";

        #region Web
        public const string SignIn = ApiHost + "/api/users/signin";
        public const string Me = ApiHost + "/api/users/me";


        #endregion

        #region CMS

        public static string SignInAdmin = ApiHost + "/api/users/cms/signin";

        #endregion

        #endregion
    }

    public class Headers
    {
        public static ICollection<KeyValuePair<string, string>> HeadersCommon()

        {
            var headersCommon = new List<KeyValuePair<string, string>>();

            headersCommon.Add(new KeyValuePair<string, string>("accept", "application/json, text/plain, /"));
            headersCommon.Add(new KeyValuePair<string, string>("accept-encoding", "gzip, deflate, br"));
            headersCommon.Add(new KeyValuePair<string, string>("content-type", "application/json"));

            return headersCommon;
        }
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

    public class UploadedImages
    {
        public const string RaffleBathroom = $"\\UploadImages\\RaffleBathroom.jfif";
        public const string RaffleBedroom = $"\\UploadImages\\RaffleBedroom.jfif";
        public const string RaffleFloorPlan = $"\\UploadImages\\RaffleFloorPlan.jpg"; 
        public const string RaffleOutspace = $"\\UploadImages\\RaffleOutspace.jfif";
    }

    public class TakeTourWithSaraLink
    {
        public const string TakeTour = "https://www.youtube.com/embed/hMvXYHRvN-I";
    }

    public class DreamHomeTexts
    {
        public const string Bedrooms = "A spacious primary bedroom with lots of natural light and LED lighting throughout for energy saving light at night. Electric radiator heating system, and Drayton Wiser smart heating system. USB outlets throughout and a video entry-phone system.";
        public const string Bathrooms = "Contemporary white sanitary-ware with Grohe chrome taps. Fully tiled walls and floor. Overhead Rain shower. Chrome heated towel rail, and modern monochromatic vibes throughout.";
        public const string Outspace = "West Drayton offers a range of parks which are all home to excellent scenery and wildlife. One of these, Bunny Park, is a perfect destination for a family day out as it not only has a fantastic play areas for kids of all ages, but there is also a maze and an animal park that houses birds, goats, sheep and peacocks. ";
        public const string About = "On October 30, live your dream and win the £250,000 West Drayton flat for just £2 \n" 
                                    + "Will you live in it, rent it out or sell up? Or you can choose to take a £200,000 cash alternative \n"
                                    + "The new development is being offered exclusively to Raffle House in partnership with the Black Property Network \n"
                                    + "Plus, we’re throwing in £3,000 to help you settle in and cover any bills \n"
                                    + "What’s more, we’ll match any ticket bought for the London flat with tickets for the Copperworks flat! That's £500,000 up for grabs for just £2! \n"
                                    + "That’s more chances to win and support for Centrepoint and Housing for Women, our chosen charities.More on them in our About page.";
        public const string ProductPageCTA = "London Dream Home or £200,000 cash";
        public const string Heading = "The London \n WIN this stunning property for just £2. Or, if you don't fancy being a homeowner, you can elect to take £200,000 tax-free!";
    }

    public class AboutTexts
    {
        public static string[] FindOutTexts =
        {
            "This is your chance to win your own home, Stamp Duty and legal fees paid while donating to worthy causes. We'll even chuck in your bills and utility costs for a year.Be mortgage-free for life; live in it, rent it, or sell it — it'll be yours, no strings attached.",
            "Our Fixed Odds competitions offer bigger prizes, and do exactly what they say on the tin; provide certainty around your odds. The amount of tickets is fixed, so your odds are too.We'll always show you how many tickets to be sold in total, as well as a real-time view of how many have been sold."
        };

        public static string[] StepsTitleTexts =
        {
            "Choose Your Prizes & Add Tickets",
            "Guaranteed Winners",
            "More Than Just a Ticket"
        };

        public static string[] StepsDescrTexts =
        {
            "Search our Fixed Odds Prizes, as well as our Jackpot Property Prizes.",
            "We guarantee multiple winners with tens of thousands of pounds up for grabs.",
            "Choose if you want us to donate some of your purchase value to our homelessness charity partners."
        };

        public static string[] CharitableTexts =
        {
            "As the pandemic continues, more young people than ever are facing homelessness, many for the first time in their lives. Centrepoint are experiencing a surge in calls from homeless young people who have lost their job and their homes, and are uncertain where to turn. From housing and health to learning and engagement, Centrepoint aim to help vulnerable young people move on from homelessness and build a future they can believe in.",
            ""
        };

        public static string TitleSiteCredit = "Earn When You Play";
        public static string[] DescriptionSiteCreditTexts =
        {
            "We reward you, every time you play. For every purchase, we'll give you 10% of the total value back in site credit. This credit can be saved or spent as you wish.",
            "Credit expires 30 days after it was first earned. We'll remind you if you have any credit that is due to expire so you'll never lose out."
        };
    }
}
