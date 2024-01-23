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
        HttpResponseMessage apiResponse;
        HttpClient client;
        private string responseBody;
        int statusCode;

        private readonly ISpecFlowOutputHelper _outputHelper;
        public Rainfall_APIStepDefinitions(ISpecFlowOutputHelper outputHelper)
        {
           HttpClient client = new HttpClient();
            this._outputHelper = outputHelper;
        }

        [Given(@"the api end point ""([^""]*)""")]
        public void GivenTheApiEndPoint(string endpoiint)
        {
            apiEndPOint = endpoiint;
        }
     
        [When(@"i make a get request")]
        public async void WhenIMakeAGetRequest()
        {
            apiResponse = await client.GetAsync(apiEndPOint);
            apiResponse.EnsureSuccessStatusCode();
            responseBody = await apiResponse.Content.ReadAsStringAsync();
            _outputHelper.WriteLine(responseBody);



            var jsonData = JsonConvert.DeserializeObject<DataModel>(apiResponse.ToString());
            Console.WriteLine(jsonData.ToString());
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            // Assert.That(statusCode, Is.EqualTo(code));
            throw new PendingStepException();
        }


    }

}
