using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon.Helpers
{
    public class DriverHelper
    {
        private static readonly string BinaryExecutionPath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("ignore-certificate-errors");
            return new ChromeDriver(BinaryExecutionPath, chromeOptions);
        }
    }
}