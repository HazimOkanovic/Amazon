using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class ResultsPage : BasePage
    {
        private readonly By _searchResultText = By.XPath("//div//span[@class = 'a-color-state a-text-bold']");
        
        public ResultsPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string GetSearchResultText()
        {
            return WaitElementVisibleAndGet(_searchResultText).Text;
        }
    }
}