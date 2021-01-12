Feature: ShareSkill

Background: I login to Mars
Given I login to Mars

@mytag
Scenario: Add Share Skill
	Given I click on Share Skill Button
	When I input skill details
	Then I can see the skill is added into list