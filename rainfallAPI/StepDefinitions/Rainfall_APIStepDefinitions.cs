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
        public void GivenTheApiEndPoint(string endpoiint)
        {
            apiEndPOint = endpoiint;
        }
     
        [When(@"i make a get request")]
        public async void WhenIMakeAGetRequest()
        {
            var client = new RestClient(apiEndPOint);
            var request = new RestRequest("");
            var response = client.Get(request);
            statusCode = (int)response.StatusCode;

            //var jsonData = JsonConvert.DeserializeObject<DataModel>(apiResponse.ToString());
            //Console.WriteLine(jsonData.ToString());
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            Assert.That(statusCode, Is.EqualTo(code));
      
        }


    }

}
