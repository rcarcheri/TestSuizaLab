SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Listar_Cita]
@doc_paciente INT
AS
BEGIN
    SELECT * FROM PACIENTES_CITAS WHERE Documento = @doc_paciente ORDER BY Tipo_Documento, Documento ASC
END