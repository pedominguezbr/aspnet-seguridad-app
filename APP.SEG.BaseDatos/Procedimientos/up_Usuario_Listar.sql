USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Listar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Listar]
 @VchNombres varchar (50),
 @VchApellidopaterno varchar (50),
 @VchApellidomaterno varchar (50)
AS
SELECT 
 IdUsuario,
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
 EstadoUsuario
 FROM Usuario
 WHERE
 (@VchNombres IS NULL OR @VchNombres='' OR Nombres LIKE @VchNombres) AND
 (@VchApellidopaterno IS NULL OR @VchApellidopaterno='' OR ApellidoPaterno LIKE @VchApellidopaterno) AND
 (@VchApellidomaterno IS NULL OR @VchApellidomaterno='' OR ApellidoMaterno LIKE @VchApellidomaterno)
GO
