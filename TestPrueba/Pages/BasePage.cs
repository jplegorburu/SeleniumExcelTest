using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver GetWebDriver()
        {
            return this.driver;
        }

        public WebDriverWait GetWebDriverWait()
        {
            return this.wait;
        }

        public void MaximizeWindow()
        {
            this.driver.Manage().Window.Maximize();
        }
    }
}