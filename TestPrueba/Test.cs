using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Pages;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using Test.TestDataAccess;

namespace TestPrueba
{
    class Test
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:/Users/juan.legorburu/Downloads");
            // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:/Users/juan.legorburu/Downloads");
            // service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            // driver = new FirefoxDriver(service);
        }

        [TestCase("Hola")]
        [TestCase("Manola")]
        public void test(string search)
        {
            GoogleHomePage gHome = new GoogleHomePage(driver);
            gHome.MaximizeWindow();
            gHome.getSearchTextBox().SendKeys(search);
        }

        [Test]
        public void cssDemo()
        {
            DemoGuru99Page demoGuru99 = new DemoGuru99Page(driver);
            demoGuru99.MaximizeWindow();
            demoGuru99.getLinkElement().Click();
        }

        [Test]
        public void cssDemoandGoogle()
        {
            DemoGuru99Page demoGuru99 = new DemoGuru99Page(driver);
            demoGuru99.MaximizeWindow();
            demoGuru99.getLinkElement().Click();
            GoogleHomePage gHome = demoGuru99.goToGoogle();
            gHome.getSearchTextBox().SendKeys("Sarasa");

        }

        [Test]
        public void googleSearch()
        {
            GoogleHomePage gHome = new GoogleHomePage(driver);
            gHome.MaximizeWindow();
            gHome.getSearchTextBox().SendKeys("Hola");
            
            GoogleResultPage gSearch = gHome.search();
            gSearch.getFirstResult().Text.ToLower().Should().Contain("Hola".ToLower());

        }

        [TestCase("Test001")]
        [TestCase("Test002")]
        [TestCase("Test003")]
        [TestCase("Test004")]
        [TestCase("Test005")]
        public void googleSearchUsingData(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);   
            GoogleHomePage gHome = new GoogleHomePage(driver);
            gHome.MaximizeWindow();
            gHome.getSearchTextBox().SendKeys(userData.Sarasa);

            GoogleResultPage gSearch = gHome.search();
            gSearch.getFirstResult().Text.ToLower().Should().Contain(userData.Sarasa.ToLower());

        }

        [TestCase("Test001")]
        [TestCase("Test002")]
        [TestCase("Test003")]
        [TestCase("Test004")]
        [TestCase("Test005")]
        public void GoogleSearchUsingData2(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName, "TestDataSheetPath2");
            GoogleHomePage gHome = new GoogleHomePage(driver);
            gHome.MaximizeWindow();
            gHome.getSearchTextBox().SendKeys(userData.Sarasa);

            GoogleResultPage gSearch = gHome.search();
            gSearch.getFirstResult().Text.ToLower().Should().Contain(userData.Sarasa.ToLower());

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }

    }
}