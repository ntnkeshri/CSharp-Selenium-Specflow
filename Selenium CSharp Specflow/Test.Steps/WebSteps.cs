using FirstAutomatedTestsProject.Test.Common;
using FirstAutomatedTestsProject.Tests.Tenants.YouTube.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FirstAutomatedTestsProject.Test.Steps
{
    [Binding]
    public class WebSteps
    {
        [Given(@"I start the (.*) browser")]
        [When(@"I start the (.*) browser")]
        [Then(@"I start the (.*) browser")]
        public static void IStartTheBrowser(string browserName)
        {
            WebHelp.StartWebDriver(browserName);
        }

        [Given(@"I stop the browser")]
        [When(@"I stop the browser")]
        [Then(@"I stop the browser")]
        public static void IStopTheBrowser()
        {
            WebHelp.StopWebDriver();
        }

        [Given(@"I navigate to the YouTubeMainPage")]
        [When(@"I navigate to the YouTubeMainPage")]
        [Then(@"I navigate to the YouTubeMainPage")]
        public static void INavigateToTheYouTubeMainPage()
        {
            WebHelp.NavigateTo(YouTubeMainPage.MainURL);
        }

        [Given(@"I navigate to the (.*) url")]
        [When(@"I navigate to the (.*) url")]
        [Then(@"I navigate to the (.*) url")]
        public static void INavigateToAURL(string url)
        {
            WebHelp.NavigateTo(url);
        }

        [Given(@"I wait (.*) seconds")]
        [When(@"I wait (.*) seconds")]
        [Then(@"I wait (.*) seconds")]
        public static void IWaitSomeSecunds(int wait)
        {
            WebHelp.WaitSomeSec(wait);
        }

        [Given(@"I select the (.*) element")]
        [When(@"I select the (.*) element")]
        [Then(@"I select the (.*) element")]
        public static void ISelectTheElement(string ElementName)
        {
            string ElementLocator = AllPages.getElementLocator(ElementName);
            Assert.IsTrue(WebHelp.WaitToAppear(ElementLocator));
            WebHelp.SelectWebElement(ElementName);
        }

        [Given(@"I should see the (.*) element")]
        [When(@"I should see the (.*) element")]
        [Then(@"I should see the (.*) element")]
        public static void IShouldSeeTheElement(string ElementName)
        {
            string ElementLocator = AllPages.getElementLocator(ElementName);
            Assert.IsTrue(WebHelp.WaitToAppear(ElementLocator));
            WebHelp.ITakeSceenShot();
        }

        [Given(@"I should see not the (.*) element")]
        [When(@"I should see not the (.*) element")]
        [Then(@"I should see not the (.*) element")]
        public static void IShouldNotSeeTheElement(string ElementName)
        {
            string ElementLocator = AllPages.getElementLocator(ElementName);
            Assert.IsTrue(WebHelp.WaitToDisppear(ElementLocator));
            WebHelp.ITakeSceenShot();
        }

        [Given(@"I enter (.*) into the (.*) element")]
        [When(@"I enter (.*) into the (.*) element")]
        [Then(@"I enter (.*) into the (.*) element")]
        public static void IEnterThisThere(string entry,string ElementName)
        {
            string ElementLocator = AllPages.getElementLocator(ElementName);
            Assert.IsTrue(WebHelp.WaitToAppear(ElementLocator));
            WebHelp.EnterInToWebelement(entry, ElementName);
        }

        [Given(@"I select (.*) from the (.*) dropdown")]
        [When(@"I select (.*) from the (.*) dropdown")]
        [Then(@"I select (.*) from the (.*) dropdown")]
        public static void ISelectFromDropdown(string OptionText, string DropDownName)
        {
            string ElementLocator = AllPages.getElementLocator(DropDownName);
            Assert.IsTrue(WebHelp.WaitToAppear(ElementLocator));
            WebHelp.SelectFromDropDownBySelect(OptionText, DropDownName);
        }

        [Given(@"I should see (.*) text in the (.*) element")]
        [When(@"I should see (.*) text in the (.*) element")]
        [Then(@"I should see (.*) text in the (.*) element")]
        public static void IShouldSeeTextInTheElement(string Text, string ElementName)
        {
            string ElementLocator = AllPages.getElementLocator(ElementName);
            Assert.IsTrue(WebHelp.WaitToAppear(ElementLocator));
            string TextToAssert = WebHelp.ReadFromWebelement(ElementName, "text");
            Assert.AreEqual(TextToAssert,Text);
            WebHelp.ITakeSceenShot();
        }

        [Given(@"I am on the (.*)")]
        [When(@"I am on the (.*)")]
        [Then(@"I am on the (.*)")]
        public static void IAmOnThePage(string PageName)
        {
            WebHelp.OnThePageOf(PageName);
        }

        
    }
}
