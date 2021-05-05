CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
  SELECT Id,[name] as Name, CAST(size as varchar)+'KB' AS Size
  FROM Files
  WHERE [NAME] LIKE '%'+@fileExtension
  ORDER BY Id ASC,Name ASC, Size DESC
GO

EXEC usp_SearchForFiles 'txt'