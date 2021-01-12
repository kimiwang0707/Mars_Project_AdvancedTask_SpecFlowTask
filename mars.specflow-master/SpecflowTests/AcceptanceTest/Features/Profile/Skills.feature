Feature: Skills Tab

Background: I login to Mars
Given I login to Mars

@automation
Scenario Outline: Add Skill 
    Given I clicked on the Profile tab under Profile page
	When I add new skill with '<SkillName>' and '<SkillLevel>'	
	Then I should see the skill '<SkillName>'and '<SkillLevel>' displayed on my listings
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |        Diving       |        Expert       |
	 |        Boxing       |       Beginner      |
	 

Scenario Outline: Add Skill without Mandatory details
    Given I clicked on the Profile tab under Profile page
	When I add new skill with blank '<SkillName>' and '<SkillLevel>'	
	Then I should see Error Message
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |                     |        Expert       |


Scenario Outline: Add existing Skill from list
    Given I clicked on the Profile tab under Profile page
	When I add existing skill from list with '<SkillName>' and '<SkillLevel>'	
	Then I should see Error Message
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |        Diving       |        Expert       |

	
Scenario Outline: Add existing Skill from list with different SkillLevel
    Given I clicked on the Profile tab under Profile page
	When I add existing skill from list with '<SkillName>' and different '<SkillLevel>'
	Then I should see Error Message
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |        Diving       |       Beginner      | 
	 
		
@automation	
Scenario Outline: Update Skill 
    Given I clicked on the Profile tab under Profile page
	When I update skill with '<SkillName>' and '<SkillLevel>' 
	Then I should see updated '<SkillName>' and '<SkillLevel>'
    Examples: 
	 |      SkillName      |      SkillLevel     |
	 |       Painting      |        Expert       | 


Scenario Outline: Update Skill without Mandatory details
    Given I clicked on the Profile tab under Profile page
	When I update skill with blank '<SkillName>' and '<SkillLevel>' 
	Then I should see Error Message
    Examples: 
	 |      SkillName      |      SkillLevel     |
	 |                     |        Expert       |
	 

Scenario Outline: Update with existing Skill from list
    Given I clicked on the Profile tab under Profile page
	When I update skill with existing '<SkillName>' and '<SkillLevel>'
	Then I should see Error Message
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |       Singing       |    Intermediate     | 


Scenario Outline: Update with existing Skill from list with different SkillLevel
    Given I clicked on the Profile tab under Profile page
	When I update skill with existing '<SkillName>' and differenr '<SkillLevel>'
	Then I should see Error Message
	Examples: 
	 |      SkillName      |      SkillLevel     |
	 |       Singing       |        Expert       | 

	
@automation
Scenario: Delete Skill 
    Given I clicked on the Profile tab under Profile page
	When I delete a skill 
	Then I will not see the language



