Feature: Language Tab

Background: I login to Mars
Given I login to Mars

@automation
Scenario: Add language
	Given I clicked on the profile tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings
	
Scenario: Add language without Mandatory details
	Given I clicked on the profile tab under Profile page
	When I dont provide a Mandatory language details
	Then I should see the ErrorMessage displayed on screen
    
Scenario: Add existing language from list
	Given I clicked on the profile tab under Profile page
	When I add existing language from list
	Then I should see the ErrorMessage displayed on screen
   
Scenario: Add existing language with different language level
	Given I clicked on the profile tab under Profile page
	When I add existing language but with different Language Level
	Then I should see the ErrorMessage displayed on screen


#@automation
Scenario: Update language 
	Given I clicked on the profile tab under Profile page
	When I  update Language 
	Then that updated language should be displayed on my listings
	 
Scenario: Update language without Mandatory deatails 
	Given I clicked on the profile tab under Profile page
	When I do not provide Mandatory Language details
	Then I should see the ErrorMessage displayed on screen
	
 Scenario: Update with existing language from list
	Given I clicked on the profile tab under Profile page
	When  I  update existing Language from list
	Then I should see the ErrorMessage displayed on screen

Scenario: Update with existing language with different language level
	Given I clicked on the profile tab under Profile page
	When  I  update exitsing Language with different language level
	Then I should see the ErrorMessage displayed on screen

   
@automation     
Scenario: Delete language 
	Given I clicked on the profile tab under Profile page
	When I delete language 
	Then that language should not be displayed on my listings
	

