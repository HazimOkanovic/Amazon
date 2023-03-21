using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Amazon.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver) 
        {
            this.driver = driver;
        }
        
        #region Methods allowing to dynamically pause the execution until needed element meets a condition

        protected void WaitElementExists(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + by);
            }
        }

        protected void WaitElementVisible(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not visible with xpath: " + by);
            }
        }

        protected void WaitElementClickable(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not clickable with xpath: " + by);
            }
        }

        protected void WaitLoaderNotVisible(int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            // wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loader));
            throw new NotImplementedException();
        }

        #endregion

        #region Methods for getting an element after element meets a condition

        protected IWebElement WaitElementExistsAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementExists(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementVisibleAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementVisible(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementClickableAndGet(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementClickable(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        #endregion

        #region Methods to assert if element meets a condition

        protected void CheckElementExists(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            WaitElementExists(by, timeoutInSeconds);
        }

         protected void CheckListOfElementsExist(List<By> elements, int timeoutInSeconds = Constants.TimeoutInSeconds)
         {
            //Assert.Multiple(() =>
           // {
                 foreach (By el in elements)
                 {
                     CheckElementExists(el, timeoutInSeconds);
                 }
            //});
        }

        #endregion

        #region Methods to check if element meets a condition

        protected bool ElementExists(By by, int timeoutInSeconds = Constants.TimeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        #endregion

        #region Helper methods to execute some actions

        public string PrepareEmail(string email)
        {
            Random random = new Random();
            int randomNum = random.Next(10000000, 99999999);
            string _email = email.Split('@')[0] + "+" + randomNum.ToString() + "@" + email.Split('@')[1];
            return _email;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void OpenNewTabAndGoToUrl(string url)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(url);
        }

        public void ClickOnText(string text)
        {
            WaitElementClickableAndGet(By.XPath("//*[contains(text(), '" + text + "')]"), 10).Click();
        }

        public void SelectFromDropdown(By dropdown, By selectOption, int timeoutInSeconds = 20)
        {
            // TODO: check if this is needed on safari with Selenium 4.0 if yes, uncomment this when browserName is fixed
            // if (browserName == "safari")
            // {
            //     WaitElementExists(dropdown, timeoutInSeconds);
            //     ClickJS(dropdown);
            //     WaitElementExists(selectOption, timeoutInSeconds);
            //     ClickJS(selectOption);
            // }
            // else
            // {
            WaitElementExistsAndGet(dropdown, timeoutInSeconds).Click();
            WaitElementExistsAndGet(selectOption, timeoutInSeconds).Click();
            // }
        }

        public void ClearInput(By element)
        {
            WaitElementExistsAndGet(element, 60).Clear();
        }

        public void ClickJS(By path)
        {
            var element = driver.FindElement(path);
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SendKeys(By element, string text)
        {
            WaitElementClickableAndGet(element, 60).SendKeys(text);
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        #endregion
    }
}