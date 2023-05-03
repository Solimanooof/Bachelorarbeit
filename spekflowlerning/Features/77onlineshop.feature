@firefox-77
Feature: 77onlineshop

77-Online Shop


@TcID_1359212
Scenario: open the website
	When click the WebSite URl
	Then Homepage should load

@TcID_1359213
Scenario: open kids page
	Given home page is open
	When click on the `Kinder` from the meneu
	Then the kids page should open
@TcID_1359214
Scenario: open login Page
	Given home page is open
	When click the login icon
	Then login page is opend
@TcID_1359215
Scenario: click radio Button on log in page
	Given home page is open
	When click the login icon
	And the radio button of neukunde clicked
	Then i can see textboxes of sing up
@TcID_1380894
Scenario: click anmelden without iput an data
	Given home page is open
	When click the login icon
	And the radio button of neukunde clicked
	And click button of anmelden
	Then warning message should occurs
@TcID_1380896
Scenario: enter an right email adress
	Given home page is open
	When click the login icon
	And click the login radio button
	Then write correct email adress in email feld
