--Тестовое на sql

SELECT 
    p.Name AS ProductName,
    ISNULL(c.Name, N'<Нет категории>') AS CategoryName --Замена Null на значение для вывода
FROM Products p
	LEFT JOIN ProductCategories pc ON p.Id = pc.ProductId
	LEFT JOIN Categories c ON pc.CategoryId = c.Id;