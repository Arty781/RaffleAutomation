﻿using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace RaffleAutomationTests.Helpers
{
    public class ScreenShotHelper
    {
        public static string MakeScreenShot()
        {
            ITakesScreenshot? ssdriver = Browser.Driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            string timestampPath = DateTime.Now.ToString("yyyy-MM-dd");
            string timestampName = DateTime.UtcNow.ToString("dd-MMMM-yyyy' 'HH-mm-ss");
            string path = Browser.RootPath() + @"\ErrorImages\" + timestampPath + @"\";
            string name = path + "Exception-" + timestampName + ".png";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            screenshot.SaveAsFile(name, ScreenshotImageFormat.Png);
            return name;
        }

        public static void DeleteScreenShot(string file)
        {
            if (!Directory.Exists(Path.Combine(file, "..\\")))
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                Directory.Delete(Path.Combine(file, "..\\"));
            }
            
        }
    }
}
