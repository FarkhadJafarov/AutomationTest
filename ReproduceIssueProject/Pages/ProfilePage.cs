using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReproduceIssueProject.Pages
{
    class ProfilePage
    {
        public IWebDriver _driver;

        private By _checkPage;
        private By _textProfile;

        public ProfilePage(IWebDriver driver)
        {
            this._driver = driver;
            _checkPage = By.XPath(".//*[text()='Welcome to your account. Here you can manage all of your personal information and orders.']");
            _textProfile = By.XPath(".//*[@class='page-heading']");

            if (_driver.FindElements(_checkPage).Count < 0)
            {
                throw new InvalidOperationException("Мы не на странице профиля");
            }
        }
        public string MyNewProfile()
        {
            IWebElement checkmyprofile = _driver.FindElement(_textProfile);
            return checkmyprofile.Text;
        }
    }
}
