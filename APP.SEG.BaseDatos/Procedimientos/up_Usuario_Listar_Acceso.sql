USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuario_Listar_Acceso]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuario_Listar_Acceso]
@IntIdusuario int,
@IntIdArea int,
@IntIdAplicacion int,
@IntIdRol int

AS

SELECT    
Usuario.IdUsuario, 
Usuario.CodigoUsuario, 
Usuario.Nombres, 
Usuario.ApellidoPaterno, 
Usuario.ApellidoMaterno, 
Usuario.IdTipoUsuario, 
Usuario.IdArea, 
Usuario.IdOficina, 
Usuario.RequierePassword, 
Usuario.PasswordCaduca, 
Usuario.FechaCaduca, 
Usuario.CambiarPasswordEnSInicio, 
Usuario.FechaCreacion, 
Usuario.IdUsuarioCreacion, 
Usuario.EstadoUsuario,
Usuario.PagoTercero, 
PermisoUsuario.IdAplicacion, 
PermisoUsuario.IdRol
FROM PermisoUsuario INNER JOIN
     Usuario ON PermisoUsuario.IdUsuario = Usuario.IdUsuario
WHERE     
(@IntIdusuario=0 OR Usuario.IdUsuario = @IntIdusuario) AND 
(@IntIdArea=0 OR Usuario.IdArea = @IntIdArea) AND 
(@IntIdRol=0 OR PermisoUsuario.IdRol = @IntIdRol) AND
(PermisoUsuario.IdAplicacion = @IntIdAplicacion)
GO
