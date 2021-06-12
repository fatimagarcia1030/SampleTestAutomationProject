using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Drawing.Imaging;

namespace SampleTestAutomationProject.Extensions
{
    public static class WebDriverExtensions
    {
        public static void NavigateToHomePage(this IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(TestConfig.HomePage);
            WaitUntilDocumentIsReady(webDriver, 60);
            webDriver.Manage().Window.Maximize();
        }

        public static void WaitUntilDocumentIsReady(this IWebDriver webDriver, int waitTime)
        {
            IWait<IWebDriver> _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTime));
            _wait.Until(driver1 => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(waitTime);
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            var _element = element;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", _element);
        }

        public static IWebElement WaitUntilVisible(this IWebDriver webDriver, IWebElement waitElement, int waitTime)
        {

            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, waitTime));
            var element = wait.Until<IWebElement>(wbd =>
            {
                try
                {
                    var elementToBeDisplayed = waitElement;
                    if (elementToBeDisplayed.Displayed)
                    {
                        return elementToBeDisplayed;
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
            return element;
        }

        public static void MouseHover(this IWebDriver driver, IWebElement element)
        {
            TouchActions actions = new TouchActions(driver);
            actions.MoveToElement(element);
        }

        public static void TakeScreenshot(this IWebDriver driver)
        {
            string baseDirectory = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.FullName;
            string folderPath = Path.GetFullPath(string.Format("{0}\\..\\Screenshots", baseDirectory));

            string fileName = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") + ".jpeg";
            string fullPath = Path.Combine(folderPath, fileName);

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);
        }

    }
}
