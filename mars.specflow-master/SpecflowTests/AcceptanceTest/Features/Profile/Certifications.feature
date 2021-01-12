Feature: Certification tab
	  As a Skill Trader
      I want to be able to Add,update,delete Certifications 
      In order to update my profile details

#
#@automation
#Scenario Outline: Add Certification
#    Given I clicked on the Certifcation tabunder Profile page
#	When i add new certification '<Certificationname>' '<Certificationfrom>' '<CertificationYear>'
#	Then i should see  the certification'<Certificatename>' displayed on my listings
#   Examples:
#    | Certificationname | Certificationfrom | CertificationYear |
#    | Java              | JAVA Association  | 1             |
#    | ISTQB             | ISTQB Association | 2              |
#		
#Scenario Outline: Add certification without Mandatory details
#    Given I clicked on the Certifcation tabunder Profile page
#	When i dont provide certification Mandatory details
#	Then i should see  the '<ErrorMessage>' displayed on screen
#Examples: 
#    | ErrorMessage | 
#    | Please Enter Certification Name,Certifcation From and Certifcation Year| 
#  
#@automation
#Scenario Outline: Update Certification
#    Given I clicked on the Certifcation tabunder Profile page
#	When i update certification '<Certificationname>' 
#	Then i should see updated certification'<Certificatename>' displayed on my listings
#   Examples:
#    | Certificationname | 
#    | C#                |   
#	
#	
#Scenario Outline: Update Certification without Mandatory details
#    Given I clicked on the Certifcation tabunder Profile page
#	When dont provide certification Mandatory details
#	Then i should see  the '<ErrorMessage>' displayed on screen
#Examples: 
#    | ErrorMessage | 
#    | Please Enter Certification Name,Certifcation From and Certifcation Year| 
#
#@automation
#Scenario Outline: Delete Certification
#    Given I clicked on the Certifcation tabunder Profile page
#	When i delete certification '<Certificationname>' 
#	Then i should not see the deleted certification '<Certificatename>' displayed on my listings
#   Examples:
#    | Certificationname | 
#    | C              |
#

  