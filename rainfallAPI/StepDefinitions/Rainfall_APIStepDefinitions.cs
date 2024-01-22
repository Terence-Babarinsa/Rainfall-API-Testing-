using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Net;

namespace rainfallAPI.StepDefinitions
{
    [Binding]
    public class Rainfall_APIStepDefinitions
    {
        private string apiEndPOint;
        HttpClient client = new HttpClient();
        int statusCode;

        [Given(@"the api end point ""([^""]*)""")]
        public void GivenTheApiEndPoint(string endpoiint)
        {
            apiEndPOint = endpoiint;
        }
        [When(@"i make a get request")]
        public async void WhenIMakeAGetRequest()
        {
            HttpResponseMessage response = await client.GetAsync(apiEndPOint);
            statusCode = (int)response.StatusCode;
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            Assert.That(statusCode, Is.EqualTo(code));
        }


    }

}
