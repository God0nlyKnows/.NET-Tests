Feature: BookController

@CleanBooks
Scenario: Add the first book 
	Given a book for registering
	| ISBN          | Name  |
	| 9789869094481 | 玩出好創意 |	
	When Create
	Then Book table should exist a record
	| ISBN          | Name  |
	| 9789869094481 | 玩出好創意 |	

	@CleanBooks
	Scenario: Query books 
	Given Book table existed books
		 | ISBN          | Name   |
		 | 9191919191919 | 九一測試資料 |
		 | 9789869094481 | 玩出好創意  |
	And Query condition is
	| ISBN | Name  |
	|      | 玩出好創意 |
	When Query
	Then ViewModel.Books should be equals
	| ISBN          | Name   |
	| 9789869094481 | 玩出好創意 |