using Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pages{
    class GoogleHomePage:BasePage{
        public GoogleHomePage(IWebDriver driver) : base(driver){
            this.GetWebDriver().Url = "http://www.google.com";
        }

        private IWebElement SearchTextBox{
            get {
                return this.GetWebDriverWait().Until(d => d.FindElement(By.Name("q")));
            }
        }

        private IWebElement SearchButton{
            get {
                return this.GetWebDriverWait().Until(d => {
                    var ele = d.FindElement(By.Name("btnK"));
                    return ele.Displayed ? ele : null;
                });
            }
        }

        public IWebElement getSearchTextBox(){
            return this.SearchTextBox;
        }

        public IWebElement getSearchButton(){
            return this.SearchButton;
        }

        public GoogleResultPage search(){
            this.getSearchButton().Click();
            return new GoogleResultPage(this.GetWebDriver());
        }
    }

    class GoogleResultPage:BasePage{
        public GoogleResultPage(IWebDriver driver) : base(driver){
        }

        private ReadOnlyCollection<IWebElement> GetResults{
            get {
                this.GetWebDriverWait().Until(d => d.FindElement(By.ClassName("LC20lb")));
                return this.GetWebDriver().FindElements(By.ClassName("LC20lb"));
            }
        }
        
        public IWebElement getFirstResult(){
            return this.GetResults[0];
        }
    }
}