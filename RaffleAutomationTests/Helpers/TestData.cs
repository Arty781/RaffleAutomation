using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace RaffleAutomationTests.Helpers
{

#if DEBUG || CHROME || FIREFOX || DEBUG_MOBILE
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

    public class ApiEndpoints
    {
        public const string API = "https://staging-api.rafflehouse.com";
    }
#endif
#if RELEASE || RELEASE_MOBILE
    
public class WebEndpoints
    {
        public const string WEBSITE_HOST = "https://rafflehouse.com";
        public const string SIGN_IN = "https://rafflehouse.com/sign-in";
        public const string SIGN_UP = "https://rafflehouse.com/sign-up";
        public const string DREAMHOME = "https://rafflehouse.com/dreamhome";
        public const string LIFESTYLE = "https://rafflehouse.com/lifestyleprizes";
        public const string FIXEDODDS = "https://rafflehouse.com/fixedodds";
        public const string WINNERS = "https://rafflehouse.com/winners";
        public const string ABOUT = "https://rafflehouse.com/about-us";
        public const string PROFILE = "https://rafflehouse.com/profile";
        public const string FREE_ENTRY = "https://rafflehouse.com/post";
    }

        public class ApiEndpoints
    {
        public const string API = "https://backend.rafflehouse.com";
    }
#endif

    public class Credentials
    {
        public const string LOGIN = "qatester91311@gmail.com";
        public const string PASSWORD = "Qaz11111";

        public const string LOGIN_ADMIN = "bennospencer@gmail.com";
        public const string PASSWORD_ADMIN = "1289Raffle@!CMS";
    }

    public class Categories
    {
        public const string TECH = "Tech";
        public const string HOLIDAYS_EXPIRIENCES = "Holidays & Experiences";
        public const string LUXURY = "Luxury";
        public const string MOTORS = "Motors";
        public const string LIVING = "Living";
        public const string WORKING_FROM_HOME = "Working From Home";
    }

    public class SubCategoriesD
    {
        public const string PHONES_TABLETS = "Phones & Tablets";
    }

    public class UploadedImages
    {
        public const string RAFFLE_BATHROOM = @"UploadImages\RaffleBathroom.jpg";
        public const string RAFFLE_BEDROOM = @"UploadImages\RaffleBedroom.jpg";
        public const string RAFFLE_FLOOR_PLAN = @"UploadImages\RaffleFloorPlan.jpg";
        public const string RAFFLE_OUTSPACE = @"UploadImages\RaffleOutspace.jpg";
        public const string RAFFLE_DESKTOP_1 = @"UploadImages\Desktop\DreamHomeImage1.jpg";
        public const string RAFFLE_DESKTOP_2 = @"UploadImages\Desktop\DreamHomeImage2.jpg";
        public const string RAFFLE_DESKTOP_3 = @"UploadImages\Desktop\DreamHomeImage3.jpg";
        public const string RAFFLE_DESKTOP_4 = @"UploadImages\Desktop\DreamHomeImage4.jpg";
        public const string RAFFLE_DESKTOP_5 = @"UploadImages\Desktop\DreamHomeImage5.jpg";
        public const string RAFFLE_DESKTOP_6 = @"UploadImages\Desktop\DreamHomeImage6.jpg";
        public const string RAFFLE_DESKTOP_7 = @"UploadImages\Desktop\DreamHomeImage7.jpg";
        public const string RAFFLE_MOBILE_1 = @"UploadImages\Mobile\DreamHomeImage1.jpg";
        public const string RAFFLE_MOBILE_2 = @"UploadImages\Mobile\DreamHomeImage2.jpg";
        public const string RAFFLE_MOBILE_3 = @"UploadImages\Mobile\DreamHomeImage3.jpg";
        public const string RAFFLE_MOBILE_4 = @"UploadImages\Mobile\DreamHomeImage4.jpg";
        public const string RAFFLE_MOBILE_5 = @"UploadImages\Mobile\DreamHomeImage5.jpg";
        public const string RAFFLE_MOBILE_6 = @"UploadImages\Mobile\DreamHomeImage6.jpg";
        public const string RAFFLE_MOBILE_7 = @"UploadImages\Mobile\DreamHomeImage7.jpg";
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

    public class HomeTexts
    {
        public static readonly string SECONDARY_BANNER_TITLE = "Win this Dream Home worth more than £2 million";
        public static readonly string[] TITLES_INFO_BLOCKS =
        {
            "This home is what dreams are made of.",
            "Move in immediately. Furnishings included",
            "Location, location, location",
            "No mortgage. No Stamp Duty. No strings attached.",
            "Dream Big. Do Good"
        };

        public static readonly string[] PARAGRAPHS_INFO_BLOCKS =
        {
            "Nestled in picturesque Cornwall, Home Farm is a sight to behold. A beautifully restored Georgian five-bedroom house with a four-bedroom newly refurbished barn and private gardens worth more than £2 million. Your Dream Home is here.",
            "The property comes fully furnished with £150,000 worth of top-of-the-range home decor. You'll be putting your feet up in no time, enjoying a glass of wine in pure opulence.",
            "This sumptuous Dream Home can be found in Cornwall, a hop, skip, and a jump from the beautiful English coast and Porthleven. Clotted cream, English jam, and fluffy scones will become an everyday staple while you enjoy your new mortgage-free life.",
            "You won't pay a penny more than your ticket to win. There's no Stamp Duty to pay and you'd own the freehold outright. We also cover any conveyancing fees as well!Or, you can choose to take the £2 million tax-free alternative. It's time to dream big and do good.",
            "Every time you enter, you're supporting youth homelessness charity Centrepoint. More young people than ever are facing homelessness, many for the first time in their lives. Centrepoint constantly experience calls from homeless young people who have lost their job and their homes, and are uncertain where to turn. From housing and health to learning and engagement, Centrepoint aim to help vulnerable young people move on from homelessness and build a future they can believe in."
        };

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Make an account",
            "More than just a ticket"
        };

        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We will direct you to make an account to keep a record of your purchase. We'll also email you a receipt containing your ticket numbers.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class Headers
    {
        public static Dictionary<string, string> COMMON = new Dictionary<string, string>()
        {
            {"accept", "application/json, text/plain, */*" },
            { "accept-encoding", "gzip, deflate, br"},
            {"content-type", "application/json" }
        };

    }

    public class Keyss
    {
        public static string Control()
        {
            string control = String.Empty;
            if (OperatingSystem.IsWindows())
            {
                control = Keys.Control;
            }
            else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
            {
                control = Keys.Command;
            }
            return control;
        }
    }

    public class Country
    {
        public static List<string> COUNTRY_CODES = new()
        {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Angola",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cayman Islands",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Costa Rica",
            "Czech Republic",
            "DR Congo",
            "Denmark",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hong Kong",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Libya",
            "Lithuania",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Moldova",
            "Mongolia",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "North Macedonia",
            "Oman",
            "Pakistan",
            "Palestinian Territories",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Republic of Korea",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Singapore",
            "Solomon Islands",
            "South Africa",
            "Spain",
            "Sri Lanka",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "UAE",
            "UK",
            "USA",
            "Uganda",
            "Ukraine",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Zambia",
            "Zimbabwe"
        };
    }
}
