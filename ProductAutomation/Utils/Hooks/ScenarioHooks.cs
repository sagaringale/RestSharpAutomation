using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProductAutomation.Utils.Hooks
{
    [Binding]
    internal static class ScenarioHookss
    {
        [BeforeScenario()]
        [Obsolete]
        //[System.Obsolete]
        internal static void BeforeHooks()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Api"))
            {
                RestAutomation.Apis.BaseApiTests.SetBaseUriAndAuth();
            }
        }
    }
}
