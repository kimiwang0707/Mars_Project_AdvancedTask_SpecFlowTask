Feature: Chat

Background: I login to Mars
Given I login to Mars

@mytag
Scenario: Chat With Others
	When I click to chat with others
	Then I can can see the chat record

Scenario: View Chat History
	When I click to view chat history
	Then I can can view the chat history
