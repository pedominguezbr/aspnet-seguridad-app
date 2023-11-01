USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Usuarioclave_Validar_Anteriores]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Usuarioclave_Validar_Anteriores]
  @IntIdusuario int  
AS

SELECT TOP 13 IDUSUARIO, CLAVEREGISTRADA FROM UsuarioClave
WHERE IdUsuario = @IntIdusuario
ORDER BY FechaRegistro DESC
GO
