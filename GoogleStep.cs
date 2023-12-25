using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MsTestProject
{
    [Binding]
    internal class GoogleStep
    {
        IWebDriver driver;

        [Given(@"I am on the google page")]
        [Given(@"I am on the Google search engine")]
        public void GivenIAmOnTheGooglePage()
        {
            TrxHelper.TrxToXml();
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
        }

        [Then(@"I can see the google title")]
        public void ThenICanSeeTheGoogleTitle()
        {
            driver.Quit();
        }


        [When(@"I enter SpecFlow in the search box")]
        public void WhenIEnterSpecFlowInTheSearchBox()
        {
            driver.FindElement(By.Name("q")).SendKeys("Specflow");
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            //throw new PendingStepException();
        }

        [Then(@"I should see search results related to SpecFlow")]
        public void ThenIShouldSeeSearchResultsRelatedToSpecFlow()
        {
            //throw new PendingStepException();
        }

        [Given(@"I have entered Admin and admin(.*)")]
        public void GivenIHaveEnteredAdminAndAdmin(int p0)
        {
            driver.Url = "https://support.orangehrm.com/portal/en/signin";
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            //throw new PendingStepException();
        }

        [Then(@"I should see the homepage")]
        public void ThenIShouldSeeTheHomepage()
        {
            //throw new PendingStepException();
        }
    }
}
