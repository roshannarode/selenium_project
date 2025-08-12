using OpenQA.Selenium;

namespace Mytra_Project
{
    public class Tests
    {   

        IWebDriver driver;

        [SetUp]
        
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}