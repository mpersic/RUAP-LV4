using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", verificationErrors.ToString());
        }
        [Test]
        public void PrviTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/category&path=20_27");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/div/div/div[2]/div[2]/button/span")).Click();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=checkout/cart");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=checkout/checkout");
            Thread.Sleep(1000);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

