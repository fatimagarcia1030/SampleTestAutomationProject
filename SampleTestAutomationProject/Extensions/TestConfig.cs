using System;
using System.Configuration;
using System.IO;

namespace SampleTestAutomationProject.Extensions
{
    public class TestConfig
    {
        private static string _homePage;
        private static string _item;
        private static string _banner;
        private static string _colour;
        private static string _size;
        private static string _quantity;
        private static string _totalAmount;
        private static string _webDriversPath;
        private static string _driver;

        public static string HomePage
        {
            get
            {
                _homePage = ConfigurationManager.AppSettings["HomePage"];
                return _homePage;
            }
        }

        public static string Item
        {
            get
            {
                _item = ConfigurationManager.AppSettings["Item"];
                return _item;
            }
        }

        public static string BannerText
        {
            get
            {
                _banner = ConfigurationManager.AppSettings["BannerTitle"];
                return _banner;
            }
        }

        public static string Colour
        {
            get
            {
                _colour = ConfigurationManager.AppSettings["Colour"];
                return _colour;
            }
        }

        public static string Size
        {
            get
            {
                _size = ConfigurationManager.AppSettings["Size"];
                return _size;
            }
        }

        public static string Quantity
        {
            get
            {
                _quantity = ConfigurationManager.AppSettings["Quantity"];
                return _quantity;
            }
        }

        public static string TotalAmount
        {
            get
            {
                _totalAmount = ConfigurationManager.AppSettings["TotalAmount"];
                return _totalAmount;
            }
        }

        public static string Driver
        {
            get
            {
                _driver = GetDriverType();
                return _driver;
            }
        }

        public static string WebDriversPath
        {
            get
            {
                _webDriversPath = GetWebDriversPath();
                return _webDriversPath;
            }
        }

        public static string GetDriverType()
        {
            string driver = "chrome";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Driver"]))
                driver = ConfigurationManager.AppSettings["Driver"];
            return driver;
        }

        public static string GetWebDriversPath()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WebDriversPath"]))
                return ConfigurationManager.AppSettings["WebDriversPath"];
            string baseDirectory = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.FullName;
            return Path.GetFullPath(string.Format("{0}\\..\\WebDrivers", baseDirectory));
        }
    }
}
