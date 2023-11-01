USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoUsuario_Listar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoUsuario_Listar]
  @IntIdusuario int,
  @IntIdAplicacion int
AS
/*
SELECT     PermisoUsuario.IdPermisoUsuario, PermisoUsuario.IdUsuario, PermisoUsuario.IdRol, Rol.NombreRol, Rol.DescripcionRol, 
                      PermisoUsuario.IdAplicacion, Rol.EstadoRol, Aplicacion.NombreCortoAplicacion, Aplicacion.NombreLargoAplicacion, Aplicacion.DescripcionAplicacion, 
                      Aplicacion.EstadoAplicacion
FROM         PermisoUsuario INNER JOIN
                      Rol ON PermisoUsuario.IdRol = Rol.IdRol INNER JOIN
                      Aplicacion ON PermisoUsuario.IdAplicacion = Aplicacion.IdAplicacion
WHERE   (PermisoUsuario.Estado = 1) AND 
		(PermisoUsuario.IdAplicacion = @IntIdAplicacion) AND 
		(PermisoUsuario.IdUsuario = @IntIdusuario)
*/		
SELECT     ISNULL(PermisoUsuario.IdPermisoUsuario,-1) AS IdPermisoUsuario, 
ISNULL(PermisoUsuario.IdUsuario,-1) AS IdUsuario, Rol.NombreRol, 
Rol.DescripcionRol, Rol.EstadoRol, Rol.IdRol, 
                      Rol.IdAplicacion, ISNULL(PermisoUsuario.Estado, 0) AS Estado
FROM         PermisoUsuario RIGHT OUTER JOIN
                      Rol ON PermisoUsuario.IdRol = Rol.IdRol AND 
                      PermisoUsuario.IdUsuario = @IntIdusuario AND 
                      PermisoUsuario.Estado = 1
                     
WHERE  Rol.IdAplicacion = @IntIdAplicacion  AND EstadoRol = 1
ORDER BY NombreRol
GO
