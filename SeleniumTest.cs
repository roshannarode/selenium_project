
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10) ;

            driver.Navigate().GoToUrl("https://www.amazon.in");
            driver.Manage().Window.Maximize();

            if (Methods.isDisplayed(driver, By.XPath("//button[@type='submit']")))
            {
                IWebElement submitContinue = driver.FindElement(By.XPath("//button[@type='submit']"));
                submitContinue.Click();
            }
        }


        [Test]
        public void SearchMobiles()
        { 
 
            SearchPage newpage = new SearchPage(driver);

            string filename = "brands.json"; 
            newpage.searchInput("mobiles");
            filter_By_Brands findProduct = new filter_By_Brands(driver , filename);
            findProduct.selectBrand();


        }

        [Test]
        public void SearchTv()
        {
            
            SearchPage search = new SearchPage(driver);

            string filename = "TvBrands.json";
            search.searchInput("Tv");
            filter_By_Brands findProduct = new filter_By_Brands(driver, filename);
            findProduct.selectBrand();


        }

        

        public void TearDown()
        {
            driver.Quit();
        }
    }
}