Feature: Land Contamination


Scenario: Create a Land Contamination record

	Given I am on the assure home page
	And I am on the land contamination module under environment
	When I click on the link new record
	And enter the following details
	| param       | value     |
	| location    | Edinburgh |
	| sample date | 01012020  |
	| description | new test1 |
	And I click on the link new record
	And enter the following details
	| param       | value     |
	| location    | Glasgow   |
	| sample date | 01012021  |
	| description | new test2 |
	And I delete the new test1, record
	Then the new test1, record is removed from the table
	And logout from assure
