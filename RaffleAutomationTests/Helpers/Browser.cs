namespace RaffleAutomationTests.Helpers
{
    public class Browser
    {
        private static IWebDriver windowsDriver;

        public static void Initialize()
        {
            AllureConfigFilesHelper.CreateJsonConfigFile();
#if DEBUG || CHROME
            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                windowsDriver = new ChromeDriver();
                Assert.NotNull(windowsDriver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
#endif
#if FIREFOX
            try
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                windowsDriver = new FirefoxDriver();
                Assert.NotNull(windowsDriver);
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message);
            }

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
