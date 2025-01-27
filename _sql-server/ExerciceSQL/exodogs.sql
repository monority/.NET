-- Création de la table Personne
CREATE TABLE Personne (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    first_name NVARCHAR(50) NOT NULL,     -- Prénom
    last_name NVARCHAR(50) NOT NULL,      -- Nom
    age INT NOT NULL,                     -- Âge
    phone_number NVARCHAR(20),            -- Numéro de téléphone
    address NVARCHAR(100)                 -- Adresse
);

-- Création de la table Chien
CREATE TABLE Chien (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    name NVARCHAR(50) NOT NULL,           -- Nom du chien
    breed NVARCHAR(50),                   -- Race
    age INT,                              -- Âge
    size DECIMAL(5,2),                    -- Taille (en cm)
    weight DECIMAL(5,2),                  -- Poids (en kg)
    id_maitre INT NULL,                   -- Identifiant du maître (clé étrangère)
    CONSTRAINT FK_Personne_Chien FOREIGN KEY (id_maitre) REFERENCES Personne(id)
);

INSERT INTO Personne (first_name, last_name, age, phone_number, address)
VALUES 
    ('Tintin', 'Dupont', 30, '1234567890', '123 Rue du Temple'),
    ('Asterix', 'Gaulois', 40, '9876543210', '456 Village Gaulois'),
    ('Sherlock', 'Holmes', 45, '5554443333', '221B Baker Street'),
    ('Hercule', 'Poirot', 50, '4443332222', '11 Rue du Luxembourg'),
    ('Gandalf', 'Le Gris', 1000, '1112223333', 'Hobbiton'),
    ('Luke', 'Skywalker', 28, '9988776655', 'Tatooine'),
    ('Harry', 'Potter', 35, '5556667777', '4 Privet Drive'),
    ('Daenerys', 'Targaryen', 32, '8887776666', 'Meereen'),
    ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
    ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

-- Insertion de données dans la table Chien
INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
VALUES 
    ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1), -- Lié à Tintin Dupont
    ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), -- Lié à Asterix Gaulois
    ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), -- Lié à Sherlock Holmes
    ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), -- Lié à Hercule Poirot
    ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5), -- Lié à Gandalf Le Gris
    ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), -- Lié à Luke Skywalker
    ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7), -- Lié à Harry Potter
    ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), -- Lié à Daenerys Targaryen
    ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, 9), -- Lié à Frodo Baggins
    ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), -- Lié à Waldo Rosenbaum
    ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), -- Pas de maître
    ('Pepette', 'Rottweiler', 6, 60.0, 40.0, NULL), -- Pas de maître
    ('Princesse', 'Dobermann', 4, 50.0, 30.0, NULL), -- Pas de maître
    ('Rex', 'Dalmatian', 2, 45.0, 25.0, NULL), -- Pas de maître
    ('Trixie', 'Poodle', 5, 30.0, 12.0, NULL), -- Pas de maître
    ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), -- Pas de maître
    ('Pikachu', 'Corgi', 2, 25.0, 10.0, NULL), -- Pas de maître
    ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), -- Pas de maître
    ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), -- Pas de maître
    ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), -- Pas de maître
    ('Max', 'Labrador', 5, 55.0, 30.0, NULL), -- Pas de maître
    ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, NULL), -- Pas de maître
    ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), -- Pas de maître
    ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), -- Pas de maître
    ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); -- Pas de maître


INSERT INTO Personne (first_name, last_name, age, phone_number, address)
VALUES     ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
    ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

    DROP TABLE Chien;
    DROP TABLE Personne;
    SELECT Chien.name, Chien.weight, Chien.breed
    FROM Chien;

    SELECT Personne.first_name, Personne.last_name
    FROM Personne

    SELECT *
    FROM Chien
    WHERE id_maitre IS NULL;

    SELECT *
FROM Chien
WHERE breed = 'Labrador';

SELECT Chien.name, Personne.last_name, Personne.first_name
FROM Chien
INNER JOIN Personne ON Personne.id = Chien.id_maitre

SELECT * 
FROM Personne
INNER JOIN Chien ON Personne.id = Chien.id WHERE Chien.weight > 20;

SELECT *
FROM Personne
LEFT JOIN Chien ON Personne.id = Chien.id_maitre;

SELECT c.name, ISNULL (p.first_name, 'None') AS 'Owner'
FROM Chien c
LEFT JOIN Personne p  ON p.id = c.id_maitre;

SELECT *
FROM Chien c
FULL OUTER JOIN Personne p
ON p.id = c.id_maitre

SELECT *
FROM Chien C
WHERE c.weight > 10 AND c.weight < 30;

SELECT p.first_name AS 'Person', SUM(c.weight) AS 'total_weight_owned_dog'
FROM Personne p
INNER JOIN Chien c ON c.id_maitre = p.id
GROUP BY p.first_name 

SELECT TOP 3 c.*, p.first_name, p.last_name
FROM Chien c
INNER JOIN Personne p ON c.id_maitre = p.id
ORDER BY c.weight DESC;

    SELECT *
    FROM Personne p 
    INNER JOIN Chien c ON c.id_maitre = p.id
    WHERE c.id_maitre IS  NOT NULL AND p.age > 40;

    SELECT p.first_name, p.last_name
    FROM Personne p 
    LEFT JOIN Chien c ON  c.id_maitre = p.id
    WHERE c.id_maitre IS NULL;

SELECT TOP 3 breed, COUNT(*) AS breed_count
FROM Chien
GROUP BY breed
ORDER BY breed_count DESC;

    
SELECT p.first_name, p.last_name, COUNT(c.breed) AS dog_count
FROM Chien c
INNER JOIN Personne p ON p.id = c.id_maitre
GROUP BY p.first_name, p.last_name
HAVING COUNT(c.breed) >= 2
ORDER BY dog_count DESC;

SELECT p.first_name, p.last_name, c.name
FROM Chien c
FULL OUTER JOIN Personne p ON p.id = c.id_maitre
WHERE c.id_maitre IS NULL 

SELECT p.first_name, p.last_name, SUM(c.size) AS sum_size
FROM Personne p 
INNER JOIN Chien c ON p.id = c.id_maitre
GROUP BY p.first_name, p.last_name

INSERT INTO Personne (first_name, last_name, age, phone_number, address)
VALUES     ('Arya', 'Stark', 18, '1231231234', 'Winterfell')

INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
VALUES 
    ('Nymeria', 'Loup géant', 3, 120, 60, 13);

UPDATE Chien
SET weight = 9
WHERE name = 'Milou';

UPDATE Personne
SET address = 'Dragonstone'
WHERE Personne.first_name = 'Daenerys';

UPDATE Chien
SET Chien.id_maitre = 3
WHERE  id_maitre IS NULL;

DELETE FROM Chien
WHERE Chien.weight < 5;

DELETE FROM Personne
INNER JOIN Chien ON Chien.id_maitre = Personne.id
WHERE Personne.first_name = 'Waldo'

TRUNCATE TABLE Chien;

-- Correction

-- 1.
SELECT [name], [breed], [weight]
FROM [Dogs];

-- 2.

-- 3.

-- 4.

-- 5.

-- 6.

-- 7.

-- 8.

-- 9.

-- 10.

-- 11.

-- 12.


