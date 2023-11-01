USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_TipoObjeto_Listar]    Script Date: 06/14/2011 17:15:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[up_TipoObjeto_Listar]
as
select 
IdTipoObjeto,
NombreTipoObjeto,
DescripcionTipoObjeto,
IconoTipoObjeto,
EstadoTipoObjeo
from 
TipoObjeto
order by NombreTipoObjeto
GO
