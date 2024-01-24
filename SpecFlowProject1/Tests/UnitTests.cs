 using NUnit.Framework;
using SpecFlowProject1.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Tests
{
    public class UnitTests
    {
        private Feature1StepDefinitions _featureSteps = new Feature1StepDefinitions();
        [SetUp]
        public void setup()
        {
            _featureSteps.GivenTheApiEndPoint("https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2023-12-26&_limit=10");
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
            Assert.That(_featureSteps.ThenTheDateOfTheMeasurementIs("2023-12-26"), Is.EqualTo("2023-12-26"));
        }

        [Test]
        public void CheckNumberOfMeasurements()
        {
            Assert.That(_featureSteps.ThenThereAreRainfallMeasurements(10), Is.EqualTo(10));
        }

    }
}
