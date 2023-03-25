using System.Threading;
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

        [Test, Order(2)]
        public void EnterLowPriceTest()
        {
            _accessoriesPage
                .ScrollToLowPrice()
                .EnterLowPrice("12000")
                .ClickGoButton();
            
            Assert.That(_accessoriesPage.GetResults(), Is.EqualTo("4 results"));
        }

        [Test, Order(3)]
        public void SortByFeaturedTest()
        {
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo("Hasselblad X1D 4116 Edition, Black (7392544139210)\r\nKATA MC-61 Medium Camera Shoulder Case, GDC Multi Case\r\nPanduit FODPX72Y\r\nPolycom Front-of-Room Camera (7200-65600-001)"));
        }

        [Test, Order(4)]
        public void SortByPriceHighToLow()
        {
            _accessoriesPage
                .SortByHighToLow();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo("Polycom Front-of-Room Camera (7200-65600-001)\r\nPanduit FODPX72Y\r\nKATA MC-61 Medium Camera Shoulder Case, GDC Multi Case\r\nHasselblad X1D 4116 Edition, Black (7392544139210)"));
        }
        
        [Test, Order(5)]
        public void SortByPriceLowToHigh()
        {
            _accessoriesPage
                .SortByLowToHigh();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo("Hasselblad X1D 4116 Edition, Black (7392544139210)\r\nKATA MC-61 Medium Camera Shoulder Case, GDC Multi Case\r\nPanduit FODPX72Y\r\nPolycom Front-of-Room Camera (7200-65600-001)"));
        } 

        [Test, Order(6)]
        public void SortByAvgCustomerReview()
        {
            _accessoriesPage
                .SortByCustomerReview();
            
            Assert.That(_accessoriesPage.GetAllProducts(), Is.EqualTo("KATA MC-61 Medium Camera Shoulder Case, GDC Multi Case\r\nHasselblad X1D 4116 Edition, Black (7392544139210)\r\nPanduit FODPX72Y\r\nPolycom Front-of-Room Camera (7200-65600-001)"));
        }
    }
}