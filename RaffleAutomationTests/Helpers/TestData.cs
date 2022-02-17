﻿using System;
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
}
