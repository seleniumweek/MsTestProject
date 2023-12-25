Feature: GoogleTest

A short summary of the feature

@Dev
Scenario: Verify Google Test
	Given I am on the google page
	Then I can see the google title

@Dev
Scenario: Searching for SpecFlow on Bing
	Given I am on the Google search engine
	When I enter SpecFlow in the search box
	And I click the search button
	Then I should see search results related to SpecFlow

@Dev
Scenario: OrangeHRM Login
	Given I have entered Admin and admin123
	When I click on the login button
	Then I should see the homepage
