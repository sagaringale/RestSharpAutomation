Feature: BaseApiScenarios
	

@Api
Scenario: Post a status to my Twitter
	Given I post a tweet of "Hello World. This is a test tweet."
	When I retrieve the response of the "/home_timeline.json" resource
	Then the latest tweet is my message of "Hello World. This is a test tweet."