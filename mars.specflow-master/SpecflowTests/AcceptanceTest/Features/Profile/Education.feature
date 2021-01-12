Feature: Education Tab
	  As a Skill Trader
      I want to be able to Add,update,delete education 
      In order to update my profile details
#
#
#@automation
#Scenario Outline:Add Education
#    Given I clicked on the Education tabunder Profile page
#	When i add new education'<Collegename>' '<CollegeCountry>' '<EducationTitle>' '<Degreename>' '<GraduationYear>'
#	Then i should see the education '<Collegename>'displayed on my listings
#	Examples: 
#	 | Collegename    |  CollegeCountry | EducationTitle   | Degreename| GraduationYear |
#	 | MIT            | 1               | 1           | BAchelor | 2012            |
#	 | AUT            | 2               | 2            | Master  | 2015            |
#     | SAT            | 3               | 3            | Master  | 2016            |
#	 
#Scenario Outline:Add existing Education from list
#    Given I clicked on the Education tabunder Profile page
#	When i add existing education from list
#	Then i should see '<ErrorMessage>' displayed on screen
#Examples: 
#    | ErrorMessage | 
#    | This Education already exists in your list  | 
#
#
#Scenario Outline:Add Education without Mandatory deatils
#    Given I clicked on the Education tabunder Profile page
#	When i dont provide education Mandatory details
#	Then i should see '<ErrorMessage>' displayed on screen
#Examples: 
#    | ErrorMessage | 
#    | Please Enter all details  | 
#
#@automation
#Scenario Outline:Update Education
#    Given I clicked on the Education tabunder Profile page
#	When I update education'<Collegename>' 
#	Then i should see the updated education '<Collegename>'displayed on my listings
#	Examples: 
#	 | Collegename    | 
#	 | GAT            | 
#	 
#Scenario Outline:Update Education without Mandatory details
#    Given I clicked on the Education tabunder Profile page
#	When I wont provide education Mandatory details
#	Then i should see '<ErrorMessage>' displayed on screen
#Examples: 
#    | ErrorMessage | 
#    | Please Enter all details| 
#	
#@automation
#Scenario Outline:Delete  Education
#    Given I clicked on the Education tabunder Profile page
#	When I delete Education '<Collegename>' 
#	Then i should not see deleted education '<Collegename>'displayed on my listings
#	Examples: 
#	 | Collegename    | 
#	 | PR            | 

