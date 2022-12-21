using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace RaffleAutomationTests.Helpers
{
    public class Browser
    {
        private static IWebDriver windowsDriver;

        public static void Initialize()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile();

            new DriverManager().SetUpDriver(new ChromeConfig());
            windowsDriver = new ChromeDriver();
            windowsDriver.Manage().Cookies.DeleteAllCookies();
#if DEBUG_MOBILE
            windowsDriver.Manage().Window.Size = new Size(390, 844);
#endif
#if DEBUG
            windowsDriver.Manage().Window.Maximize();
#endif

#if RELEASE_MOBILE
            windowsDriver.Manage().Window.Size = new Size(390, 844);
#endif
#if RELEASE
            windowsDriver.Manage().Window.Maximize();
#endif

            Assert.NotNull(windowsDriver);
        }


        public static string RootPath()
        {
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            return mainpath;
        }
        public static string RootPathReport()
        {
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            return mainpath;
        }
        public static ISearchContext Driver => windowsDriver;
        public static IWebDriver _Driver => windowsDriver;
        
        public static void Close()
        {
            _Driver.Close();
        }

        public static void Quit()
        {
            _Driver.Quit();
        }
    }
}
