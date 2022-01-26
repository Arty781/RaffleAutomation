using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    class AllureServe
    {
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSuite("WebSite")]
        [AllureSubSuite("Client")]
        [Test]

        
        public void GoToAllureResults()
        {

            Process.Start(RootPath() + "allure serve.bat");
        }
        public static string RootPath()
        {
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            return mainpath;
        }
    }
}
