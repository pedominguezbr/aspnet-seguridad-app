USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Obtener_Aplicacion]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Obtener_Aplicacion]
@IntIdAplicacion int
AS
SELECT 
 IdAplicacion,
 NombreCortoAplicacion,
 NombreLargoAplicacion,
 DescripcionAplicacion,
 EstadoAplicacion
 FROM Aplicacion
 WHERE IdAplicacion = @IntIdAplicacion
GO
