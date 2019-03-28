using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Conditions
{
    static class ExpectedConditions
    {
        public static IWebElement ElementIsEnabled(IWebDriver driver, By by)
        {
            var ele = driver.FindElement(by);
            return ele.Displayed ? ele : null;
        }

        public static IWebElement ElementIsClickable(IWebDriver driver, By by)
        {
            var ele = driver.FindElement(by);
            return ele.Enabled ? ele : null;
        }
    }
}
