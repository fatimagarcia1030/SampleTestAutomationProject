using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SampleTestAutomationProject.Extensions
{
    public class WebDriverManager
    {
        public static WebDriverManager _webDriverManager;
        private IWebDriver _currentWebDriver;

        public static WebDriverManager Current
        {
            get
            {
                _webDriverManager = new WebDriverManager();
                return _webDriverManager;
            }
        }

        private WebDriverManager() { }

        public IWebDriver CurrentWebDriver
        {
            get
            {
                _currentWebDriver = GetDefaultWebDriver();
                return _currentWebDriver;
            }
        }

        public IWebDriver GetDefaultWebDriver()
        {
            switch (TestConfig.Driver.ToLower())
            {
                case "chrome":
                    return new ChromeDriver(TestConfig.WebDriversPath);
                case "firefox":
                    return new FirefoxDriver();
                case "ie":
                    return new InternetExplorerDriver();
                default:
                    return new ChromeDriver(TestConfig.WebDriversPath);

            }

        }
    }
}
