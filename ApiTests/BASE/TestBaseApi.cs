using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.BASE
{
    public class TestBaseApi
    {
        [SetUp]

        public void SetUp()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile(AllureConfigFilesHelper.Json());
        }
    }
}
