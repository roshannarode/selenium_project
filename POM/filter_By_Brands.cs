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
        private string datafile;

        private IWebElement seemore
        {
            set { driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']")); }

            get {return driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']")); }
        }

        private IList<IWebElement> brands => driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));

        public filter_By_Brands(IWebDriver driver , string datafile) { 
            
            this.driver = driver;
            this.datafile = datafile;
       
        }
        public void seeMore()
        {
            
            seemore.Click();
        }

        public void selectBrand() {


            //Wait Logic
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(4),
                PollingInterval = TimeSpan.FromMilliseconds(500)

            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));


            
            foreach (var brand in UserList(datafile))
            {

                fluentWait.Until(driver => Methods.isDisplayed(driver, seemore));
                seeMore();

                foreach (IWebElement brandName in brands)
                {
                    if (brandName.Text == brand.brandName)
                    {
                        brandName.Click();
                        fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']")));
                        //fluentWait.Until(driver => Methods.isDisplayed(driver, seemore));
                        break;
                    }

                }

            }
            

        }

        public static IEnumerable<BrandData> UserList(string datafile)
        {
            try
            {
                string jsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, datafile);
                string jsonString = File.ReadAllText(jsonfilepath);

                var mobilebrands = JsonSerializer.Deserialize<List<BrandData>>(jsonString);

                return mobilebrands;
            }
            catch (Exception ex) {


                TestContext.WriteLine("Error: " + ex.Message);
                TestContext.WriteLine("Stack Trace: " + ex.StackTrace);
                Assert.Fail("Test failed due to exception: Could not find file " + datafile);
                return Enumerable.Empty<BrandData>();

            }
               
        }
    }
}
