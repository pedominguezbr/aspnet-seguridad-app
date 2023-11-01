USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Insertar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Insertar]
  @IntIdusuario int OUTPUT,
  @VchCodigousuario varchar (30),
  @VchNombres varchar (50),
  @VchApellidopaterno varchar (50),
  @VchApellidomaterno varchar (50),
  @IntIdtipousuario int,
  @IntIdarea int,
  @IntIdoficina int,
  @BitRequierepassword bit,
  @VchPassword varchar (200),
  @BitPasswordcaduca bit,
  @DtmFechacaduca datetime,
  @BitCambiarpasswordensinicio bit,
  @DtmFechacreacion datetime,
  @IntIdusuariocreacion int,
  @BitEstadousuario bit,
  @IntPagoTercero int
AS

DECLARE @CantidadUsuarios int

SELECT @CantidadUsuarios = COUNT(*) FROM Usuario 
WHERE UPPER(CodigoUsuario) = UPPER(@VchCodigousuario)

IF @CantidadUsuarios = 0
BEGIN
	INSERT INTO Usuario
	(
	 CodigoUsuario,
	 Nombres,
	 ApellidoPaterno,
	 ApellidoMaterno,
	 IdTipoUsuario,
	 IdArea,
	 IdOficina,
	 RequierePassword,
	 Password,
	 PasswordCaduca,
	 FechaCaduca,
	 CambiarPasswordEnSInicio,
	 FechaCreacion,
	 IdUsuarioCreacion,
	 EstadoUsuario,
	 PagoTercero
	)
	VALUES
	(
	  @VchCodigousuario,
	  @VchNombres,
	  @VchApellidopaterno,
	  @VchApellidomaterno,
	  @IntIdtipousuario,
	  @IntIdarea,
	  @IntIdoficina,
	  @BitRequierepassword,
	  @VchPassword,
	  @BitPasswordcaduca,
	  @DtmFechacaduca,
	  @BitCambiarpasswordensinicio,
	  @DtmFechacreacion,
	  @IntIdusuariocreacion,
	  @BitEstadousuario,
	  @IntPagoTercero
	)
	
	SET @IntIdusuario = SCOPE_IDENTITY()
END
ELSE	
BEGIN
	SET @IntIdusuario = -1
END
GO
