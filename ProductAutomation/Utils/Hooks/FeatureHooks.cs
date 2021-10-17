using RestAutomation.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProductAutomation.Utils.Hooks
{
   
        [Binding]
        internal static class FeatureHooks
        {
            [BeforeFeature()]
        [Obsolete]
        // [System.Obsolete]
        internal static void BeforeHooks()
            {
                if (FeatureContext.Current.FeatureInfo.Tags.Contains("Api"))
                {
                    BaseApiTests.SetBaseUriAndAuth();
                }
            }
        }
    }
