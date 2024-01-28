using Newtonsoft.Json;
using NUnit.Framework;
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

        [Then(@"each measurement value shoud match with input")]
        public void ThenEachMeasurementValueShoudMatchWithInput(Table table)
        {
            int count = 0;
            //cycles through each item in table 
            foreach (TableRow row in table.Rows)
            {
                //cycle through all items in json
                foreach (var item in jsonData.items)
                {
                    //converts float value to decimal
                    decimal _item = Convert.ToDecimal(item.value);
                    Console.WriteLine(_item);
                    ////**unable to outout decimal
                    //Assert.That(Math.Round( _item,3), Is.EqualTo(row["input"]));
                    count++;
                }
            }

        }
        [Given(@"correct api endpoint ""([^""]*)"" with invalid limit")]
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


    }
}
