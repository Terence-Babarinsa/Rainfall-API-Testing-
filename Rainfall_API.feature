Feature: Rainfall_API
A public API used to report rainfall 
from hte measurement stations
around the UK

@ApiTest
Scenario: Perform a GET request 
Given  the api endpoint "http://environment.data.gov.uk/flood-monitoring/id/stations/2165"
When i make a get request to the api
Then the reponse status code should be 200

