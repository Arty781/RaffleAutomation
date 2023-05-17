using Allure.Commons;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RaffleAutomationTests.APIHelpers.Admin.UsersPage;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.Basket;
using RaffleAutomationTests.PageObjects;
using RimuTec.Faker;
using SharpCompress.Common;
using static RaffleAutomationTests.Helpers.DbModels;

namespace RaffleAutomationTests.Helpers
{

#if DEBUG || CHROME || FIREFOX || DEBUG_MOBILE
    public class AdminEndpoints
    {
        public const string ADMIN_HOST = "https://admin-staging.rafflehouse.com";
        public const string DREAMHOME_PRIZES = "https://admin-staging.rafflehouse.com/#/dreamHome";
        public const string LIFESTYLE_PRIZES = "https://admin-staging.rafflehouse.com/#/prizes";
        public const string FIXEDODDS_PRIZES = "https://admin-staging.rafflehouse.com/#/fixedOdds";
        public const string USER_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/users";
        public const string STAFF_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/staffUsers";
        public const string SETTINGS_GENERAL = "https://admin-staging.rafflehouse.com/#/general";
        public const string SETTING_WINNERS = "https://admin-staging.rafflehouse.com/#/winners";
        public const string SETTINGS_REFERRALS = "https://admin-staging.rafflehouse.com/#/referrals";
        public const string COMPETITIONS = "https://admin-staging.rafflehouse.com/#/competitions";
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
        public const string BASKET = "https://staging.rafflehouse.com/basket";
        public const string PAGE_DISCOUNT = "https://pagediscount-staging.rafflehouse.com/";
        public const string WIN_RAFFLE = "https://win-staging.rafflehouse.com/";
    }

    public class ApiEndpoints
    {
        public const string API = "https://staging-api.rafflehouse.com";
        public const string API_CHIL = "staging-api.rafflehouse.com";
    }

    public class DbConnection
    {
        public const string DB_STAGING = "rafflehousedb_staging";
        public const string DB_STAGING_CONNECTION_STRING = "mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging";
    }
#endif
#if RELEASE || RELEASE_MOBILE

    public class AdminEndpoints
    {
        public const string ADMIN_HOST = "https://admin.rafflehouse.com";
        public const string DREAMHOME_PRIZES = "https://admin.rafflehouse.com/#/dreamHome";
        public const string LIFESTYLE_PRIZES = "https://admin.rafflehouse.com/#/prizes";
        public const string FIXEDODDS_PRIZES = "https://admin.rafflehouse.com/#/fixedOdds";
    }
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
        public const string BASKET = "https://rafflehouse.com/basket";
        public const string PAGE_DISCOUNT = "https://discount.rafflehouse.com/";
        public const string WIN_RAFFLE = "https://win.rafflehouse.com/";
    }

        public class ApiEndpoints
    {
        public const string API = "https://backend.rafflehouse.com";
        public const string API_CHIL = "backend.rafflehouse.com";
    }
