-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS InvoiceDB;
USE InvoiceDB;

-- Crear la tabla Client
CREATE TABLE Client (
    Code INT PRIMARY KEY AUTO_INCREMENT, -- Código autoincrementado como clave primaria
    Name VARCHAR(100) NOT NULL, -- Nombre del cliente
    DniNif VARCHAR(20) NOT NULL UNIQUE, -- DNI/NIF único
    IsProfessional BOOLEAN NOT NULL, -- Tipo de cliente: profesional o particular
    Discount INT, -- Descuento, permite valores NULL
    RegistrationDate DATE NOT NULL, -- Fecha de alta del cliente
    TotalAnnualSales DECIMAL(10, 2) -- Ventas anuales totales, permite valores NULL
);

-- Crear la tabla Invoice
CREATE TABLE Invoice (
    InvoiceNumber INT PRIMARY KEY AUTO_INCREMENT, -- Número de factura autoincrementado como clave primaria
    Code INT NOT NULL, -- Código del cliente asociado
    InvoiceDate DATE NOT NULL, -- Fecha de la factura
    Pvp DECIMAL(10, 2) NOT NULL, -- Precio sin descuento ni IVA
    DiscountedPrice DECIMAL(10, 2) NOT NULL, -- Precio con descuento aplicado
    FinalPrice DECIMAL(10, 2) NOT NULL, -- Precio final con IVA incluido
    Paid BOOLEAN NOT NULL, -- Si la factura ha sido pagada o no
    FOREIGN KEY (Code) REFERENCES Client(Code) -- Relación con la tabla Client
);

-- Insertar algunos clientes en la tabla Client
INSERT INTO Client (Name, DniNif, IsProfessional, Discount, RegistrationDate, TotalAnnualSales)
VALUES 
('John Smith', '12345678Z', TRUE, 10, '2023-01-01', 5000.00),
('Jane Doe', '87654321Y', FALSE, NULL, '2023-02-15', 3000.00),
('Carlos Ruiz', '12341234X', TRUE, 15, '2023-03-10', 12000.00),
('Ana Pérez', '43214321W', FALSE, 5, '2023-04-20', NULL);

-- Insertar algunas facturas en la tabla Invoice
INSERT INTO Invoice (Code, InvoiceDate, Pvp, DiscountedPrice, FinalPrice, Paid)
VALUES 
(1, '2023-09-30', 100.00, 90.00, 108.90, FALSE), -- Factura para John Smith
(2, '2023-09-15', 200.00, 200.00, 242.00, TRUE), -- Factura para Jane Doe
(3, '2023-09-10', 300.00, 255.00, 306.90, FALSE), -- Factura para Carlos Ruiz
(4, '2023-09-05', 150.00, 142.50, 172.43, TRUE); -- Factura para Ana Pérez

-- Mostrar los datos insertados en las tablas
SELECT * FROM Client;
SELECT * FROM Invoice;
