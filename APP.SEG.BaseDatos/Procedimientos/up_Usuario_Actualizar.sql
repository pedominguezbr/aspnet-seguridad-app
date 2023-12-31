USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Actualizar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Actualizar]
  @IntIdusuario int,
  @VchCodigousuario varchar (30),
  @VchNombres varchar (50),
  @VchApellidopaterno varchar (50),
  @VchApellidomaterno varchar (50),
  @IntIdtipousuario int,
  @IntIdarea int,
  @IntIdoficina int,
  @VchPassword varchar(200),
  @BitRequierepassword bit,
  @BitPasswordcaduca bit,
  @DtmFechacaduca datetime,
  @BitCambiarpasswordensinicio bit,
  @BitEstadousuario bit,
  @IntPagoTercero int
  
AS

IF @BitCambiarpasswordensinicio = 1
BEGIN

	UPDATE Usuario
	SET   
	 CodigoUsuario = @VchCodigousuario,
	 Nombres = @VchNombres,
	 ApellidoPaterno = @VchApellidopaterno,
	 ApellidoMaterno = @VchApellidomaterno,
	 IdTipoUsuario = @IntIdtipousuario,
	 IdArea = @IntIdarea,
	 IdOficina = @IntIdoficina,
	 Password=@VchPassword,
	 RequierePassword = @BitRequierepassword,
	 PasswordCaduca = @BitPasswordcaduca,
	 FechaCaduca = @DtmFechacaduca,
	 CambiarPasswordEnSInicio = @BitCambiarpasswordensinicio,
	 EstadoUsuario = @BitEstadousuario,
	 Pagotercero=@IntPagoTercero
	WHERE
	 IdUsuario = @IntIdusuario
END
ELSE
BEGIN
	UPDATE Usuario
	SET   
	 CodigoUsuario = @VchCodigousuario,
	 Nombres = @VchNombres,
	 ApellidoPaterno = @VchApellidopaterno,
	 ApellidoMaterno = @VchApellidomaterno,
	 IdTipoUsuario = @IntIdtipousuario,
	 IdArea = @IntIdarea,
	 IdOficina = @IntIdoficina,
	 RequierePassword = @BitRequierepassword,
	 PasswordCaduca = @BitPasswordcaduca,
	 FechaCaduca = @DtmFechacaduca,
	 CambiarPasswordEnSInicio = @BitCambiarpasswordensinicio,
	 EstadoUsuario = @BitEstadousuario,
	 Pagotercero=@IntPagoTercero
	WHERE
	 IdUsuario = @IntIdusuario

END
GO
