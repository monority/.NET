

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

-- Exercice 
-- 1. Affichez toutes les colonnes de la table "Users" pour tous les utilisateurs.
SELECT * FROM Users;

--2. Sélectionnez les noms et prénoms des utilisateurs nés à New York ou à Paris.
SELECT first_name, last_name 
FROM Users
WHERE birth_location = 'Paris' OR birth_location = 'New York';

--3. Affichez les utilisateurs dont le travail est "Developer" ou "Designer".
SELECT * 
FROM Users
WHERE job = 'Developer' OR job = 'Designer';

--4. Sélectionnez les utilisateurs dont l'âge est supérieur à 30 ans.
SELECT *
FROM Users
WHERE age > 30;

--5. Affichez les utilisateurs dont le salaire est compris entre 2500 et 3000.
SELECT *
FROM Users
WHERE salary > 2500 and salary < 3000;

--6. Sélectionnez les utilisateurs dont le travail n'est ni "Developer" ni "Designer".
SELECT *
FROM Users
WHERE job != 'Developer' AND job != 'Designer';

--7. Affichez les utilisateurs triés par ordre alphabétique du nom de famille, puis du prénom.
SELECT first_name, last_name
FROM Users
GROUP BY last_name, first_name;

--8. Sélectionnez les utilisateurs nés avant l'année 1990.
SELECT *
FROM Users
WHERE  birth_date <=  '1990-11-20'

--9. Affichez les utilisateurs dont le lieu de naissance est "London" ou "Berlin" et dont le travail est "Designer".
SELECT *
FROM Users
WHERE birth_location IN ( 'London', 'Berlin') AND job = 'Designer';

--10. Sélectionnez les 10 utilisateurs avec les salaires les plus élevés.
SELECT TOP 10 *
FROM Users
ORDER BY salary DESC;

--11. Affichez les noms, prénoms et âges des utilisateurs nés entre 1980 et 1990.
SELECT first_name, last_name, age
FROM Users
WHERE birth_date >= '1980-01-01' AND birth_date <= '1990-01-01';

--12. Sélectionnez les utilisateurs par ordre décroissant d'âge.
SELECT * 
FROM Users
ORDER BY age DESC;

--13. Sélectionnez les utilisateurs dont le travail est "Doctor" et dont le salaire est supérieur à 3000.	
SELECT * 
FROM Users 
WHERE( job = 'Doctor' and salary> 3000);

--14. Affichez les utilisateurs triés par lieu de naissance, puis par salaire.
SELECT birth_date, salary
FROM Users
GROUP BY birth_date, salary;

--15. Sélectionnez les utilisateurs nés à Paris et dont le travail est "Lawyer".
SELECT *
FROM Users
WHERE birth_location = 'Paris' AND job = 'Lawyer';

--16. Affichez le salaire le plus bas de tout les utilisateurs en utilisant un alias.
SELECT MIN(salary) as min_salary
FROM Users;

--17. Sélectionnez les utilisateurs nés après l'année 1985 et dont le travail est "Engineer".
SELECT *
FROM Users
WHERE birth_date >= '1985-01-01' AND job = 'Engineer';

--18. Affichez les utilisateurs dont le prénom est "John" et le nom de famille est "Doe".
SELECT *
FROM Users
WHERE first_name = 'John' AND last_name = 'Doe';

--19. Sélectionnez les 6 utilisateurs dont le salaire est le plus bas en omettant les trois premiers résultats.
SELECT *
FROM Users
ORDER BY salary ASC
OFFSET 3 ROWS
FETCH NEXT 6 ROWS ONLY;

--20. Affichez les utilisateurs par ordre croissant d'âge, limités aux 5 premiers.
SELECT TOP 5 *
FROM Users
ORDER BY age ASC

--1. **Affichez le nombre d'utilisateurs par lieu de naissance, mais ne montrez que les lieux avec plus d'un' utilisateur.**
SELECT birth_location, COUNT(*) AS user_count
FROM Users
GROUP BY birth_location HAVING COUNT(*) > 1;

--2. **S�lectionnez la profession et la moyenne des salaires pour chaque profession, mais ne montrez que celles avec une moyenne de salaire sup�rieure � 2500.**
SELECT job, AVG(salary) AS average_salary
FROM Users
GROUP BY job HAVING AVG(salary) >2500;

--3. **Affichez la somme des salaires pour chaque lieu de naissance, mais ne montrez que les lieux dont la somme des salaires est sup�rieure � 5000.**
SELECT birth_location, SUM(salary) AS sum_salary
FROM Users
GROUP BY birth_location HAVING  SUM(salary)>5000;

--4. **S�lectionnez la date de naissance et le nombre d'utilisateurs n�s � chaque date, mais ne montrez que les dates o� il y a plus d'un utilisateur n�.**
SELECT birth_date, COUNT(birth_date) as birth_date_count
FROM Users 
GROUP BY birth_date HAVING COUNT(birth_date) > 1;

--5. **Affichez la profession, le lieu de naissance, et le salaire maximum pour chaque profession et lieu, mais ne montrez que les r�sultats o� le salaire maximum est sup�rieur � 3000.**
SELECT job, birth_location, MAX(salary) as max_salary
FROM Users
GROUP BY job, birth_location HAVING MAX(salary) > 3000;

-- Cr�ation de la table Clients
--CREATE TABLE Clients (
--    id INT PRIMARY KEY IDENTITY(1,1),
--    first_name NVARCHAR(100),
--    last_name NVARCHAR(100),
--    city NVARCHAR(100),
--    age INT,
--    --CONSTRAINT PK_Clients_Id PRIMARY KEY (id)
--);

-- Cr�ation de la table Abonnements
--CREATE TABLE Abonnements (
--    client_id INT, -- FOREIGN KEY (client_id) REFERENCES Clients(id),
--    abonnement_type NVARCHAR(100),
--    CONSTRAINT FK_Client_Abonnement FOREIGN KEY (client_id)
--    REFERENCES Clients(id)
--);


-- Insertion des donn�es dans la table Clients
--INSERT INTO Clients (first_name, last_name, city, age)
--VALUES 
--    ('John', 'Doe', 'New York', 34),
--    ('Alice', 'Smith', 'London', 28),
--    ('Michael', 'Johnson', 'Berlin', 40),
--    ('Emily', 'Brown', 'Paris', 25),
--    ('David', 'Lee', 'Tokyo', 31),
--    ('Sophia', 'Taylor', 'Sydney', 29),
--    ('Daniel', 'Anderson', 'Toronto', 45),
--    ('Olivia', 'Jackson', 'Rome', 38),
--    ('James', 'Moore', 'Moscow', 50),
--    ('Emma', 'Davis', 'New York', 22);

-- Insertion des donn�es dans la table Abonnements
--INSERT INTO Abonnements (client_id, abonnement_type)
--VALUES 
--    (1, 'Premium'),
--    (2, 'Standard'),
--    (3, 'Premium'),
--    (4, 'Basic'),
--    (5, 'Premium'),
--    (5, 'Standard'), -- Un client avec plusieurs abonnements
--    (6, 'Basic'),
--    (7, 'Standard'), -- le n�8 n'a pas d'abonnement
--    (9, 'Premium'),
--    (10, 'Basic');
DROP TABLE Abonnements;
DROP TABLE Clients;
