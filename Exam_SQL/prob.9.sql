/*
SELECT column_name(s)
FROM table_name
WHERE condition
GROUP BY column_name(s)
Id, Name, COUNT(*)
*/

SELECT top(5) r.Id,a.name,a.Commits FROM (
 SELECT r.Name,Count(*) AS Commits FROM RepositoriesContributors RC
	JOIN Repositories r On rc.RepositoryId=r.ID
	join Commits c on rc.RepositoryId=c.RepositoryId
	Group by r.[name]
	) a
	join Repositories r On a.name=r.name
	Order by a.Commits DESC,r.id asc, a.name asc