using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTestAutomationProject.Extensions;
using SampleTestAutomationProject.PageModels;
using System;

namespace SampleTestAutomationProject.Actions
{
    public class SearchPageActions
    {
        private static IWebDriver _driver;
        private static SearchResultPage _searchResult;
        private decimal _initialPrice;
        private decimal _sortPrice;
        

        public SearchPageActions(IWebDriver driver)
        {
            _driver = driver;
            _searchResult = new SearchResultPage(_driver);
        }

        public void SortByLowest()
        {
            _initialPrice = GetPrice(_searchResult.FirstProductTile);
            _searchResult.SortButton.Click();
            _searchResult.SortLowest.Click();
            _sortPrice = GetPrice(_searchResult.FirstProductTile);
            Assert.IsTrue(_initialPrice >= _sortPrice);
        }

        public void ClickOnTheLowestItem()
        {
            _driver.ScrollTo(_searchResult.FirstProductTile);
            _searchResult.FirstProductImage.Click();
            _driver.WaitUntilDocumentIsReady(60);
        }

        private decimal GetPrice(IWebElement _element)
        {
            decimal _price;
            _price = Convert.ToDecimal((_element.Text as string).Trim('$'));
            return _price;
        }
    }
}
