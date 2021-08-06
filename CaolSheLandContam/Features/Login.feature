Feature: Login

Scenario: Check user is able to login to Assure

	Given I am on the assure login page
	When I enter my login details and click enter
	Then I am logged in
