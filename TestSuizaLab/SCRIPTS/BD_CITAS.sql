CREATE DataBase CITAS
USE CITAS
GO

CREATE TABLE PACIENTES_CITAS
    (Documento int PRIMARY KEY NOT NULL,
    Tipo_Documento int NOT NULL,
    Nombre varchar(100) NOT NULL,
    Especialidad varchar(50) NOT NULL,
    Fecha_Cita DATETIME NOT NULL)
GO

INSERT INTO PACIENTES_CITAS 
VALUES (70707070 ,1, 'Jesus Manuel Lopez Romero', 'Odontologia', '2023-09-08 10:00:00'),
(20202005,1, 'Maria Jimenez Lopez', 'Cardiologia', '2023-09-08 10:30:00')



