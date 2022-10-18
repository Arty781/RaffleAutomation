using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using NUnit.Allure.Core;
using ApiTests.BASE;
using RaffleAutomationTests.APIHelpers.Web;

namespace API
{
    [TestFixture]
    [AllureNUnit]
    public class ApiTests : TestBaseApi
    {
        [Test]

        public void Demo()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile();
        }

        [Test]
        public void AddTicketsToBasket()
        {
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var dreamHomeId = CountdownRequestWeb.GetDreamHomeCountdown(token);
            var competitionId = CountdownRequestWeb.GetWeeklyPrizesCompetitionId(token);
            var weeklyID = competitionId[2].Id;
            var listOfWeeklyPrizes = CountdownRequestWeb.GetWeeklyPrizes(token, weeklyID);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, dreamHomeId);
            for (int i = 0; i < 5; i++)
            {
                WeeklyPrizesRequestWeb.GetWeeklyPrizes(token, listOfWeeklyPrizes);
            }

        }
    }
}