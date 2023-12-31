USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Rol_Actualizar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Rol_Actualizar]
  @IntIdrol int,
  @VchNombrerol varchar (50),
  @VchDescripcionrol varchar (200),
  @IntIdaplicacion int,
  @BitEstadorol bit,
  @IntCodigoMensaje int OUTPUT
AS

DECLARE @CantidadRoles int

SELECT @CantidadRoles = COUNT(*) FROM Rol 
WHERE UPPER(NombreRol) = UPPER(@VchNombrerol) and IdAplicacion = @IntIdaplicacion
AND IdRol <> @IntIdrol

IF @CantidadRoles = 0
BEGIN

	UPDATE Rol
	SET   
	 NombreRol = @VchNombrerol,
	 DescripcionRol = @VchDescripcionrol,
	 IdAplicacion = @IntIdaplicacion,
	 EstadoRol = @BitEstadorol
	WHERE
	 IdRol = @IntIdrol

END
ELSE	
BEGIN
	SET @IntCodigoMensaje = -1
END
GO
