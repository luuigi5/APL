CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Reservations (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50),
    idUser INT NOT NULL,
    idStructure INT NOT NULL,
    revenue DECIMAL(10,2) NOT NULL,
    startDate VARCHAR(50) NOT NULL,
    endDate VARCHAR(50) NOT NULL,
    FOREIGN KEY (idUser) REFERENCES Users(id) ON DELETE CASCADE,
    FOREIGN KEY (idStructure) REFERENCES Structures(id) ON DELETE CASCADE
);

CREATE TABLE Structures(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50), 
    idUser INT NOT NULL,
    type VARCHAR(50), 
    rooms INT,
    FOREIGN KEY (idUser) REFERENCES Users(id) ON DELETE CASCADE,
);