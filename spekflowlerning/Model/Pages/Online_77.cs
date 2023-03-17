using OpenQA.Selenium;
using spekflowlerning.Session;

namespace spekflowlerning.Model.Pages
{
    public sealed class Online_77
    {
        public void OpenHomePage()
        {
            BrowserSessionFixture.WebDriver.Navigate().GoToUrl("https://www.77onlineshop.de/");
            if (BrowserSessionFixture.WebDriver
                .FindElement(By.CssSelector("#cookieOverview > div > div:nth-child(2) > label")).Displayed)
            {
                BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("#cookieOverview > div > div:nth-child(2) > label")).Click();
            }
        }

       public void OpenKidsPage()
        {
            BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("#nav > li:nth-child(7) > a")).Click();
        }

        public IWebElement KidsPage => BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("#nav > li:nth-child(7) > a:nth-child(1)"));
        

        public void OpenLoginPage()
        {
            BrowserSessionFixture.WebDriver.FindElement(By.CssSelector(".loginText")).Click();
        }
    }
}
