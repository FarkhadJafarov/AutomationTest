using NUnit.Framework;
using OpenQA.Selenium;
using ReproduceIssueProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace ReproduceIssueProject.StepDefinitions
{

    [Binding]
    public class AuthorizationSteps
    {
        private ScenarioContext scenarioContext;

        public AuthorizationSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I have navigate to my website")]
        public void GivenIHaveNavigateToMyWebsite()
        {
            IWebDriver driver = (IWebDriver)scenarioContext["_driver"];
            AuthorizationPage authorizationPage = new AuthorizationPage(driver);
            scenarioContext["authorizationPage"] = authorizationPage;
        }

        [Given(@"I typed (.*) and (.*)")]
        public void GivenITypedAnd(string email, string password, Table table)
        {
            AuthorizationPage authorizationPage = (AuthorizationPage)scenarioContext["authorizationPage"];
             email = table.Rows[0]["email"];
             password = table.Rows[0]["password"];

            authorizationPage.MethodForAuthorization(email, password);

            //loginPage.MethodForAuthorization(table.Rows[0]["Login"], table.Rows[0]["Password"]);
        }

        [When(@"I click button Sign in")]
        public void WhenIClickButtonSignIn()
        {
            IWebDriver driver = (IWebDriver)scenarioContext["_driver"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AuthorizationPage authorizationPage = (AuthorizationPage)scenarioContext["authorizationPage"];
            authorizationPage.ButtonSignIn();
        }
        
        [Then(@"I should log in to the site")]
        public void ThenIShouldLogInToTheSite()
        {
            string expected = "MY ACCOUNT";
            IWebDriver driver = (IWebDriver)scenarioContext["_driver"];
            ProfilePage profile = new ProfilePage(driver);
            string actual = profile.MyNewProfile();
            Assert.AreEqual(expected, actual);
        }
    }
}
