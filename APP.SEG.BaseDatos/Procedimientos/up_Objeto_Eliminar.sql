USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Objeto_Eliminar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Objeto_Eliminar]
  @IntIdObjeto int,
  @IntCodigoMensaje int OUTPUT
AS

DECLARE @CantidadPermisoObjeto int
DECLARE @CantidadObjetosHijos int

SELECT @CantidadPermisoObjeto = COUNT(*) FROM PermisoObjeto
WHERE IdObjeto = @IntIdObjeto 

SELECT @CantidadObjetosHijos = COUNT(*) FROM Objeto
WHERE IdObjetoPadre = @IntIdObjeto 

IF @CantidadPermisoObjeto = 0 AND @CantidadObjetosHijos = 0
BEGIN
	
	DELETE FROM Objeto WHERE IdObjeto = @IntIdObjeto

END
ELSE
BEGIN
	IF @CantidadObjetosHijos > 0
	BEGIN
		SET @IntCodigoMensaje = -1--NO SE PUEDE ELIMINAR DEBIDO A QUE TIENE HIJOS
	END
	ELSE
	BEGIN
		SET @IntCodigoMensaje = -2--NO SE PUEDE ELIMINAR DEBIDO A QUE HAY PERMISOS ASOCIADOS
	END
END
GO
