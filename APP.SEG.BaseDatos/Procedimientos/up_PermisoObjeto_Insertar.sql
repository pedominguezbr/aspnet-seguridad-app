USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoObjeto_Insertar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoObjeto_Insertar]
  @IntIdpermisoobjeto int OUTPUT,
  @IntIdObjeto int,
  @IntIdRol int,
  @IntIdAplicacion int,
  @BitEstadoPermisoObjeto bit,
  @DtmFechaCreacion datetime,
  @IntCodigoError int OUTPUT
AS

DECLARE @IdObjetoPadre int
DECLARE @CantidadPermisos int


SELECT @IdObjetoPadre = ISNULL(IdObjetoPadre, -1) FROM Objeto WHERE IdObjeto = @IntIdobjeto

IF @IdObjetoPadre <> -1 --TIENE PADRE, HAY QUE VERIFICAR SI EL PADRE TIENE PERMISOS
BEGIN
	SELECT @CantidadPermisos = COUNT(*) FROM PermisoObjeto WHERE IdObjeto = @IdObjetoPadre
	AND IdAplicacion = @IntIdaplicacion AND IdRol = @IntIdrol
	
	IF @CantidadPermisos > 0 --EL PADRE TIENE PERMISOS
	BEGIN
		INSERT INTO PermisoObjeto
		(
		 IdObjeto,
		 IdRol,
		 IdAplicacion,
		 EstadoPermisoObjeto,
		 FechaCreacion
		)
		VALUES
		(
		  @IntIdObjeto,
		  @IntIdRol,
		  @IntIdAplicacion,
		  @BitEstadoPermisoObjeto,
		  @DtmFechaCreacion
		)
		 SET @IntIdpermisoobjeto = SCOPE_IDENTITY()
		 SET @IntCodigoError = 0
	END
	ELSE
	BEGIN
		SET @IntCodigoError = -1
	END	

END
ELSE --NO TIENE PADRE, ENTONCES SI SE PUEDE INSERTAR DIRECTAMENTE
BEGIN
	INSERT INTO PermisoObjeto
	(
	 IdObjeto,
	 IdRol,
	 IdAplicacion,
	 EstadoPermisoObjeto,
	 FechaCreacion
	)
	VALUES
	(
	  @IntIdObjeto,
	  @IntIdRol,
	  @IntIdAplicacion,
	  @BitEstadoPermisoObjeto,
	  @DtmFechaCreacion
	)
	 SET @IntIdpermisoobjeto = SCOPE_IDENTITY()
	 SET @IntCodigoError = 0
END
GO
