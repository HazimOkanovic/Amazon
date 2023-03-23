using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _searchField = By.Id("twotabsearchtextbox");
        private readonly By _searchButton = By.Id("nav-search-submit-button");
        private readonly By _signUpButton = By.XPath("(//div//a[contains(text(), 'Start here.')])[2]");
        
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage EnterTextInSearch(string searchText)
        {
            WaitElementVisibleAndGet(_searchField).SendKeys(searchText);
            return this;
        }

        public ResultsPage ClickSearchButton()
        {
            WaitElementVisibleAndGet(_searchButton).Click();
            return new ResultsPage(driver);
        }

        public SignUpPage ClickSignUp()
        {
            WaitElementVisibleAndGet(_signUpButton).Click();
            return new SignUpPage(driver);
        }
    }
}