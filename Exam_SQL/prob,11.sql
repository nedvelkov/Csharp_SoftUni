
CREATE FUNCTION dbo.udf_AllUserCommits(@username VARCHAR)
RETURNS int AS 
BEGIN
DECLARE @RESULT INT;
SET @RESULT=(
 SELECT COUNT(*) FROM Users s
	join Commits c on s.Id=c.ContributorId
	WHERE S.USERNAME LIKE @username)

	     IF (@RESULT IS NULL)   
        SET @RESULT = 0;  
    RETURN @RESULT;  
END