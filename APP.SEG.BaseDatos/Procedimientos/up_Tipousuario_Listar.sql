USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Tipousuario_Listar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure
[dbo].[up_Tipousuario_Listar]
as 
select * from TipoUsuario
GO
