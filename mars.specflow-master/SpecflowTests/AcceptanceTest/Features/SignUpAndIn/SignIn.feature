Feature: SignIn


@mytag
Scenario: Sign in a registered account
	When I sign in with my registered credentials
	Then I am able to verify the account is logged in