using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace PizzaHQ_TestMethods
{
    internal class Contact
    {
        private readonly IWebDriver driver;
        public Contact(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Forename => driver.FindElement(By.Id("forename"));
        public IWebElement ForenameErr;

        public IWebElement Email => driver.FindElement(By.Id("email"));
        public IWebElement EmailErr;

        public IWebElement Message => driver.FindElement(By.Id("message"));
        public IWebElement MessageErr;

        public IWebElement SubmitBtn => GetSubmit();
        ReadOnlyCollection<IWebElement> ButtonSpans => driver.FindElements(By.CssSelector("span.v-btn__content"));

        internal IWebElement GetSubmit()
        {
            foreach (var buttonspan in ButtonSpans)
            {
                if(buttonspan.Text.ToUpper() == "SUBMIT".ToUpper())
                {
                    return buttonspan;
                }
            }

            throw new NotFoundException("Submit button not found.");
        }

        internal void ClickSubmit()
        {
            //GetSubmit();
            SubmitBtn.Click();
        }

        internal void SetName(string name)
        {
            Forename.Click();
            Forename.SendKeys(name);
        }

        internal void SetEmail(string email)
        {
            Email.Click();
            Email.SendKeys(email);
        }

        internal void SetMessage(string message)
        {
            Message.Click();
            Message.SendKeys(message);
        }

        internal ErrorShownEnum GetNameError()
        {
            try
            {
                ForenameErr = driver.FindElement(By.Id("forename-err"));
                return ErrorShownEnum.NAMEERROR_TRUE;
            }
            catch
            {
                return ErrorShownEnum.NAMEERROR_FALSE;
            }
        }
        internal ErrorShownEnum GetEmailError()
        {
            try
            {
                ForenameErr = driver.FindElement(By.Id("email-err"));
                return ErrorShownEnum.EMAILERROR_TRUE;
            }
            catch
            {
                return ErrorShownEnum.EMAILERROR_FALSE;
            }
        }
        internal ErrorShownEnum GetMessageError()
        {
            try
            {
                ForenameErr = driver.FindElement(By.Id("message-err"));
                return ErrorShownEnum.MESSAGEERROR_TRUE;
            }
            catch
            {
                return ErrorShownEnum.MESSAGEERROR_FALSE;
            }
        }
    }
}