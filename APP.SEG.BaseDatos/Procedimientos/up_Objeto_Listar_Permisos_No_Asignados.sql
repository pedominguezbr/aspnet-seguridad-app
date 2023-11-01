USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Objeto_Listar_Permisos_No_Asignados]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_Objeto_Listar_Permisos_No_Asignados]
@IntIdAplicacion int,
@IntIdRol int
AS
BEGIN
/*
SELECT DISTINCT Objeto.IdObjeto, Objeto.NombreFisicoObjeto 
FROM Objeto
WHERE IdAplicacion = @IntIdAplicacion
AND IdObjeto NOT IN (SELECT IdObjeto FROM PermisoObjeto
						WHERE IdRol = @IntIdRol AND EstadoPermisoObjeto = 1) 
AND Objeto.EstadoObjeto = 1
*/

SELECT OB.IdObjeto, 
(OB.NombreFisicoObjetoPadre + CASE OB.NombreFisicoObjetoPadre WHEN '' THEN '' ELSE ' - ' END + OB.NombreFisicoObjeto) as NombreFisicoObjeto,
ISNULL(OB.nivel, 0) --SE MUESTRAN PRIMERO LOS OBJ QUE NO TIENEN PADRE
FROM (		
	SELECT DISTINCT O.IdObjeto, O.NombreFisicoObjeto ,
		ISNULL((SELECT NombreFisicoObjeto FROM Objeto
		WHERE IdObjeto = O.IdObjetoPadre),'') as NombreFisicoObjetoPadre,
		(SELECT DISTINCT TOP 1 CASE IdTipoObjeto 
		WHEN 7 THEN 1 --MENU
		WHEN 5 THEN 2 --FORMULARIO
		ELSE 3 --OTROS
		END 
		FROM Objeto WHERE IdObjetoPadre = O.IdObjetoPadre) as nivel

	FROM Objeto O
	WHERE IdAplicacion = @IntIdAplicacion
	AND IdObjeto NOT IN (SELECT IdObjeto FROM PermisoObjeto
							WHERE IdRol = @IntIdRol AND EstadoPermisoObjeto = 1) 
	AND O.EstadoObjeto = 1

) OB
ORDER BY 3,2

END
GO
