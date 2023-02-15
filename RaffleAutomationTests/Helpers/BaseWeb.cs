namespace RaffleAutomationTests.Helpers
{
    [AllureNUnit]
    public class BaseWeb
    {

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            AllureConfigFilesHelper.CreateBatFile();

        }



        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {

            if (Browser._Driver != null)
            {
                Browser.Quit();

                ForceCloseWebDriver.ForceClose();
                ForceCloseWebDriver.RemoveBatFile();
            }

        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _ = TelegramHelper.SendMessage();
                Browser.Close();
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
            {
                Browser.Close();
            }

        }
    }
}
