--INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;

SELECT f1.Id,f1.Name,CAST(f1.Size as varchar)+'KB' AS Size FROM Files as f1  
left JOIN Files as f2 ON f1.id=f2.ParentId
	where f2.name iS null
	ORDER BY f1.Id,f1.nAME asc,f1.size desc
	--ORDER BY Id ASC,Name ASC,Size DESC