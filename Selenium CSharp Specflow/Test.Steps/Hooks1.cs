using FirstAutomatedTestsProject.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Selenium_CSharp_Specflow.Test.Steps
{
    [Binding]
    public sealed class Hooks1
    {
       

        [BeforeScenario]
        public void BeforeScenario()
        {
            string Driver = ScenarioContext.Current.ScenarioInfo.Tags.ToList()[2].ToString();
            WebHelp.StartWebDriver(Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebHelp.StopWebDriver();
        }
    }
}
