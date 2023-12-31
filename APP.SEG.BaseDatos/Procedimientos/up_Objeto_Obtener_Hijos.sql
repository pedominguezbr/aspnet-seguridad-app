USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Objeto_Obtener_Hijos]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Objeto_Obtener_Hijos]
@IntIdObjeto int
AS

	WITH Managers AS
	(
	
	SELECT IdObjeto--, IdObjetoPadre, NombreFisicoObjeto
	FROM Objeto
	WHERE IdObjeto = @IntIdObjeto
	UNION ALL
	
	SELECT e.IdObjeto--, e.IdObjetoPadre, e.NombreFisicoObjeto
	FROM Objeto e INNER JOIN Managers m 
	ON e.IdObjetoPadre = m.IdObjeto
	)
	SELECT IdObjeto FROM Managers
	WHERE IdObjeto <> @IntIdObjeto OPTION (MAXRECURSION 50)
GO
