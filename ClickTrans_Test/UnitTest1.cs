using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ClickTrans_Test
{
    [TestClass]
    public class Testing
    {
        private IWebDriver _driver;
        private static string url = "https://dev-1.clicktrans.pl/register-test/courier";
        
        [TestInitialize]
        public void init()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(url);
        }
        [TestMethod]
        public void Check_RegistrationForm()
        {
            _driver.FindElement(By.Id("user_register_company_name")).SendKeys("ClickTrans Industries");
            _driver.FindElement(By.Id("user_register_email")).SendKeys("jan.kowalski@o2.pl");
            _driver.FindElement(By.Id("user_register_name")).SendKeys("Jan Kowalski");
            _driver.FindElement(By.Id("user_register_phone")).SendKeys("600100300");
            _driver.FindElement(By.Id("user_register_plainPassword")).SendKeys("panjan12");
            _driver.FindElement(By.Id("user_register_settings_agreementRegulations")).Click();
            _driver.FindElement(By.Id("user_register_settings_agreementPersonalData")).Click();
            _driver.FindElement(By.Id("user_register_submit")).Click();

            var success = _driver.FindElement(By.CssSelector(".ui.success.message")).Displayed;
            Assert.IsTrue(success);
        }

        [TestCleanup]
        public void cleanUp()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}