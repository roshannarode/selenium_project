using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

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

            driver.Navigate().GoToUrl("https://www.amezon.com/");

            

            IWebElement Continue = driver.FindElement(By.ClassName("a-button-text"));

            Continue.Click();

            IWebElement searchText = driver.FindElement(By.Id("twotabsearchtextbox"));

            searchText.SendKeys("T Shirt");

             IWebElement search = driver.FindElement(By.Id("nav-search-submit-button"));
            search.Click(); 
            
            

        }
    }
}