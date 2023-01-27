USE AdventureWorks2019;

-- 1. How many products can you find in the Production.Product table?
SELECT COUNT(ProductID) AS [Number of Product]
FROM Production.Product

-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT ProductSubcategoryID, COUNT(ProductID) AS [CountedProducts]
FROM Production.Product
GROUP BY ProductSubcategoryID

-- 4. How many products that do not have a product subcategory.
SELECT COUNT(ProductID) AS [Number of Product Without Product Subcategory]
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS [Sum of Products Quantity]
FROM Production.ProductInventory

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 
-- and limit the result to include just summarized quantities less than 100.
SELECT ProductID, SUM(Quantity) AS [TheSum]
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

-- 10. Write query  to see the average quantity  of  products by shelf 
-- excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS [TheAvg]
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf

-- 11. List the members (rows) and average list price in the Production.Product table. 
-- This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(ProductID) AS [TheCount], AVG(ListPrice) AS [AvgPrice]
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

-- 12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. 
-- Join them and produce a result set similar to the following.
SELECT cr.Name AS [Country], sp.Name AS [Province]
FROM person.CountryRegion cr
INNER JOIN person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode

-- 13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables
--  and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT cr.Name AS [Country], sp.Name AS [Province]
FROM person.CountryRegion cr
INNER JOIN person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada')
ORDER BY [Country]

USE Northwind;
-- 15. List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS [Total Sale]
FROM dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.ShipPostalCode
ORDER BY [Total Sale] DESC

-- 17. List all city names and number of customers in that city.
SELECT c.City, COUNT(CustomerID) AS [Number of Customers]
FROM dbo.Customers c
GROUP BY c.City

-- 18. List city names which have more than 2 customers, and number of customers in that city
SELECT c.City, COUNT(CustomerID) AS [Number of Customers]
FROM dbo.Customers c
GROUP BY c.City
HAVING COUNT(CustomerID) > 2

-- 19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName, o.OrderDate
FROM dbo.Customers c
INNER JOIN dbo.Orders o ON o.CustomerID = c.CustomerID
WHERE o.OrderDate > '1998-01-01'

-- 20. List the names of all customers with most recent order dates
WITH CustomerOrders AS (
    SELECT c.ContactName, o.OrderDate, RANK() OVER(PARTITION BY c.ContactName ORDER BY o.OrderDate DESC) AS [Rank]
    FROM dbo.Customers c
    INNER JOIN dbo.Orders o ON o.CustomerID = c.CustomerID    
)
SELECT co.ContactName, co.OrderDate
FROM CustomerOrders co
WHERE co.Rank = 1

-- 23. List all of the possible ways that suppliers can ship their products. Display the results as below
SELECT sup.CompanyName AS [Supplier Company Name], ship.CompanyName AS [Shipping Company Name]
FROM dbo.Shippers ship
CROSS JOIN dbo.Suppliers sup
ORDER BY [Supplier Company Name], [Shipping Company Name]

-- 26. Display all the Managers who have more than 2 employees reporting to them.
WITH SubToMan AS (
    SELECT e1.FirstName + ' ' + e1.LastName  AS [Subordinate], e2.FirstName + ' ' + e2.LastName AS [Managers],
            COUNT(e1.FirstName + ' ' + e1.LastName) OVER(PARTITION BY e2.FirstName + ' ' + e2.LastName) AS [Subordinate Counts]
    FROM dbo.Employees e1
    INNER JOIN dbo.Employees e2 ON e1.ReportsTo = e2.EmployeeID
)
SELECT DISTINCT stm.Managers
FROM SubToMan stm
WHERE stm.[Subordinate Counts] > 2
