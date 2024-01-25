 using NUnit.Framework;
using SpecFlowProject1.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Tests
{
    public class UnitTests
    {
        private Feature1StepDefinitions _featureSteps { get; set; }
        private string date = "2023-12-30";
        private int limit = 10;

        [SetUp]
        public void Setup()
        {
            string baseURL = $"https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date={date}&_limit={limit}";
            Uri uri = new Uri(baseURL);
            string test = uri.ToString();

            _featureSteps = new Feature1StepDefinitions();
            _featureSteps.GivenTheApiEndPoint(test);
            _featureSteps.WhenIMakeAGetRequest();
        }
        [Test]
        public void CheckStatusCode()
        {
            Assert.That(_featureSteps.WhenIMakeAGetRequest(), Is.EqualTo(200));
        }

        [Test]
        public void CheckDate()
        {
            Assert.That(_featureSteps.ThenTheDateOfTheMeasurementIs(date), Is.EqualTo(date));
        }

        [Test]
        public void CheckNumberOfMeasurements()
        {
            Assert.That(_featureSteps.ThenThereAreRainfallMeasurements(limit), Is.EqualTo(limit));
        }

    }
}
