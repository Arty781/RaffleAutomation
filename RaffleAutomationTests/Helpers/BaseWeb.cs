using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    
    public class BaseWeb
    {
       
        public static Process? _process;

        [OneTimeSetUp]
        public static void OneTimeSetUp() => _process = Process.Start(Browser.RootPath1() + ChromeDriverPath.path);



        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            if (_process != null)
            {
                _process.Kill();
            }
        }

        [TearDown]
        public static void TearDown()
        {
            if (Browser._Driver != null)
            {
                Browser.Close();
            }
        }
    }
}
