-- 1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_xu AS (
    SELECT od.ProductID, p.ProductName, SUM(od.Quantity) AS [Total Ordered Quantity]
    FROM dbo.[Order Details] od
    INNER JOIN dbo.Products p ON p.ProductID = od.ProductID
    GROUP BY od.ProductID, p.ProductName
)
GO
-- test q1
SELECT * FROM view_product_order_xu
DROP VIEW view_product_order_xu;

-- 2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” 
-- that accept product id as an input and total quantities of order as output parameter.
GO
CREATE PROC sp_product_order_quantity_xu @ProductID INT, @OrderQuantities INT OUT AS
BEGIN
    SELECT @OrderQuantities = tmp.TotalOrderedQuantity 
    FROM (
        SELECT od.ProductID, SUM(od.Quantity) AS [TotalOrderedQuantity]
        FROM dbo.[Order Details] od
        WHERE od.ProductID = @ProductID
        GROUP BY od.ProductID
    ) tmp
END
-- test q2
DECLARE @ROrderQuantities INT
EXEC sp_product_order_quantity_xu 23, @ROrderQuantities OUT
PRINT @ROrderQuantities

-- 3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities 
-- that ordered most that product combined with the total quantity of that product ordered from that city as output.
GO
CREATE PROC sp_product_order_city_xu @ProductName VARCHAR(40) AS
BEGIN
    WITH CityRankByProduct AS (
        SELECT od.ProductID, p.ProductName, c.City, SUM(od.Quantity) AS [Product Quantity by City], 
                RANK() OVER(PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS [Rank]
        FROM dbo.[Order Details] od
        INNER JOIN dbo.Orders o ON od.OrderID = o.OrderID
        INNER JOIN dbo.Customers c ON c.CustomerID = o.CustomerID
        INNER JOIN dbo.Products p ON p.[ProductID] = od.ProductID
        WHERE p.ProductName = @ProductName
        GROUP BY od.ProductID, p.ProductName, c.City
    )
    SELECT crbp.City, crbp.[Product Quantity by City]
    FROM CityRankByProduct crbp
    WHERE crbp.Rank BETWEEN 1 AND 5
END
-- test q3
EXEC sp_product_order_city_xu 'Chang'
EXEC sp_product_order_city_xu 'Chai'

/*
    4. Create 2 new tables “people_your_last_name” “city_your_last_name”.
    City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
    People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}.
    Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”.
    Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
    (after test) Drop both tables and view.
*/
-- step1: create tables and insert rows
GO
CREATE TABLE city_xu(
    Id INT PRIMARY KEY,
    City VARCHAR(30)
)
INSERT INTO city_xu(Id, City) VALUES 
    (1, 'Seattle'), (2, 'Green Bay')
SELECT * FROM city_xu

CREATE TABLE people_xu(
    Id INT PRIMARY KEY,
    Name VARCHAR(30),
    City INT FOREIGN KEY REFERENCES city_xu(Id)
)
INSERT INTO people_xu(Id, Name, City) VALUES
    (1, 'Aaron Rodgers', 2), (2, 'Russell Wilson', 1), (3, 'Jody Nelson', 2)
SELECT * FROM people_xu

-- step2: update people from seattle to madison and remove city seattle
GO
CREATE PROC remove_seattle AS
BEGIN
    DECLARE @SeattlePeopleCount INT
    SELECT @SeattlePeopleCount = 
        COUNT(*)
        FROM people_xu px
        INNER JOIN city_xu cx ON px.City = cx.Id
        WHERE cx.City = 'Seattle'
    
    IF @SeattlePeopleCount <> 0
        INSERT city_xu VALUES (3, 'Madison')
        
        UPDATE people_xu
        SET City = 3
        WHERE City = 1 

        DELETE FROM city_xu WHERE City = 'Seattle'
END
EXEC remove_seattle

-- step3: list people from Green Bay
GO
CREATE VIEW list_green_bay_people AS (
    SELECT px.Name
    FROM people_xu px
    INNER JOIN city_xu cx ON cx.Id = px.City
    WHERE cx.City = 'Green Bay'
)
GO
SELECT * FROM list_green_bay_people

-- step4: clean up
DROP VIEW list_green_bay_people
DROP PROC remove_seattle
DROP TABLE people_xu
DROP TABLE city_xu

-- 5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” 
-- and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
GO
CREATE PROC sp_birthday_employees_xu AS
BEGIN
    CREATE TABLE birthday_employees_xu(
        LastName VARCHAR(20),
        FirstName VARCHAR(10),
        BirthDate DATETIME
    )
    INSERT INTO birthday_employees_xu
    SELECT e.LastName, e.FirstName, e.BirthDate
    FROM Employees e
    WHERE MONTH(e.BirthDate) = '02'
END
EXEC sp_birthday_employees_xu
SELECT * FROM birthday_employees_xu
DROP TABLE birthday_employees_xu

-- 6. How do you make sure two tables have the same data?
/*
    Step1: use COUNT(*) to see if two tables have the same number of rows
    Step2:
        SELECT * FROM Table1
        EXCEPT
        SELECT * FROM Table2
    If this query returns any row, they are not identical; otherwise they are identical
*/