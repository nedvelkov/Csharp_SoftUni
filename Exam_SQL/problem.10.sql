

 SELECT s.Username,AVG(f.size) as Size FROM RepositoriesContributors RC
	JOIN Users s On rc.ContributorId=s.ID
	join Commits c on rc.ContributorId=c.ContributorId
	Join Files  f on f.CommitId=c.Id
	GROUP BY S.Username
	Order by Size DESC,S.USERNAME ASC