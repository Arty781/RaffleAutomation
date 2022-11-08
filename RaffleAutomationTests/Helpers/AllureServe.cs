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
    public class ForceCloseWebDriver
    {
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSuite("DriverLevel")]
        [AllureSubSuite("ForceCloseDriver")]
        [Test]
        public static void ForceClose()
        {
            ForceCloseDriver.CreateBatFile();
            WaitUntil.WaitSomeInterval(1000);
            Process.Start(Browser.RootPathReport() + "_!CloseOpenWith.bat");
        }

        public static void RemoveBatFile()
        {
            string path = Browser.RootPathReport() + "_!CloseOpenWith.bat";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
        }

        public class ForceCloseDriver
        {
            public static string CreateBatFile()
            {
                string path = Browser.RootPathReport() + "_!CloseOpenWith.bat";
                string forceCloseAppList = string.Format(
                    "TASKKILL" + " /IM " + "\"OpenWith.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"chromedriver.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"java.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"node.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"AppleMobileDeviceService.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"APSDaemon.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"ICloudServices.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"mDNSResponder.exe\"" + " /F " + "F" + "\n" +
                    "TASKKILL" + " /IM " + "\"altserver.exe\"" + " /F " + "\n" +
                    "TASKKILL" + " /IM " + "\"Screencast-O-Matic.exe\"" + " /F " + "\n"
                    );
                FileInfo fileInf = new(path);
                if (fileInf.Exists == true)
                {
                    fileInf.Delete();
                }
                using (FileStream fstream = new($"{path}", FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(forceCloseAppList);
                    fstream.Write(array, 0, array.Length);
                }
                return path;
            }
        }
    }
}
