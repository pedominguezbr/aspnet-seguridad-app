USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Aplicacion_Listar_IdAplicacion]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Aplicacion_Listar_IdAplicacion]
  @IntIdAplicacion int
AS
SELECT 
 IdAplicacion,
 NombreCortoAplicacion,
 NombreLargoAplicacion,
 DescripcionAplicacion,
 EstadoAplicacion
 FROM Aplicacion
 WHERE (@IntIdAplicacion = -1 or IdAplicacion = @IntIdAplicacion)
 AND EstadoAplicacion = 1
GO
