Feature: LoginRequirements

These are the requirements about security when login.

Background:
    Given a started app

#1
@login @security
Scenario: An user can login when he has valid credentials
	Given an user at login screen
	When he populate user field
	And he populate password field
	And he press login button
	Then he is allowed to access app