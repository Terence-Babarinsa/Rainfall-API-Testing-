Feature: Rainfall_API
A public API used to report rainfall 
from hte measurement stations
around the UK

@ApiTest
Scenario: Performn GET request
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?_sorted&_limit=10"
	When i make a get request
	Then the reponse status code should be 200
