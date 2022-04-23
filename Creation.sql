CREATE DATABASE gmapdb;
GO

USE gmapdb;
CREATE TABLE markers
(
	id INT PRIMARY KEY IDENTITY,
	name VARCHAR(30) NOT NULL,
	lat FLOAT NOT NULL,
	lng FLOAT NOT NULL
);

INSERT markers (name, lat, lng)
VALUES 
('Грузовик 1', 54.7, 82.9),
('Грузовик 2', 54.3, 82.4),
('Грузовик 3', 54.9, 82.6),
('Грузовик 4', 54.2, 82.9),
('Грузовик 5', 54.7, 82.3);