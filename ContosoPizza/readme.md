# Readme

## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

## Setup database
Connect to database and run manually the script of init-db.sql
(PRO OPTIONs:
- https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database)
- https://www.softwaredeveloper.blog/initialize-mssql-in-docker-container

## Save database
docker commit & docker push

## Data Base

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

CREATE TABLE Ingredientes (
    idIngrediente NVARCHAR(50) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

INSERT INTO Ingredientes (idIngrediente, Nombre)
VALUES 
('0', 'Jamón'),
('1', 'Piña'),
('2', 'Tomate'),
('3', 'Pimiento'),
('4', 'Cebolla'),
('5', 'Aceitunas'),
('6', 'Pepperoni'),
('7', 'Queso Mozzarella');

CREATE TABLE Usuarios (
    idUsuario NVARCHAR(50) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(15),
    Email NVARCHAR(100)
);

INSERT INTO Usuarios (idUsuario, Nombre, Direccion, Telefono, Email)
VALUES 
('1001', 'Juan Pérez', 'Calle Principal 123', '+1234567890', 'juan@example.com'),
('1002', 'María López', 'Avenida Central 456', '+9876543210', 'maria@example.com'),
('1003', 'Carlos Rodríguez', 'Calle Secundaria 789', '+5555555555', 'carlos@example.com');

CREATE TABLE Pedidos (
    idPedido NVARCHAR(50) PRIMARY KEY,
    idUsuario NVARCHAR(50) NOT NULL,
    idPizza NVARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idPizza) REFERENCES Pizzas(idPizza)
);

INSERT INTO Pedidos (idPedido, idUsuario, idPizza, Cantidad)
VALUES 
('2001', '1001', '0', 2),
('2002', '1002', '1', 1),
('2003', '1003', '2', 3);

SELECT * FROM Pizzas;