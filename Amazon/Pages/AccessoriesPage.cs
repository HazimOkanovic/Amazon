using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Amazon.Pages
{
    public class AccessoriesPage : BasePage
    {
        private readonly By _pageTitle = By.XPath("//div//div[@class = 'nav-search-facade']");
        private readonly By _lowPriceInput = By.Id("low-price");
        private readonly By _goButton = By.XPath("//span//input[@class='a-button-input']");
        private readonly By _results = By.XPath("//div[@class='a-section a-spacing-small a-spacing-top-small']");
        
        public AccessoriesPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string GetPageTitle()
        {
            return WaitElementVisibleAndGet(_pageTitle).Text;
        }
        
        public string GetResults()
        {
            return WaitElementVisibleAndGet(_results).Text;
        }

        public AccessoriesPage ScrollToLowPrice()
        {
            var element = driver.FindElement(_lowPriceInput);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            return this;
        }

        public AccessoriesPage EnterLowPrice(string lowPrice)
        {
            WaitElementVisibleAndGet(_lowPriceInput).SendKeys(lowPrice);
            return this;
        }

        public AccessoriesPage ClickGoButton()
        {
            WaitElementVisibleAndGet(_goButton).Click();
            return this;
        }
    }
}