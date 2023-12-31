USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Rol_Listar_IdUsuario]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[up_Rol_Listar_IdUsuario]
(
@IntIdUsuario int
)
as
SELECT     Aplicacion.IdAplicacion, PermisoUsuario.IdRol, Rol.NombreRol
FROM         Aplicacion INNER JOIN
                      PermisoUsuario ON Aplicacion.IdAplicacion = PermisoUsuario.IdAplicacion INNER JOIN
                      Rol ON Aplicacion.IdAplicacion = Rol.IdAplicacion AND PermisoUsuario.IdRol = Rol.IdRol
WHERE     (PermisoUsuario.IdUsuario = @IntIdUsuario) AND EstadoAplicacion = 1
GO
