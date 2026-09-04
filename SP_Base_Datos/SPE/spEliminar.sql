IF OBJECT_ID('spEliminar') IS NOT NULL
    DROP PROCEDURE spEliminar;
GO
CREATE PROCEDURE spEliminar
    @IdExamen  INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CodRetorno INT;
    DECLARE @Descrip NVARCHAR(255);

    BEGIN TRY
        DELETE FROM dbo.tblExamen 
          WHERE  IdExamen = @IdExamen 

        SET @CodRetorno = 0;
        SET @Descrip = 'Registro eliminado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @CodRetorno = ERROR_NUMBER();
        SET @Descrip = ERROR_MESSAGE();
    END CATCH

    SELECT @CodRetorno AS CodigoRetorno,
           @Descrip AS DescripcionRetorno

END
GO