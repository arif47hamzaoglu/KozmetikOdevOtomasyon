-- Kozmetik Otomasyon Sistemi - Veritabanı Script
-- Uygulama başlarken bu tabloları otomatik oluşturur.
-- Manuel kurmak isterseniz MySQL Workbench'te çalıştırın.

CREATE DATABASE IF NOT EXISTS kozmetik_db;
USE kozmetik_db;

CREATE TABLE IF NOT EXISTS Users (
    Id       INT AUTO_INCREMENT PRIMARY KEY,
    Name     VARCHAR(100) NOT NULL,
    Email    VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Products (
    Id    INT AUTO_INCREMENT PRIMARY KEY,
    Name  VARCHAR(100)  NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT           NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Orders (
    Id         INT AUTO_INCREMENT PRIMARY KEY,
    UserId     INT           NOT NULL,
    ProductId  INT           NOT NULL,
    Quantity   INT           NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    OrderDate  DATETIME      NOT NULL,
    Status     VARCHAR(20)   NOT NULL DEFAULT 'Beklemede',
    FOREIGN KEY (UserId)    REFERENCES Users(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Admin kullanıcı (email: admin@admin.com / şifre: 123456)
INSERT IGNORE INTO Users (Name, Email, Password)
VALUES ('Admin', 'admin@admin.com', '123456');

-- Örnek ürünler
INSERT IGNORE INTO Products (Name, Price, Stock) VALUES
('Chanel No.5 EDP 100ml',        2499.90, 15),
('Dior Sauvage EDT 75ml',        1899.90, 20),
('Versace Eros EDP 50ml',        1299.90, 30),
('Carolina Herrera Good Girl 80ml', 1749.90, 12),
('Yves Saint Laurent Black Opium 90ml', 1599.90, 18);
