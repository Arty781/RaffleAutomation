namespace RaffleAutomationTests.Helpers
{
    [AllureNUnit]
    public class BaseWeb
    {

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            if (Browser.Driver != null)
            {
                Browser.Quit();
                ForceCloseDriver.ForeseClose();
            }
        }

        [TearDown]
        public static void TearDown()
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            _ = testStatus == TestStatus.Failed ? TelegramHelper.SendMessage() : null;
            Browser.Close();
        }
    }
}
