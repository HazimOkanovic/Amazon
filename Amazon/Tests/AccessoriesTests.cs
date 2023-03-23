using Amazon.Helpers;
using Amazon.Pages;
using NUnit.Framework;

namespace Amazon.Tests
{
    public class AccessoriesTests : BaseTest
    {
        private readonly HomePage _homePage;
        private readonly AccessoriesPage _accessoriesPage;
        
        public AccessoriesTests()
        {
            _homePage = new HomePage(driver);
            _accessoriesPage = new AccessoriesPage(driver);
        }
        
        [OneTimeSetUp]
        public void Setup()
        {
            _homePage.GoToUrl(ConfigHelper.WEB_URL);
        }

        [Test, Order(1)]
        public void GoToAccessories()
        {
            _homePage
                .ClickAllButton()
                .ClickElectronicsButton()
                .ClickAccessories();
            
            Assert.That(_accessoriesPage.GetPageTitle(), Is.EqualTo("Accessories & Supplies"));
        }
    }
}