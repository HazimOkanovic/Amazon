using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class AccessoriesPage : BasePage
    {
        private readonly By _pageTitle = By.XPath("//div//div[@class = 'nav-search-facade']");
        
        public AccessoriesPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string GetPageTitle()
        {
            return WaitElementVisibleAndGet(_pageTitle).Text;
        }
    }
}