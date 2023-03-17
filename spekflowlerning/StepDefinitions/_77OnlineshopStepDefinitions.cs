using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using spekflowlerning.Model.Pages;
using System;
using spekflowlerning.Session;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist.ValueRetrievers;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace spekflowlerning.StepDefinitions
{
  
    [Binding]
    public class _77OnlineshopStepDefinitions

    {
          Online_77 online_77= new Online_77();


    
      
        [When(@"click the WebSite URl")]
        public void WhenClickTheWebSiteURl()
        {
            online_77.OpenHomePage();
            Thread.Sleep(5000);
        }
       
        [Then(@"Homepage should load")]
        public void ThenHomepageShouldLoad()
        {
            BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("#logo > a:nth-child(1)")).Displayed.Equals(true);    
        }

        
        [Given(@"home page is open")]
        public void GivenHomePageIsOpen()
        {
            online_77.OpenHomePage();
            Thread.Sleep(5000);
        }
       
        [When(@"click on the `Kinder` from the meneu")]
   
        public void WhenClickOnTheKinderFromTheMeneu()
        {
           
            online_77.OpenKidsPage();
            Thread.Sleep(5000);
        }
        
        [Then(@"the kids page should open")]
        public void ThenTheKidsPageShouldOpen( )
        {
            BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("h1.headline")).Displayed.Equals(true);
        }

        
        [When(@"click the login icon")]
        public void WhenClickTheLoginIcon()
        {
            online_77.OpenLoginPage();
            Thread.Sleep(5000);
        }
        
        [Then(@"login page is opend")]
        public void ThenLoginPageIsOpend()
        {
           Assert.IsTrue(BrowserSessionFixture.WebDriver.FindElement(By.ClassName("col-xs-12")).Displayed);
        }

      
        [When(@"the radio button of neukunde clicked")]
        public void WhenTheRadioButtonOfNeukundeClicked()
        {
            BrowserSessionFixture.WebDriver.FindElement
                (By.XPath("/html/body/div[3]/div/div[4]/main/div[2]/form/div[2]/div[1]/div[1]/div/div[2]/div[1]/div/div[2]/label/input")).Click(); // if many elements have the same name, Index can be used. 
            Thread.Sleep(8000);
        }
        
        [Then(@"i can see textboxes of sing up")]
        public void ThenICanSeeTextboxesOfSingUp()
        {
            Assert.IsTrue(BrowserSessionFixture.WebDriver.FindElement(By.Name("ws_clogin_input_email")).Displayed);
        }
        
        [When(@"click button of anmelden")]
        public void WhenClickButtonOfAnmelden()
        {
            BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("input.btn:nth-child(2)")).Click();

        }
        
        [Then(@"warning message should occurs")]
        public void ThenWarningMessageShouldOccurs()
        {
            Assert.IsTrue(BrowserSessionFixture.WebDriver.FindElement(By.CssSelector("div.alert:nth-child(2)")).Displayed); // I want here compare the text of message
        }

        
        [When(@"click the login radio button")]
        public void WhenClickTheLoginRadioButton()
        {
            BrowserSessionFixture.WebDriver.FindElements(By.Name("user-type"))[0].Click();
            Thread.Sleep(3000);
        }
        
        [Then(@"write correct email adress in email feld")]
        public void ThenWriteCorrectEmailAdressInEmailFeld()
        {
            BrowserSessionFixture.WebDriver.FindElement(By.Name("ws_clogin_input_email")).SendKeys("test@hotmail.com");
            Thread.Sleep(8000);
        }


    }
}
