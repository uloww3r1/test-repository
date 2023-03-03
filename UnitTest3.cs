using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace csharp_example
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("[type=submit]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Dashboard | My Store"));
            driver.FindElement(By.CssSelector("[title=Appearance]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Template | My Store"));
            // driver.FindElement(By.CssSelector("span")).Click();
            driver.FindElement(By.CssSelector("[data-id=favicon]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Favicon | My Store"));
            driver.FindElement(By.CssSelector("[data-id=logotype]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Logotype | My Store"));
            driver.FindElement(By.CssSelector("[data-id=edit styling]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Edit Styling | My Store"));
            Thread.Sleep(1000);
            
        }
        
        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        } 
    } 
} 