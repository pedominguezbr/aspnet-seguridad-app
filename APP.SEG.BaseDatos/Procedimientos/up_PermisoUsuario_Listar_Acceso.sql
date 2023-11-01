USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoUsuario_Listar_Acceso]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoUsuario_Listar_Acceso]
  @IntIdusuario int,
  @IntIdAplicacion int,
  @IntIdRol Int
AS
SELECT     PermisoUsuario.IdPermisoUsuario, PermisoUsuario.IdUsuario, PermisoUsuario.IdRol, Rol.NombreRol, Rol.DescripcionRol, 
                      PermisoUsuario.IdAplicacion, Rol.EstadoRol, Aplicacion.NombreCortoAplicacion, Aplicacion.NombreLargoAplicacion, Aplicacion.DescripcionAplicacion, 
                      Aplicacion.EstadoAplicacion
FROM         PermisoUsuario INNER JOIN
                      Rol ON PermisoUsuario.IdRol = Rol.IdRol INNER JOIN
                      Aplicacion ON PermisoUsuario.IdAplicacion = Aplicacion.IdAplicacion
WHERE   (PermisoUsuario.Estado = 1) AND 
		(PermisoUsuario.IdAplicacion = @IntIdAplicacion) AND 
		(PermisoUsuario.IdUsuario = @IntIdusuario) AND
		(PermisoUsuario.IdRol = @IntIdRol)
GO
