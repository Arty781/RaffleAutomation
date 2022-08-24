using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace RaffleAutomationTests.Helpers
{
    public class Browser
    {
        public IWebDriver WindowsDriver { get; set; }
        private static IWebDriver windowsDriver;

        public static void Initialize()
        {
            AllureConfigFilesHelper.CopyJsonConfigFile();

            new DriverManager().SetUpDriver(new ChromeConfig());
            windowsDriver = new ChromeDriver();
            _Driver.Manage().Cookies.DeleteAllCookies();
            _Driver.Manage().Window.Maximize();

            Assert.NotNull(windowsDriver);
        }


        public static string RootPath()
        {
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            return mainpath;
        }
        public static ISearchContext Driver => windowsDriver;
        public static IWebDriver _Driver => windowsDriver;
        public static string Title => windowsDriver.Title;
        public static string CurrentURL => windowsDriver.Url;
        

    }
}
