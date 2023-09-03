Feature: Vehicle

A short summary of the feature

@tag
Scenario: Get vehicle list
	Given I am a client
	And the repository has vehicle data
	When I make a GET request
	Then the response status code should be '200'