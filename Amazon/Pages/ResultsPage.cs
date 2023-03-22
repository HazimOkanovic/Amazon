using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using GroupDocs.Comparison;
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
        
        public void SecondImage()
        {
            WaitElementVisibleAndGet(By
                .XPath(
                    "//div//img[@alt = 'Huffy Hardtail Mountain Bike, Stone Mountain 26 inch, 21-Speed, Lightweight, Dark Blue']")).Click();
            // 1. Capture the actual pixels from a given window
            Thread.Sleep(2000);
            Snapshot actual = Snapshot.FromRectangle(new Rectangle(290, 260, 466, 466));
            
// 2. Load the reference/master data from a previously saved file
            Snapshot expected = Snapshot.FromFile("C:/Users/hazim/Downloads/image.png");

// 3. Compare the actual image with the master image
//    This operation creates a difference image. Any regions which are identical in 
//    the actual and master images appear as black. Areas with significant 
//    differences are shown in other colors.
            Snapshot difference = actual.CompareTo(expected);

// 4. Configure the snapshot verifier - It expects a black image with zero tolerances
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());

// 5. Evaluate the difference image
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                // Log failure, and save the diff file for investigation
                actual.ToFile("C:/Users/hazim/Downloads/Actual.png", ImageFormat.Png);
                difference.ToFile("C:/Users/hazim/Downloads/Difference.png", ImageFormat.Png);
            }
            /*
            Comparer comparer = new Comparer("C:/Users/hazim/Downloads/image.png");
            CompareOptions options = new CompareOptions();
            comparer.Add("filepath/targetImage.jpg");
            comparer.Compare("filepath/comparisonResultImage.jpg", options); */
        }
    }
}