using Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages{
    class DemoGuru99Page:BasePage{
        public DemoGuru99Page(IWebDriver driver) : base(driver){
            this.GetWebDriver().Url = "http://demo.guru99.com/test/guru99home/";
        }

        private IWebElement LinkElement{
            get {
                return this.GetWebDriver().FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
            }
        }

        public IWebElement getLinkElement(){
            return this.LinkElement;
        }

        public GoogleHomePage goToGoogle(){
            return new GoogleHomePage(this.GetWebDriver());
        }

    }
}