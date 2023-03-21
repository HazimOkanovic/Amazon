using Amazon.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Amazon.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        protected BaseTest()
        {
            driver = DriverHelper.GetDriver();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}