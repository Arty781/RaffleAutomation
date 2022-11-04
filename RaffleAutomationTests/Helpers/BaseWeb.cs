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
        
        public static void OneTimeTearDown()
        {

            if (Browser._Driver != null)
            {
                Browser._Driver.Quit();
            }


        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _ = TelegramHelper.SendMessage();
            }
            Browser._Driver.Close();
        }
    }
}
