Feature: Feature1

This feature tests the new functionality added to the Rainfall api

@Positive_test
Scenario: Correct Status Code
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2024-01-10&_limit=10"
	When i make a get request
	Then the reponse status code should be 200

@Positive_test
Scenario: Correct date
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2024-01-10&_limit=10"
	When i make a get request
	Then the date of the measurement is "2024-01-10"
	

@Positive_test
Scenario: Correct Limit 
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2024-01-10&_limit=10"
	When i make a get request
	Then there are 10 rainfall measurements

	@Positive_test
Scenario: Correct Data
	Given the api end point "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2024-01-10&_limit=10"
	When i make a get request
	Then each measurement value shoud match with <input>

	Examples: 
	| input |     
	| 3.409 |
	| 3.403 |
	| 3.398 |
	| 3.399 |
	| 3.386 |
	| 3.386 |
	| 3.382 |
	| 3.375 |
	| 3.376 |
	| 3.373 |

	@Negative_test
	Scenario: Limit out of scope
	Given correct api endpoint $"https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2025-01-10&_limit=<input>" with invalid limit
	When i make a get request
	Then the number of items in the json should not match the <input>

	Examples: 
	| input |
	| 5000  |
	| -1    |


	@Negative_test 
	Scenario: Date out of scope 
	Given correct api endpoint "https://environment.data.gov.uk/flood-monitoring/id/stations/2165/readings?date=2025-01-10&_limit=10" with invalid date
	When i make a get request
	Then there should be 0 items in the json
