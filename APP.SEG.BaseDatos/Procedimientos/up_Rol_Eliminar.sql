USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Rol_Eliminar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Rol_Eliminar]
  @IntIdrol int,
  @IntCodigoMensaje int OUTPUT
AS

DECLARE @CantidadPermisoObjeto int
DECLARE @CantidadPermisoUsuario int

SELECT @CantidadPermisoObjeto = COUNT(*) FROM PermisoObjeto
WHERE IdRol = @IntIdrol 

SELECT @CantidadPermisoUsuario = COUNT(*) FROM PermisoUsuario
WHERE IdRol = @IntIdrol 

IF @CantidadPermisoObjeto = 0 AND @CantidadPermisoUsuario = 0
BEGIN

	DELETE FROM Rol
	WHERE
	 IdRol = @IntIdrol

END
ELSE
	BEGIN
	IF @CantidadPermisoObjeto > 0
	BEGIN
		SET @IntCodigoMensaje = -1
	END
	ELSE
	BEGIN
		SET @IntCodigoMensaje = -2
	END	
END
GO
