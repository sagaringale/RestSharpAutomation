using System.Collections.Generic;
using NUnit.Framework;
using ProductAutomation.Apis.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using static ProductAutomation.Utils.Settings.Settings;

namespace RestAutomation.Apis
{
    public class BaseApiTests
    {
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl);
            Client.Authenticator = AuthTwitter();
        }

        private static OAuth1Authenticator AuthTwitter()
        {
            OAuth1Authenticator oAuth1Authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            return oAuth1Authenticator;
        }

        public static void PostTweet(string message)
        {
            Request = new RestRequest("/update.json", Method.POST);
            Request.AddParameter("status", message, ParameterType.GetOrPost);
            GetResponse();
        }

        public static void GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest();
            Request.Resource = apiResource;
            GetResponse();
        }

        private static void GetResponse()
        {
            Response = Client.Execute(Request);
        }

        private static T DeserialiseResponse<T>()
        {
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            return jsonDeserializer.Deserialize<T>(Response);
        }

        public static void AssertTweetWasPosted(string tweet)
        {
            var result = DeserialiseResponse<List<HomeTimeline>>();
            Assert.True(result[0].text == tweet);
        }
    }
}