using System;
using System.Diagnostics;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace RaffleAutomationTests.Helpers
{
    [AllureNUnit]
    public class BaseWeb
    {

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            AllureConfigFilesHelper.CreateBatFile();
            Browser.Initialize();
        }



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            if (Browser._Driver != null)
            {
                Browser.Quit();

                ForceCloseWebDriver.ForceClose();
                ForceCloseWebDriver.RemoveBatFile();
            }

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _ = TelegramHelper.SendMessage();
                Browser.Close();
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                Browser.Close();
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Skipped)
            {
                Browser.Close();
            }

        }
    }
}
