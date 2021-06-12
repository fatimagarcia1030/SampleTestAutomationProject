using OpenQA.Selenium;

namespace SampleTestAutomationProject.PageModels
{
    public class OrderPage
    {
        private static IWebDriver Driver;
        private static IWebElement _elementName;

        public OrderPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement AddQuantity
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//form[@id='buy_block']//div[1]/div[2]/p[1]/a[2]/span"));
                return _elementName;
            }
        }

        public IWebElement Size
        {
            get 
            {
                _elementName = Driver.FindElement(By.XPath("//select[@name='group_1']"));
                return _elementName;
            }
        }

        public IWebElement Medium
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//select[@name='group_1']//option[@value='2']"));
                return _elementName;
            }
        }

        public IWebElement Green
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='attributes']/fieldset[2]/div/ul/li[1]/a"));
                return _elementName;
            }
        }

        public IWebElement AddToCart
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//button[@name='Submit']"));
                return _elementName;
            }
        }

        public IWebElement AddedToCartBanner
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='layer_cart']//div[@class='clearfix']/div[1]/h2"));
                return _elementName;
            }
        }

        public IWebElement OrderSizeColor
        {
            get 
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='layer_cart']//div[@class='clearfix']/div[1]/div[2]/span[2]"));
                return _elementName;
            }
        }

        public IWebElement OrderQuantity
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='layer_cart']//div[@class='clearfix']/div[1]/div[2]/div[1]/span"));
                return _elementName;
            }
        }

        public IWebElement TotalAmount
        {
            get
            {
                _elementName = Driver.FindElement(By.XPath("//div[@id='layer_cart']//div[@class='clearfix']/div[2]/div[3]/span"));
                return _elementName;
            }
        }
    }
}
