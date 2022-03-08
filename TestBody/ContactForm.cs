using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PizzaHQ_TestMethods
{
    internal class ContactForm
    {
        private readonly IWebDriver driver;
        public ContactForm(IWebDriver driver)
        {
            this.driver = driver;
        }

        Contact contact => new(driver);

        public IWebElement ContactBtn => driver.FindElement(By.CssSelector("[aria-label='contact"));       

        public void ClickContact()
        {
            ContactBtn.Click();
        }

        public void Submit()
        {
            contact.ClickSubmit();
        }

        public ErrorShownEnum NameErrorCheck(string name)
        {
            contact.SetName(name);

            return contact.GetNameError();
        }
        public ErrorShownEnum EmailErrorCheck(string email)
        {
            contact.SetEmail(email);

            return contact.GetEmailError(); 
        }
        public ErrorShownEnum MessageErrorCheck(string message)
        {
            contact.SetMessage(message);

            return contact.GetMessageError();
        }
    }
}