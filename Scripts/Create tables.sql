BEGIN TRANSACTION;
	CREATE TABLE Products (
		Id INT PRIMARY KEY,
		Name NVARCHAR(255) NOT NULL
	);

	CREATE TABLE Categories (
		Id INT PRIMARY KEY,
		Name NVARCHAR(255) NOT NULL
	);

	--Таблица для связи многие ко многим
	CREATE TABLE ProductCategories (
		ProductId INT,
		CategoryId INT,
		PRIMARY KEY (ProductId, CategoryId),
		FOREIGN KEY (ProductId) REFERENCES Products(Id),
		FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
	);
COMMIT TRANSACTION;