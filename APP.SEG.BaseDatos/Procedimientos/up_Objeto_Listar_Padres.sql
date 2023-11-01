USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_Objeto_Listar_Padres]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[up_Objeto_Listar_Padres]
@IntIdAplicacion int,
@IntIdTipoObjeto int
 as 
 /*
 while (select Idobjetopadre from objeto)<>0
begin  
 select * from Objeto
 where IdObjeto=IdObjetoPadre
 break
 
 end
 */
 IF @IntIdTipoObjeto IN (1,2,3,4,6) 
 BEGIN
 
	 SELECT * FROM Objeto WHERE IdAplicacion = @IntIdAplicacion --AND EstadoObjeto = 1
	 AND IdTipoObjeto = 5
 END
 ELSE
 BEGIN
	 SELECT * FROM Objeto WHERE IdAplicacion = @IntIdAplicacion --AND EstadoObjeto = 1
	 AND IdTipoObjeto = 7
 END
 /*
 boton			formulario
listadespl		formulario
check			formulario
radio			formulario
formulario		menu
caja			formulario
opcion menu		menu

 
 */
GO
