using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQ_TestMethods
{
    [TestCategory("VeganPizzaPrice")]
    [TestClass]
    public class PizzaHQ_TestMethods_VerifyVeganPizzaPrices
    {
        ChromeDriver driver = new ChromeDriver();

        
        [TestInitialize]
        public void Init()
        {
            driver.Url = "https://d2ju5vf8ca0qio.cloudfront.net/#/";
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TestMethod]
        public void TestErrorMessages()
        {
            MenuForm menuForm = new(driver);
            Menu menu = new(driver);

            menuForm.ClickMenu();

            /*
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => menu.VeganPizzaCards.isEnabled);
            */

            //Tests pass, but could not get them to fail.
            Assert.AreEqual(expected: PriceErrorEnum.PRICEVALID_TRUE, actual: menuForm.VerifyVeganPrices());
        }

        [TestCleanup]
        public void Clean()
        {
            driver.Quit();
        }
    }
}
