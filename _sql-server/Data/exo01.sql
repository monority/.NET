

SELECT * FROM [Users];
SELECT * FROM Users;
SELECT name, database_id, create_date FROM sys.databases;
SELECT name FROM sys.tables;
SELECT first_name FROM Users;
SELECT first_name, job, last_name FROM Users;
SELECT * FROM Users WHERE age > 29;

-- Exercice01
SELECT * FROM Users WHERE job != 'Developer';

SELECT * FROM Users WHERE first_name = 'John';

SELECT * FROM Users WHERE salary >= 3000;

SELECT * FROM USERS WHERE age < 30 OR age >= 35;

SELECT * FROM USERS WHERE job = 'Teacher' AND salary > 2500;

-- Exercice 02
SELECT first_name, last_name, birth_location, job
FROM Users 
WHERE birth_location = 'New York' AND (job = 'Teacher') OR job = 'Developer';

-- Exercice 03
SELECT * 
FROM Users
WHERE 
birth_location = 'New York'
AND (salary > 3000 AND salary < 3500)
AND NOT (job = 'Doctor' OR  job = 'Lawyer');

-- Insertion de données
INSERT INTO Users (first_name, last_name, job, birth_date, birth_location, age, salary)
VALUES ('Theo', 'Martin', 'Developer', '1980-07-15', 'New York', 29 , 3500);

SELECT DISTINCT job, first_name 
FROM Users;

SELECT first_name, last_name
FROM Users
WHERE birth_location IN ('Paris','London');

SELECT first_name, last_name
FROM Users
WHERE birth_location NOT IN ('Paris','London');

SELECT * FROM Users WHERE job = 'Engineer';

SELECT first_name, last_name
FROM Users
WHERE birth_location IN ('Paris', 'London', 'Berlin');

SELECT * 
FROM Users
WHERE age BETWEEN 25 AND 35;

SELECT * 
FROM Users
WHERE (job = 'Developer' AND salary > 2500);

SELECT * 
FROM USERS
ORDER BY last_name, age ASC;

SELECT TOP 5 first_name, last_name, salary
FROM Users
ORDER BY salary ASC;

SELECT first_name, last_name, salary
FROM Users
ORDER BY salary DESC 
OFFSET 5 ROWS
FETCH NEXT 5 ROWS ONLY;

SELECT TOP 5 first_name, last_name, age
FROM Users
ORDER BY age DESC;

SELECT *
FROM Users
ORDER BY first_name ASC
OFFSET 6 ROWS
FETCH NEXT 4 ROWS ONLY;

SELECT TOP 3 * 
FROM Users
ORDER BY salary DESC;

SELECT MIN(age) AS min_age
FROM Users;
SELECT MAX(age) AS max_age
FROM Users;

SELECT COUNT(*) AS total_users
FROM Users;


SELECT MIN(salary) AS salaire_min
FROM Users;

SELECT MAX(age) as max_age_enginner
FROM Users 
WHERE job = 'Engineer';

SELECT AVG(salary) as average_salary
FROM Users
WHERE job = 'Teacher';

SELECT SUM(salary) as total_salary
FROM Users;


SELECT birth_location, SUM(salary) as salary_bytown
FROM USERS 
GROUP BY birth_location