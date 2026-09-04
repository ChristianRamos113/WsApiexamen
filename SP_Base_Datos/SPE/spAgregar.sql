IF OBJECT_ID('spAgregar') IS NOT NULL
    DROP PROCEDURE spAgregar; 
GO
    CREATE PROCEDURE spAgregar
    @Nombre NVARCHAR(255),
    @Descripcion NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CodRetorno INT;
    DECLARE @Descrip NVARCHAR(255);

    BEGIN TRY
        INSERT INTO dbo.tblExamen (Nombre, Descripcion)
        VALUES (@Nombre, @Descripcion);

        SET @CodRetorno = 0;
        SET @Descrip = 'Registro insertado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @CodRetorno = ERROR_NUMBER();
        SET @Descrip = ERROR_MESSAGE();
    END CATCH

    SELECT @CodRetorno AS CodigoRetorno,
           @Descrip AS DescripcionRetorno

END
GO