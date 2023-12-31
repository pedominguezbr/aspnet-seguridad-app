USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoObjeto_Eliminar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoObjeto_Eliminar]
  @IntIdPermisoObjeto int,
  @IntCodigoError INT OUTPUT
AS

DECLARE @CantidadPermisos INT
DECLARE @IdAplicacion INT
DECLARE @IdRol INT

SELECT @IdAplicacion = IdAplicacion FROM PermisoObjeto WHERE IdPermisoObjeto = @IntIdPermisoObjeto
SELECT @IdRol = IdRol FROM PermisoObjeto WHERE IdPermisoObjeto = @IntIdPermisoObjeto

SELECT @CantidadPermisos = COUNT(*) FROM PermisoObjeto WHERE IdObjeto IN (
SELECT IdObjeto FROM Objeto
WHERE IdObjetoPadre = (SELECT IdObjeto FROM PermisoObjeto WHERE IdPermisoObjeto = @IntIdPermisoObjeto)
) AND IdAplicacion = @IdAplicacion AND IdRol = @IdRol

IF @CantidadPermisos > 0 --TIENE HIJOS, NO SE PUEDE ELIMINAR. PRIMERO DEBE ELIMINAR LOS PERMISOS DE LOS HIJOS
BEGIN
	SET @IntCodigoError = -1
END
ELSE
BEGIN
	DELETE FROM PermisoObjeto
	WHERE
	 IdPermisoObjeto = @IntIdPermisoObjeto
	 
	SET @IntCodigoError = 0 
END
GO
