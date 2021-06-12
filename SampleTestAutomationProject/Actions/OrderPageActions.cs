using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTestAutomationProject.Extensions;
using SampleTestAutomationProject.PageModels;
using System;

namespace SampleTestAutomationProject.Actions
{
    public class OrderPageActions
    {
        private static IWebDriver _driver;
        private static OrderPage _orderPage;
        private decimal _initialPrice;
        private decimal _sortPrice;
        

        public OrderPageActions(IWebDriver driver)
        {
            _driver = driver;
            _orderPage = new OrderPage(_driver);
        }

        public void ChangeOrder()
        {
            _driver.WaitUntilVisible(_orderPage.AddQuantity, 30);
            _orderPage.AddQuantity.Click();
            _orderPage.Size.Click();
            _driver.WaitUntilVisible(_orderPage.Medium, 30);
            _orderPage.Medium.Click();
            _orderPage.Green.Click();
        }

        public void AddToCart()
        {
            _orderPage.AddToCart.Click();
            _driver.WaitUntilVisible(_orderPage.AddedToCartBanner, 30);
            Assert.IsTrue(_orderPage.AddedToCartBanner.Text.Contains(TestConfig.BannerText));
        }

        public void CheckOrder()
        {
            Assert.IsTrue(_orderPage.OrderSizeColor.Text.Contains(TestConfig.Colour+", "+TestConfig.Size));
            Assert.IsTrue(_orderPage.OrderQuantity.Text.Contains(TestConfig.Quantity));
            Assert.IsTrue(_orderPage.TotalAmount.Text.Contains(TestConfig.TotalAmount));
        }
    }
}
