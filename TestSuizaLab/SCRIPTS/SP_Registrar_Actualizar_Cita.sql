SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Registrar_Actualizar_Cita]
(
@Cod_operacion INT,
@doc_paciente INT,
@tipodoc INT,
@nombre NVARCHAR(MAX),
@espec_paciente NVARCHAR(MAX),
@fecha_cita_paciente DATETIME,
@ReturnCode NVARCHAR(20) OUTPUT
)
AS
BEGIN
    SET @ReturnCode = '0'
    IF (@Cod_operacion = 1)
        BEGIN
            IF EXISTS (SELECT 1 FROM PACIENTES_CITAS WHERE Documento = @doc_paciente AND Tipo_Documento = @tipodoc AND Especialidad = @espec_paciente AND Fecha_Cita = @fecha_cita_paciente)
                BEGIN    

                    UPDATE PACIENTES_CITAS SET
                    Especialidad = @espec_paciente,
                    Fecha_Cita = @fecha_cita_paciente
                    WHERE Documento = @doc_paciente,
                    Tipo_Documento = @tipodoc,
                    Especialidad = @espec_paciente,
                    Fecha_Cita = @fecha_cita_paciente

                    SET @ReturnCode = '1'
                    RETURN
                END
            ELSE
                BEGIN
                    SET @ReturnCode = '2'
                    RETURN
                END
            END    
        END
    ELSE
        BEGIN
        IF EXISTS (SELECT 1 FROM PACIENTES_CITAS WHERE Documento = @doc_paciente AND Tipo_Documento = @tipodoc AND Especialidad = @espec_paciente AND Fecha_Cita = @fecha_cita_paciente)
            BEGIN
                SET @ReturnCode = '3'
                RETURN
            END
        ELSE
            BEGIN
            INSERT INTO PACIENTES_CITAS 
            VALUES (@doc_paciente,@tipodoc,@nombre,@espec_paciente,@fecha_cita_paciente)
            END    
        END    
    END    
    SELECT @ReturnCode as 'Resultado'
END
