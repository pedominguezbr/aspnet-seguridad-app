using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Helper
{
    public static class Constantes
    {
        #region Constantes del Web.Config

        public static readonly string ID_APLICACION = "ID_APLICACION";
        public static readonly string USUARIO_SERVICIO = "USUARIO_SERVICIO";
        public static readonly string PASSWORD_SERVICIO = "PASSWORD_SERVICIO";
        public static readonly string SYMMPROVIDER = "utilEncrypt";
        public static readonly string DIRECCION_FRM_BIENVENIDO = "DireccionFrmBienvenido";
        public static readonly string DIRECCION_FRM_LOGIN = "DireccionFrmLogin";
        public static readonly string DIRECCION_FRM_RENOVACION_CLAVE = "DireccionFrmRedireccionClave";
        //Roles
        public static readonly string DIRECCION_FRM_ROL_BUSCAR = "DireccionFrmRolBuscar";
        public static readonly string DIRECCION_FRM_ROL_DETALLE = "DireccionFrmRolDetalle";
        public static readonly string DIRECCION_FRM_ROL_DETALLE_MODIFICAR = "DireccionFrmRolDetalleModificar";
        public static readonly string DIRECCION_FRM_ROL_DETALLE_CONSULTAR = "DireccionFrmRolDetalleConsultar";
        //Objetos
        public static readonly string DIRECCION_FRM_OBJETO_BUSCAR = "DireccionFrmObjetoBuscar";
        public static readonly string DIRECCION_FRM_OBJETO_DETALLE = "DireccionFrmObjetoDetalle";
        public static readonly string DIRECCION_FRM_OBJETO_DETALLE_MODIFICAR = "DireccionFrmObjetoDetalleModificar";
        public static readonly string DIRECCION_FRM_OBJETO_DETALLE_CONSULTAR = "DireccionFrmObjetoDetalleConsultar";
        //Permisos
        public static readonly string DIRECCION_FRM_PERMISO_BUSCAR = "DireccionFrmPermisoBuscar";
        public static readonly string DIRECCION_FRM_PERMISO_DETALLE = "DireccionFrmPermisoDetalle";
        public static readonly string DIRECCION_FRM_PERMISO_DETALLE_MODIFICAR = "DireccionFrmPermisoDetalleModificar";
        public static readonly string DIRECCION_FRM_PERMISO_DETALLE_CONSULTAR = "DireccionFrmPermisoDetalleConsultar";
        public static readonly string DIRECCION_FRM_PERMISO_USUARIO_DETALLE = "DireccionFrmPermisoUsuarioDetalle";
        //Usuarios
        public static readonly string DIRECCION_FRM_USUARIO_BUSCAR = "DireccionFrmUsuarioBuscar";
        public static readonly string DIRECCION_FRM_USUARIO_DETALLE = "DireccionFrmUsuarioDetalle";
        public static readonly string DIRECCION_FRM_USUARIO_DETALLE_MODIFICAR = "DireccionFrmUsuarioDetalleModificar";
        public static readonly string DIRECCION_FRM_USUARIO_DETALLE_CONSULTAR = "DireccionFrmUsuarioDetalleConsultar";
        public static readonly string DIRECCION_FRM_ACCESO_RESTRINGIDO = "DireccionFrmAccesoRestringido";
        public static readonly string DIRECCION_FRM_USUARIO_PERMISO_BUSCAR = "DireccionFrmPermisoUsuarioBuscar";
        public static readonly string DIRECCION_FRM_PERMISO_OBJETO_DETALLE = "DireccionFrmPermisoObjetoDetalle";
        public static readonly string DIRECCION_FRM_PERMISO_OBJETO_BUSCAR = "DireccionFrmPermisoObjetoBuscar";
        public static readonly string DIRECCION_FISICA_FRM_PERMISO_USUARIO_BUSCAR = "DireccionFisicaFrmPermisoUsuarioBuscar";

        //Empresa
        public static readonly string DIRECCION_FRM_EMPRESA_DETALLE = "DireccionFrmEmpresaDetalle";
        public static readonly string DIRECCION_FRM_EMPRESA_DETALLE_MODIFICAR = "DireccionFrmEmpresaDetalleModificar";
        public static readonly string DIRECCION_FRM_EMPRESA_DETALLE_CONSULTAR = "DireccionFrmEmpresaDetalleConsultar";
        public static readonly string DIRECCION_FRM_EMPRESA_BUSCAR = "DireccionFrmEmpresaBuscar";

        //TipoEmpresa
        public static readonly string DIRECCION_FRM_TIPOEMPRESA_DETALLE = "DireccionFrmTipoEmpresaDetalle";
        public static readonly string DIRECCION_FRM_TIPOEMPRESA_DETALLE_MODIFICAR = "DireccionFrmTipoEmpresaDetalleModificar";
        public static readonly string DIRECCION_FRM_TIPOEMPRESA_DETALLE_CONSULTAR = "DireccionFrmTipoEmpresaDetalleConsultar";
        public static readonly string DIRECCION_FRM_TIPOEMPRESA_BUSCAR = "DireccionFrmTipoEmpresaBuscar";
        public static readonly string DIRECCION_FRM_TIPOEMPRESA_APLICACION = "DireccionFrmTipoEmpresaAplicacion";

        //Permiso Empresa

        public static readonly string DIRECCION_FRM_EMPRESA_PERMISO_BUSCAR = "DireccionFrmEmpresaPermisoBuscar";
        public static readonly string DIRECCION_FRM_PERMISO_EMPRESA_DETALLE = "DireccionFrmEmpresaPemisoDetalle";

        //DireccionFisicaFrmPermisoUsuarioBuscar

        //Titulos
        public static readonly string TITULO_RENOVACION_CLAVE = "TITULO_RENOVACION_CLAVE";
        public static readonly string RECURSO_RUTA_APLICACION = "RECURSO_RUTA_APLICACION";
        public static readonly string RECURSO_RUTA_BOTON = "RECURSO_RUTA_BOTON";
        public static readonly string RECURSO_RUTA_TEXTBOX = "RECURSO_RUTA_TEXTBOX";
        public static readonly string RECURSO_RUTA_CHECKBOX = "RECURSO_RUTA_CHECKBOX";
        public static readonly string RECURSO_RUTA_FORMULARIO = "RECURSO_RUTA_FORMULARIO";
        public static readonly string RECURSO_RUTA_COMBO = "RECURSO_RUTA_COMBO";
        public static readonly string RECURSO_RUTA_MENU = "RECURSO_RUTA_MENU";
        public static readonly string RECURSO_RUTA_RADIO = "RECURSO_RUTA_RADIO";

        public static readonly string ITEM_DEFAULT_COMBO_ROL = "ITEM_DEFAULT_COMBO_ROL";
        //
        #endregion FIN Constantes del Web.Config

        #region Constantes propias de la aplicación
        //SESSION --------------------------------------------------------------------------------------
        public static readonly string SESION_ROLES = "ROLES";
        public static readonly string SESION_ROL = "ROL";
        public static readonly string SESION_PERMISOS = "PERMISOS";
        public static readonly string SESION_PERMISO = "PERMISO";
        public static readonly string SESION_USUARIOS = "USUARIOS";
        public static readonly string SESION_EMPRESAS = "EMPRESAS";
        public static readonly string SESION_TIPOEMPRESAS = "TIPOEMPRESAS";
        public static readonly string SESION_USUARIO = "USUARIO";
        public static readonly string SESION_USUARIO_LOGIN = "USUARIO_LOGIN";
        public static readonly string SESION_OBJETOS = "OBJETOS";
        public static readonly string SESION_OBJETO = "OBJETO";
        public static readonly string SESION_OPCIONES_MENU = "SESION_OPCIONES_MENU";
        //xx

        //DGV ------------------------------------------------------------------------------------------
        //Comandos de Row
        public static readonly string COMANDO_MODIFICAR = "cmdModificar";
        public static readonly string COMANDO_CONSULTAR = "cmdConsultar";
        public static readonly string COMANDO_ANULAR = "cmdAnular";
        public static readonly string COMANDO_AGREGAR_ROL = "cmdAgregarRol";
        public static readonly string COMANDO_MODIFICAR_PERMISOS = "cmdModificarPermiso";
        public static readonly string COMANDO_MODIFICAR_EMPRESAS = "cmdModificarEmpresa";


        //POST -----------------------------------------------------------------------------------------
        public static readonly string ACCION_VISUALIZACION = "CONSULTAR";
        public static readonly string ACCION_EDICION = "EDITAR";
        public static readonly string ACCION_NUEVO = "NUEVO";
        public static readonly string MODO = "MODO";

        //DDL ------------------------------------------------------------------------------------------
        public static readonly string ID_DDL_DEFAULT = "-1";
        //DDL Estado
        public static readonly string DEFAULT_DDL_ESTADO = "-- Seleccione --";
        public static readonly int BOOL_ESTADO_ACTIVO = 1;
        public static readonly string VALUE_ESTADO_ACTIVO = "1";
        public static readonly string TEXTO_ESTADO_ACTIVO = "Activo";
        public static readonly int BOOL_ESTADO_INACTIVO = 0;
        public static readonly string VALUE_ESTADO_INACTIVO = "0";
        public static readonly string TEXTO_ESTADO_INACTIVO = "Inactivo";
        //DDL Aplicativo
        public static readonly string DEFAULT_DDL_APLICATIVO = "-- Seleccione --";
        public static readonly string VALUE_DDL_APLICATIVO = "IdAplicacion";
        public static readonly string TEXTO_DDL_APLICATIVO = "NombreCortoAplicacion";
        //DDL TipoObjeto
        public static readonly string DEFAULT_DDL_TIPO_OBJETO = "-- Seleccione --";
        public static readonly string VALUE_DDL_TIPO_OBJETO = "IdTipoObjeto";
        public static readonly string TEXTO_DDL_TIPO_OBJETO = "NombreTipoObjeto";
        //DDL ObjetoPadre
        public static readonly string DEFAULT_DDL_OBJETO_PADRE = "-- Ninguno --";
        public static readonly string VALUE_DDL_OBJETO_PADRE = "IdObjeto";
        public static readonly string TEXTO_DDL_OBJETO_PADRE = "NombreFisicoObjeto";

        public static readonly string DEFAULT_DDL_PAGO_TERCERO = "-- Seleccione --";

        public static readonly string VALUE_DDL_ROL = "IdRol";
        public static readonly string TEXTO_DDL_ROL = "NombreRol";
        public static readonly string DEFAULT_DDL_ROL = "-- Seleccione --";

        public static readonly string DEFAULT_DDL_OBJETO = "-- Seleccione --";
        public static readonly string VALUE_DDL_OBJETO = "IdObjeto";
        public static readonly string TEXTO_DDL_OBJETO = "NombreFisicoObjeto";

        #endregion Fin de las constantes propias

        public static readonly string CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB = "0";
        public static readonly string CODIGO_RESPUESTA_CLAVE_ACTUALIZADA_CORRECTAMENTE = "1";
        public static readonly string CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS = "3";
        public static readonly string CODIGO_RESPUESTA_USUARIO_INVALIDO = "4";
        public static readonly string CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS = "5";

        public static readonly string CODIGO_RESPUESTA_EXITOSA_LISTA_ROLES = "1";
        public static readonly string CODIGO_RESPUESTA_EXITOSA_LISTA_PERMISO_OBJETO = "1";

        public static readonly string CODIGO_RESPUESTA_LOGUEO_EXISTOSO= "1";
        public static readonly string CODIGO_RESPUESTA_LOGUEO_CLAVE_ERRONEA = "2";
        public static readonly string CODIGO_RESPUESTA_LOGUEO_CLAVE_EXPIRADA = "3";
        public static readonly string CODIGO_RESPUESTA_LOGUEO_USUARIO_NO_TIENE_PERMISOS_APLICACION = "4";
        public static readonly string CODIGO_RESPUESTA_LOGUEO_USUARIO_INACTIVO = "5";
        public static readonly string CODIGO_RESPUESTA_LOGUEO_USUARIO_DEBE_CAMBIAR_CLAVE = "6";

        public static readonly string CODIGO_RESPUESTA_ENCRIPTACION_EXITOSA = "1";
        public static readonly string CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA = "1";

        public const int CODIGO_TIPO_OBJETO_BOTON = 1;
        public const int CODIGO_TIPO_OBJETO_LISTA_DESPLEGABLE = 2;
        public const int CODIGO_TIPO_OBJETO_CHECK_BOX = 3;
        public const int CODIGO_TIPO_OBJETO_RADIO = 4;
        public const int CODIGO_TIPO_OBJETO_FORMULARIO = 5;
        public const int CODIGO_TIPO_OBJETO_CAJA_TEXTO = 6;
        public const int CODIGO_TIPO_OBJETO_OPCION_MENU = 7;


        public static readonly string TITULO_RESULTADO_BUSQUEDA = "TituloResultadoBusqueda";
        public static readonly string TITULO_RESULTADO_BUSQUEDA_CERO = "TituloResultadoBusquedaCero";

        public static readonly string MSG_ROL_REGISTRADO_EXITOSAMENTE = "MSG_ROL_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_ROL_ACTUALIZADO_EXITOSAMENTE = "MSG_ROL_ACTUALIZADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_GENERAL = "MSG_ERROR_GENERAL";

        public static readonly string MSG_ROL_ELIMINADO_EXITOSAMENTE = "MSG_ROL_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_ROL_EXISTEN_PERMISOS_OBJETO = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_ROL_EXISTEN_PERMISOS_OBJETO";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_ROL_EXISTEN_PERMISOS_USUARIO = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_ROL_EXISTEN_PERMISOS_USUARIO";

        public static readonly string MSG_USUARIO_REGISTRADO_EXITOSAMENTE = "MSG_USUARIO_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_USUARIO_ACTUALIZADO_EXITOSAMENTE = "MSG_USUARIO_ACTUALIZADO_EXITOSAMENTE";
        public static readonly string MSG_USUARIO_CODIGO_REPETIDO = "MSG_USUARIO_CODIGO_REPETIDO";
        public static readonly string MSG_ROL_NOMBRE_REPETIDO = "MSG_ROL_NOMBRE_REPETIDO";

        public static readonly string MSG_EMPRESA_REGISTRADO_EXITOSAMENTE = "MSG_EMPRESA_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_EMPRESA_ACTUALIZADO_EXITOSAMENTE = "MSG_EMPRESA_ACTUALIZADO_EXITOSAMENTE";
        public static readonly string MSG_EMPRESA_ELIMINADO_EXITOSAMENTE = "MSG_EMPRESA_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_EMPRESA = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_EMPRESA";


        public static readonly string MSG_TIPOEMPRESA_REGISTRADO_EXITOSAMENTE = "MSG_TIPOEMPRESA_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_TIPOEMPRESA_ACTUALIZADO_EXITOSAMENTE = "MSG_TIPOEMPRESA_ACTUALIZADO_EXITOSAMENTE";
        public static readonly string MSG_TIPOEMPRESA_ELIMINADO_EXITOSAMENTE = "MSG_TIPOEMPRESA_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_TIPOEMPRESA = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_TIPOEMPRESA";


        public static readonly string REGISTRO_PAGINA = "REGISTRO_PAGINA";

        public static readonly string TEXTO_PAGO_TERCERO_1 = "Nivel 1";
        public static readonly string TEXTO_PAGO_TERCERO_2 = "Nivel 2";
        public static readonly string TEXTO_PAGO_TERCERO_3 = "Nivel 3";

        public static readonly string VALUE_PAGO_TERCERO_1 = "1";
        public static readonly string VALUE_PAGO_TERCERO_2 = "2";
        public static readonly string VALUE_PAGO_TERCERO_3 = "3";

        public static readonly string MSG_USUARIO_ELIMINADO_EXITOSAMENTE = "MSG_USUARIO_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_USUARIO_EXISTEN_PERMISOS_USUARIO = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_USUARIO_EXISTEN_PERMISOS_USUARIO";
        public static readonly string MSG_ERROR_NO_SE_PUEDE_ELIMINAR_USUARIO = "MSG_ERROR_NO_SE_PUEDE_ELIMINAR_USUARIO";

        public static readonly string MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS = "MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS";

        public static readonly string CLAVE_SIMBOLOS_ESPECIALES = "@#$%^&+=";
        public static readonly string MSG_CLAVES_DISTINTAS = "MSG_CLAVES_DISTINTAS";
        public static readonly string MSG_COPIA_PERMISOS_EXITOSA = "MSG_COPIA_PERMISOS_EXITOSA";
        public static readonly string MSG_ERROR_COPIA_PERMISOS = "MSG_ERROR_COPIA_PERMISOS";

        public static readonly string MSG_OBJETO_REGISTRADO_EXITOSAMENTE = "MSG_OBJETO_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_OBJETO_ACTUALIZADO_EXITOSAMENTE = "MSG_OBJETO_ACTUALIZADO_EXITOSAMENTE";

        public static readonly string MSG_OBJETO_ELIMINADO_EXITOSAMENTE = "MSG_OBJETO_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_OBJETO_NO_SE_PUEDE_ELIMINAR_USUARIO_EXISTEN_PERMISOS_OBJETO = "MSG_ERROR_OBJETO_NO_SE_PUEDE_ELIMINAR_USUARIO_EXISTEN_PERMISOS_OBJETO";
        public static readonly string MSG_ERROR_OBJETO_NO_SE_PUEDE_ELIMINAR_TIENE_HIJOS = "MSG_ERROR_OBJETO_NO_SE_PUEDE_ELIMINAR_TIENE_HIJOS";
        public static readonly string MSG_ERROR_OBJETO_DEBE_SELECCIONAR_UN_OBJETO = "MSG_ERROR_OBJETO_DEBE_SELECCIONAR_UN_OBJETO";

        public static readonly string MSG_PERMISO_OBJETO_REGISTRADO_EXITOSAMENTE = "MSG_PERMISO_OBJETO_REGISTRADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_OBJETO_PADRE_NO_TIENE_PERMISO = "MSG_ERROR_OBJETO_PADRE_NO_TIENE_PERMISO";

        public static readonly string MSG_PERMISO_OBJETO_ELIMINADO_EXITOSAMENTE = "MSG_PERMISO_OBJETO_ELIMINADO_EXITOSAMENTE";
        public static readonly string MSG_ERROR_PERMISO_OBJETO_NO_SE_PUEDE_ELIMINAR_POR_PERMISOS_HIJOS = "MSG_ERROR_PERMISO_OBJETO_NO_SE_PUEDE_ELIMINAR_POR_PERMISOS_HIJOS";
        public static readonly string MSG_PERMISO_OBJETOS_REGISTRADOS_EXITOSAMENTE = "MSG_PERMISO_OBJETOS_REGISTRADOS_EXITOSAMENTE";
        public static readonly string MSG_ERROR_TEXTO_MUY_LARGO = "MSG_ERROR_TEXTO_MUY_LARGO";
        public static readonly string MSG_CLAVE_ACTUALIZADA_EXITOSAMENTE = "MSG_CLAVE_ACTUALIZADA_EXITOSAMENTE";
        public static readonly string MSG_ERROR_FECHA_CADUCIDAD_DEBE_SER_MAYOR_FECHA_ACTUAL = "MSG_ERROR_FECHA_CADUCIDAD_DEBE_SER_MAYOR_FECHA_ACTUAL";
        public static readonly string MSG_ERROR_ACTUALIZAR_OBJETO_REPETIDO = "MSG_ERROR_ACTUALIZAR_OBJETO_REPETIDO";

        public static readonly string CLAVE_PAGINA_ENCRYPTAR = "CLAVE_PAGINA_ENCRYPTAR";

        public static readonly string VIEWSTATE_LISTATIPOEMPRESA_APLICACION = "ViewStateListaTipoEmpresaAplicacion";
        public static readonly string VIEWSTATE_APLICACION = "ViewStateAplicacion";
        public static readonly string VIEWSTATE_LISTAEMPRESA = "ViewStateListaEmpresa";
        public static readonly string VIEWSTATE_LISTAEMPRESASELECCIONADOS = "ViewStateListaEmpresaSeleccionados";
    }
}
