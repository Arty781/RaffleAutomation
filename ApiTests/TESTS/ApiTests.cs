using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using NUnit.Allure.Core;
using ApiTests.BASE;
using RaffleAutomationTests.APIHelpers.Web;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.APIHelpers.Web.Weekly;
using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;
using RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb;

namespace API
{
    [TestFixture]
    public class ApiTests : TestBaseApi
    {
        [Test]

        public void Demo()
        {
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);


        }

        [Test]
        public static void AddTicketsToBasket()
        {
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var competitionId = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var listOfWeeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, competitionId[2].Id);
            for (int i = 0; i < 5; i++)
            {
                WeeklyPrizesRequestWeb.AddWeeklyPrizes(token, listOfWeeklyPrizes, "151");
            }

        }
    }
}