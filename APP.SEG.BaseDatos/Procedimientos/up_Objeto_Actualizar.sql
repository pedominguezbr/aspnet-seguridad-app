USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Objeto_Actualizar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Objeto_Actualizar]
  @IntIdobjeto int,
  @VchNombrefisicoobjeto varchar (50),
  @VchDescripcionobjeto varchar (150),
  @VchEtiquetaobjeto varchar (50),
  @IntIdtipoobjeto int,
  @VchUrlobjeto varchar (60),
  @IntIdobjetopadre int,
  @IntIdaplicacion int,
  @BitEstadoobjeto bit,
  @IntCodigoMensaje int OUTPUT
AS

DECLARE @CantidadObjetos int
SET @CantidadObjetos = 0

IF @IntIdtipoobjeto = 5 --FORMULARIO
BEGIN
	SELECT @CantidadObjetos = COUNT(*) FROM Objeto 
	WHERE UPPER(NombreFisicoObjeto) = UPPER(@VchNombrefisicoobjeto) and IdAplicacion = @IntIdaplicacion
	AND IdObjeto <> @IntIdobjeto AND IdTipoObjeto = 5 --FORMULARIO
END

IF @CantidadObjetos = 0
BEGIN

	UPDATE Objeto
	SET   
	 NombreFisicoObjeto = @VchNombrefisicoobjeto,
	 DescripcionObjeto = @VchDescripcionobjeto,
	 EtiquetaObjeto = @VchEtiquetaobjeto,
	 IdTipoObjeto = @IntIdtipoobjeto,
	 UrlObjeto = @VchUrlobjeto,
	 IdObjetoPadre = @IntIdobjetopadre,
	 IdAplicacion = @IntIdaplicacion,
	 EstadoObjeto = @BitEstadoobjeto
	WHERE
	 IdObjeto = @IntIdobjeto

END
ELSE	
BEGIN
	SET @IntCodigoMensaje = -1
END
GO
