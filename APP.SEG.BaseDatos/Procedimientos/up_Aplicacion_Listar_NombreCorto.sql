USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Aplicacion_Listar_NombreCorto]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Aplicacion_Listar_NombreCorto]
  @NombreCortoAplicacion varchar(50)
AS
SELECT 
 IdAplicacion,
 NombreCortoAplicacion,
 NombreLargoAplicacion,
 DescripcionAplicacion,
 EstadoAplicacion
 FROM Aplicacion
 WHERE (@NombreCortoAplicacion IS NULL OR @NombreCortoAplicacion='' OR NombreCortoAplicacion LIKE @NombreCortoAplicacion)
 AND EstadoAplicacion = 1
GO