#endif

    public class Credentials
    {
        public const string LOGIN = "qatester91311@gmail.com";
        public const string PASSWORD = "Qaz11111";
        public const string NEW_PASWORD = "Qaz11111!";

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
        public const string RAFFLE_LOCATION_MAP = @"UploadImages\RaffleLocationMap.jpg";
        public const string RAFFLE_OUTSPACE = @"UploadImages\RaffleOutspace.jpg";
        public const string RAFFLE_DESKTOP_1 = @"UploadImages\Desktop\DreamHomeImage01.jpg";
        public const string RAFFLE_DESKTOP_2 = @"UploadImages\Desktop\DreamHomeImage02.jpg";
        public const string RAFFLE_DESKTOP_3 = @"UploadImages\Desktop\DreamHomeImage03.jpg";
        public const string RAFFLE_DESKTOP_4 = @"UploadImages\Desktop\DreamHomeImage04.jpg";
        public const string RAFFLE_DESKTOP_5 = @"UploadImages\Desktop\DreamHomeImage05.jpg";
        public const string RAFFLE_DESKTOP_6 = @"UploadImages\Desktop\DreamHomeImage06.jpg";
        public const string RAFFLE_DESKTOP_7 = @"UploadImages\Desktop\DreamHomeImage07.jpg";
        public const string RAFFLE_DESKTOP_8 = @"UploadImages\Desktop\DreamHomeImage08.jpg";
        public const string RAFFLE_DESKTOP_9 = @"UploadImages\Desktop\DreamHomeImage09.jpg";
        public const string RAFFLE_DESKTOP_10 = @"UploadImages\Desktop\DreamHomeImage10.jpg";
        public const string RAFFLE_DESKTOP_11 = @"UploadImages\Desktop\DreamHomeImage11.jpg";
        public const string RAFFLE_MOBILE_1 = @"UploadImages\Mobile\DreamHomeImage01.jpg";
        public const string RAFFLE_MOBILE_2 = @"UploadImages\Mobile\DreamHomeImage02.jpg";
        public const string RAFFLE_MOBILE_3 = @"UploadImages\Mobile\DreamHomeImage03.jpg";
        public const string RAFFLE_MOBILE_4 = @"UploadImages\Mobile\DreamHomeImage04.jpg";
        public const string RAFFLE_MOBILE_5 = @"UploadImages\Mobile\DreamHomeImage05.jpg";
        public const string RAFFLE_MOBILE_6 = @"UploadImages\Mobile\DreamHomeImage06.jpg";
        public const string RAFFLE_MOBILE_7 = @"UploadImages\Mobile\DreamHomeImage07.jpg";
        public const string RAFFLE_MOBILE_8 = @"UploadImages\Mobile\DreamHomeImage08.jpg";
        public const string RAFFLE_MOBILE_9 = @"UploadImages\Mobile\DreamHomeImage09.jpg";
        public const string RAFFLE_MOBILE_10 = @"UploadImages\Mobile\DreamHomeImage10.jpg";
        public const string RAFFLE_MOBILE_11 = @"UploadImages\Mobile\DreamHomeImage11.jpg";
    }

    public class TakeTourWithSaraLink
    {
        public const string TAKE_TOUR = "https://www.youtube.com/embed/hMvXYHRvN-I";
    }

    public class CardDetails
    {
        public static readonly List<string> CARD_NUMBER = new()
        {
            "4242424242424242",
            "4485040371536584",
            "5588686116426417"
        };
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
        public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
        public static readonly string SECONDARY_BANNER_TITLE = "Win This Dream Home Worth More Than £2 Million";
        public static readonly string SECONDARY_BANNER_SUBTITLE = "Plus £1 million in early bird cash-prizes to be won by four lucky customers! Enter today for your chance to win.";

        public static readonly string BOTTOM_SLIDER_TITLE = "Let’s Take A Closer Look At Your Dream Home";
        public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

        public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "This Home Is What Dreams Are Made Of; Meet The Orchard",
            "Move In Immediately. Furnishings Included",
            "Location, location, location",
            "No mortgage. No Stamp Duty. No strings attached",
            "Dream Big. Do Good",
            "Enter Now To Win A £250,000 Early Bird Bonus Prize"
        };
        public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "A Dream Home prize worth more than £2 million, with £100,000 to help start your new life. Or a tax-free alternative of £2 million cash.",
            "The Orchard is a luxury and contemporary four-bedroom house with private gardens and woodland on England’s south coast." ,
            "Your Dream Home is here.",
            "We want to make the winner’s journey that much more exciting by providing a further £100,000 to furnish the property as you see fit." ,
            "We’ll set you up with world renowned and leading interior design house, Alexander James, to fully kit out your new Dream Home with dramatic and sublime home décor.",
            "This sublime Dream Home can be found in Ovingdean, a hop, skip and jump from our country’s summer capital, Brighton.",
            "The Orchard is surrounded by private woodland, the South Downs, and England’s great countryside, which are yours to enjoy in your new mortgage-free life.",
            "You won't pay a penny more than your ticket to win. There's no Stamp Duty to pay and you'd own the freehold outright. We also cover any conveyancing fees as well.",
            "Or you can choose to take the £2 million tax-free cash alternative. It's time to dream big and do good, our 7th Dream Home competition has arrived.",
            "Every time you enter, you’ll be supporting the Great Ormond Street Hospital, which sees about 600 children and young people from across the UK arrive for life-changing treatments every single day.",
            "This extraordinary hospital has always depended on charitable support, and you can make a difference today by supporting them just by buying a ticket to win your Dream Home.",
            "Enter today for your chance to win your slice of £1 million in bonus, early bird prizes as well.",
            "Every time you buy Dream Home tickets, every single one of them will be entered into all upcoming £250,000 draws - and there are four of these before the big £2 million Dream Home competition ends!",
            "That's a total prize pool worth more than £3 million. The time to dream big is today."
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
            "Select which ticket bundle you want to buy to win your Dream Home. ",
            "We will direct you to make an account to keep a record of your purchase. We'll also email you a receipt containing your ticket numbers.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class SubscriptionTexts
    {
        public static readonly string TITLE_H1 = "Never Miss Your Chance To Dream Big And Do Good";
        public static readonly List<string> TITLES_H2 = new()
        {
            "Subscription Benefits",
            "How it Works",
            "Frequently Asked Questions",
            "Dream Big. Do Good",
            string.Empty,
            "As Seen In",
            "Got A Question?"
        };
        public static readonly List<string> TITLES_H3 = new()
        {
            "Subscribe at any time",
            "You’re all set",
            "Peace of mind",
            "Choose your charity every month",
            "About Raffle House"
        };
        public static readonly List<string> PARAGRAPHS = new()
        {
            "Get triple the entries to all our Early Bird and multi-million pound Dream Home draws every single month. ",
            "Dream Big and Do Good Every Single Month with a Raffle House Subscription",
            "",
            "If you want the peace of mind that you’ve always got your tickets to win our Early Bird Prizes or Dream Homes, our subscription options are the perfect solution. ",
            "Subscribing to our competitions is quick and easy.",
            "Get triple the usual entries into every single upcoming Early Bird and Dream Home draw",
            "You’ll receive your subscription tickets at the beginning of every month.",
            "Whenever a new Dream Home is announced, even if two are live at the same time, you’ll be automatically entered into both without having to make a new purchase.",
            "Every month, you can choose to change where you want 10% of your payment to be donated to or keep your preferred charity. You can cancel at any time or even skip a month or two.",
            "What’s the benefit of subscribing?",
            "Not only will you always guarantee yourself tickets to win our Early Bird and Dream Home Prizes, but you’ll be also doing so with three times more tickets than a one-off purchase.",
            "Where will I see my tickets?",
            "We’ll email you your tickets when you first activate your subscription, and then at the beginning of every month we’ll confirm your new ticket numbers on your renewed subscription. You’ll also be able to find these in your account.",
            "Can I choose a different charity each month?",
            "Yes. In that same email you’ll receive at the beginning of the month, you can decide to switch your charitable giving or do nothing to keep it the same.",
            "Are my tickets entered into all prize pools?",
            "Yes. Your tickets will be entered into every single Early Bird Prize draw, as well as all Dream Home draws, as well as any other prize pools yet to be announced.",
            "Can I cancel whenever I like?",
            "Absolutely. Your tickets will remain valid for all upcoming Early Bird Prizes and the next Dream Home draw and you can choose to use the Free Entry option at any time. You can manage your subscription from your account or our customer support team can help you.",
            "I won’t lose any tickets even if I cancel my subscription?",
            "That’s right. You’ll keep all of the tickets from the beginning of your subscription period to its end, and they’ll all remain valid for any upcoming Early Bird or Dream Home draws.",
            "If I subscribe, can I still buy regular ticket bundles?",
            "Yes. You’ll still have the option of buying regular ticket bundles or using the Free Entry option, as well as taking advantage of any discounts or deals that we offer from time-to-time.",
            "Every month, you’ll be able to choose from one of over 25 charities to donate to or keep your donation where it is.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good.",
            "",
            "",
            "",
            "Contact Us"

        };
    }

    public class Headers
    {
        public static Dictionary<string, string> COMMON = new Dictionary<string, string>()
        {
            {"accept", "application/json, text/plain, */*" },
            {"accept-encoding", "gzip, deflate, br"},
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

    public class FooterText
    {
        public const string FOOTER_TITLE = "About Raffle House";
        public const string FOOTER_PARAGRAPH = "We offer you the chance to win your Dream Home or multi-million pound cash-prize while donating to worthwhile causes. Every Dream Home entry is automatically added to the bonus prize pools and will be drawn for each consecutive competition. Our paid competitions to win a Dream Home and bonus prizes also include a postal entry method. It’s time to dream big and do good.";
        public static readonly List<string> FOOTER_CONTACTS_LINKS = new()
        {
            "Home",
            "Winners",
            "Subscription",
            "Login / Register",
            "Terms & Conditions",
            "Privacy Policy",
            "Contact"
        };
        public static readonly List<string> FOOTER_SPONSORS_LINKS = new()
        {
            "GambleAware",
            "Copyright 2017-2023 - Raffle House Ltd.",
            "Company Reg. No. 10928240 - All Rights Reserved"
        };
    }

    public class PostText
    {
        public const string TITLE_POST = "How To Enter For Free By Post";
        public static readonly List<string> PARAGRAPH_POST = new()
        {
            "Raffle House offers a postal entry for its competitions. Just like the paid method of entering its competitions, the postal method requires that you create an online account and accept our T&Cs. This is so that we can verify your entry details and provide you with an electronic record of your entry.",
            "Click the button below to create an account.",
            "On a blank sheet of paper write your full name, date of birth, telephone number, email address, and the title of the competition you are submitting an entry for. Please refer to the individual product pages for competition titles. Examples of these can be found in our T&Cs. This information must match the information that you use to create your online account and needs to be written legibly otherwise the entry may be deemed invalid.",
            "We have appointed Civica Election Services, formerly known as Electoral Reform Services (ERS),as our independent scrutineers to administer this competition. They have over 100 years’ experience in administering elections, ballots and competitions for a wide range of clients including TV programmes and various lottery projects. Please send the sheet of paper in an envelope to the following address via first- or second-class post to:",
            "A maximum of one entry can be made per envelope received.",
            "Postal entries are treated in exactly the same way as paid entries for the purposes of determining a winner. However, there is a difference in the deadlines for postal entries for the property competition.\r\nOur property draw closes at midnight on its final day; the corresponding cut-off for postal entries will be that they are received and processed before 5pm four business days later.",
            "One postal entry has an equal chance of winning as any one paid entry. If a postal entry wins a prize there will be no further purchase or payment necessary to be notified of the win or to receive the prize. If the above steps are not followed as described, then a postal entry will be invalid.",
            "You will not be notified if your entry is invalid and only valid entries will appear on your online account."

        };
        public static readonly List<string> PARAGRAPH_LINKS_POST = new()
        {
            "Raffle House Postal Entry​",
            "Civica Election Services​",
            "33 Clarendon Road​",
            "London",
            "N8 0NW​"
        };
    }

    public class TermsConditions
    {
        public const string TERMS = "Last Update: April 5, 2021\r\n\r\n" +
            "Subject to the Terms and Conditions detailed in full below:\r\n\r\n" +
            "No purchase, payment or other financial contribution is necessary to enter or win any Competition and Raffle House’s Postal Entry is available for all Competitions.\r\n\r\n" +
            "Raffle House Ltd. gives its customers the chance to win Jackpot Property, Weekly Lifestyle, Fixed Odds, and Cash Prizes through Competitions it displays on its Website.\r\n\r\n" +
            "Every week, at least one Winner of the Weekly Cash Prize Competition of £1,000 will be Drawn, one winner of the Weekly Lifestyle Prize Competition will be Drawn, and if applicable, one winner of any Closed/completed Fixed Odds Competition will be Drawn.\r\n\r\n" +
            "The Jackpot Property Competition Closing Date is 30 June, 2021. The Weekly Lifestyle and Cash Prize Competitions reset every Sunday at midnight. Fixed Odds Competitions have bespoke dates reflected by their specific Competition product page on the Site.\r\n\r\n" +
            "For the Property to be awarded, the Minimum Number of Jackpot Property Entries to be sold is 650,000, and more information on this threshold can be found in our Help Centre (click FAQ in the menu and search for “threshold”).\r\n\r\n" +
            "In the event that the Jackpot Property Competition threshold is not met, full details regarding the 90% cash-prize can be found below.\r\n\r\n" +
            "The Promoter offers an automatic charitable donation option at checkout and we urge you to select a charity at checkout.\r\n\r\n" +
            "Customers that pay the Entry Fee will be emailed their receipt and Ticket(s) and find their Ticket(s) in their Account.\r\n\r\n" +
            "Customers that choose the Postal Entry will find their Ticket(s) in their Account following an administration period but cannot be emailed a receipt.\r\n\r\n" +
            "Terms & Conditions\r\n\r\n" +
            "The following Terms & Conditions apply to all Entries submitted to the Competition for which is set out in these Terms.\r\n\r\n" +
            "In entering the Competition, Entrants will be required to tick on the Website that they are over the age of 18, and have read and accepted these Terms and Conditions and agreed to be bound by them.\r\n\r\n" +
            "The Promoters\r\n\r\n" +
            "The Competition is operated by the Promoter. The Promoter is authorised by the owner of the Property to offer the Property as a prize in this Competition. The Promoters are members of the Property Redress Scheme, more information about which can be found here: www.theprs.co.uk.\r\n\r\n" +
            "How to enter\r\n\r\n" +
            "By submitting an Entry, Entrants agree to be bound by these Terms and Conditions. If you do not so agree, do not submit an Entry.\r\n\r\n" +
            "No purchase, payment or other financial contribution is necessary to enter or win any Competition and Raffle House’s Postal Entry is available for all Competitions. To validly enter the Competition Entrants must:\r\n" +
            "First, create a free Account; and then either:\r\n\r\n" +
            "pay the Entry Fee. The entry will qualify for the Jackpot Competition and the Weekly Lifestyle, Fixed Odds, and Cash Prize Competitions as per their Definitions; or\r\n\r\n" +
            "Print your full name, phone number, email address, and which competition you are submitting a ticket request for (Dream Home, Lifestyle Prize “xx” (for example: Lifestyle Prize “£5,000 Fast Cash”), Fixed Odds “xx” (for example: Fixed Odds “£1,000 A Week For A Year”) on a piece of paper and enclose in an envelope. This information must match with the information provided when creating a free account or your Postal Entry will be deemed invalid. With a first-class stamp, post the completed entry to: Raffle House Postal Entry, Civica Election Services, 33 Clarendon Road, London N80NW. There is a limit of one entry per outer stamped, mailing envelope. Each valid entry made via the Postal Entry will automatically qualify for the Jackpot Competition and, if the requirements are met, the Weekly Lifestyle, Fixed Odds and Cash Prize Competition with effect from the date that an entry is received and processed. No mechanically reproduced entries are permitted. Illegible entries are void. Raffle House is not responsible for lost, late, mutilated, delayed, inaccurate, incomplete, postage due, misdirected entries or entries not received by the last day of the applicable entry period. Each Postal Entry will be equivalent to a single entry into the relevant Competition that may be awarded via paying an Entry Fee. You must provide all required information to be eligible to enter and win. Automated entries will be disqualified. Postal Entries must be submitted by the Raffle House account holder. No copies, facsimiles, or mechanical reproductions of entries will be accepted. Postal Entries shall have the same status as Entries paid in cash, except they shall not count towards the calculation of the Minimum Number of Jackpot Property Entries. Civica Election Services are a third-party entity that provide the Promoter with an independent postal and submission verification service only, with no recourse or liability with regards to providing prizes to entrants as advertised by the Promoter.\r\n\r\n\r\n" +
            "At the Promoter’s sole discretion, the requirement to pay the Entry Fee may be satisfied by redeeming a voucher code or credit provided to the Entrant under one of its promotional schemes. Entries so credited as paid shall have the same status as Entries paid in cash excepting that they shall not count towards the calculation of the Minimum Number of Jackpot Property Entries.\r\n\r\n" +
            "Payment of the Entry Fee shall be processed by Checkout.com. Card payments shall be subject to Checkout.com’s terms and conditions, which shall be available to view by following the link:http://checkout.com/.The Entry Fee must be received by the Promoter in pounds sterling only and if you make payment in a different currency, the amount you pay in that currency may have currency exchange and international transfer charges added.\r\n\r\n" +
            "Entrants will be asked to provide their contact details, including e-mail address and phone number. This information will be processed in accordance with the provisions below and the Promoter’s Data Protection and Privacy Policy. The Promoter’s card service provider, Checkout.com, will require the Entrant’s card payment details. Once the Entry is submitted, the Entrant’s card payment will be electronically approved and the Promoter will not retain any records of the Entrant’s card details. Raffle House never sees or stores any card payment details.\r\n\r\n" +
            "The Promoter will store and process the Entrant’s name and personal information (which must include details of at least one form of contact) which will be used for the following purposes:\r\n\r\n" +
            "The Promoter will store and process the Entrant’s name and personal information (which must include details of at least one form of contact) which will be used for the following purposes:\r\n\r\n" +
            "to notify any Winner or Runner(s) Up that they that they have won a prize in the Competitions;\r\n\r\n" +
            "to administer the Website and conduct the Competitions; and\r\n\r\n" +
            "after a Draw, to post the Winner and any Runner(s) Up's name and town of residence on the Website and in publicity about the Competitions.\r\n\r\n" +
            "All Entrants are solely and completely responsible for providing the Promoters with accurate and current personal and contact details.\r\n\r\n" +
            "The Promoters will be in no way liable for any failure or inability to make contact with any Entrant due to any errors, omissions or inaccuracies in the contact details provided by the Entrants or otherwise.\r\n\r\n" +
            "The Promoters will not accept:\r\n\r\n" +
            "responsibility for Entries that are lost, mislaid, damaged or delayed in transit, regardless of cause including, for example, equipment failure, technical malfunction, systems, satellite, network, server, computer hardware or software failure of any kind; or\r\n\r\n" +
            "any other purported proof of entry to the Competitions other than as recorded by the Website’s systems.\r\n\r\n" +
            "An Entry shall be declared void (without any refund being given) if the Entrant engages in: (a) any form of fraud (actual or apparent); (b) fraudulent misrepresentation; (c) fraudulent concealment; (d) hacking or interference with the proper functioning of the Website; or (e) amending, or unauthorised use of, any of the code that constitutes the Website.\r\n\r\n" +
            "Each individual Entrant may submit up to 5,000 (five thousand) paid Entries to the Jackpot Property competition, and the Entry Fee must be paid on each purchase. If using the Postal Entry, each individual Entrant may submit up to 5,000 (five thousand) valid Entries, but there is a limit of one entry per outer stamped, mailing envelope (pursuant to term 3). Any “Fast Cash” Lifestyle or Fixed Odds Competition will have a limit of £1,000 per individual Entrant, and the equivalent number of Postal Entries.\r\n\r\n" +
            "All entries will be electronically recorded by the Promoter and accessible via the Entrant’s Account. Valid Postal Entry submissions will take a processing time before being visible via the Entrant’s account.\r\n\r\n" +
            "All Postal Entries will become the property of the Promoters on receipt and will not be returned. Entrants via this method will not receive notification of their Ticket; instead, it is incumbent on the individual to check their account online.\r\n\r\n" +
            "All Entries to the Competition are final and no refunds shall be made at any time or for any reason, except in the case of Entries submitted after the Closing Date for which payment has been taken and pursuant with terms 46 and 47. In the case of Postal Entries, all those entries posted on the last business day of the Competition will be included, based on typical postal service delivery times.\r\n\r\nFor help with Entries, please visit the Website.\r\n\r\n\r\nEligibility\r\n\r\n" +
            "The Competitions are open for entry only to private individuals (i.e., not companies or businesses) aged 18 or over, excluding:\r\n\r\n" +
            "the Promoter, their immediate family, agents, or employees; or\r\n\r\n" +
            "anyone else connected with the development or operation of the Website or the conduct or administration of the Competition in any way, shape or form; or\r\n\r\n" +
            "the members of the immediate families or households of the above.\r\n\r\n" +
            "In entering any Competition, all Entrants confirm that they are eligible to do so and eligible to claim any prize awarded in any Competition. The Promoters may require any Entrant to provide evidence that they are eligible to enter any Competition.\r\n\r\n" +
            "The Promoter will not accept Postal Entries that are:\r\n\r\n" +
            "from countries outside of the UK\r\n\r\n" +
            "automatically generated by computer;\r\n\r\n" +
            "illegible, have been altered, reconstructed, forged, tampered with or incomplete\r\n\r\n" +
            "The Promoters reserve all rights to disqualify Entrants if their conduct is contrary to the spirit or intention of any Competition.\r\n\r\n" +
            "Entries on behalf of another person can be accepted and joint submissions are allowed. However, a single Account holder and person will be required to take ownership of any Prize and be the Ticket holder.\r\n\r\n" +
            "Credit can be earned by any Account holder and Referrals can be made by any Account holder. Any consumed Credit granted to the Account holder and transferred to Entries will be treated in exactly the same way as any paid or Postal Entries for any Competition and its corresponding Draw.\r\n\r\n" +
            "If any Entrant, at any time prior to the end of any Competition, deletes their Account, any Entries held by that Account will also be removed from any future Draw. Deleting Accounts is different from logging out, which will not remove any Entries. Deleting Accounts requires 2-step verification for safety. Any Entries removed from any Draw due to Account deletion will not be re-instated and refunds will not be awarded (pursuant to term 15).\r\n\r\n" +
            "By entering any Competition, all Entrants warrant that all information which they submit is accurate, true, current and complete. The Promoter reserves the right to disqualify any Entrant (entirely at their own discretion) if there are reasonable grounds to believe the Entrant has acted in breach of any of these Terms and Conditions.\r\n\r\n" +
            "The Jack Property Prize and its Draw\r\n\r\n" +
            "The title of the Jackpot Property Competition is “A £2 ticket to your dream home”.\r\n\r\n" +
            "The Winner and Referral Prize Winner will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\r\n\r\n" +
            "The Draw to determine the Winner, the Referral Prize Winner and any Runner(s) Up will be made on the Draw Date (subject to term 28).\r\n\r\n" +
            "The Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, bring forward the Closing Date to a new Closing Date, to be before and no later than the specified Closing Date. Also, the Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, extend the Competition Closing Date.\r\n\r\n" +
            "If by the Closing Date (subject to term 28), at least the Minimum Number of Jackpot Property Entries has been received, the Competition will close and on the Draw Date:\r\n\r\n" +
            "there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 31), and the prize shall be the Property, plus the payment of Stamp Duty (as set out in term 37) and the Bonus Prize;\r\n\r\n" +
            "there will be an evaluation to determine the Winner of the Referral Prize, who shall be awarded the Referral Prize.\r\n\r\n" +
            "If by the Closing Date (subject to term 28), the actual number of Entries received is less than the Minimum Number of Jackpot Property Entries, the Competition will close and on the Draw Date there will be a Draw, at the sole discretion of the Promoter, by reference to the proceeds received from the Entries to:\r\n\r\naward to the Winner the Cash Prize and;\r\n\r\n" +
            "There will be an evaluation to determine the Winner of the Referral Bonus Prize, who shall be awarded the Referral Bonus Prize.\r\n\r\n" +
            "If any Jackpot Prize Winner or Runner(s) Up cannot be contacted by the Promoter within 21 days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Jackpot Prize Winner or Runner Up shall likewise comply with the above 21-day contact requirement.\r\n\r\n" +
            "The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. The Jackpot Prize Competition Draw shall be managed and verified by Sterling Lotteries who are independent of the Promoter and licensed and regulated by the Gambling Commission (More information about them can be found here:https://sterlinglotteries.co.uk/. The Weekly Lifestyle and Cash Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\r\n\r\n" +
            "On the Jackpot Property Draw Date, the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\r\n\r\n" +
            "The Winner and any Runner(s) Up will be required to forward a copy of their passport or driving licence together with two utility bills or bank statements (or a combination of the two) dated within the previous three months to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 31 above.\r\n\r\n" +
            "If the prize comprises the Property, the Promoter will arrange for the Property to be transferred by (or on behalf of) the legal owner(s)/proprietor(s) of the Property to the Winner subject to the terms of a separate sale contract and instrument of transfer to be entered into between the owner(s) of the Property and the Winner, free from any charges, mortgages or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any matters arising out of the conduct of the transfer of the Property including without limitation any negligence of any conveyancers.\r\n\r\n" +
            "The Promoters take care to only offer properties in good repair though do not in any way guarantee or give any warranties as to the value of the Property, its condition, history or any other matters associated with the Property.\r\n\r\n" +
            "Any Stamp Duty Land Tax (SDLT) and contribution to SDLT will only be paid to the extent that SDLT is actually payable. The maximum SDLT that could be payable (if the winner already owns a home) is £35,000. The Winner will be responsible for all other taxes or charges incurred arising out of the transfer to and ownership or occupation of the Property, including council taxes, grounds rents and service charges which are not covered by the Bonus Prize.\r\n\r\nThe Winner shall execute all documents required for the transfer of the Property and take all steps they can to ensure transfer and registration of the Property at the Land Registry within 4 months of the Draw Date.\r\n\r\n" +
            "The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\r\n\r\n" +
            "Fixed Odds Competitions and its Draws\r\n\r\n" +
            "The Winners will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\r\n\r\n" +
            "The Draw to determine the Winners and any Runner(s) Up will be made on the Draw Date (subject to term 42).\r\n\r\n" +
            "The Promoter may, at its sole discretion, and at any time during the Fixed Odds Competitions up to the end of the Closing Date, bring forward the Closing Date to a new Closing Date, to be before and no later than the specified Closing Date in the event that the Stated Number of Fixed Odds Entries have been sold. Also, the Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, extend the Competition Closing Date in the event that the Stated Number of Fixed Odds Entries has not been met a maximum of 4 times and extend no more than 30 days at each individual extension.\r\n\r\n" +
            "If by the Closing Date (subject to term 42), the Stated Number of Fixed Odds Entries has been received, the Competition will close and on the Draw Date: there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 45), and the Prize shall be awarded.\r\n\r\nFor Fixed Odds Competitions, if by the Closing Date (subject to term 42), the actual number of Entries received is less than the Stated Number of Fixed Odds Entries, the Competition will close and on the Draw Date there will be a Draw, at the sole discretion of the Promoter, by reference to the proceeds received from the Entries to: award to the Winner the Cash Prize (For Fixed Odds Competitions).\r\n\r\n" +
            "If any Fixed Odds Winner cannot be contacted by the Promoter within 7-days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Prize Winner or Runner Up shall likewise comply with the above 7-day contact requirement.\r\n\r\n" +
            "The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. Fixed Odds Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\r\n\r\n" +
            "On the Jackpot Property Draw Date, (or within the financial year if there are no properties offered), the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\r\n\r\n" +
            "The Winner may be required to forward a copy of their passport or driving to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 45 above.\r\n\r\n" +
            "The Promoter will arrange for any Prizes to be delivered or transferred to the Winners to the free from any charges or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any costs associated with the ownership of any Prize once transferred to the Winners.\r\n\r\n" +
            "The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\r\n\r\n" +
            "Weekly Lifestyle, and Weekly Cash Prize Competitions and their Draws\r\n\r\nThe Winners will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\r\n\r\n" +
            "The Draw to determine the Winners and any Runner(s) Up will be made the day after the Competitions’ Closing Date.\r\n\r\nOn every Closing Date there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 54), and the prize shall be awarded.\r\n\r\n" +
            "If any Lifestyle Prize or Weekly Cash Prize Winner cannot be contacted by the Promoter within 7-days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Prize Winner or Runner Up shall likewise comply with the above 7-day contact requirement.\r\n\r\n" +
            "The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. Weekly Lifestyle and Weekly Cash Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\r\n\r\nOn the Jackpot Property Draw (or within the financial year if there are no properties offered), the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\r\n\r\n" +
            "The Winner may be required to forward a copy of their passport or driving to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 54 above.\r\n\r\n" +
            "The Promoter will arrange for any Prizes to be delivered or transferred to the Winners free from any charges or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any costs associated with the ownership of any Prize once transferred to the Winners.\r\n\r\n" +
            "The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\r\n\r\nWinner Announcement\r\n\r\nThe Winner(s) and any Runner(s) Up shall be announced and publicised on the Website and via email campaigns, as well as on Raffle House’s associated social media pages/sites, such as Facebook, Instagram and Twitter. Any Winner and Runner(s) Up shall cooperate with and participate in the Promoter’s reasonable publicity requests.\r\n\r\n" +
            "Limitation of Liability\r\n\r\nInsofar as is permitted by law, the Promoter, their agents or distributors will not in any circumstances be responsible or liable to compensate any Entrant or accept any liability for any loss, damage, personal injury or death occurring as a result of submitting and Entry or in relation to the Property except where it caused by the negligence or fraud of the Promoter, their agents or distributors, or that of their employees. The Winner’s(') statutory rights are not affected.\r\n\r\nThe liability of the Promoter to each Entrant is limited to the aggregate value of the Entry Fees paid by that Entrant.\r\n\r\n" +
            "The Promoters accept no liability for errors or omissions contained within the description of the Property or the Property Value or for any other description or specification or any other part of the Website. It is the responsibility of each Entrant (and in particular the Winner) to satisfy him/herself as to the accuracy of any such details and/or any content of the Website.\r\n\r\n" +
            "Each Entrant agrees that the usual requirement under the Consumer Protection (Distance Selling) Regulations 2000 for any goods and services ordered online to be supplied within 30 days will not apply to the Competition.\r\n\r\n" +
            "General\r\n\r\n" +
            "The Promoter shall not be a trustee of any Entry Fees received.\r\n\r\n" +
            "The Promoter reserves the right to suspend or cancel any Competition at any time either before or after Entries have been received. If the Competition is cancelled, the Promoter will return the Entry Fees to each Entrant by bank card refund or by cheque (at the Promoter’s sole discretion). Any refund of the Entry Fee may be subject to deduction of any irrecoverable acquiring bank service charge fees. Where the Entry Fee is returned, the Promoter shall have no further liability to the Entrant or to any other person.\r\n\r\n" +
            "Without prejudice to the operation of term 57 above, the Promoters reserve the right to cancel any Competition in the event that an order is made or a resolution is passed for the winding up of the Promoter, or an order is made for the appointment of an administrator to manage the affairs of the Promoter, or circumstances arise which entitle a court or creditor to appoint a receiver or manager or which entitle a court to make a winding up order, or the Promoter takes or suffers any analogous action in consequence of debt or an application to court for protection from its creditors is made by the Promoter.\r\n\r\n" +
            "The Promoters reserve the right to make reasonable amendments to these Terms and Conditions at any time, with immediate effect upon publishing such amendments on the Website. Any such amendments shall not prejudice any Entries received prior to the time of such changes.\r\n\r\n" +
            "These Terms and Conditions shall not create or be construed as creating any form of contract, joint venture or other agreement between any Entrant and the Promoters.\r\n\r\n" +
            "The Competition, its administration and all associated activities shall be governed by the laws of England and Wales and the parties submit to the exclusive jurisdiction of the courts of England and Wales.\r\n\r\n" +
            "Each Entrant should retain a copy of these Terms and Conditions as at the date of their Entry for their future reference.\r\n\r\n" +
            "Definitions\r\n \r\n" +
            "The following definitions apply in these Terms and Conditions:\r\n\r\n" +
            "ACCOUNT: means a free-to-create online Raffle House account, created using personal information, such as name, email address and telephone number or by using a Facebook or Google login, as set out in term 6 and processed in accordance with the Promoter’s Data Protection and Privacy Policy. The Account will display information pertinent to the Dream Home Prize Competition, Weekly Lifestyle, Fixed Odds and Weekly Cash Prize Competitions, such as Tickets, Referral links, account information and management tools.\r\n\r\n" +
            "BONUS PRIZE: is a sum payable to the Winner (subject to term 29) of up to £3,000 to cover council tax and reasonable utilities for a period of 12 months; and reasonable solicitors’ fees (to include disbursements) incurred in connection with the transfer of the Property to the Winner, capped at £1,500 inclusive of VAT.\r\n\r\n" +
            "CASH PRIZE (FOR THE DREAM HOME PROPERTY COMPETITION): in the event of a Draw under term 30, a cash prize payable to the Winner being calculated as (1) 90% of the total value of the total Entry Fees received up to the Closing Date net the Promoter’s costs and overheads; less (2) the amount of the Charity Donation; and less (3) the payment processor and acquiring bank fees.\r\n \r\n" +
            "CASH PRIZE (FOR FIXED ODDS COMPETITIONS): unless the prize is stated as guaranteed on the website and in the event of a Draw under term 44, a cash prize payable to the Winner being calculated as 70% of the total value of the total Entry Fees received up to the final Closing Date less (1) the amount of the Charity Donation; and less (2) the payment processor and acquiring bank fees.\r\n \r\n" +
            "CHARITY(IES): means the charities or charitable causes specified on the Website to whom the Charitable Donation will be paid after the Dream Home Property Competition Draw.\r\n \r\n" +
            "CHARITY DONATION: means 2.5% of the total value of Entry Fees received to be payable to the Charity(ies) after the Dream Home Property Competition Draw (or within the financial year if there are no properties offered) - where there is more than one Charity, in proportion to the preferences stated by all the Entrants at the time of submitting their Entry.\r\n \r\n" +
            "CLOSING DATE(s): for the Dream Home Property Competition: means 30 June, 2021, subject to term 28. For Weekly Cash and Lifestyle Competitions: means every Sunday at midnight (00:00:00:000 UK time). Fixed Odds Competitions close when stated on their unique product page, subject to term 42.\r\n \r\n" +
            "CREDIT: Credit can be earned for any purchase, awarded separately, or via making a valid Referral. Credit can be spent on any Competition and, if not used, will expire 30-days after first being awarded. Once expired, Credit cannot be used or redeemed. The amount of credit earned in any way is subject to change and customers will be notified at the point of purchase, and referrers at point of action of what credit they are going to be awarded.\r\n \r\n" +
            "DRAW or DRAWN: means the choice of an Entry or Entries, made at random, which may be made by Postal Entry or by way of a computer function (at the Promoter’s sole discretion) on any Draw Date (for the Weekly Lifestyle, Fixed Odds, and Cash Prize Competitions or Dream Home Prize Competition) to determine a Winner and, where applicable, any Runner(s) Up.\r\n \r\n" +
            "DRAW DATE: The Dream Home Property Competition will be Drawn up to but no later than 21 days after the Closing Date of any Competition and at the sole discretion of the promoter (subject to term 28). Fixed Odds Competitions will be Drawn up to but no later than 7 days after the Closing Date of any Competition and at the sole discretion of the promoter (subject to term 44). The Weekly Lifestyle and Cash Prize Draws will be held the first working day following the closure of the previous Sunday’s weekly competition.\r\n \r\n" +
            "ENTRANT: any natural person (not including a limited company, partnership or limited liability partnership) who validly submits an Entry to the Competition, in accordance with these Terms and Conditions.\r\n \r\n" +
            "ENTRY: means a validly submitted and completed entry by the Entrant through the Website or Postal Entry in order to obtain an opportunity to win any of the Prizes (and ENTRIES means more than one Entry).\r\n \r\n" +
            "ENTRY FEE: the entry fee payable as a condition of submitting a single valid Entry online only.\r\n \r\n" +
            "FIXED ODDS PRIZE: means the Prize as advertised on the Website as detailed in the specific Fixed Odds product page awarded to the Winner subject to a Draw under term 43 or the Cash Prize (for Fixed Odds Competitions) subject to a Draw under term 44.\r\n \r\n" +
            "DREAM HOME PRIZE: means the Property to be awarded to the Winner subject to a Draw under term 29 or the Cash Prize (for the Dream Home Property Competition) subject to a Draw under term 30.\r\n \r\n" +
            "DREAM HOME PROPERTY COMPETITION: means the Dream Home Property Competition operated by the Promoters to which these Terms and Conditions apply, wherein the Entrants submit Entries via the Website or via Postal Entry to win the Dream Home Property Prize (subject to term 30).\r\n\r\n" +
            "MINIMUM NUMBER OF DREAM HOME PROPERTY ENTRIES: means 650,000 Entries where the Entry Fee has been paid in cash and exempting any Entries credited as paid by the utilisation of a promotional voucher, Postal Entry or credit offered by the Promoter under term 4.\r\n \r\n" +
            "OPENING DATE (only applicable to the Dream Home Property Competition): means August 1, 2020\r\n \r\n" +
            "POSTAL ENTRY: the means of entering by post rather than paying online. Like an online entry, a free account must be created in order for a free entry to be applied. A full explanation of the Postal Entry requirements can be found in term 3 and on the Website at https://rafflehouse.com/post\r\n \r\n" +
            "PROPERTY: means 1A, Eastlake Road, London, SE5 9QJ, as shown on the Promoters’ Website, in the 3D tour, floorplan and photos and other media.\r\n \r\n" +
            "PROPERTY VALUE: £750,000 being the amount so specified as an asking price by the owner of the Property for the purposes of offering it as a prize in this Dream Home Prize Competition and verified by an independent agent, which is accessible on the Website.\r\n \r\n" +
            "PROMOTER: means Raffle House Ltd, company number 10928240, whose registered office address is 1B Ashmere Grove, London, SW2 5UH\r\n\r\n" +
            "REFERRAL: means any successful Entrant recorded through any account holders’ unique referral link, which can be found and accessed in every Account.\r\n\r\n" +
            "REFERRAL PRIZE: means a cash prize of £5,000 payable to the Referral Winner following the closure of the Dream Home Prize Competition (subject to term 28).\r\n\r\n" +
            "REFERRAL WINNER: means the Winner of the Referral Bonus Prize, as defined by the highest total number of Referrals recorded by the Website for that Account Holder. The Promoter’s decision is final and all referral counts will be available for review on the Website following the closure of the Dream Home Prize Competition.\r\n\r\n" +
            "RUNNER(S) UP: The Entrant(s) corresponding to the next reasonable number of Tickets Drawn after the Winner on the Draw Date and handled in chronological order reflected in their Draw positions.\r\n \r\n" +
            "STATED NUMBER OF FIXED ODDS ENTRIES: means the fixed and total number of Entries as detailed on the competitions’ unique product pages.\r\n \r\n" +
            "TICKET(S): means a unique identifier used for the purposes of determining a Winner or Runner(s) Up during any Draw. Tickets are Universally Unique Identifiers comprised of 32 letters and numbers conforming to this logic: 32 hexadecimal (base-16) digits, displayed in five groups separated by hyphens, in the form 8-4-4-4-12 for a total of 36 characters (32 hexadecimal characters and 4 hyphens). It should be noted that they are unique identifiers rather than numbers drawn via a lottery style mechanic.\r\n\r\n" +
            "WEBSITE: https://www.rafflehouse.com\r\n\r\n" +
            "WEEKLY CASH PRIZE COMPETITION: means the weekly £1,000 giveaway that runs from Monday (00:00:00:000) through Sunday (23:59:59:999). Any Ticket purchases with an aggregate transaction value of £20 or more will be entered into that week’s Weekly Cash Prize Competition. Weekly Cash Prize draws will be secondary to Weekly Lifestyle Prize Draws, and the winner of the Weekly Lifestyle Prize cannot win the Weekly Cash Prize. If a corresponding number of Postal Entries to the aggregate value of £20 for any Competition are received and processed before close of business Friday, they will also be entered into the corresponding Weekly Cash Prize Draw. Any Postal entries received after the corresponding weekly cut-off will be counted towards the next weekly draw should a total corresponding number of Postal Entries to the aggregate value of £20 be received the following week. There will be no Weekly Cash Prize Competition Draw or Winner for paid or Postal Entries in the final full week of the Dream Home Prize Competition.\r\n \r\n" +
            "WEEKLY LIFESTYLE PRIZE COMPETITION: means the weekly Lifestyle Prize Competition that runs from Monday (00:00:00:000) through Sunday (23:59:59:999). All Entries for all Lifestyle Prize Competitions will be entered into a single Draw and one Winner will be Drawn every week. The winning Entry, associated with a specific prize at time of purchase or defined in a Postal Entry, will define the Prize to be awarded.\r\n \r\n" +
            "WINNER: The Entrant corresponding to the first Correct Entry Drawn on the Draw Date and in accordance with these Terms and Conditions!";

        public const string POLICY = "Last Update: April 5, 2021\r\n\r\n" +
            "Raffle House recognises the importance of honest and responsible use of your personal information. We will never share or sell your personal data to other companies or third parties; we treat personal data with extreme sensitivity and in accordance with all applicable GDPR laws. Site usage information (non-personally identifiable data) provided to us through usage of the Site may be shared with other companies. This Privacy and Cookies Policy (\"Policy\") explains how and why we collect, and use personal and non-personally identifiable information about you when you visit this Site and when you contact us, whether by e-mail, post, or telephone using the contact options on this Site.\r\n\r\n" +
            "It is important to us that you feel comfortable in visiting the Site. For any questions regarding this Policy, data removal and/or deletion requests, or other questions, please email info@rafflehouse.com.\r\n\r\n" +
            "This Privacy and Cookies Policy applies to the website https://www.rafflehouse.com (\"the Site\") which is run by Raffle House Ltd. (\"the Company\") (company number 10928240) whose registered office address is 1 Ashmere Grove, London, SW2 5UH.\r\n " +
            "Our collection of website use information may involve the use of cookies and Web beacons. Please see the \"Cookies\" section below for more information.\r\n\r\n" +
            "DATA PROTECTION\r\n\r\n\r\n" +
            "For the purposes of the Data Protection Act 1998 (the Act) and the General Data Protection Regulation, the data controller is the Company.\r\n\r\n" +
            "LEGAL BASIS FOR THE USE OF PERSONAL DATA\r\n\r\n" +
            "The legal basis on which we rely to process your personal information includes:\r\n\r\n" +
            "On some occasions, we process your data with your consent (for example, when you agree that we may place cookies or process information that you input into our website).\r\n\r\n" +
            "On other occasions, we process your data when we need to do this to fulfil a contract with you (for example, if you win a prize in the competitions we promoted or where we are required to do this by law (for example, to comply with record keeping obligations).\r\n\r\n" +
            "We also process your data when it is in our legitimate interests to do this and when these interests are not overridden by your data protection rights (including for example, when we share data with our affiliates).\r\n\r\n" +
            "In most cases, the information the Company processes about you is required to deal with your request or registration, or required by law, or is necessary for the exercise of the Company’s legitimate business interests and needs, in which case special care is taken to safeguard your rights and to ensure any such use is proportionate.\r\n\r\n" +
            "The Company may also convert personal information into anonymous data and use it (normally on an aggregated statistical basis) for research and analysis to improve Company performance.\r\n\r\n" +
            "PERSONAL INFORMATION WE COLLECT FROM YOU\r\n\r\n\r\n" +
            "If you want to use certain facilities we provide on this Site, you will need to provide us with some additional personal information so that we can liaise with you and deal with your request, query or application. If you do choose to provide us with your personal information, we will collect that information for our own use and for the purposes described in this Policy.\r\n\r\n" +
            "Where you choose to provide personal details to us, we may collect, store and process the following personal information from you. We do so largely so that in the event of a win, we can contact you and ask for you by name and begin any verification process that may need to occur in order to transfer winnings, Prize or Property:\r\n\r\n" +
            "your full name;\r\n\r\n" +
            "your contact details e.g. phone number and e-mail address;\r\n\r\n" +
            "the reason for your contact, which may be an enquiry, a request or enquiry on behalf of someone else, providing a comment, or details in relation to a possible or existing competition;\r\n\r\n" +
            "if you create an account - your password, e-mail address and your full name;\r\n\r\n" +
            "if you enter competitions on the Site - full name, email address;\r\n\r\n" +
            "your contact and marketing preferences;\r\n\r\n" +
            "if you take a survey or interact with us in various other ways - demographics information and information about subjects that may interest you;\r\n\r\n" +
            "standard internet and website log information and details of patterns about how website visitors behave on our Site. The information we may collect includes information about your Internet service provider, your operating system, browser type, domain name, the Internet protocol (IP) address of your computer (or other electronic Internet-enabled device), your access times, the website that referred you to us, the Web pages you request and the date and time of those requests.\r\n\r\n" +
            "where you \"like\" us or make posts on our pages on social networking websites.\r\n\r\n" +
            "This information will be collected primarily from you as information voluntarily provided to us, but we may also collect it where lawful to do so from (and combine it with information from) public sources, third party service providers, individuals whom you have indicated have agreed for you to provide their personal information, government, tax or law enforcement agencies, and other third parties. We may also collect personal information about you from your use of other company services.\r\n\r\n" +
            "USES MADE OF YOUR PERSONAL INFORMATION\r\n\r\n" +
            "The Company may use information about you for purposes described in this Policy or disclosed to you on our Site or with our services. For example, we may use information about you for the following purposes, all of which we believe to be in our legitimate business interests:\r\n\r\n" +
            "to operate competitions promoted on the Site\r\n\r\n" +
            "to respond and/or deal with any request or enquiry you may raise;\r\n\r\n" +
            "to improve our products and services and to ensure that content from the Site is presented in the most effective manner for you and for your computer (or other electronic Internet-enabled device);\r\n\r\n" +
            "to administer the Site;\r\n\r\n" +
            "for internal record keeping;\r\n\r\n" +
            "to contact you (directly, either by the Company or through a relevant partner or agent) by e-mail or phone for the above reasons;\r\n\r\n" +
            "subject to your consent where required under applicable laws, to carry out direct marketing and/or e-mail marketing that you have requested;\r\n\r\n" +
            "to perform any contract the Company has with you; and\r\n\r\n" +
            "for compliance with legal, regulatory and other good governance obligations.\r\n\r\n" +
            "DISCLOSURE OF YOUR PERSONAL INFORMATION\r\n\r\n" +
            "Your personal information will be made available for the purposes mentioned above (or as otherwise notified to you from time to time), on a ‘need-to-know’ basis and only to responsible management, human resources, accounting, legal, audit, compliance, information technology and other Company staff who properly need to know these details for their functions within the Company and our parent and subsidiary companies (“Group”). Please note that certain individuals who will see your personal information may not be based at the Company or in your country (please see below).\r\n\r\n" +
            "We may share personal information within the Company as needed for reasonable management, analysis, planning and decision making, including in relation to taking decisions regarding the expansion and promotion of our service offering and for use by the Company for the other purposes described in this Policy.\r\n\r\n" +
            "Your personal information may also be made available to third parties (within or outside the Company) providing relevant services under contract to the Company, (see below for further details), such as credit card processors, auditors and compliance managers, provider or call centres and IT hosting and IT maintenance providers. These companies may use information about you to perform their functions on our behalf. The Company has put in place various security and data privacy measures, including with such third parties, in order to protect personal information and shall seek to comply with applicable legal requirements.\r\n\r\n" +
            "The data that we collect from you may be transferred to, and stored at, a destination outside the European Economic Area (\"EEA\"). It may also be processed by staff operating outside the EEA who work for us or for one of our providers. This may include staff engaged in, among other things, the fulfilment of any contract with you, the processing of your payment details and the provision of support services. By submitting your personal data, you agree to this transfer, storing or processing. We will take all steps reasonably necessary to ensure that your data is treated securely and in accordance with this privacy policy.\r\n\r\n" +
            "We may disclose specific information upon lawful request by government authorities, law enforcement and regulatory authorities where required or permitted by law and for tax or other purposes. Personal information may also be released to external parties in response to legal process, and when required to comply with laws, or to enforce our agreements, corporate policies, and terms of use, or to protect the rights, property or safety of the Company, our employees, agents, customers, and others, as well as to parties to whom you authorise the Company to release your personal information.\r\n\r\n" +
            "We will not sell your personal information to any third party other than as part of any restructuring of the Company or sale of the business.\r\n\r\n" +
            "WHAT CHOICES DOES THE COMPANY OFFER YOU WITH REGARD TO DIRECT MARKETING?\r\n\r\n\r\n" +
            "The Company may wish to provide you with information about new products, services, promotions and offers, which may be of interest to you and may invite you to take part in market research or request feedback on our products and services. This communication may occur by e-mail, telephone, post, social media or SMS. We will obtain your consent and advise you of how to opt-out of receiving such communications where we are required to do so in accordance with applicable law.\r\n\r\n" +
            "WHAT SAFEGUARDS ARE IN PLACE TO PROTECT YOUR PERSONAL INFORMATION?\r\n\r\n\r\n" +
            "The Company takes reasonable steps to maintain appropriate physical, technical and administrative security to help prevent loss, misuse, unauthorised access, disclosure or modification of personal information. While we take these reasonable efforts to safeguard your personal information, we cannot guarantee the security of any personal information you disclose online. You accept the inherent security implications of dealing online and will not hold us responsible for any breach of security unless such breach has been caused by the specific negligence of the Company, or their agents.\r\n\r\n" +
            "WHAT RIGHTS DO YOU HAVE TO REVIEW AND AMEND PERSONAL INFORMATION?\r\n\r\n\r\n" +
            "You have the right to review and access your personal information held by the Company.\r\n\r\n" +
            "You also have the right to ask us to rectify, block, complete and delete your personal information, to restrict its use, and to ‘port’ your personal information (that is, to ask us to provide it to you in a structured, commonly used and machine readable format and to transmit it directly to another organisation).\r\n\r\n" +
            "In addition, you have the right to request further information about the handling of your personal information.\r\n\r\n" +
            "If you wish to do so, or to notify the Company of a change in your details, please contact info@rafflehouse.com and/or post to Raffle House Ltd, 1 Ashmere Grove, London, SW2 5UH.\r\n\r\n" +
            "There are exceptions to these rights, however. For example, access to personal information may be denied in some circumstances if making the information available would reveal personal information about another person or if we are legally prevented from disclosing such information. In addition, we may be able to retain data even if you withdraw your consent, where we can demonstrate that we have a legal requirement to process your data.\r\n\r\n" +
            "If you have a question about the use of your personal information, or wish to file a complaint about it, please contact us using the contact details set out above.\r\n\r\n" +
            "Finally, if you have unresolved concerns, you also have the right to complain to data protection authorities\r\n\r\n" +
            "KEEPING YOU INFORMED\r\n\r\n" +
            "When we store your information, we do so for as long as necessary to (i) fulfil the specific purposes for which your personal information was collected to perform the services set out in this notice and (ii) to comply with our legal obligations or enforce our legal rights.\r\n\r\n" +
            "INFORMATION ABOUT OUR USE OF COOKIES\r\n\r\n" +
            "We use cookies for certain areas of our Site. Cookies are small data files stored on your hard drive by a website. Cookies help us improve our Site and your experience. We use cookies to see which areas and features are popular and to count visits to our websites, to recognise you as a returning visitor and to tailor your experience of the Site according to your preferences. Overall, cookies help us provide you with better websites, by enabling us to monitor which pages you find useful and which you do not. We may also use cookies for targeting or advertising purposes. We may use Web beacons on our Site or in our e-mails. Web beacons are electronic images that may be used to deliver cookies, count visits, understand usage of group websites and to tell if an e-mail has been opened and acted upon. Further details about cookie purposes and types are below. To delete or block cookies by browser settings at any time and for more general information about cookies including the difference between session and persistent cookies, visit www.allaboutcookies.org.\r\n\r\n" +
            "We also use Google Analytics on our Site to collect information about your online activity on the Site, such as the Web pages you visit and the links you click on the Site. We use the information to compile reports and to help us improve the Site. The cookies collect information in an anonymous form, including the number of visitors to the Site, where visitors have come to the Site from and the pages they visited.\r\n\r\n" +
            "For more information about the information gathered using Google Analytics please visit http://www.google.com/intl/en/analytics/privacyoverview.html. You can prevent these cookies by selecting the appropriate settings on your browser. If you do this you may not be able to use the full functionality of this Site. You may download and install the Google Analytics Opt-out Browser Add-on available here: http://tools.google.com/dlpage/gaoptout.\r\n\r\nThe cookies used on our Site are categorised in accordance with the International Chamber of Commerce United Kingdom Cookie Guide as follows:\r\n\r\n\r\n\r\nCookies which are \"strictly necessary\" for functionality of the Site’s platforms. These cookies are essential in order to enable users to move around the Site and use its features.\r\n\r\n" +
            "\"Performance\" cookies which collect information about how users navigate the Site, for example, which pages users access most frequently. They identify how users interact with our Site, any errors that occur, which pages are not used often, which pages take a long time to load, which pages users tend to visit and in what order. These cookies do not collect any information which could identify you and are only used to help us improve how our Site works and understand what interests our Site’s users.\r\n\r\n\"Functionality\" cookies which allow the Site to remember choices you make and your preferences as a logged in user (based on e.g. your user name).\r\n\r\n" +
            "\"Targeting or advertising\" cookies used to deliver adverts relevant to an identified machine or other device (not a named or otherwise identifiable person) which are tailored to interests associated with the website activity tied to that machine or device. For example, if a cookie on a third party website recognises that a particular product was purchased from a particular device, that cookie may “talk to” marketing cookies on the Site to ensure advertisements about similar products displayed on the Site are accessed from that device. These cookies are also used to limit the number of times a user sees an advertisement as well as to help measure the effectiveness of an advertising campaign. They may also remember that the Site has been visited from a device and share that information with marketing organisations. The marketing cookies on our Site are operated by third parties with our permission. Marketing cookies are used to monitor from which advertising source a user was directed towards our Site so that we know whether it is worth us investing in that particular advertising source.\r\n\r\n" +
            " Cookie name/type\r\n" +
            "Expiration Period\r\n" +
            "Purpose\r\n" +
            "Category of cookie as defined in the ICC Cookie Guide\r\n" +
            "ASP.NET_SessionId\r\n" +
            "Session\r\n" +
            "(these cookies typically\r\n" +
            "expire at the end of your session or at the latest within one week)\r\n" +
            "Authentication session to prevent having to login multiple times in\r\n" +
            "one browser session. A unique ID that ties the current session to a database settings table.\r\n" +
            "A. Strictly necessary\r\n" +
            "C. Functionality\r\n" +
            "VSI Cookie Status\r\n" +
            "12 months from set/update\r\n" +
            "Enables us to remember if you have seen the cookie information panel and accept cookies from this website.\r\n" +
            "A. Strictly necessary\r\n" +
            "C. Functionality\r\n" +
            "Google Analytics\r\n" +
            "utma\r\n" +
            "2 years from set/update\r\n" +
            "Provides a unique ID for each Web browser that visits this site.\r\n" +
            "D. Targeting/advertising\r\n" +
            "Google Analytics\r\n" +
            "utmb\r\n" +
            "Session\r\n" +
            "30 minutes from set/update\r\n" +
            "Used to establish and continue a user session with this website.\r\n" +
            "D. Targeting/advertising\r\n" +
            "Google Analytics\r\n" +
            "utmc\r\n" +
            "Session\r\n" +
            "(these cookies typically expire\r\n" +
            "at the end of your session ie when you close your browser)\r\n" +
            "Used to establish and continue a user session with this website.\r\n" +
            "D. Targeting/advertising\r\n" +
            "Twitter eu_cn\r\n" +
            "Session\r\n" +
            "1 year from set/update\r\n" +
            "Used to collect information\r\n" +
            "about users browsing behaviour for\r\n" +
            "marketing purposes including digital\r\n" +
            "display and social media advertising\r\n" +
            "D. Targeting/advertising\r\n" +
            "Twitter _ga\r\n" +
            "Session\r\n" +
            "2 years from set/update\r\n\r\n" +
            "D. Targeting/advertising\r\n" +
            "Twitter guest_id\r\n" +
            "Twitter\r\n" +
            "personalization_id\r\n" +
            "Session\r\n" +
            "2 years from set/update\r\n" +
            "Used to collect information about users browsing behaviour for\r\n" +
            "marketing purposes including digital display and social media advertising\r\n" +
            "D. Targeting/advertising\r\n" +
            "YouTube Cookies\r\n" +
            "Session\r\n" +
            "2 years from set/update\r\n" +
            "We embed videos from\r\n" +
            "YouTube using YouTube’s privacy-enhanced mode.\r\n" +
            "This mode may set cookies\r\n" +
            "on your computer once you click on the YouTube\r\n" +
            "video player\r\n" +
            "C. Functionality\r\n" +
            "D. Targeting\r\n\r\n\r\n" +
            "COOKIE SETTINGS\r\n\r\n" +
            "We will ask for your consent to the use of cookies set out in this Privacy and Cookies Policy when you first access the Site and if we introduce any new cookies to the Site. When you first visit the Site, a box/banner will appear asking you to agree to the cookies that we set on the Site.\r\n\r\n" +
            "You can usually choose to set your browser to warn you when a cookie is being sent or to remove or reject cookies. Each browser is a little different, so look at your browser Help menu to learn the correct way to modify your cookie settings. If you choose to remove or reject cookies, it will affect many features or services on our Site.\r\n\r\n" +
            "If you agree to cookies from our Site by clicking on the \"I agree\" button, we will set cookies from categories A, B, C and D on your device. If you wish to delete the cookies we have set on your device, please refer to your browser Help menu.\r\n\r\n" +
            "If you do nothing to indicate your cookie preference for our Site (i.e. if you do not click on \"I agree\"), we will treat this as acceptance and set category A, B and C cookies (which are, in our reasonable view, not ‘intrusive’ of your privacy) on your device. By default, category D cookies will not be set on your device. To modify your cookie settings, please refer to the Help menu of your browser.\r\n\r\n" +
            "If you say no to cookies on our Site we will not set category A, B C, or D cookies on your device. Please note that if you do this you may not be able to use the full functionality of our Site.\r\n\r\n" +
            "CHANGES TO THIS PRIVACY AND COOKIES POLICY\r\n\r\n" +
            "We keep this Policy under regular review. We may change this Policy from time to time by updating this page in order to reflect changes in the law and/or our privacy practices. The date at the top of this Policy will be updated accordingly.\r\n\r\n" +
            "We encourage you to check the date of this Policy when you visit this Site for any updates or changes. We will notify you of any modified versions of this Policy that might materially affect the way we use or disclose your personal information.\r\n\r\n" +
            "Contact/address details\r\n" +
            "If you have any questions about this Privacy Policy, please contact us at: info@rafflehouse.com.";
    }

    public class Competitions
    {
        public const string DREAMHOME = "Dream home";
        public const string WEEKLY = "Lifestyle";
        public const string FIXED_ODDS = "Fixed Odds";
    }

    public class DbModels
    {
        #region Users Collection

        [BsonIgnoreExtraElements]
        public class UserRequest
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("isAdmin")]
            public bool? IsAdmin { get; set; }

            [BsonElement("isManager")]
            public bool? IsManager { get; set; }

            [BsonElement("isVerified")]
            public bool? IsVerified { get; set; }

            [BsonElement("freeEntries")]
            public int? FreeEntries { get; set; }

            [BsonElement("successfullReferralCount")]
            public int? SuccessfullReferralCount { get; set; }

            [BsonElement("totalTicketsBought")]
            public int? TotalTicketsBought { get; set; }

            [BsonElement("emailCommunication")]
            public bool? EmailCommunication { get; set; }

            [BsonElement("registerReferrals")]
            public List<object>? RegisterReferrals { get; set; }

            [BsonElement("freeTickets")]
            public int? FreeTickets { get; set; }

            [BsonElement("isSocialRegistration")]
            public bool? IsSocialRegistration { get; set; }

            [BsonElement("isBlocked")]
            public bool? IsBlocked { get; set; }

            [BsonElement("notifications")]
            public Notification? Notifications { get; set; }

            [BsonElement("spentMoney")]
            public int? SpentMoney { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("surname")]
            public string? Surname { get; set; }

            [BsonElement("email")]
            public string? Email { get; set; }

            [BsonElement("password")]
            public string? Password { get; set; }

            [BsonElement("phone")]
            public string? Phone { get; set; }

            [BsonElement("country")]
            public string? Country { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("registerRaffle")]
            public ObjectId? RegisterRaffle { get; set; }

            [BsonElement("referralKey")]
            public string? ReferralKey { get; set; }

            [BsonElement("neededSpend")]
            public int? NeededSpend { get; set; }

            [BsonElement("referralCredits")]
            public int? ReferralCredits { get; set; }

            [BsonElement("isEmailValid")]
            public bool IsEmailValid { get; set; }

            [BsonElement("updatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("corporateNotification")]
            public bool? CorporateNotification { get; set; }

        }
        public class Notification
        {

            public bool? dreamHome { get; set; }
            public bool? lifestyle { get; set; }
            public bool? fixedOdds { get; set; }
            public bool? myCompetitions { get; set; }
            public bool? newPrizes { get; set; }
            public bool? all { get; set; }
        }
        public class Memberships
        {
            public int? active { get; set; }
            public int? count { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class UserResponse
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("isAdmin")]
            public bool? IsAdmin { get; set; }

            [BsonElement("isManager")]
            public bool? IsManager { get; set; }

            [BsonElement("isVerified")]
            public bool? IsVerified { get; set; }

            [BsonElement("freeEntries")]
            public int? FreeEntries { get; set; }

            [BsonElement("successfullReferralCount")]
            public int? SuccessfullReferralCount { get; set; }

            [BsonElement("totalTicketsBought")]
            public int? TotalTicketsBought { get; set; }

            [BsonElement("emailCommunication")]
            public bool? EmailCommunication { get; set; }

            [BsonElement("registerReferrals")]
            public List<object>? RegisterReferrals { get; set; }

            [BsonElement("freeTickets")]
            public int? FreeTickets { get; set; }

            [BsonElement("isSocialRegistration")]
            public bool? IsSocialRegistration { get; set; }

            [BsonElement("isBlocked")]
            public bool? IsBlocked { get; set; }

            [BsonElement("notifications")]
            public Notification? Notifications { get; set; }

            [BsonElement("membership")]
            public Memberships? Membership { get; set; }

            [BsonElement("spentMoney")]
            public int? SpentMoney { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("surname")]
            public string? Surname { get; set; }

            [BsonElement("email")]
            public string? Email { get; set; }

            [BsonElement("password")]
            public string? Password { get; set; }

            [BsonElement("phone")]
            public string? Phone { get; set; }

            [BsonElement("country")]
            public string? Country { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("registerRaffle")]
            public ObjectId? RegisterRaffle { get; set; }

            [BsonElement("referralKey")]
            public string? ReferralKey { get; set; }

            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("googleAccountId")]
            public string? GoogleAccountId { get; set; }

            [BsonElement("facebookAccountId")]
            public string? FacebookAccountId { get; set; }

            [BsonElement("neededSpend")]
            public int? NeededSpend { get; set; }

            [BsonElement("referralCredits")]
            public int? ReferralCredits { get; set; }

            [BsonElement("referredBy")]
            public ObjectId? ReferredBy { get; set; }

            [BsonElement("emailMarketingSentDate")]
            public DateTimeOffset? EmailMarketingSentDate { get; set; }

            [BsonElement("isEmailValid")]
            public bool IsEmailValid { get; set; }

            [BsonElement("boughtDHafterMailing")]
            public bool? BoughtDHafterMailing { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("corporateNotification")]
            public bool? CorporateNotification { get; set; }

            [BsonElement("mobileEntry")]
            public bool? MobileEntry { get; set; }

            [BsonElement("spentMobile")]
            public int? SpentMobile { get; set; }
        }

        #endregion

        #region Raffles Collection

        [BsonIgnoreExtraElements]
        public class Raffle
        {
            [BsonElement("__v")]
            public int V { get; set; }

            [BsonElement("_id")]
            public ObjectId Id { get; set; }

            [BsonElement("active")]
            public bool Active { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset CreatedAt { get; set; }

            [BsonElement("creditsRates")]
            public List<Object>? CreditsRates { get; set; }

            [BsonElement("defaultTickets")]
            public int DefaultTickets { get; set; }

            [BsonElement("discountCategory")]
            public string DiscountCategory { get; set; }

            [BsonElement("discountRates")]
            public List<DiscountRate> DiscountRates { get; set; }

            [BsonElement("discountTicket")]
            public DiscountTicket DiscountTicket { get; set; }

            [BsonElement("endsAt")]
            public DateTime? EndsAt { get; set; }

            [BsonElement("freeTicketsRates")]
            public List<FreeTicketsRates> FreeTicketsRates { get; set; }

            [BsonElement("isActiveDiscount")]
            public bool IsActiveDiscount { get; set; }

            [BsonElement("isClosed")]
            public bool IsClosed { get; set; }

            [BsonElement("isCreditsActive")]
            public bool IsCreditsActive { get; set; }

            [BsonElement("isDeleted")]
            public bool IsDeleted { get; set; }

            [BsonElement("isDiscountRates")]
            public bool IsDiscountRates { get; set; }

            [BsonElement("isFreeTicketsRates")]
            public bool IsFreeTicketsRates { get; set; }

            [BsonElement("isPopular")]
            public bool IsPopular { get; set; }

            [BsonElement("isRemoved")]
            public bool IsRemoved { get; set; }

            [BsonElement("isTrending")]
            public bool IsTrending { get; set; }

            [BsonElement("metaDescription")]
            public string MetaDescription { get; set; }

            [BsonElement("metaTitle")]
            public string MetaTitle { get; set; }

            [BsonElement("property")]
            public ObjectId? Property { get; set; }

            [BsonElement("startAt")]
            public DateTime? StartAt { get; set; }

            [BsonElement("ticketPrice")]
            public double TicketPrice { get; set; }

            [BsonElement("ticketsBundles")]
            public List<int> TicketsBundles { get; set; }

            [BsonElement("title")]
            public string Title { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset UpdatedAt { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("creditsEndDate")]
            public DateTimeOffset? CreditsEndDate { get; set; }

            [BsonElement("creditsStartDate")]
            public DateTimeOffset? CreditsStartDate { get; set; }

            [BsonElement("isCreditsPermanent")]
            public bool? IsCreditsPermanent { get; set; }

            [BsonElement("location")]
            public string? Location { get; set; }

            [BsonElement("completedAt")]
            public string? CompletedAt { get; set; }

            [BsonElement("quizType")]
            public string? QuizType { get; set; }

            [BsonElement("stepperCountdown")]
            public StepperCountDown? StepperCountdown { get; set; }

        }

        public class CreditRate
        {
            [BsonElement("count")]
            public double? Count { get; set; }

            [BsonElement("percent")]
            public int? Percent { get; set; }

            [BsonElement("id")]
            public string? Id { get; set; }
        }

        public class DiscountRate
        {
            [BsonElement("newPrice")]
            public double? NewPrice { get; set; }

            [BsonElement("percent")]
            public double? Percent { get; set; }

            [BsonElement("amountTickets")]
            public int? AmountTickets { get; set; }
        }

        public class DiscountTicket
        {
            [BsonElement("newPrice")]
            public double? NewPrice { get; set; }

            [BsonElement("percent")]
            public double? Percent { get; set; }
        }

        public class StepperCountDown
        {
            [BsonElement("isActive")]
            public bool? IsActive { get; set; }

            [BsonElement("title")]
            public string? Title { get; set; }

            [BsonElement("startAt")]
            public DateTimeOffset? StartAt { get; set; }

            [BsonElement("endsAt")]
            public DateTimeOffset? EndsAt { get; set; }

        }

        public class FreeTicketsRates
        {
            [BsonElement("tickets")]
            public int? Tickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("isShow")]
            public bool? IsShow { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class Property
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId Id { get; set; }

            [BsonElement("badroomImage")]
            public string? BadroomImage { get; set; }

            [BsonElement("bathroomImage")]
            public string? BathroomImage { get; set; }

            [BsonElement("bathroomText")]
            public string? BathroomText { get; set; }

            [BsonElement("bedroomText")]
            public string? BedroomText { get; set; }

            [BsonElement("cardImage")]
            public string? CardImage { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("description")]
            public string? Description { get; set; }

            [BsonElement("floorPlanImage")]
            public string? FloorPlanImage { get; set; }

            [BsonElement("galleryImages")]
            public List<string>? GalleryImages { get; set; }

            [BsonElement("galleryImagesMobile")]
            public List<string>? GalleryImagesMobile { get; set; }

            //[BsonElement("generalText")]
            //public string? GeneralText { get; set; }

            [BsonElement("heading")]
            public string? Heading { get; set; }

            [BsonElement("latitude")]
            public double? Latitude { get; set; }

            [BsonElement("location")]
            public string? Location { get; set; }

            [BsonElement("locationMapImage")]
            public string? LocationMapImage { get; set; }

            [BsonElement("longitude")]
            public double? Longitude { get; set; }

            [BsonElement("outspaceImage")]
            public string? OutspaceImage { get; set; }

            [BsonElement("ooutspaceText")]
            public string? OoutspaceText { get; set; }

            [BsonElement("overview")]
            public List<Overview> Overview { get; set; }

            [BsonElement("pixangleSource")]
            public string? PixangleSource { get; set; }

            [BsonElement("tourLink")]
            public string? TourLink { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("address")]
            public string? Address { get; set; }

            [BsonElement("area")]
            public string? Area { get; set; }

            [BsonElement("bedroomCount")]
            public dynamic? BedroomCount { get; set; }

            [BsonElement("bathroomCount")]
            public dynamic? BathroomCount { get; set; }

            [BsonElement("outspaceCount")]
            public dynamic? OutspaceCount { get; set; }

            [BsonElement("outspaceText")]
            public string? OutspaceText { get; set; }

            [BsonElement("floorPlanText")]
            public string? FloorPlanText { get; set; }

            [BsonElement("threeDTourText")]
            public string? ThreeDTourText { get; set; }

            [BsonElement("areaText")]
            public string? AreaText { get; set; }

            [BsonElement("transportText")]
            public string? TransportText { get; set; }

            [BsonElement("amenitiesText")]
            public string? AmenitiesText { get; set; }

            [BsonElement("metroStations")]
            public List<MetroStations>? MetroStations { get; set; }

            [BsonElement("adress")]
            public string? Adress { get; set; }

            [BsonElement("propertyPrice")]
            public dynamic? PropertyPrice { get; set; }

            [BsonElement("tax")]
            public dynamic? Tax { get; set; }

            [BsonElement("freehold")]
            public string? Freehold { get; set; }

            [BsonElement("garden")]
            public string? Garden { get; set; }

            [BsonElement("energy")]
            public string? Energy { get; set; }


            [BsonElement("GeneralText")]
            public string? GeneralText { get; set; }

        }

        public class Overview
        {
            [BsonElement("title")]
            public string? Title { get; set; }

            [BsonElement("value")]
            public string? Value { get; set; }

            [BsonElement("icon")]
            public string? Icon { get; set; }

        }

        public class MetroStations
        {
            [BsonElement("text")]
            public string? Text { get; set; }

            [BsonElement("title")]
            public string? Title { get; set; }
        }

        #endregion

        #region Competitions

        [BsonIgnoreExtraElements]
        public class Competitions
        {
            public class PrizesLF
            {
                [BsonElement("__v")]
                public int? V { get; set; }

                [BsonElement("_id")]
                public ObjectId Id { get; set; }

                [BsonElement("competitionId")]
                public string? CompetitionId { get; set; }

                [BsonElement("competitionType")]
                public string? CompetitionType { get; set; }

                [BsonElement("endsAt")]
                public DateTimeOffset EndsAt { get; set; }

                [BsonElement("fixedOdds")]
                public dynamic? FixedOdds { get; set; }

                [BsonElement("isActive")]
                public bool? IsActive { get; set; }

                [BsonElement("prizes")]
                public List<ObjectId>? Prizes { get; set; }

                [BsonElement("startAt")]
                public DateTimeOffset StartAt { get; set; }
            }

            public class Raffle
            {
                [BsonElement("_id")]
                public ObjectId Id { get; set; }

                [BsonElement("isActive")]
                public bool? IsActive { get; set; }

                [BsonElement("startAt")]
                public DateTime? StartAt { get; set; }

                [BsonElement("endsAt")]
                public DateTime? EndsAt { get; set; }

                [BsonElement("competitionType")]
                public string? CompetitionType { get; set; }

                [BsonElement("dreamHome")]
                public ObjectId? DreamHome { get; set; }

                [BsonElement("competitionId")]
                public string? CompetitionId { get; set; }

                [BsonElement("createdAt")]
                public DateTime? CreatedAt { get; set; }

                [BsonElement("updatedAt")]
                public DateTime? UpdatedAt { get; set; }

                [BsonElement("__v")]
                public int? V { get; set; }

                [BsonElement("fixedOdds")]
                public dynamic? FixedOdds { get; set; }

                [BsonElement("prizes")]
                public dynamic? Prizes { get; set; }
            }
        }




        #endregion

        #region Subscriptions

        [BsonIgnoreExtraElements]
        public class Subscriptions
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("count")]
            public int? Count { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("purchaseDate")]
            public DateTimeOffset? PurchaseDate { get; set; }

            [BsonElement("refference")]
            public string? Refference { get; set; }

            [BsonElement("status")]
            public string? Status { get; set; }

            [BsonElement("totalCost")]
            public double? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("pausedAt")]
            public DateTime? PausedAt { get; set; }

            [BsonElement("pauseEnd")]
            public DateTime? PauseEnd { get; set; }

            [BsonElement("UpdatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("cardSource")]
            public string? CardSource { get; set; }

            [BsonElement("nextPurchaseDate")]
            public DateTime? NextPurchaseDate { get; set; }

            [BsonElement("subscriptionModel")]
            public ObjectId SubscriptionModel { get; set; }

            [BsonElement("isReminderSent")]
            public bool IsReminderSent { get; set; }

            [BsonElement("emails")]
            public List<Emails>? Emails { get; set; }

            [BsonElement("raffle")]
            public ObjectId Raffle { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class SubscriptionsModels
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("isActive")]
            public bool? IsActive { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

        }

        [BsonIgnoreExtraElements]
        public class SubscriptionsInsert
        {

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("count")]
            public int? Count { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("purchaseDate")]
            public DateTime? PurchaseDate { get; set; }

            [BsonElement("refference")]
            public string? Refference { get; set; }

            [BsonElement("status")]
            public string? Status { get; set; }

            [BsonElement("totalCost")]
            public double? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("pausedAt")]
            public DateTime? PausedAt { get; set; }

            [BsonElement("pauseEnd")]
            public DateTime? PauseEnd { get; set; }

            [BsonElement("UpdatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("cardSource")]
            public string? CardSource { get; set; }

            [BsonElement("nextPurchaseDate")]
            public DateTime? NextPurchaseDate { get; set; }

            [BsonElement("subscriptionModel")]
            public ObjectId SubscriptionModel { get; set; }

            [BsonElement("isReminderSent")]
            public bool IsReminderSent { get; set; }

            [BsonElement("emails")]
            public List<string>? Emails { get; set; }

            [BsonElement("raffle")]
            public ObjectId Raffle { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class Emails
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("type")]
            public string? Type { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("raffle")]
            public ObjectId? Raffle { get; set; }


        }

        #endregion

        #region Orders

        [BsonIgnoreExtraElements]
        public class Orders
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("appliedCredits")]
            public List<AppliedCredits> AppliedCredits { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("competitionId")]
            public ObjectId? CompetitionId { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("fixedOdds")]
            public ObjectId? FixedOdds { get; set; }

            [BsonElement("groupId")]
            public string? GroupId { get; set; }

            [BsonElement("isArchive")]
            public bool IsArchive { get; set; }

            [BsonElement("paymentStatus")]
            public string? PaymentStatus { get; set; }

            [BsonElement("selectedCharity")]
            public string? SelectedCharity { get; set; }

            [BsonElement("spentCredits")]
            public int? SpentCredits { get; set; }

            [BsonElement("tickets")]
            public List<Tickets> Tickets { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("orderType")]
            public string? OrderType { get; set; }
        }

        public class AppliedCredits
        {
            [BsonElement("creditId")]
            public ObjectId? CreditId { get; set; }

            [BsonElement("spentAmount")]
            public double? SpentAmount { get; set; }
        }

        public class Tickets
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("code")]
            public string? Code { get; set; }

            [BsonElement("bonus")]
            public bool? Bonus { get; set; }
        }

        #endregion
    }

    public class SubscriptionStatuses
    {
        public const string PAUSED = "PAUSED";
        public const string CANCELLED = "CANCELLED";
        public const string IN_PAYMENT_PROCESS = "IN_PAYMENT_PROCESS";
        public const string ACTIVE = "ACTIVE";
    }

    public class SubscriptionEmailsTemplate
    {
        public const string INITIAL_UNAUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Activate account</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        public const string INITIAL_AUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        public const string MONTHLY_AUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        public const string PAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully paused your Raffle House subscription. Your subscription will automatically reactivate on the 1st of the next month, following a full month’s pause.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        public const string UNPAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription has been reactivated following your pause!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><p style=\"color:#31323C;font:HK Grotesk;\">You can manage your subscription and view your active tickets in your account at any time!</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        public const string CANCEL = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully cancelled your Raffle House subscription. Any tickets that you had prior to the cancellation will remain active for any upcoming draw in the current competition cycle.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you want to renew your subscription or view your active tickets, head to your account at any time.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">If you want to increase your chances to win, just hit the button below to buy more tickets.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        public const string SEVEN_DAYS_BEFORE_UNPAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription will automatically reactivate in 7 days, on the 1st of the next month, following your full month’s pause. You do not need to take any action to start dreaming big and doing good once more!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account, as will all future tickets yet to be awarded. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        public const string PURCHASE_FAILED = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription payment has failed. This may be due to insufficient funds or your card’s expiry date. As a result, your tickets for this month have not been credited and your subscription has been cancelled.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to purchase tickets this month, you can do so manually.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to continue to benefit from a Raffle House subscription, you’ll need to purchase a new one.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;margin-bottom:20px;height:auto;border:none;\">Purchase a Subscription</button>\n</a></div><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
    }

    public class SubscriptionsCardDetails
    {
        public static readonly List<string> CHECKOUT_ID = new List<string>
        {
            "pay_zozashz6mpo2domxtg2onz32m4",
            "pay_mmmyrsuds7q2hbyxwlnqijucpe",
            "pay_rgmpd24ladf2rl2gt46aa5ahsy",
            "pay_kgqv3kqpq3a25hq6iyy6taswgy",
            "pay_cntqqf4k5u42tm2raaqwug6ihq",
            "pay_wl6pllcn6e7khhdwzcmdbwaliu",
            "pay_y4ifhgvrcilk7kku6s7b7p3inu",
            "pay_2txlcey3dsakjhb6gjv6tvkag4",
            "pay_6rh3pyukksf25d3cmns2qsbo4q",
            "pay_73ydulxnj672tfid4al6mr4rke",
            "pay_pbqulg5w2c2kjavvqkjrmmg3w4",
            "pay_vmqwfw6ohzxk3iauijegjvfwb4",
            "pay_ttskl5rpe63kdggeuggfrregey",
            "pay_62asca2v43akllz6uzfmxcopry",
            "pay_xgiv2z4f23l27cfvdhbjm6pge4",
            "pay_nz5s2prp5wr2ri27rqqkbs73ia",
            "pay_wjujmck33nnk5ph4gltzcpjskq",
            "pay_3vc56mhpfwfktn6vzekz3cstq4",
            "pay_jnibsan2s2ikblaufcobcjxfue",
            "pay_fbrnwelnvj525kz3r6hxjjtrp4"


        };
        public static readonly List<string> REFFERENCE = new List<string>()
        {
            "47885be9-9dae-4c87-9d44-19a2dca99678",
            "ff828a52-ed6d-41dc-8487-94e2ec649298",
            "c4f438c5-5954-4d74-a784-21ebd67bdc8c",
            "d30e888a-29e6-49a1-85a5-23f9863651e4",
            "f723114a-2678-4dc7-ab78-8bd89b06805a",
            "3f221f31-6712-4cfb-bb3e-bfe785dc15ce",
            "06037f6b-4f75-40b2-a61e-06be9cdbb100",
            "be0cd6a3-c1c4-4e8c-8211-ff30db68ddc2",
            "449299e0-8f12-4c7a-b38c-ff8b0d751db0",
            "eb1ba28a-9b7f-474c-8c3d-767fc6b223fc",
            "0c83a92a-f851-4264-a142-23291bf62a07",
            "b3092642-440c-4d84-9c6c-971e545f86cf",
            "585920a7-2044-42ed-9f7c-6ec320f9ae3f",
            "c56e472c-0dd9-4161-a140-71a750c407bd",
            "7eb10715-d03b-49d7-9e5c-450df8b926c8",
            "d33f45a3-eaed-4481-a726-0b560c96cf65",
            "d6493868-5108-47a6-88cc-76559d6157b3",
            "e5e76b05-14c6-43bc-b53a-a06ed9b0afd4",
            "4b3e428c-ccb9-47bf-931c-f04cec8aca96",
            "030612c8-d4b0-4cc1-bc48-8e121a4198a7"


        };
        public static readonly List<string> CARD_SOURCE = new List<string>()
        {
            "src_b2srl7h33bofgcdun744gsjpji",
            "src_hzfef6jt2phfacgpzdpmgxlrge",
            "src_rzkgdukr26jvwcg7ew3t5rftee",
            "src_vojz7nyxzvdfecfkoukjajhu5e",
            "src_mpksjv7pivqfkcfsiyo3b6eu6e",
            "src_47yeebnneblvkchchez4cbmdiy",
            "src_rdwhmhc2durf4cgin2yoxrvlxe",
            "src_yeqvhjwvzm5vschdfwa4yj3qyq",
            "src_j4jfe7lbt2ovwcgig52zpigqwm",
            "src_6gpwglrzujwv6caqz44tynhsrm",
            "src_e6wfk2d2j2jv6carpfwr4nj4mq",
            "src_hsmiiawjocsfeccfrb7mf3fjta",
            "src_yn5hi5m42auvychmoh72mcm4be",
            "src_od22wd6t3zcvgchvzyx7vasnxq",
            "src_svwcy4lvwkiveccmknautmhlhu",
            "src_7htkzb2be3cvgcb2e45gj5mtxm",
            "src_ujplivxoub5vicatazsyfxm7ve",
            "src_7u3anjrxfnkvqceqdrkjq777ky",
            "src_bsuxs3bgzdyfwchddwsbupa76e",
            "src_i4oqobro5fvfocgviav2bpqwuy"


        };
    }

    public class Charities
    {
        public static readonly List<string> CHARITY = new()
        {
            "Alzheimer's Research UK",
            "Alzheimer's Society",
            "Barnardo's",
            "Battersea Dogs and Cats Home",
            "British Heart Foundation",
            "British Red Bross",
            "Cancer Research UK",
            "Children in Need",
            "Dementia UK",
            "Diabetes UK",
            "Duke of Edinburgh Awards",
            "Guide Dogs",
            "Help for Heroes",
            "Keep Britain Tidy",
            "Macmillan Cancer Support",
            "Marie Curie",
            "National Trust",
            "No charity selected",
            "NSPCC",
            "Parkinson's UK",
            "Prostate Cancer UK",
            "RNLI Lifeboats",
            "Royal British Legion",
            "RSPCA",
            "Samaritans",
            "Save the Children",
            "St. John Ambulance",
            "WWF"

        };
    }

    public class ErrorTotalCost
    {
        public const int ERROR_BAD_TRACK_DATA = 154;
        public const int ERROR_SECURITY_VIOLATION = 163;
        public const int ERROR_INVALID_TRANSACTION = 12;
        public const int ERROR_RESTRICTED_CARD = 62;
        public const int ERROR_INSUFIENT_FUNDS = 151;
    }

    public class PutsboxEmail
    {
        public string id { get; set; }
        public string headers { get; set; }
        public string from_email { get; set; }
        public string from_name { get; set; }
        public List<string> to { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
        public object attachments { get; set; }
        public string created_at { get; set; }

    }

    public class WebMOdels
    {
        public class Profile
        {
            public class OrderHistory
            {
                public string PRIZE { get; set; }
                public string PURCHASE_DATE { get; set; }
                public int NUM_TICKETS { get; set; }
                public int PRICE { get; set; }
            }
        }
    }


}
