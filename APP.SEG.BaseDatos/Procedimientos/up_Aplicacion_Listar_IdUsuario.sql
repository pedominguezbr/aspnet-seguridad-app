USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Aplicacion_Listar_IdUsuario]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[up_Aplicacion_Listar_IdUsuario]
(
@IntIdUsuario int
)
as
SELECT  DISTINCT   Aplicacion.IdAplicacion, Aplicacion.NombreCortoAplicacion
FROM         Aplicacion INNER JOIN
                      PermisoUsuario ON Aplicacion.IdAplicacion = PermisoUsuario.IdAplicacion
WHERE     (PermisoUsuario.IdUsuario = @IntIdUsuario) AND EstadoAplicacion = 1
GO
