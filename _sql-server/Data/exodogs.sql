-- Cr�ation de la table Personne
CREATE TABLE Personne (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    first_name NVARCHAR(50) NOT NULL,     -- Pr�nom
    last_name NVARCHAR(50) NOT NULL,      -- Nom
    age INT NOT NULL,                     -- �ge
    phone_number NVARCHAR(20),            -- Num�ro de t�l�phone
    address NVARCHAR(100)                 -- Adresse
);

-- Cr�ation de la table Chien
CREATE TABLE Chien (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    name NVARCHAR(50) NOT NULL,           -- Nom du chien
    breed NVARCHAR(50),                   -- Race
    age INT,                              -- �ge
    size DECIMAL(5,2),                    -- Taille (en cm)
    weight DECIMAL(5,2),                  -- Poids (en kg)
    id_maitre INT NULL,                   -- Identifiant du ma�tre (cl� �trang�re)
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

-- Insertion de donn�es dans la table Chien
INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
VALUES 
    ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1), -- Li� � Tintin Dupont
    ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), -- Li� � Asterix Gaulois
    ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), -- Li� � Sherlock Holmes
    ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), -- Li� � Hercule Poirot
    ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5), -- Li� � Gandalf Le Gris
    ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), -- Li� � Luke Skywalker
    ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7), -- Li� � Harry Potter
    ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), -- Li� � Daenerys Targaryen
    ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, 9), -- Li� � Frodo Baggins
    ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), -- Li� � Waldo Rosenbaum
    ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), -- Pas de ma�tre
    ('Pepette', 'Rottweiler', 6, 60.0, 40.0, NULL), -- Pas de ma�tre
    ('Princesse', 'Dobermann', 4, 50.0, 30.0, NULL), -- Pas de ma�tre
    ('Rex', 'Dalmatian', 2, 45.0, 25.0, NULL), -- Pas de ma�tre
    ('Trixie', 'Poodle', 5, 30.0, 12.0, NULL), -- Pas de ma�tre
    ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), -- Pas de ma�tre
    ('Pikachu', 'Corgi', 2, 25.0, 10.0, NULL), -- Pas de ma�tre
    ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), -- Pas de ma�tre
    ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), -- Pas de ma�tre
    ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), -- Pas de ma�tre
    ('Max', 'Labrador', 5, 55.0, 30.0, NULL), -- Pas de ma�tre
    ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, NULL), -- Pas de ma�tre
    ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), -- Pas de ma�tre
    ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), -- Pas de ma�tre
    ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); -- Pas de ma�tre


INSERT INTO Personne (first_name, last_name, age, phone_number, address)
VALUES     ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
    ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

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

    
SELECT TOP 3 breed, COUNT(*) AS breed_count
FROM Chien
INNER JOIN Personne ON Personne.id = Chien.id_maitre
GROUP BY breed
ORDER BY breed_count DESC; 
