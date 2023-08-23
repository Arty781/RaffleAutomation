
using CONFIG_JSON;
using Newtonsoft.Json;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


namespace AppiumAutomation
{
    public class Browser
    {

        public WindowsDriver<WindowsElement> WindowsDriver { get; set; }
        private static WindowsDriver<WindowsElement> windowsDriver;
        private static AppiumLocalService _appiumLocalService;

        public Browser(WindowsDriver<WindowsElement> windowsDriver)
        {
            WindowsDriver = windowsDriver;
        }
        public class DriverPuth
        {
            public const string WinDriverPuth = @"WinAppDriver\WinAppDriver.exe";
        }

        public static void Initialize()
        {
            
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Program Files\Google\Chrome\Application\chrome.exe");
            options.AddAdditionalCapability("deviceName", "ARTY");
            options.AddAdditionalCapability("ms:waitForAppLaunch", 3);
            options.AddAdditionalCapability("ms:experimental-webdriver", "--incognito");
            windowsDriver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), options);
            Assert.NotNull(windowsDriver);
        }
        public static string RootPath()
        {
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            return mainpath;
        }
        public static ISearchContext Driver => windowsDriver;
        public static WindowsDriver<WindowsElement> _Driver => windowsDriver;
        public static void Close() => windowsDriver?.Close();

    }

    public class Helpers 
    {
        public static void CreateJsonConfigFile()
        {
            ConfigJson json = new ConfigJson()
            {
                Allure = new CONFIG_JSON.Allure()
                {
                    Directory = Path.Combine(Browser.RootPath() + "allure-results"),
                    Links = new List<string>()
                    {
                        "{link}",
                        "https://testrail.com/browse/{tms}",
                        "https://jira.com/browse/{issue}"
                    }
                },
                Specflow = new Specflow()
                {
                    StepArguments = new StepArguments()
                    {
                        ConvertToParameters = true,
                        ParamNameRegex = "",
                        ParamValueRegex = ""
                    },
                    Grouping = new Grouping()
                    {
                        Suites = new Suites()
                        {
                            ParentSuite = "^parentSuite:?(.+)",
                            Suite = "^suite:?(.+)",
                            SubSuite = "^subSuite:?(.+)"
                        },
                        Behaviors = new Behaviors()
                        {
                            Epic = "^epic:?(.+)",
                            Story = "^story:(.+)"
                        }
                    },
                    Labels = new Labels()
                    {
                        Owner = "^author:?(.+)",
                        Severity = "^(normal|blocker|critical|minor|trivial)"
                    },
                    Links = new Links()
                    {
                        Tms = "^story:(.+)",
                        Issue = "^issue:(.+)",
                        Link = "^link:(.+)"
                    }
                }
            };
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) + "allureConfig.json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter file = File.CreateText(path))
            {
                serializer.Serialize(file, json);
            }
        }
    }

    [TestFixture]
    public class Base
    {

        public static Process process;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Helpers.CreateJsonConfigFile();
            process = Process.Start(Browser.RootPath() + Browser.DriverPuth.WinDriverPuth);
        }

        [SetUp]
        public static void SetUp()
        {
            
            Browser.Initialize();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Browser._Driver?.Dispose();
            process.Kill();
        }

        [TearDown]
        public static void TearDown() => Browser._Driver.Close();
    }

    [TestFixture]
    [AllureNUnit]
    public class Demo : Base
    {
        

        [Test]
        //[Ignore("Demo test")]

        public void Demotest()
        {
            WaitUntil.CustomElementIsVisible(Pages.CmsLogin.addressBar);
            Pages.CmsLogin.addressBar.SendKeys("https://admin-staging.rafflehouse.com/#/login" + Keys.Enter);
            Thread.Sleep(5000);
            WaitUntil.CustomElementIsVisible(Pages.CmsLogin.email);
            Pages.CmsLogin.email.Clear();
            Pages.CmsLogin.email.SendKeys("bennospencer@gmail.com");
            Pages.CmsLogin.password.Clear();
            Pages.CmsLogin.password.SendKeys("1289Raffle@!CMS");
            Pages.CmsLogin.btnSignIn.Click();
            Thread.Sleep(10000);
        }
    }

    public class WaitUntil
    {
        public static void CustomElementIsVisible(IWebElement element, int seconds = 10)
        {
            Thread.Sleep(500);
            WebDriverWait wait = new WebDriverWait(Browser._Driver, TimeSpan.FromSeconds(seconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            wait.Message = $"Element is not visible after {seconds} sec";
            try
            {
                wait.Until(e =>
                {
                    try
                    {
                        if (element != null && element.Enabled == true || element.Displayed == true)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception) { return false; }

                });
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(); }
            catch (StaleElementReferenceException) { throw new StaleElementReferenceException(); }
        }
    }

    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            SeleniumExtras.PageObjects.PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static CmsLogin CmsLogin => GetPage<CmsLogin>();
    }

    public class CmsLogin
    {
        public IWebElement addressBar => Browser._Driver.FindElement(By.XPath("//*[contains(@Name, 'Адресний і пошуковий рядок')]"));
        public IWebElement email => Browser._Driver.FindElement(By.XPath("//*[contains(@Name, 'Email')]"));
        public IWebElement password => Browser._Driver.FindElement(By.XPath("//*[contains(@Name, 'Password')]"));
        public IWebElement btnSignIn => Browser._Driver.FindElement(By.XPath("//*[contains(@Name, 'Sign In')]"));
    }

}



namespace CONFIG_JSON
{
    public partial class ConfigJson
    {
        [JsonProperty("allure")]
        public Allure Allure { get; set; }

        [JsonProperty("specflow")]
        public Specflow Specflow { get; set; }
    }

    public partial class Allure
    {
        [JsonProperty("directory")]
        public string Directory { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }
    }

    public partial class Specflow
    {
        [JsonProperty("stepArguments")]
        public StepArguments StepArguments { get; set; }

        [JsonProperty("grouping")]
        public Grouping Grouping { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public partial class Grouping
    {
        [JsonProperty("suites")]
        public Suites Suites { get; set; }

        [JsonProperty("behaviors")]
        public Behaviors Behaviors { get; set; }
    }

    public partial class Behaviors
    {
        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("story")]
        public string Story { get; set; }
    }

    public partial class Suites
    {
        [JsonProperty("parentSuite")]
        public string ParentSuite { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("subSuite")]
        public string SubSuite { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("tms")]
        public string Tms { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class StepArguments
    {
        [JsonProperty("convertToParameters")]
        public bool ConvertToParameters { get; set; }

        [JsonProperty("paramNameRegex")]
        public string ParamNameRegex { get; set; }

        [JsonProperty("paramValueRegex")]
        public string ParamValueRegex { get; set; }
    }
}

