USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Auditoriausuario_Insertar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Auditoriausuario_Insertar]
  @IntIdusuarioafectado int,
  @IntIdusuarioafectador int,
  @IntIdtipooperacion int,
  @VchObservacion varchar (150)
AS
INSERT INTO AuditoriaUsuario
(
 IdUsuarioAfectado,
 IdUsuarioAfectador,
 IdTipoOperacion,
 Observacion,
 FechaHora,
 EstadoAuditoria
)
VALUES
(
  @IntIdusuarioafectado,
  @IntIdusuarioafectador,
  @IntIdtipooperacion,
  @VchObservacion,
  GETDATE(),
  1
)
GO
