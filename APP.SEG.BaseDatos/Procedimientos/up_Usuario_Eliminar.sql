USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Eliminar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Eliminar]
  @IntIdusuario int,
  @IntCodigoMensaje int OUTPUT
AS

DECLARE @CantidadPermisoUsuario int
DECLARE @CantidadAuditoria int
DECLARE @CantidadUsuarioClave int

SELECT @CantidadPermisoUsuario = COUNT(*) FROM PermisoUsuario
WHERE IdUsuario = @IntIdusuario 

SELECT @CantidadAuditoria = COUNT(*) FROM AuditoriaUsuario
WHERE IdUsuarioAfectado = @IntIdusuario OR IdUsuarioAfectador = @IntIdusuario

SELECT @CantidadUsuarioClave = COUNT(*) FROM UsuarioClave
WHERE IdUsuario = @IntIdusuario 

IF @CantidadAuditoria = 0 AND @CantidadPermisoUsuario = 0 AND @CantidadUsuarioClave = 0
BEGIN
	
	DELETE FROM Usuario WHERE IdUsuario = @IntIdusuario

END
ELSE
BEGIN
	IF @CantidadAuditoria > 0 OR @CantidadUsuarioClave > 0
	BEGIN
		SET @IntCodigoMensaje = -1	
	END
	ELSE
	BEGIN 
		SET @IntCodigoMensaje = -2
	END		
END
GO
