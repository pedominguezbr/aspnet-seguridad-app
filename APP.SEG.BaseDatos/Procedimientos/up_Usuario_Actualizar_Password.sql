USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Actualizar_Password]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Actualizar_Password]
  @IntIdusuario int,
  @BitRequierepassword bit,
  @VchPassword varchar (200),
  @BitPasswordcaduca bit,
  @DtmFechacaduca datetime,
  @BitCambiarpasswordensinicio bit
AS
UPDATE Usuario
SET   
 
 --RequierePassword = @BitRequierepassword,
 Password = @VchPassword,
 --PasswordCaduca = @BitPasswordcaduca,
 FechaCaduca = @DtmFechacaduca,
 CambiarPasswordEnSInicio = @BitCambiarpasswordensinicio
WHERE
 IdUsuario = @IntIdusuario
GO
