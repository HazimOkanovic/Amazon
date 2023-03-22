using Amazon.Helpers;
using Amazon.Pages;
using NUnit.Framework;

namespace Amazon.Tests
{
    public class ImageComparisonTests : BaseTest
    {
        private readonly HomePage _homePage;
        private readonly ResultsPage _resultsPage;

        public ImageComparisonTests()
        {
            _homePage = new HomePage(driver);
            _resultsPage = new ResultsPage(driver);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage.GoToUrl(ConfigHelper.WEB_URL);
        }

        [Test, Order(1)]
        public void SearchForProduct()
        {
            _homePage
                .EnterTextInSearch(Constants.SearchText)
                .ClickSearchButton();

            Assert.That(_resultsPage.GetSearchResultText(), Is.EqualTo(Constants.SearchResultText));
        }

        [Test, Order(2)]
        public void SelectTheBike()
        {
            _resultsPage
                .ClickFirstBike();

            Assert.That(_resultsPage.GetProductTitle(),
                Is.EqualTo(Constants.ProductTitle));
        }

        [Test, Order(3)]
        public void CompareImagesTest()
        {
            _resultsPage
                .GetImage()
                .ClickOnImage()
                .CompareImages();
        }
    }
}