USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Oficina_Listar]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[up_Oficina_Listar]
as
select * from Oficina
GO
