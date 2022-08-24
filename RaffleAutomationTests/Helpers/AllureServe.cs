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
        
        [Test]
        public void GoToAllureResults()
        {
            AllureConfigFilesHelper.CreateBatFile();
            Process.Start(Browser.RootPath() + "allure serve.bat");
        }
        
    }
}
