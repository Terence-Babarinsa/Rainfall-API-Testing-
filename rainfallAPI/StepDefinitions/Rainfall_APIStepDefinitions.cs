using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rainfallAPI.Support;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow.Infrastructure;


namespace rainfallAPI.StepDefinitions
{
    [Binding]
    public class Rainfall_APIStepDefinitions
    {
        private string apiEndPOint;
        int statusCode;

        [Given(@"the api end point ""([^""]*)""")]
        public void GivenTheApiEndPoint(string endpoint)
        {
            apiEndPOint = endpoint;
        }
     
        [When(@"i make a get request")]
        public void WhenIMakeAGetRequest()
        {
            //sending GET request with RestSharp
            var client = new RestClient(apiEndPOint);
            var request = new RestRequest("");
            var response = client.Get(request);
            //taking response code and coverting to integer
            statusCode = (int)response.StatusCode;

           //var jsonData = JsonConvert.DeserializeObject<DataModel>(response.ToString());
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            //asserting response code to prove connection has been made ot api
            Assert.That(statusCode, Is.EqualTo(code));
      
        }


    }

}
