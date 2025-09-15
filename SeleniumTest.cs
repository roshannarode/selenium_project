
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_project;
using Selenium_project.POM;
using Selenium_project.TestData;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


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


            foreach (var brand in brandNames())
            {
                Methods.brands(driver, brand.brandName);
            }

            
            bool result = Methods.isDisplayed(driver, By.XPath("//div[@data-cy='title-recipe']//h2[@aria-label='App Store Code']"));

            Assert.AreEqual(
                true, result, "Sum should be 10");



        }

        public static IEnumerable<BrandData> brandNames()
        {
            string jsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brands.json");
            string jsonString = File.ReadAllText(jsonfilepath);

            var Brands = JsonSerializer.Deserialize<List<BrandData>>(jsonString);

            return Brands;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}