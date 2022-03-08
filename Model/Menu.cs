using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace PizzaHQ_TestMethods
{
    internal class Menu
    {
        private readonly IWebDriver driver;
        public Menu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> VeganPizzaCards => driver.FindElements(By.ClassName(".flexcard.vegan"));
        public IWebElement Price;

        internal PriceErrorEnum VerifyPrices()
        {
            foreach(var pizzacard in VeganPizzaCards)
            {
                Price = pizzacard.FindElement(By.ClassName("price"));
                //Console.WriteLine($"Price: {Price.Text}");

                if(Price.Text != "$14.99")
                {
                    return PriceErrorEnum.PRICEVALID_FALSE;
                }
            }
            return PriceErrorEnum.PRICEVALID_TRUE;
        }
    }
}