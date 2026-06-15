CREATE TABLE Student (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(200),
    Age INT,
    Address VARCHAR(1000)
);
CREATE TABLE Teacher (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(200),
    CousrseName VARCHAR(200),
    Phone INT,
    Address VARCHAR(1000)
);
INSERT INTO Teacher (Name, CousrseName, Address,Phone)
VALUES ('John Doe', 'Dhinkachika', 'Dhaka',00000012121);
INSERT INTO Student (Name, Age, Address)
VALUES ('John Doe', 21, 'Dhaka');

UPDATE dbo.Student
SET Address = 'austrelia'
WHERE Name = 'chandu';

DELETE FROM dbo.Student
WHERE Name = 'John sina';

SELECT * FROM dbo.Student;