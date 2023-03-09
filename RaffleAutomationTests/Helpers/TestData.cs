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
        public const string BASKET = "https://staging.rafflehouse.com/basket";
        public const string PAGE_DISCOUNT = "https://pagediscount-staging.rafflehouse.com/";
        public const string WIN_RAFFLE = "https://win-staging.rafflehouse.com/";
    }

    public class ApiEndpoints
    {
        public const string API = "https://staging-api.rafflehouse.com";
        public const string API_CHIL = "staging-api.rafflehouse.com";
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
        public const string RAFFLE_OUTSPACE = @"UploadImages\RaffleOutspace.jpg";
        public const string RAFFLE_DESKTOP_1 = @"UploadImages\Desktop\DreamHomeImage1.jpg";
        public const string RAFFLE_DESKTOP_2 = @"UploadImages\Desktop\DreamHomeImage2.jpg";
        public const string RAFFLE_DESKTOP_3 = @"UploadImages\Desktop\DreamHomeImage3.jpg";
        public const string RAFFLE_DESKTOP_4 = @"UploadImages\Desktop\DreamHomeImage4.jpg";
        public const string RAFFLE_DESKTOP_5 = @"UploadImages\Desktop\DreamHomeImage5.jpg";
        public const string RAFFLE_DESKTOP_6 = @"UploadImages\Desktop\DreamHomeImage6.jpg";
        public const string RAFFLE_DESKTOP_7 = @"UploadImages\Desktop\DreamHomeImage7.jpg";
        public const string RAFFLE_DESKTOP_8 = @"UploadImages\Desktop\DreamHomeImage8.jpg";
        public const string RAFFLE_MOBILE_1 = @"UploadImages\Mobile\DreamHomeImage1.jpg";
        public const string RAFFLE_MOBILE_2 = @"UploadImages\Mobile\DreamHomeImage2.jpg";
        public const string RAFFLE_MOBILE_3 = @"UploadImages\Mobile\DreamHomeImage3.jpg";
        public const string RAFFLE_MOBILE_4 = @"UploadImages\Mobile\DreamHomeImage4.jpg";
        public const string RAFFLE_MOBILE_5 = @"UploadImages\Mobile\DreamHomeImage5.jpg";
        public const string RAFFLE_MOBILE_6 = @"UploadImages\Mobile\DreamHomeImage6.jpg";
        public const string RAFFLE_MOBILE_7 = @"UploadImages\Mobile\DreamHomeImage7.jpg";
        public const string RAFFLE_MOBILE_8 = @"UploadImages\Mobile\DreamHomeImage8.jpg";
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

    public class FooterText
    {
        public const string FOOTER_TITLE = "About Raffle House";
        public const string FOOTER_PARAGRAPH = "We offer you the chance to win your Dream Home or multi-million pound cash-prize while donating to worthwhile causes. Every Dream Home entry is automatically added to the bonus prize pools and will be drawn for each consecutive competition. Our paid competitions to win a Dream Home and bonus prizes also include a postal entry method. It’s time to dream big and do good.";
        public static readonly List<string> FOOTER_CONTACTS_LINKS = new()
        {
            "Home",
            "Winners",
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
            "We have appointed Civica Election Services, formerly known as Electoral Reform Services (ERS),as our independent scrutineers to administer this competition. They have over 100 years’ experience in administering elections, ballots and competitions for a wide range of clients including TV programmes and various lottery projects. Please send the sheet of paper in an envelope to the following address via first- or second-class post to:​​​",
            "Due to differing postal timings, entries enclosed in envelopes stamped ​with a second-class stamp will not be considered.",
            "A maximum of one entry can be made per envelope received.",
            "Postal entries are treated in exactly the same way as paid entries for the purposes of determining a winner. However, there is a difference in the deadlines for postal entries for the property competition.Our property draw closes at midnight on its final day; the corresponding cut-off for postal entries will be that they are received and processed before 5pm four business days later.",
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
}
