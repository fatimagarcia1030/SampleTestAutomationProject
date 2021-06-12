using OpenQA.Selenium;

namespace SampleTestAutomationProject.PageModels
{
    public class HomePage
    {
        private static IWebDriver Driver;
        private static IWebElement _elementName;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchBox
        {
            get
            {
                _elementName = Driver.FindElement(By.Id("search_query_top"));
                return _elementName;
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                _elementName = Driver.FindElement(By.Name("submit_search"));
                return _elementName;
            }
        }
    }
}
