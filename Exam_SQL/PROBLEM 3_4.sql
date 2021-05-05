/*
UPDATE table_name
SET column1 = value1, column2 = value2, ...
WHERE condition;
*/

UPDATE Issues
SET IssueStatus='closed'
WHERE AssigneeId=6

/*
DELETE FROM table_name WHERE condition;
*/

SELECT * FROM Repositories
 WHERE NAME='Softuni-Teamwork'

 /* Id=3 Softuni-Teamwork */

DELETE FROM issues 
WHERE RepositoryId=3

DELETE FROM RepositoriesContributors
WHERE RepositoryId=3