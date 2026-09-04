
-- Se Crea la base de datos en caso de no existir
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BdiExamen')
BEGIN
    CREATE DATABASE BdiExamen;
END
GO