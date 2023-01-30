USE Northwind;

-- 3. List all products and their total order quantities throughout all orders.
SELECT p.ProductID, p.ProductName, SUM(od.Quantity) AS [total Order Quantities]
FROM dbo.Products p
INNER JOIN dbo.[Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY p.ProductID

-- 4. List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS [Total Products Ordered]
FROM dbo.Customers c
INNER JOIN dbo.Orders o ON o.CustomerID = c.CustomerID
INNER JOIN dbo.[Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.City
ORDER BY c.City

-- 5. List all Customer Cities that have at least two customers.
SELECT c.City, COUNT(c.CustomerID) AS [Number of Customers]
FROM dbo.Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 1
ORDER BY c.City

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH ProductRankByCity AS (
    SELECT od.ProductID, c.City, SUM(od.Quantity) AS [Product Quantity by City], 
            RANK() OVER(PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS [Rank]
    FROM dbo.[Order Details] od
    INNER JOIN dbo.Orders o ON od.OrderID = o.OrderID
    INNER JOIN Customers c ON c.CustomerID = o.CustomerID
    GROUP BY od.ProductID, c.City
),
Top1ProductByCity AS (
    SELECT *
    FROM ProductRankByCity prbc
    WHERE prbc.Rank = 1
)
SELECT TOP 5 od.ProductID, p.ProductName, SUM(od.Quantity) AS [Total Quantity], AVG(od.UnitPrice) AS [Average Price], tpbc.City
FROM dbo.[Order Details] od
INNER JOIN dbo.Products p ON p.ProductID = od.ProductID
INNER JOIN Top1ProductByCity tpbc ON tpbc.ProductID = p.ProductID
GROUP BY od.ProductID, p.ProductName, tpbc.City
ORDER BY SUM(od.Quantity) DESC

-- 9. List all cities that have never ordered something but we have employees there.
WITH EmployeeCity AS (
    SELECT DISTINCT e.City
    FROM dbo.Employees e
)
SELECT DISTINCT ec.City AS [Employee City]
FROM dbo.Customers c
RIGHT OUTER JOIN EmployeeCity ec ON ec.City = c.City
WHERE c.City IS NULL

-- 10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH CityHasMostOrders AS (
    SELECT TOP 1 c.City, SUM(od.Quantity) AS [Total Quantity of Products Ordered]
    FROM dbo.Orders o
    INNER JOIN dbo.Customers c ON c.CustomerID = o.CustomerID
    INNER JOIN dbo.[Order Details] od ON od.OrderID = o.OrderID
    GROUP BY c.City
    ORDER BY [Total Quantity of Products Ordered] DESC
),
CityHasMostQuantity AS (
    SELECT TOP 1 c.City, COUNT(o.OrderID) AS [Number of Orders]
    FROM dbo.Orders o
    INNER JOIN dbo.Customers c ON c.CustomerID = o.CustomerID
    GROUP BY c.City
    ORDER BY [Number of Orders] DESC
)
SELECT chmo.City
FROM CityHasMostOrders chmo
INNER JOIN CityHasMostQuantity chmq ON chmq.City = chmo.City

-- 11. How do you remove the duplicates record of a table?
/*
    Answer:
        Method 1: Use SELECT DISTINCT
        Method 2: Use COUNT to count the occurance, select the occurace with value 1
        Method 3: Use UNION to UNION the same table twice to get non-duplicate value
*/