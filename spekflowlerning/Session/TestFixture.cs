
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace spekflowlerning.Session
{
     [SetUpFixture]
    public class TestFixture
    {
        [SetUp]
        public  void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var option = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            BrowserSessionFixture.WebDriver = new FirefoxDriver(option);
        }
    }
}
