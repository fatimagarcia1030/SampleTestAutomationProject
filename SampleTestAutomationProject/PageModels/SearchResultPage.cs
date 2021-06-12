using OpenQA.Selenium;

namespace SampleTestAutomationProject.PageModels
{
    public class SearchResultPage
    {
        private static IWebDriver Driver;
        private static IWebElement _elementName;

        public SearchResultPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement SearchGrid
        {
            get
            {
                _elementName = Driver.FindElement(By.Id("center_column"));
                return _elementName;
            }
        }

        public IWebElement FirstProductTile
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='center_column']/ul/li[1]/div/div[2]/div[1]/span[1]"));
                return _elementName;
            }
        }

        public IWebElement FirstProductImage
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='center_column']/ul/li[1]/div/div[2]/h5/a"));
                return _elementName;
            }
        }

        public IWebElement SortButton
        {
            get
            {
                _elementName = Driver.FindElement(By.Id("selectProductSort"));
                return _elementName;
            }
        }

        public IWebElement SortLowest
        {
            get 
            {
                _elementName = Driver.FindElement(By.XPath("//Option[@value='price:asc']"));
                return _elementName;
            }
        }
    }
}
