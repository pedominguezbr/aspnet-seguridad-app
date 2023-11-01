USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Rol_Obtener]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Rol_Obtener]
@IntIdRol int
AS
SELECT 
 IdRol,
 NombreRol,
 DescripcionRol,
 IdAplicacion,
 EstadoRol
 FROM Rol
 WHERE 
	IdRol=@IntIdRol
GO
