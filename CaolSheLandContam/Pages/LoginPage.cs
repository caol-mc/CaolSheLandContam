using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CaolSheLandContam.Pages
{
    [Binding]
    class LoginPage
    {

        private ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public LoginPage(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }


        public static void Login(IWebDriver _driver, string Username, String Password)
        {
            Shared.SendKeysToLabel(_driver, "username", Username);
            Shared.SendKeysToLabel(_driver, "password", Password);
            Shared.ClickOnButton(_driver, Constants.LOGIN);
            Shared.WaitForElementVisibility(_driver, Constants.BYHOMEPAGE);
        }


    }
}
