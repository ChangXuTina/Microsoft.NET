Use AdventureWorks2019;

-- 1
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product

-- 2
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice != 0

-- 3
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL

-- 4
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

-- 5
SELECT Name + ' ' + Color [Name and Color]
FROM Production.Product
WHERE Color IS NOT NULL

-- 6
SELECT 'NAME: ' + Name + ' -- COLOR: ' + Color
FROM Production.Product
WHERE Name LIKE '%Crankarm' OR NAME LIKE 'Chainring%'
ORDER BY ProductID

-- 8
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500

-- 9
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color in ('Black', 'Blue')

-- 10
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'

-- 12
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE '[AS]%'
ORDER BY Name

-- 13
SELECT Name
FROM Production.Product
WHERE Name LIKE 'SPO[^K]%'
ORDER BY Name

-- 14
SELECT DISTINCT Color
FROM Production.Product
ORDER BY Color DESC