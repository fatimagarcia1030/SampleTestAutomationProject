using OpenQA.Selenium;
using SampleTestAutomationProject.Extensions;
using SampleTestAutomationProject.PageModels;

namespace SampleTestAutomationProject.Actions
{
    public class HomePageActions
    {
        private static IWebDriver _driver;
        private static HomePage _homePage;
        private static SearchResultPage _searchResult;

        public HomePageActions(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _searchResult = new SearchResultPage(_driver);
        }

        public void NavigateToHomePage()
        {
            _driver.NavigateToHomePage();
            _driver.WaitUntilDocumentIsReady(60);
            _driver.WaitUntilVisible(_homePage.SearchBox, 30);
        }

        public void SearchForItem()
        {
            _homePage.SearchBox.SendKeys(TestConfig.Item);
            _homePage.SearchButton.Click();
            _driver.WaitUntilDocumentIsReady(60);
            _driver.WaitUntilVisible(_searchResult.SearchGrid, 30);
        }
    }
}
