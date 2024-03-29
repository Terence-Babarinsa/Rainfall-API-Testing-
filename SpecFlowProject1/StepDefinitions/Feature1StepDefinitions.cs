using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestSharp;
using SpecFlowProject1.HttpManager;
using SpecFlowProject1.Support;
using System;
using System.Net;
using System.Net.Sockets;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        public  string apiEndpoint { get; set; }
        public int statusCode { get; set; }
        public Rootobject jsonData { get; set; }
        private GET_Request getReqeust {  get; set; }
        public RestResponse getResponse { get; set; }

        public Feature1StepDefinitions()
        {
            getReqeust = new GET_Request();
        }
        [Given(@"the api end point ""([^""]*)""")]
        public void GivenTheApiEndPoint(string endpoint)
        {
            apiEndpoint = endpoint;
        }
        [When(@"i make a get request")]
        public void WhenIMakeAGetRequest()
        {
             getResponse = getReqeust.get_Request(apiEndpoint);

            //deserialisinig json into datamodel
            jsonData = JsonConvert.DeserializeObject<Rootobject>(getResponse.Content.ToString());

            //assigning status code to variable for testing 
             statusCode = (int)getResponse.StatusCode;
        }

        [Then(@"the reponse status code should be (.*)")]
        public void ThenTheReponseStatusCodeShouldBe(int code)
        {
            Assert.That(statusCode, Is.EqualTo(code));
        }
        [Then(@"the date of the measurement is ""([^""]*)""")]
        public void ThenTheDateOfTheMeasurementIs(string date)
        {
            //formatting the date from the json
            string jsonDate = jsonData.items[1].dateTime.ToString("yyyy-MM-dd");

            Assert.That( jsonDate, Is.EqualTo(date));

        }

        [Then(@"there are (.*) rainfall measurements")]
        public void ThenThereAreRainfallMeasurements(int measurementCount)
        {
            int count = jsonData.items.Count();

            Assert.That( count, Is.EqualTo(measurementCount));
        }

        [Then(@"each measurement value shoud match with (.*)")]
        public void ThenEachMeasurementValueShoudMatchWith(Decimal input)
        {
            int count = jsonData.items.Count();

            //sort incoming list

            //cycle through all items in json
            for (int i = 0; i > count; i++)
            {
                //*****not working as intended, please ignore********
                //Assert.That((item.ToString() ,Is.EqualTo( input.ToString()));
                ClassicAssert.AreEqual((decimal)jsonData.items[i].value, input);
            }

        }

        [Given(@"correct api endpoint \$""([^""]*)"" with invalid limit")]
        public void GivenCorrectApiEndpointWithInvalidLimit(string endpoint)
        {
            apiEndpoint = endpoint;
        }

        [Given(@"correct api endpoint ""([^""]*)"" with invalid date")]
        public void GivenCorrectApiEndpointWithInvalidDate(string endpoint)
        {
            apiEndpoint = endpoint;  
        }

        [Then(@"there should be (.*) items in the json")]
        public void ThenThereShouldBeItemsInTheJson(int count)
        {
            int itemCount = jsonData.items.Count();

            Assert.That(itemCount, Is.EqualTo(count));
        }

        [Then(@"the number of items in the json should not match the (.*)")]
        public void ThenTheNumberOfItemsInTheJsonShouldNotMatchThe(int input)
        {
                Assert.That(jsonData.items.Count, Is.Not.EqualTo(input));
            
        }

    }
}
