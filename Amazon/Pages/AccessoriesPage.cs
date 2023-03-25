using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
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
        private readonly By _productsNames = By.XPath("//a//span[@class='a-size-base-plus a-color-base a-text-normal']");
        private readonly By _sortDropDown = By.XPath("//span[@class = 'a-button-text a-declarative']");
        private readonly By _lowToHigh = By.XPath("(//li//a[contains(.,  'Price: Low to High')])[2]");
        private readonly By _highToLow = By.XPath("//li//a[contains(text(),  'Price: High to Low')]");
        private readonly By _avgCustomerReview = By.XPath("(//li//a[contains(.,  'Avg. Customer Review')])[3]");
        
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

        public string GetAllProducts()
        {
            Thread.Sleep(2000);
            List<string> allProducts = new List<string>();
            ReadOnlyCollection<IWebElement> myList=driver.FindElements(_productsNames);
            foreach (var t in myList)
            {
                allProducts.Add(t.Text);
            }
            string items = string.Join(Environment.NewLine, allProducts);
            return items;
        }

        public AccessoriesPage SortByHighToLow()
        {
            SelectFromDropdown(_sortDropDown, _highToLow);
            return this;
        }

        public AccessoriesPage SortByLowToHigh()
        {
            SelectFromDropdown(_sortDropDown, _lowToHigh);
            return this;
        }

        public AccessoriesPage SortByCustomerReview()
        {
            SelectFromDropdown(_sortDropDown, _avgCustomerReview);
            return this;
        }
    }
}