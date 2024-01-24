using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rainfallAPI;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow.Infrastructure;
using rainfallAPI.DataHandling;


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
            //sending GET request tp api endpoint
            var client = new RestClient(apiEndPOint);
            var request = new RestRequest("");
            var response = client.Get(request);

            //deserialisinig json into datamodel
            Rootobject jsonData = JsonConvert.DeserializeObject<Rootobject>(response.Content.ToString());

            //extracting data from json
            Console.WriteLine($"test 1{jsonData.items[0].value}");

            //assigning status code to variable for testing 
            statusCode = (int)response.StatusCode;
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            //asserting response code to prove connection has been made ot api
            Assert.That(statusCode, Is.EqualTo(code));
      
        }


    }

}
