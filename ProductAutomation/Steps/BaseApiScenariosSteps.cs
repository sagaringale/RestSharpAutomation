using TechTalk.SpecFlow;
using ProductAutomation.Apis;
using RestAutomation.Apis;

namespace ProductAutomation.Steps
{
    [Binding]
    public sealed class BaseApiScenariosSteps
    {
        [Given(@"I post a tweet of ""(.*)""")]
        public void GivenIPostATweetOf(string tweet)
        {
            BaseApiTests.PostTweet(tweet);
        }

        [When(@"I retrieve the response of the ""(.*)"" resource")]
        public void WhenIRetrieveTheResponseOfTheResource(string apiResource)
        {
            BaseApiTests.GetResponseOfResource(apiResource);
        }

        [Then(@"the latest tweet is my message of ""(.*)""")]
        public void ThenTheLatestTweetIsMyMessageOf(string tweet)
        {
            BaseApiTests.AssertTweetWasPosted(tweet);
        }


    }
}