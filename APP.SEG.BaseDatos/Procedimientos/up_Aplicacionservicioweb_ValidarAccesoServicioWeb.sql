USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Aplicacionservicioweb_ValidarAccesoServicioWeb]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Aplicacionservicioweb_ValidarAccesoServicioWeb]
  @VchUsuarioservicioweb varchar (50),
  @VchClaveusuarioservicioweb varchar (200)
AS
SELECT 
 IdAplicacionServicioWebClave,
 IdAplicacion,
 UsuarioServicioWeb,
 ClaveUsuarioServicioWeb,
 FechaCreacionServicioWeb,
 EstadoServicioWeb
 FROM AplicacionServicioWeb
 WHERE (UsuarioServicioWeb = @VchUsuarioservicioweb) AND
       (ClaveUsuarioServicioWeb = @VchClaveusuarioservicioweb) AND
       (EstadoServicioWeb = 1)
GO
