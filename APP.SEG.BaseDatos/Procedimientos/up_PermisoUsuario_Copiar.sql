USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoUsuario_Copiar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoUsuario_Copiar]
	@VchCodigoUsuarioCopiar VARCHAR(30),
	@IntIdUsuario int,
	@IntCodigoError int OUTPUT
AS
BEGIN

DECLARE @IdUsuarioCopiar int
SET @IdUsuarioCopiar = -1;

	SELECT @IdUsuarioCopiar = IdUsuario FROM Usuario
	WHERE CodigoUsuario = @VchCodigoUsuarioCopiar AND EstadoUsuario = 1
	
	IF @IdUsuarioCopiar = -1
	BEGIN
		SET @IntCodigoError = -1;--USUARIO NO EXISTE
	END
	ELSE
	BEGIN
		
		DELETE FROM PermisoUsuario WHERE IdUsuario = @IntIdUsuario
	
		INSERT INTO PermisoUsuario (IdUsuario, IdRol, IdAplicacion, IdUsuarioCreacion, FechaCreacion, Estado) 
		SELECT     @IntIdUsuario, IdRol, IdAplicacion, IdUsuarioCreacion, FechaCreacion, Estado
		FROM         PermisoUsuario
		WHERE     (IdUsuario = @IdUsuarioCopiar)
		
		SET @IntCodigoError = 0;
	END
END
GO
