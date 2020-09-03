using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReproduceIssueProject.Pages
{
    class HomePage
    {
        public IWebDriver _driver;
        private string _url;
        private By _signIn;
        private By _check_Page;

        public HomePage(IWebDriver driver)
        {

            this._driver = driver;
            _url = "http://automationpractice.com/index.php";
            _signIn = By.XPath("//[@class='login']");
            _check_Page = By.XPath("[id='editorial_image_legend']");
            _driver.Navigate().GoToUrl(_url);


            if (_driver.FindElements(_check_Page).Count < 0)
            {
                throw new InvalidOperationException("Мы не на странице MainMenu_Page");
            }
        }
        public void SignIn()
        {
            _driver.FindElement(_signIn).Click();
        }
        public void MainMenu()
        {
            SignIn();
        }

    }
}
