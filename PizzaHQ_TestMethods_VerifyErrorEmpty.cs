using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQ_TestMethods
{
    [TestCategory("ErrorMessages")]
    [TestClass]
    public class PizzaHQ_TestMethods_VerifyErrorEmpty
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
            ContactForm contactForm = new(driver);
            Contact contact = new(driver);

            string name = "Dan", email = "dan@abc.com", message = "Nice Pizza";
            contactForm.ClickContact();

            //Stale element exception if the submit button is not loaded.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => contact.SubmitBtn.Displayed);

            contactForm.Submit();

            //Test name field error message
            Assert.AreEqual(expected: ErrorShownEnum.NAMEERROR_FALSE, 
                actual: contactForm.NameErrorCheck(name));

            //Test email field error message
            Assert.AreEqual(expected: ErrorShownEnum.EMAILERROR_FALSE, 
                actual: contactForm.EmailErrorCheck(email));

            //Test message field error message
            Assert.AreEqual(expected: ErrorShownEnum.MESSAGEERROR_FALSE, 
                actual: contactForm.MessageErrorCheck(message));
        }

        [TestCleanup]
        public void Clean()
        {
            driver.Quit();
        }
    }
}
