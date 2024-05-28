SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Eliminar_Cita]
(
@doc_paciente INT,
@tipodoc INT,
@espec_paciente NVARCHAR(MAX),
@fecha_cita_paciente DATETIME,
@ReturnCode NVARCHAR(20) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET @ReturnCode = '0'
    IF NOT EXISTS (SELECT 1 FROM PACIENTES_CITAS WHERE Documento = @doc_paciente AND Tipo_Documento = @tipodoc AND Especialidad = @espec_paciente AND Fecha_Cita = @fecha_cita_paciente)
    BEGIN
        SET @ReturnCode ='1'
        RETURN
    END
    ELSE
    BEGIN
        DELETE FROM PACIENTES_CITAS 
        WHERE Documento = @doc_paciente,
        Tipo_Documento = @tipodoc,
        Especialidad = @espec_paciente,
        Fecha_Cita = @fecha_cita_paciente 
    END
    SELECT @ReturnCode as 'Resultado'
END