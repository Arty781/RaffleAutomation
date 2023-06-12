using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RaffleAutomationTests.Helpers;

namespace ApiTests.BASE
{
    public class TestBaseApi
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile();
        }

        [SetUp]

        public void SetUp()
        {
            
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            
        }

        [TearDown]
        public static void TearDown()
        {
            
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _ = TelegramHelper.SendMessage();
            }
        }
    }
}
