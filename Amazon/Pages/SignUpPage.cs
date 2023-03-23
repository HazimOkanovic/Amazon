using OpenQA.Selenium;

namespace Amazon.Pages
{
    public class SignUpPage : BasePage
    {
        private readonly By _firstAndLastNameInput = By.Id("ap_customer_name");
        private readonly By _emailOrPhoneInput = By.Id("ap_email");
        private readonly By _passwordInput = By.Id("ap_password");
        private readonly By _reEnterPasswordInput = By.Id("ap_password_check");
        private readonly By _continueButton = By.Id("continue");
        
        public SignUpPage(IWebDriver driver) : base(driver)
        {
            
        }

        public SignUpPage EnterFirstAndLastName(string firstAndLastName)
        {
            WaitElementVisibleAndGet(_firstAndLastNameInput).SendKeys(firstAndLastName);
            return this;
        }

        public SignUpPage EnterEmailOrPhoneNumber(string emailOrPhoneNumber)
        {
            WaitElementVisibleAndGet(_emailOrPhoneInput).SendKeys(emailOrPhoneNumber);
            return this;
        }

        public SignUpPage EnterPassword(string password)
        {
            WaitElementVisibleAndGet(_passwordInput).SendKeys(password);
            return this;
        }

        public SignUpPage ReEnterPassword(string reEnterPassword)
        {
            WaitElementVisibleAndGet(_reEnterPasswordInput).SendKeys(reEnterPassword);
            return this;
        }

        public SignUpPage ClickContinue()
        {
            WaitElementVisibleAndGet(_continueButton).Click();
            return this;
        }
    }
}