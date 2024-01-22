Feature: Rainfall_API
A public API used to report rainfall 
from hte measurement stations
around the UK

@ApiTest
Scenario: Limiting paramaters returned 
	Given The API endpoint
	When I make a GET request to the API
	And I limit th amout of rainfall measurements
	Then I get rainfall limited measurement for an individual station

@ApiTest
Scenario: Individual station request
	Given The API endpoint
	When I make a GET request to the API
	And I specify the date 
	Then I get rainfall measurement for an individual station on a specific date 