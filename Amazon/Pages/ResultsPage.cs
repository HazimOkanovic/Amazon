using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.Test.VisualVerification;
using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class ResultsPage : BasePage
    {
        private readonly By _searchResultText = By.XPath("//div//span[@class = 'a-color-state a-text-bold']");
        private readonly By _firstBikeResult = By.XPath("//a//span[contains(text(), 'Huffy Hardtail')]");
        private readonly By _productTitle = By.Id("productTitle");
        private readonly By _bikeImage = By.Id("landingImage");

        public ResultsPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string GetSearchResultText()
        {
            return WaitElementVisibleAndGet(_searchResultText).Text;
        }

        public string GetProductTitle()
        {
            return WaitElementVisibleAndGet(_productTitle).Text;
        }

        public ResultsPage ClickFirstBike()
        {
            WaitElementVisibleAndGet(_firstBikeResult).Click();
            return this;
        }

        public ResultsPage GetImage()
        {
            IWebElement element = driver.FindElement(_bikeImage);
            var imageSrc = element.GetAttribute("src");
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(imageSrc, @"C:\Users\hazim\Downloads\image.png");
            }

            return this;
        }

        public ResultsPage ClickOnImage()
        {
            WaitElementVisibleAndGet(_bikeImage).Click();
            Thread.Sleep(2000);
            return this;
        }
        
        public void CompareImages()
        {
            Snapshot actual = Snapshot.FromRectangle(new Rectangle(290, 260, 466, 466));
            
            Snapshot expected = Snapshot.FromFile("C:/Users/hazim/Downloads/image.png");
            
            Snapshot difference = actual.CompareTo(expected);
            
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());
            
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                actual.ToFile("C:/Users/hazim/Downloads/Actual.png", ImageFormat.Png);
                difference.ToFile("C:/Users/hazim/Downloads/Difference.png", ImageFormat.Png);
            }
        }
    }
}