using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class ApiEndpoints
    {
        public const string API = "https://staging-api.rafflehouse.com";
    }
    public class AdminEndpoints
    {
        public const string ADMIN_HOST = "https://admin-staging.rafflehouse.com";
        public const string DREAMHOME_PRIZES = "https://admin-staging.rafflehouse.com/#/dreamHome";
        public const string LIFESTYLE_PRIZES = "https://admin-staging.rafflehouse.com/#/prizes";
        public const string FIXEDODDS_PRIZES = "https://admin-staging.rafflehouse.com/#/fixedOdds";
    }
    public class WebEndpoints
    {
        public const string WEBSITE_HOST = "https://staging.rafflehouse.com";
        public const string SIGN_IN = "https://staging.rafflehouse.com/sign-in";
        public const string SIGN_UP = "https://staging.rafflehouse.com/sign-up";
        public const string DREAMHOME = "https://staging.rafflehouse.com/dreamhome";
        public const string LIFESTYLE = "https://staging.rafflehouse.com/lifestyleprizes";
        public const string FIXEDODDS = "https://staging.rafflehouse.com/fixedodds";
        public const string WINNERS = "https://staging.rafflehouse.com/winners";
        public const string ABOUT = "https://staging.rafflehouse.com/about-us";
        public const string PROFILE = "https://staging.rafflehouse.com/profile";
        public const string FREE_ENTRY = "https://staging.rafflehouse.com/post";
    }

    public class Credentials
    {
        public const string LOGIN = "qatester91311@gmail.com";
        public const string PASSWORD = "Qaz11111";

        public const string LOGIN_ADMIN = "bennospencer@gmail.com";
        public const string PASSWORD_ADMIN = "1289Raffle@!CMS";
    }

    public class Categories
    {
        public const string CATEGORY = "Tech";
    }

    public class SubCategories
    {
        public const string SUBCATEGORY = "Phones & Tablets";
    }

    public class UploadedImages
    {
        public const string RAFFLE_BATHROOM = $"\\UploadImages\\RaffleBathroom.jfif";
        public const string RAFFLE_BEDROOM = $"\\UploadImages\\RaffleBedroom.jfif";
        public const string RAFFLE_FLOOR_PLAN = $"\\UploadImages\\RaffleFloorPlan.jpg"; 
        public const string RAFFLE_OUTSPACE = $"\\UploadImages\\RaffleOutspace.jfif";
    }

    public class TakeTourWithSaraLink
    {
        public const string TAKE_TOUR = "https://www.youtube.com/embed/hMvXYHRvN-I";
    }

    public class DreamHomeTexts
    {
        public const string BEDROOMS = "A spacious primary bedroom with lots of natural light and LED lighting throughout for energy saving light at night. Electric radiator heating system, and Drayton Wiser smart heating system. USB outlets throughout and a video entry-phone system.";
        public const string BATHROOMS = "Contemporary white sanitary-ware with Grohe chrome taps. Fully tiled walls and floor. Overhead Rain shower. Chrome heated towel rail, and modern monochromatic vibes throughout.";
        public const string OUTSPACE = "West Drayton offers a range of parks which are all home to excellent scenery and wildlife. One of these, Bunny Park, is a perfect destination for a family day out as it not only has a fantastic play areas for kids of all ages, but there is also a maze and an animal park that houses birds, goats, sheep and peacocks. ";
        public const string ABOUT = "On October 30, live your dream and win the £250,000 West Drayton flat for just £2 \n" 
                                    + "Will you live in it, rent it out or sell up? Or you can choose to take a £200,000 cash alternative \n"
                                    + "The new development is being offered exclusively to Raffle House in partnership with the Black Property Network \n"
                                    + "Plus, we’re throwing in £3,000 to help you settle in and cover any bills \n"
                                    + "What’s more, we’ll match any ticket bought for the London flat with tickets for the Copperworks flat! That's £500,000 up for grabs for just £2! \n"
                                    + "That’s more chances to win and support for Centrepoint and Housing for Women, our chosen charities.More on them in our About page.";
        public const string PRODUCT_CTA_BTN = "London Dream Home or £200,000 cash";
        public const string HEADING = "The London \n WIN this stunning property for just £2. Or, if you don't fancy being a homeowner, you can elect to take £200,000 tax-free!";
    }

    public class AboutTexts
    {
        public static string[] FINDOUT_TEXT =
        {
            "This is your chance to win your own home, Stamp Duty and legal fees paid while donating to worthy causes. We'll even chuck in your bills and utility costs for a year.Be mortgage-free for life; live in it, rent it, or sell it — it'll be yours, no strings attached.",
            "Our Fixed Odds competitions offer bigger prizes, and do exactly what they say on the tin; provide certainty around your odds. The amount of tickets is fixed, so your odds are too.We'll always show you how many tickets to be sold in total, as well as a real-time view of how many have been sold."
        };

        public static string[] STEPS_TITLE_TEXTS =
        {
            "Choose Your Prizes & Add Tickets",
            "Guaranteed Winners",
            "More Than Just a Ticket"
        };

        public static string[] STEPS_DESCR_TEXTS =
        {
            "Search our Fixed Odds Prizes, as well as our Jackpot Property Prizes.",
            "We guarantee multiple winners with tens of thousands of pounds up for grabs.",
            "Choose if you want us to donate some of your purchase value to our homelessness charity partners."
        };

        public static string[] CHARITABLE_TEXTS =
        {
            "As the pandemic continues, more young people than ever are facing homelessness, many for the first time in their lives. Centrepoint are experiencing a surge in calls from homeless young people who have lost their job and their homes, and are uncertain where to turn. From housing and health to learning and engagement, Centrepoint aim to help vulnerable young people move on from homelessness and build a future they can believe in.",
            ""
        };

        public static string TITLE_SITE_CREDITS = "Earn When You Play";
        public static string[] DESCR_SITE_CREDIT_TEXTS =
        {
            "We reward you, every time you play. For every purchase, we'll give you 10% of the total value back in site credit. This credit can be saved or spent as you wish.",
            "Credit expires 30 days after it was first earned. We'll remind you if you have any credit that is due to expire so you'll never lose out."
        };
    }

    public class Headers
    {
        public static Dictionary<string, string> COMMON = new Dictionary<string, string>()
        {
            {"accept:", "application/json, text/plain, /" },
            { "accept-encoding:", "gzip, deflate, br"}
        };

    }
}
