
CREATE TABLE People (
   id INT PRIMARY KEY IDENTITY(1,1), 
   first_name NVARCHAR(50) NOT NULL, 
   last_name NVARCHAR(50) NOT NULL,
   age INT, -- Age of the person
   phone_number NVARCHAR(20), 
   address NVARCHAR(100), 
);

-- Table for dogs
CREATE TABLE Dogs (
   id INT PRIMARY KEY IDENTITY(1,1), 
   name NVARCHAR(50) NOT NULL, 
   breed NVARCHAR(50), 
   age INT, 
   size DECIMAL(5,2), 
   weight DECIMAL(5,2),
   owner_id INT,
   FOREIGN KEY (owner_id) REFERENCES People(id)
);

INSERT INTO People (first_name, last_name, age, phone_number, address)
VALUES 
   ('Tintin', 'Dupont', 30, '1234567890', '123 Rue du Temple'),
   ('Asterix', 'Gaulois', 40, '9876543210', '456 Village Gaulois'),
   ('Sherlock', 'Holmes', 45, '5554443333', '123 Main St'),
   ('Hercule', 'Poirot', 50, '4443332222', '11 Rue du Luxembourg'),
   ('Gandalf', 'Le Gris', 1000, '1112223333', 'Hobbiton'),
   ('Luke', 'Skywalker', 28, '9988776655', 'Tatooine'),
   ('Harry', 'Potter', 35, '5556667777', '4 Privet Drive'),
   ('Daenerys', 'Targaryen', 32, '8887776666', 'Meereen'),
   ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
   ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

INSERT INTO Dogs (name, breed, age, size, weight, owner_id)
VALUES 
   ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1),
   ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), 
   ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), 
   ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), 
   ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5),
   ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), 
   ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7),
   ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), 
   ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, NULL),
   ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), 
   ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), 
   ('Pepette', 'Rottweiler', 6, 60.0, 40.0, 5), 
   ('Princesse', 'Dobermann', 4, 50.0, 30.0, 5), 
   ('Rex', 'Dalmatian', 2, 45.0, 25.0, 5), 
   ('Trixie', 'Poodle', 5, 30.0, 12.0, 5), 
   ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), 
   ('Pikachu', 'Corgi', 2, 25.0, 10.0, 8), 
   ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), 
   ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), 
   ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), 
   ('Max', 'Labrador', 5, 55.0, 30.0, NULL), 
   ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, 8),
   ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), 
   ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), 
   ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); 

CREATE TABLE Cat (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(50) NOT NULL,
	age INT NOT NULL, 
	color NVARCHAR(50) NOT NULL,
	owner_id INT NULL,
   FOREIGN KEY (owner_id) REFERENCES People(id)
);

CREATE TABLE RelationDogsAndCats
(
    id_cat INT NULL,
    id_dog INT NULL,
    relation_type NVARCHAR(50) NOT NULL DEFAULT 'neutral', 
    CONSTRAINT Fk_Cats FOREIGN KEY (id_cat) REFERENCES Cat(id),
    CONSTRAINT Fk_Dogs FOREIGN KEY (id_dog) REFERENCES Dogs(id),
    CONSTRAINT Chk_RelationType CHECK (relation_type IN ('loves', 'hate', 'neutral'))
);


INSERT INTO Cat (name,age, color,owner_id)
 VALUES
 ('Garfield', 5, 'orange', 9 ),
 ('Salem', 7, 'noir', 5 );

INSERT INTO RelationDogsAndCats
VALUES 
(1, 1, 'loves'),
(2,2, 'hate'),
(1,4, 'neutral');

ALTER TABLE People
ADD
    gender NVARCHAR(10) NOT NULL DEFAULT 'Other'
        CONSTRAINT CHK_Gender CHECK (gender IN ('Male', 'Female', 'Other'));


ALTER TABLE Dogs 
MODIFY 

DROP TABLE RelationDogsAndCats