Feature: Feature1

This feature tests the new functionality added to the Rainfall api

@tag1
Scenario: Test
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2023-12-29&_limit=10"
	When i make a get request
	Then the reponse status code should be 200
	And the date of the measurement is "2023-12-29"
	And there are 10 rainfall measurements
	And each measurement value shoud match with input
	| input |
	| 1.826 |
	| 1.816 |
	| 1.803 |
	| 1.792 |
	| 1.788 |
	| 1.777 |
	| 1.768 |
	| 1.766 |
	| 1.762 |
	| 1.753 |