using Amazon.Helpers;
using Amazon.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Amazon.Tests
{
    public class SomeTest : BaseTest
    {
        private HomePage _homePage;
        private ResultsPage _resultsPage;

        public SomeTest()
        {
            _homePage = new HomePage(driver);
            _resultsPage = new ResultsPage(driver);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            _homePage.GoToUrl(ConfigHelper.WEB_URL);
        }
    }
}