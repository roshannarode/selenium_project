using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_project
{
    internal class Methods
    {
        public static bool isDisplayed(IWebDriver driver , By locator) 
        {
            bool isVisible;

            try
            {
                isVisible = driver.FindElement(locator).Displayed;
            }
            catch (Exception){ 
                
                isVisible = false;
            
            }

            if (isVisible)
            {
                return true;
            }
             return false;
        }

        public static void seeMore(IWebDriver driver, By locator)
        {

            IWebElement element = driver.FindElement(locator);
            element.Click();
        }

        public static void brands (IWebDriver driver, String brandName)
        { 
            seeMore(driver, By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']"));

            IList<IWebElement> brands = driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));

            foreach (IWebElement brand in brands)
            {
                if (brand.Text == brandName)
                {
                    brand.Click();
                    break;
                }

            }
        }

    }
}
