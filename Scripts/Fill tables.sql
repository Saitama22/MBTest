BEGIN TRANSACTION;
	INSERT INTO Categories (Id, Name) VALUES 
	(1, N'Молочные продукты'),
	(2, N'Фрукты'),
	(3, N'Сладкое'),
	(4, N'Из пекарни'),
	(5, N'Полезно для здоровья'),
	(6, N'Овощи');

	INSERT INTO Products (Id, Name) VALUES 
	(1, N'Молоко'),
	(2, N'Яблоко'),
	(3, N'Сыр'),
	(4, N'Колбаса'),
	(5, N'Кофе'),
	(6, N'Чай'),
	(7, N'Белый хлеб'),
	(8, N'Черный хлеб'),
	(9, N'Сливки');
	
	INSERT INTO ProductCategories (ProductId, CategoryId) VALUES 
	(1,1),
	(2,2),
	(2,3),
	(2,5),
	(3,1),
	(3,5),
	(7,4),
	(8,4),
	(9,1);	
COMMIT TRANSACTION;
