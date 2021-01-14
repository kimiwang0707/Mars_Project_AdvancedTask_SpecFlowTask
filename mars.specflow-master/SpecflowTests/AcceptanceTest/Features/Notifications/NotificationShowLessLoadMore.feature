Feature: NotificationShowLessLoadMore

Background: I login to Mars
Given I login to Mars

@mytag
Scenario: Show Less And Load More Notification
	Given I navigate to Notification page
	When I click Load More button and Show Less button
	Then the results will be shown as request