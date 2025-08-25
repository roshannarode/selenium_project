using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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



            IWebElement searchText = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchText.SendKeys("mobile phones");

            IWebElement search = driver.FindElement(By.Id("nav-search-submit-button"));
            search.Click();

            IWebElement seeMore = driver.FindElement(By.XPath("//div[@id='brandsRefinements']//span[@class='a-expander-prompt']"));
            seeMore.Click();

             IList <IWebElement> brands = driver.FindElements(By.XPath("//div[@id='brandsRefinements']//span[@class='a-size-base a-color-base']"));
             Console.WriteLine(brands.Count);

            List<String> brandNames = new List<String>();
            foreach (IWebElement brand in brands)
            {
                string brandName = brand.Text; // or "name"
                brandNames.Add(brandName);
            }

            foreach (String outputText in brandNames)
            {
                Console.WriteLine(outputText);
            }


            driver.Quit();

        }
    }
}