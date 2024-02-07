 CREATE DATABASE PizzasDB;

USE PizzasDB;

    -- Aquí colocas la creación de la tabla
    CREATE TABLE Pizzas (
        idPizza NVARCHAR(50) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Price DECIMAL(18, 2) NOT NULL
    );

INSERT INTO Pizzas (idPizza, Nombre, Price)
VALUES 
('0', 'Pizza Hawaiana', 15.50),
('1', 'Pizza Vegetariana', 13.75),
('2', 'Pizza Pepperoni', 15.75);

SELECT * FROM Pizzas;