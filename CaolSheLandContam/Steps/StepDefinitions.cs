using CaolSheLandContam.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CaolSheLandContam.Steps
{
    [Binding]
    public class StepDefinitions
    {
        IWebDriver _driver = new ChromeDriver();

        
        [Given(@"I am on the assure home page")]
        public void GivenIAmOnTheAssureHomePage()
        {
            GivenIAmOnTheAssureLoginPage();
            WhenIEnterMyLoginDetails();

        }

        [Given(@"I am on the (land contamination) module under (environment)")]
        public void GivenIAmOnTheModule(string ModuleType, string ModuleParent)
        {
            Shared.ClickOnModulesLink(_driver, ModuleParent, ModuleType);
        }



        [When(@"I click on the button (.+)")]
        public void WhenIClickOnTheNewRecordButton(string button)
        {
            Shared.ClickOnButton(_driver, button);
        }

        [When(@"I click on the link (.+)")]
        public void WhenIClickOnTheNewRecordLink(string button)
        {
            Shared.ClickOnLink(_driver, button);
        }

        [When(@"enter the following details")]
        public void WhenEnterTheFollowingDetails(Table table)
        {
            IEnumerable<StepDefinitions.StepData> steps = table.CreateSet<StepData>();

            foreach (StepDefinitions.StepData step in steps)
            {
                Shared.SendKeysToLabel(_driver, step.param, step.value);
            }
            Shared.ClickOnButton(_driver, Constants.SAVEANDCLOSE);

        }

        [When(@"I delete the (.*)?, record")]
        public void WhenIDeleteTheRecord(string value)
        {
            Shared.DeleteRecord(_driver, value.ToLower());           
        }

        [Then(@"the (.*)?, record is removed from the table")]
        public void ThenTheRecordIsRemovedFromTheTable(string value)
        {
            By by = By.XPath($"{Constants.PREFIX}li/span[{Constants.TRANSLATE}='sample date']/following::a[{Constants.TRANSLATE}='{value.ToLower()}']");
            if (_driver.FindElements(by).Count > 0)
                throw new Exception($"User was able to find the record {value}");
        }

        [Then(@"logout from assure")]
        public void ThenLogoutFromAssure()
        {
            string ByUser = $"{Constants.PREFIX}a[contains(@class, 'she-user-name')]";
            _driver.FindElement(By.XPath(ByUser)).Click();
            _driver.FindElement(By.XPath(ByUser + $"/following::a[{Constants.TRANSLATE}='log out']")).Click();
            _driver.Close();
        }






        [Given(@"I am on the assure login page")]
        public void GivenIAmOnTheAssureLoginPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://stirling.she-development.net/automation");
            Shared.WaitForElementVisibility(_driver, Constants.BYLOGINPAGE);
        }

        [When(@"I enter my login details and click enter")]
        public void WhenIEnterMyLoginDetails()
        {
            LoginPage.Login(_driver, Constants.USERNAME, Constants.PASSWORD);
        }


        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Shared.WaitForElementVisibility(_driver, Constants.BYHOMEPAGE);
        }

        public class StepData
        {
            public string param { get; set; }
            public string value { get; set; }
        }
    }
}
