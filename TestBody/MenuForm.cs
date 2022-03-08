using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PizzaHQ_TestMethods
{
    internal class MenuForm
    {
        private readonly IWebDriver driver;
        public MenuForm(IWebDriver driver)
        {
            this.driver = driver;
        }

        Menu menu => new(driver);

        public IWebElement MenuBtn => driver.FindElement(By.CssSelector("[aria-label='menu"));

        public void ClickMenu()
        {
            MenuBtn.Click();
        }

        public PriceErrorEnum VerifyVeganPrices()
        {
            return menu.VerifyPrices();
        }
    }
}
