USE [SEGURIDAD]
GO
/****** Object:  StoredProcedure [dbo].[up_PermisoObjeto_Insertar_Sin_Validacion]    Script Date: 06/14/2011 17:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_PermisoObjeto_Insertar_Sin_Validacion]
  @IntIdpermisoobjeto int OUTPUT,
  @IntIdObjeto int,
  @IntIdRol int,
  @IntIdAplicacion int,
  @BitEstadoPermisoObjeto bit,
  @DtmFechaCreacion datetime
  
AS

INSERT INTO PermisoObjeto
(
 IdObjeto,
 IdRol,
 IdAplicacion,
 EstadoPermisoObjeto,
 FechaCreacion
)
VALUES
(
  @IntIdObjeto,
  @IntIdRol,
  @IntIdAplicacion,
  @BitEstadoPermisoObjeto,
  @DtmFechaCreacion
)
 SET @IntIdpermisoobjeto = SCOPE_IDENTITY()
GO
