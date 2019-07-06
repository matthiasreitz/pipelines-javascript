using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITests
{
    [TestClass]
    public class UITest
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public UITest()
        {
        }

        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void TestMethod1()
        {
            string city = "Essen";
            driver.Navigate().GoToUrl("https://devcicdonazure.azurewebsites.net/");

            IWebElement setCity = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/fieldset/form/input[1]")));
            setCity.SendKeys(city);
            setCity.SendKeys(Keys.Enter);

            IWebElement weatherCity = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/fieldset/p")));
            
            string responseCity = weatherCity.Text.Split(' ').Last();

            //anzeigeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            try
            {
                System.Threading.Thread.Sleep(5000);
                Assert.AreEqual(city, weatherCity);
            }
            catch (AssertFailedException exception)
            {
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string city = "Duisburg";
            driver.Navigate().GoToUrl("https://devcicdonazure.azurewebsites.net/");

            IWebElement setCity = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/fieldset/form/input[1]")));
            setCity.SendKeys(city);
            setCity.SendKeys(Keys.Enter);

            IWebElement weatherCity = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/fieldset/p")));

            string responseCity = weatherCity.Text.Split(' ').Last();

            //anzeigeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            try
            {
                System.Threading.Thread.Sleep(5000);
                Assert.AreEqual(city, weatherCity);
            }
            catch (AssertFailedException exception)
            {
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
