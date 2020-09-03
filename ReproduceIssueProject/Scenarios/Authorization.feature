Feature: Authorization
	In  order to use a website 
	As a user 
	I want to have  field for authorisation

@Test for authorizationFeature
#TestCase ...
Scenario Outline: Verify if the login functionality is working
	Given I have navigate to my website
	And I typed <email> and <password>
	| email                       | password |
	| test111@gmail.com | test111  |
	When I click button Sign in 
	Then I should log in to the site 