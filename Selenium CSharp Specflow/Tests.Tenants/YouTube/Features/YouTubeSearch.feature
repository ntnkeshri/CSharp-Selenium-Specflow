Feature: YouTubeSearch

	@Smoke @Dev @Chrome
	Scenario: I can Search for a text in the youtube search
	Given I navigate to the YouTubeMainPage
	And I am on the YouTubeMainPage
	And I enter Visual Studio into the search_field element
	When I select the search_button element
	Then I should see the search_result_1st_image element

	@Regression @QA @Chrome
	Scenario Outline: I can Search for a many text in the youtube search
	Given I navigate to the YouTubeMainPage
	And I am on the YouTubeMainPage
	And I enter <search_text> into the search_field element
	When I select the search_button element
	Then I should see the search_result_1st_image element

	Examples:
	| search_text   |
	| Visual Studio |
	| SpecFlow      |