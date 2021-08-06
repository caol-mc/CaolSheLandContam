using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CaolSheLandContam
{
    [Binding]
    class Shared
    {

        private ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public Shared(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }


        public static void WaitForElementVisibility(IWebDriver _driver, By by)
        {
            int attempts = 0;
            while (_driver.FindElements(by).Count == 0 && attempts < 5)
            {
                Thread.Sleep(2000);
                attempts++;
            }
            if (_driver.FindElements(by).Count == 0)
                throw new Exception($"User was not to find the element {by}");
        }



        public static void ClickOnButton(IWebDriver _driver, string button)
        {
            By by = By.XPath($"{Constants.PREFIX}button[{Constants.TRANSLATE}='{button.ToLower()}'][1]");
            if (_driver.FindElements(by).Count == 1)
                _driver.FindElement(by).Click();
            else
                _driver.FindElement(By.XPath($"{Constants.ITEMBOX}button[{Constants.TRANSLATEVALUE}='{button.ToLower()}'][1]")).Click();
        }

        public static void SendKeysToLabel(IWebDriver _driver, string label, string value)
        {
            string prefix = $"{Constants.PREFIX}label[contains({Constants.TRANSLATE},'{label.ToLower()}')]";
            if (_driver.FindElements(By.XPath(prefix + "/following-sibling::span/descendant::textarea[1]")).Count == 1)
                _driver.FindElement(By.XPath(prefix + "/following-sibling::span/descendant::textarea[1]")).SendKeys(value);
            else
                _driver.FindElement(By.XPath(prefix + "/following::input[1]")).SendKeys(value);
        }

        public static void ClickOnLink(IWebDriver _driver, string link)
        {
            _driver.FindElement(By.XPath($"{Constants.PREFIX}a[{Constants.TRANSLATE}='{link.ToLower()}' and not(ancestor::*[contains(@class, 'breadcrumb')]) and not(ancestor::li/a/following::li/a[{Constants.TRANSLATE}='{link.ToLower()}'])]")).Click();
        }

        public static void DeleteRecord(IWebDriver _driver, string record)
        {
            string ByRecord = $"{Constants.PREFIX}a[{Constants.TRANSLATE}='{record.ToLower()}']/following::button[contains(@class, 'dropdown')][1]";
            _driver.FindElement(By.XPath(ByRecord)).Click();
            _driver.FindElement(By.XPath(ByRecord + "/following::a[contains(@class, 'delete')][1]")).Click();
            ClickOnButton(_driver, "confirm");
        }

        public static void ClickOnModulesLink(IWebDriver _driver, string ModuleParent, string ModuleType)
        {
            ClickOnLink(_driver, "modules");
            ClickOnLink(_driver, ModuleParent);
            WaitForElementVisibility(_driver, By.XPath($"//h2[{Constants.TRANSLATE}= '{ModuleParent.ToLower()}']"));
            ClickOnLink(_driver, ModuleType);
        }


    }
}
