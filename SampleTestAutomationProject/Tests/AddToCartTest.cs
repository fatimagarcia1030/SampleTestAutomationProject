using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleTestAutomationProject.Extensions;
using SampleTestAutomationProject.Actions;

namespace SampleTestAutomationProject.Tests
{
    /// <summary>
    /// Summary description for AddToCartTest
    /// </summary>
    [TestClass]
    public class AddToCartTest
    {
        private IWebDriver _driver;
        private HomePageActions _homePageActions;
        private SearchPageActions _searchPageActions;
        private OrderPageActions _orderPagesActions;


        [TestInitialize]
        public void RunBeforeScenario()
        {
            _driver = WebDriverManager.Current.GetDefaultWebDriver();
            _homePageActions = new HomePageActions(_driver);
            _searchPageActions = new SearchPageActions(_driver);
            _orderPagesActions = new OrderPageActions(_driver);
        }

        [TestCleanup]
        public void RunAfterScenario()
        {
            _driver.Close();
            _driver.Quit();
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddItemToCart()
        {
            _homePageActions.NavigateToHomePage();
            _homePageActions.SearchForItem();
            _searchPageActions.SortByLowest();
            _searchPageActions.ClickOnTheLowestItem();
            _orderPagesActions.ChangeOrder();
            _orderPagesActions.AddToCart();
            _orderPagesActions.CheckOrder();
            _driver.TakeScreenshot();
            
        }
    }
}
