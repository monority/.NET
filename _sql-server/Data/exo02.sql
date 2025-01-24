﻿CREATE TABLE Clients (
    id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100),
    last_name NVARCHAR(100),
    city NVARCHAR(100),
    age INT
);

CREATE TABLE Abonnements (
    client_id INT,
    abonnement_type NVARCHAR(100),
    CONSTRAINT FK_Client_Abonnement FOREIGN KEY (client_id)
    REFERENCES Clients(id)
);

INSERT INTO Clients (first_name, last_name, city, age)
VALUES 
    ('John', 'Doe', 'New York', 34),
    ('Alice', 'Smith', 'London', 28),
    ('Michael', 'Johnson', 'Berlin', 40),
    ('Emily', 'Brown', 'Paris', 25),
    ('David', 'Lee', 'Tokyo', 31),
    ('Sophia', 'Taylor', 'Sydney', 29),
    ('Daniel', 'Anderson', 'Toronto', 45),
    ('Olivia', 'Jackson', 'Rome', 38),
    ('James', 'Moore', 'Moscow', 50),
    ('Emma', 'Davis', 'New York', 22);

INSERT INTO Abonnements (client_id, abonnement_type)
VALUES 
    (1, 'Premium'),
    (2, 'Standard'),
    (3, 'Premium'),
    (4, 'Basic'),
    (5, 'Premium'),
    (5, 'Standard'),
    (6, 'Basic'),
    (7, 'Standard'),
    (9, 'Premium'),
    (10, 'Basic');

    CREATE TABLE Purchases (
    client_id INT,                    -- Cl� �trang�re vers la table Clients
    product NVARCHAR(100),            -- Nom du produit achet�
    amount DECIMAL(10, 2),            -- Montant de l'achat
    CONSTRAINT FK_Client_Purchases FOREIGN KEY (client_id) REFERENCES Clients(id) -- Contrainte de cl� �trang�re
);

-- Insertion des donn�es dans la table Purchases
INSERT INTO Purchases (client_id, product, amount)
VALUES 
    (1, 'Laptop', 1200.50),           -- Achat par le client 1
    (1, 'Keyboard', 45.99),           -- Achat par le client 1
    (2, 'Smartphone', 800.00),        -- Achat par le client 2
    (2, 'Earbuds', 29.99),            -- Achat par le client 2
    (3, 'Tablet', 300.00),            -- Achat par le client 3
    (3, 'Cover', 20.00),              -- Achat par le client 3
    (4, 'TV', 500.00),                -- Achat par le client 4
    (4, 'HDMI Cables', 10.00),        -- Achat par le client 4
    (1, 'Mouse', 25.50),              -- Achat suppl�mentaire pour le client 1
    (5, 'Gaming Console', 450.00);    -- Achat par le client 5


    SELECT c.first_name, c.last_name, p.product, p.amount
FROM Clients c
INNER JOIN Purchases p ON p.client_id = c.id;

SELECT Clients.first_name, Purchases.amount,Purchases.product
FROM Clients
LEFT JOIN Purchases ON Purchases.client_id = Clients.id;

SELECT *
FROM Purchases
RIGHT JOIN Clients ON Clients.id = Purchases.client_id;

