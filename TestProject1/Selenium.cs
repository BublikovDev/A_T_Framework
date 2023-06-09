using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace TestProject1
{
    [TestFixture]
    public class WebUITests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [AllureTag("SuccessLoginTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("SeleniumAuthentication")]
        [Test]
        public void SuccessLoginTest()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/signin");


            Task.Delay(5000).Wait();
            var usernameField = _driver.FindElement(By.Id("usernameSignIn"))!=null?null: _driver.FindElement(By.Id("usernameSignIn"));
            
            if(usernameField == null) {
                throw new Exception("username Field is not found");
            }
            var passwordField = _driver.FindElement(By.Id("passwordSignIn"));
            usernameField.SendKeys("DeveloperCreator");
            passwordField.SendKeys("123456TESTss");

            var loginButton = _driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            Task.Delay(5000).Wait();

            var url = _driver.Url;
            //Assert.AreEqual("https://localhost:7274/profile",url);
            Assert.AreEqual("https://localhost:7274/profile",url);
        }


        [AllureTag("UnSuccessLoginTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("SeleniumAuthentication")]
        [Test]
        public void UnSuccessLoginTest()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/signin");


            Task.Delay(5000).Wait();
            var usernameField = _driver.FindElement(By.Id("usernameSignIn"));
            var passwordField = _driver.FindElement(By.Id("passwordSignIn"));
            usernameField.SendKeys("DeveloperCreators");
            passwordField.SendKeys("123456TESTss");

            var loginButton = _driver.FindElement(By.Id("login-button"));
            loginButton.Click();

            Task.Delay(5000).Wait();

            var url = _driver.Url;
            Assert.AreNotEqual("https://localhost:7274/profile", url);
            Assert.AreEqual("https://localhost:7274/signin", url);
        }

        [AllureTag("CheckRedirectToSignInWhenNotAuthorized")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("SeleniumAuthentication")]
        [Test]
        public void CheckRedirectToSignInWhenNotAuthorized()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/profile");

            Task.Delay(5000).Wait();

            var url = _driver.Url;
            Assert.AreEqual("https://localhost:7274/signin", url);
        }

    }
}