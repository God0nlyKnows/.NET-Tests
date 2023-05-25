@web
Feature: BookMaintenance
	In order to maintain books easily
	As a librarian
	I want to add, update, query books information

@CleanBooks
Scenario: Add a book
	Given go to Book Registering Page
	And a book for registering
	| ISBN          | Name  |
	| 9789869094481 | 玩出好創意 |	
	When Add book into library
	Then added successfully message should be displayed

@CleanBooks
Scenario: Query books
	Given go to Book Query Page
	And Query Condition: book name is "玩出好創意"	
	And Book table existed books
	| ISBN          | Name   |
	| 9191919191919 | 九一測試資料 |
	| 9789869094481 | 玩出好創意 |
	When Query
	Then it should display book records
	| ISBN          | Name   |
	| 9789869094481 | 玩出好創意 |
	