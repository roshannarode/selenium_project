using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_project.POM
{
    public class SearchPage
    {

        private readonly IWebDriver driver;

        private IWebElement searchBox => driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));

        private IWebElement searchbtn => driver.FindElement(By.Id("nav-search-submit-button"));

        public SearchPage(IWebDriver driver) {

            this.driver = driver;
        }

        public void searchInput (string text)
        {
            searchBox.SendKeys(text);
            searchbtn.Click();
        }




    }
}
