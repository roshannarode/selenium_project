using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_project.POM
{
    public class filter_By_price
    {
        private readonly IWebDriver driver;
        IWebElement slider => driver.FindElement(By.XPath("//div[@class='a-section s-range-input-container s-upper-bound']"));


        public filter_By_price(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void filter_click()
        {
            

            Actions action = new Actions(driver);

            // Move slider 100 pixels to the right
            action.ClickAndHold(slider).MoveByOffset(100, 0).Release().Perform();

        }
    }
}
