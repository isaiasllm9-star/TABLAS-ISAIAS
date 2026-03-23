-- SQL Script para el sistema FitLife - Enfoque en Miembros

-- Crear Tabla Miembros
CREATE TABLE IF NOT EXISTS Miembros (
    cedula TEXT PRIMARY KEY,
    nombre_completo TEXT NOT NULL,
    telefono TEXT NOT NULL
);

-- Insertar Datos de Prueba Iniciales
INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ('101', 'Juan Pérez', '123-4567');
INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ('102', 'María Rodríguez', '234-5678');
INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ('103', 'Carlos Sánchez', '345-6789');
INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ('104', 'Lucía López', '456-7890');
INSERT INTO Miembros (cedula, nombre_completo, telefono) VALUES ('105', 'Mario González', '567-8901');
