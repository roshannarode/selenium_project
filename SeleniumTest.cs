using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Network;
using OpenQA.Selenium.Support.UI;
using Selenium_project;
using Selenium_project.POM;


namespace Mytra_Project
{
    public class Tests
    {

        private IWebDriver driver = new ChromeDriver();

       

        [SetUp] 
        public void Setup()
        {

            

            driver.Navigate().GoToUrl("https://www.amazon.in");
            driver.Manage().Window.Maximize();

            if (Methods.isDisplayed(driver, By.XPath("//button[@type='submit']")))
            {
                IWebElement submitContinue = driver.FindElement(By.XPath("//button[@type='submit']"));
                submitContinue.Click();
            }
        }

        [Test]
        public void Search()
        { 
            
       
            SearchPage newpage = new SearchPage(driver);

            newpage.searchInput("mobiles");
            

            String [] brands = {"Apple","Samsung", "OnePlus"};


            foreach (String brand in brands)
            {
                Methods.brands(driver, brand);
            }

            
          
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }


    }
}