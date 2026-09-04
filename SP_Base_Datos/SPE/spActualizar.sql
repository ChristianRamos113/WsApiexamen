IF OBJECT_ID('spActualizar') IS NOT NULL
    DROP PROCEDURE spActualizar;
GO
CREATE PROCEDURE spActualizar
    @Id INT,
    @Nombre NVARCHAR(255),
    @Descripcion NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CodRetorno INT;
    DECLARE @Descrip NVARCHAR(255);

    BEGIN TRY
     IF NOT EXISTS (
            SELECT 1
            FROM dbo.tblExamen
            WHERE IdExamen = @Id
        )
        BEGIN
            SET @CodRetorno = 1;
            SET @Descrip = 'Registro no localizado';
        END
        ELSE
        BEGIN
        UPDATE dbo.tblExamen 
          SET Nombre = @Nombre,
              Descripcion = @Descripcion
          WHERE  IdExamen = @Id

        SET @CodRetorno = 0;
        SET @Descrip = 'Registro insertado satisfactoriamente';
     END
    END TRY
    BEGIN CATCH
        SET @CodRetorno = ERROR_NUMBER();
        SET @Descrip = ERROR_MESSAGE();
    END CATCH

    SELECT @CodRetorno AS CodigoRetorno,
           @Descrip AS DescripcionRetorno

END
GO