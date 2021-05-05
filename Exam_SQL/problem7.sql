/*JOIN Customers ON Orders.CustomerID=Customers.CustomerID;*/


SELECT i.Id,u.Username+ ' : '+i.Title as IssueAssignee FROM Issues as i
JOIN Users as u ON i.AssigneeId=u.Id
	ORDER BY i.Id desc,i.AssigneeId ASC
	