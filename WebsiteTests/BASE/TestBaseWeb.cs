
using NUnit.Allure.Core;
using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteTests.BASE
{
    
    public class TestBaseWeb : BaseWeb
    {
        [SetUp]

        public void Initialize()
        {
            
            Browser._Driver.Navigate().GoToUrl(Endpoints.websiteHost);
        }
        
    }
}
