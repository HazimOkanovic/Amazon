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
            
            Assert.That(_accessoriesPage.GetPageTitle(), Is.EqualTo(Constants.AccessoriesPageTitle));
        }

        [Test, Order(2)]
        public void EnterLowPriceTest()
        {
            _accessoriesPage
                .ScrollToLowPrice()
                .EnterLowPrice(Constants.PriceInput)
                .ClickGoButton();
            
            Assert.That(_accessoriesPage.GetResults(), Is.EqualTo(Constants.AccessoriesResult));
        }

        [Test, Order(3)]
        public void SortByFeaturedTest()
        {
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo(Constants.FeaturedProducts));
        }

        [Test, Order(4)]
        public void SortByPriceHighToLow()
        {
            _accessoriesPage
                .SortByHighToLow();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo(Constants.HighToLowProducts));
        }
        
        [Test, Order(5)]
        public void SortByPriceLowToHigh()
        {
            _accessoriesPage
                .SortByLowToHigh();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo(Constants.LowToHighProducts));
        } 

        [Test, Order(6)]
        public void SortByAvgCustomerReview()
        {
            _accessoriesPage
                .SortByCustomerReview();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo(Constants.AvgCustomerReviewProducts));
        }
    }
}