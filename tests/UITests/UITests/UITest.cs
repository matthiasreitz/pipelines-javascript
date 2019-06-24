using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITests
{
    [TestClass]
    public class UITest
    {
        public UITest()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("https://devcicdonazure.azurewebsites.net/");

            IWebElement anzeigeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            try
            {
                Assert.AreEqual(anzeigeText.Text, "Azure Pipelines");
            }
            finally
            {
                driver.Quit();
            }
        }   
    }
}
 