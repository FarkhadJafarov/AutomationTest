using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReproduceIssueProject.Pages
{
    class AuthorizationPage
    {
        public IWebDriver _driver;
        private string _url;
        private By _checkPage;
        private By _emailCreate;
        private By _buttonCreateAccount;
        private By _email;
        private By _passworld;
        private By _buttonSignIn;

        private By _errorInvalidAuthorization;
        private By _errorInvalidCreateAccount;
        public AuthorizationPage(IWebDriver driver)
        {
            
            this._driver = driver;

            _url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
            _checkPage = By.ClassName("page-heading");
            _emailCreate = By.Id("email_create");
            _buttonCreateAccount = By.XPath("//*[@class='icon-user left']");
            _email = By.XPath("//*[@id='email']");
            _passworld = By.XPath("//*[@id='passwd']");
            _buttonSignIn = By.XPath("//*[@id='SubmitLogin']/span");
            _driver.Navigate().GoToUrl(_url);

            if (_driver.FindElements(_checkPage).Count < 0)
            {
                throw new InvalidOperationException("Мы не на странице ауденфикации");
            }
            //Error Selector
            _errorInvalidAuthorization = By.XPath("//*[@id='center_column']//ol/li");
            _errorInvalidCreateAccount = By.XPath("//*[@id='create_account_error']/ol/li");
        }
        public void Create_Email(string Email)
        {
            _driver.FindElement(_emailCreate).SendKeys(Email);
        }
        public void ButtonForCreateEmail()
        {
            _driver.FindElement(_buttonCreateAccount).Click();
        }
        public void EnterEmailForLogin(string Email)
        {
            _driver.FindElement(_email).SendKeys(Email);
        }
        public void EnterPasswordForLogin(string pass)
        {
            _driver.FindElement(_passworld).SendKeys(pass);
        }
        public void ButtonSignIn()
        {
            IWebElement button = _driver.FindElement(_buttonSignIn);
            button.Click();
        }
        public string ErrorAuthorizationInvalid()
        {
            IWebElement errorInvalid = _driver.FindElement(_errorInvalidAuthorization);
            return errorInvalid.Text;
        }
        public string ErrorCreateAccountInvalid()
        {
            IWebElement errorInvalid = _driver.FindElement(_errorInvalidCreateAccount);

            return errorInvalid.Text;
        }
        public void MethodForCreateEmail(string EmailForCheck)
        {
            Create_Email(EmailForCheck);
            ButtonForCreateEmail();
        }//метод для проверки email на  регистрацию
        public void MethodForAuthorization(string Email, string Pass)
        {
            EnterEmailForLogin(Email);
            EnterPasswordForLogin(Pass);


        }//метод для авторизации
    }
}
