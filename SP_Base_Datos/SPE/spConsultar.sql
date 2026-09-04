IF OBJECT_ID('spConsultar') IS NOT NULL
    DROP PROCEDURE spConsultar;
GO

CREATE PROCEDURE spConsultar
AS
BEGIN
    SET NOCOUNT ON;

      SELECT 
        IdExamen as IdExamen, 
        Nombre as Nombre, 
        Descripcion as Descripcion
      FROM dbo.tblExamen

END