USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Aplicacion_Listar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[up_Aplicacion_Listar]

AS
SELECT 
 IdAplicacion,
 NombreCortoAplicacion,
 NombreLargoAplicacion,
 DescripcionAplicacion,
 EstadoAplicacion
 FROM Aplicacion
GO
