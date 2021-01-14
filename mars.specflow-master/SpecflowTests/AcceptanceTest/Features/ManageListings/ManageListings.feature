Feature: ManageListings

Background: I login to Mars
Given I login to Mars

@mytag
Scenario: Edit Listing
	Given I nativate to managelisting page
	When I edit the listing
	Then the listing will be updated

Scenario: Delete Listing
	Given I nativate to managelisting page
	When I delete a listing
	Then the listing will be deleted