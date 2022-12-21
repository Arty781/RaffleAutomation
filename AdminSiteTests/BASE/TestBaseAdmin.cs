﻿
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSiteTests.BASE
{
    
    public class TestBaseAdmin : BaseWeb
    {

        [SetUp]

        public void SetUp()
        {
            Browser.Initialize();
            Browser._Driver.Navigate().GoToUrl(AdminEndpoints.ADMIN_HOST);
        }

    }
}
