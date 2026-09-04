-- Se genera Creacion de la tabla tblExamen

CREATE TABLE tblExamen (
    IdExamen INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,    
    Descripcion NVARCHAR(255) NOT NULL
);