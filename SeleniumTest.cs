using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Network;
using OpenQA.Selenium.Support.UI;


namespace Mytra_Project
{
    public class Tests
    {   

      

        [SetUp]
        
        public void Setup()
        {
        }

        [Test]
        public void Amezon()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.amazon.in");
            driver.Manage().Window.Maximize();

            
            IWebElement submitContinue = driver.FindElement(By.XPath("//button[@type='submit']"));

            if (submitContinue.Displayed)
            {
                submitContinue.Click();
            }

            IWebElement searchText = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchText.SendKeys("mobile phones");

            IWebElement search = driver.FindElement(By.Id("nav-search-submit-button"));
            search.Click();

            IWebElement seeMore = driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']"));
            seeMore.Click();

             IList <IWebElement> brands = driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));
             Console.WriteLine(brands.Count);

            foreach (IWebElement brand in brands)
            {
                string brandName = brand.Text; // or "name"

                if (brand.Text == "Apple" )
                {
                    brand.Click();
                   
                }

            }

            IWebElement seeMore1 = driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']"));
            seeMore1.Click();

            IList<IWebElement> brands1 = driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));
            Console.WriteLine(brands1.Count);

            foreach (IWebElement brand1 in brands1)
            {
           
                if (brand1.Text == "Samsung")
                {
                    brand1.Click();
                    break;
                }


            }

          /*  foreach (String outputText in brandNames)
            {
                Console.WriteLine(outputText);
            }
          */

            driver.Quit();

        }
    }
}