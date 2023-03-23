using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _searchField = By.Id("twotabsearchtextbox");
        private readonly By _searchButton = By.Id("nav-search-submit-button");
        private readonly By _allButton = By.Id("nav-hamburger-menu");
        private readonly By _electronicsButton = By.XPath("//li//a[@data-menu-id='5']");
        private readonly By _accessoriesButton = By.XPath("(//li//a[contains(text(), 'Accessories')])[2]");

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

        public HomePage ClickAllButton()
        {
            WaitElementVisibleAndGet(_allButton).Click();
            return this;
        }

        public HomePage ClickElectronicsButton()
        {
            WaitElementVisibleAndGet(_electronicsButton).Click();
            return this;
        }

        public AccessoriesPage ClickAccessories()
        {
            WaitElementVisibleAndGet(_accessoriesButton).Click();
            return new AccessoriesPage(driver);
        }
    }
}