using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;


namespace RaffleAutomationTests.Helpers
{
    public class Browser
    {
        private static IWebDriver driver;

        public static void Initialize()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile();
#if DEBUG || CHROME || RELEASE
            try
            {
                var options = new ChromeOptions();
                //options.AddArgument("--headless");
                //options.AddArgument("--window-size=1920,1020");
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver(options);
                Assert.NotNull(driver);
            }
            catch (Exception ex) { throw new ArgumentException(ex.Message); }
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
#endif
#if FIREFOX
            try
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                Assert.NotNull(driver);
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
#endif
#if DEBUG_MOBILE || RELEASE_MOBILE
            driver.Manage().Window.Size = new Size(390, 844);
            driver.Manage().Cookies.DeleteAllCookies();
#endif
        }

        public static string RootPath() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
        public static string RootPathReport() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        public static IWebDriver Driver => driver;
        public static void Close() => Driver.Close();
        public static void Quit() => Driver.Quit();
        public static void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


    }

    public class ForceCloseDriver
    {
        public static string CreateBatFile()
        {
            string path = Browser.RootPathReport() + "_!CloseOpenWith.bat";
            string forceCloseAppList = string.Format("echo off" +
                "TASKKILL /F /IM \"OpenWith.exe\"\r\n" +
                "TASKKILL /F /IM \"chromedriver.exe\"\r\n" +
                "TASKKILL /F /IM \"java.exe\"\r\n" +
                "TASKKILL /F /IM \"node.exe\"\r\n" +
                "TASKKILL /F /IM \"AppleMobileDeviceService.exe\"\r\n" +
                "TASKKILL /F /IM \"APSDaemon.exe\"\r\n" +
                "TASKKILL /F /IM \"ICloudServices.exe\"\r\n" +
                "TASKKILL /F /IM \"mDNSResponder.exe\"\r\n" +
                "TASKKILL /F /IM \"altserver.exe\"\r\n" +
                "TASKKILL /F /IM \"Screencast-O-Matic.exe\"" +
                "pause"
                );
            FileInfo fileInf = new(path);
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
            using StreamWriter writer = new(path, false, Encoding.UTF8);
            writer.Write(forceCloseAppList);

            return path;
        }

        public static void RemoveBatFile(string path)
        {
            FileInfo fileInf = new(path);
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
        }

        public static void ForeseClose()
        {
            string path = CreateBatFile();
            Process process = new();
            process.StartInfo.FileName = path;
            process.Start();
            process.Close();
            Thread.Sleep(1000);
            RemoveBatFile(path);
        }
    }

}
