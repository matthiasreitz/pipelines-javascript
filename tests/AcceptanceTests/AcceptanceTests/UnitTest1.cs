﻿using System;
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
            driver.Navigate().GoToUrl("https://devcicdonazure.azurewebsites.net/");

            IWebElement anzeigeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            try
            {
                System.Threading.Thread.Sleep(5000);
                Assert.AreEqual(anzeigeText.Text, "Azure Pipelines");
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
            driver.Navigate().GoToUrl("https://devcicdonazure.azurewebsites.net/");

            IWebElement anzeigeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            try
            {
                System.Threading.Thread.Sleep(5000);
                Assert.AreEqual(anzeigeText.Text, "Azure Pipelines");
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
