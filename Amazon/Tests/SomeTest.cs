using Amazon.Helpers;
using Amazon.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Amazon.Tests
{
    public class SomeTest : BaseTest
    {
        private SomePage somePage;

        public SomeTest() : base()
        {
            somePage = new SomePage(driver);
        }
        [Test]
        public void Setup()
        {
            somePage.GoToUrl(ConfigHelper.WEB_URL);
        }
    }
}