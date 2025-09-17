using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using Selenium_project.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Selenium_project.POM
{
    public class filter_By_Brands
    {
        private readonly IWebDriver driver;

        private IWebElement seemore => driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']"));

        private IList<IWebElement> brands => driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));

        public filter_By_Brands(IWebDriver driver) { 
            
            this.driver = driver;
       
        }
        public void seeMore()
        {
            seemore.Click();
        }

        public void selectBrand() {

           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            foreach (var brand in userList())
            {
               

                seeMore();

                foreach (IWebElement brandName in brands)
                {
                    if (brandName.Text == brand.brandName)
                    {
                        brandName.Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']")));
                        break;
                    }

                }

            }
            

        }

        public static IEnumerable<BrandData> userList()
        {
            string jsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brands.json");
            string jsonString = File.ReadAllText(jsonfilepath);

            var mobilebrands = JsonSerializer.Deserialize<List<BrandData>>(jsonString);

            return mobilebrands;
            
               
        }
    }
}
