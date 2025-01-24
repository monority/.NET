CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    age INT,
    grade NVARCHAR(10)
);

INSERT INTO Students ( first_name, last_name, age, grade)
VALUES 
('Maria', 'Rodriguez', 21, 'B'),
('Ahmed', 'Khan', 21, 'A'),
('Emily', 'Baker', 22, 'C');

--DROP TABLE Students;

UPDATE Students 
SET grade = 'A'
WHERE first_name = 'Maria'

UPDATE STUDENTS
SET age = age +1;

DELETE FROM Students
WHERE first_name = 'Emily'

DELETE FROM Students
WHERE age < 20;

TRUNCATE TABLE Students;