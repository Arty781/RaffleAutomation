using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
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
#if CHROME
            new DriverManager().SetUpDriver(new ChromeConfig());
            windowsDriver = new ChromeDriver();
#endif
#if FIREFOX
            new DriverManager().SetUpDriver(new FirefoxConfig());
            windowsDriver = new FirefoxDriver();
#endif
            windowsDriver.Manage().Cookies.DeleteAllCookies();
#if DEBUG_MOBILE
            windowsDriver.Manage().Window.Size = new Size(390, 844);
#endif
#if DEBUG || CHROME || FIREFOX
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

        public static void Navigate(string url)
        {
            _Driver.Navigate().GoToUrl(url);
        }
    }
}
