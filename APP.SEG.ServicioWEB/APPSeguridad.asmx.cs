using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using APP.SEG.Entidades;
using APP.SEG.Negocio;
using System.Configuration;
using System.Text;

namespace APP.SEG.ServicioWEB
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class ServicioSeguridad : System.Web.Services.WebService
    {

        [WebMethod(Description = "Valida el acceso de un usuario")]
        public BERespuestaAcceso ValidarAcceso(BEValidaAcceso beValidaAcceso)//string usuario, string clave, string usuarioServicio, string claveUsuarioServicio, int idAplicacion, int idRol)
        {
            string mensaje = string.Empty;
            BERespuestaAcceso respuestaAcceso = new BERespuestaAcceso();
            //BEValidaAcceso beValidaAcceso = new BEValidaAcceso();

            #region validacion de parametros
            StringBuilder parametrosFaltantes = new StringBuilder();
            if (beValidaAcceso.UsuarioLogueo == null || beValidaAcceso.UsuarioLogueo.Equals(string.Empty))
            {
                parametrosFaltantes.Append("UsuarioLogueo");
            }
            if (beValidaAcceso.ClaveLogueo == null || beValidaAcceso.ClaveLogueo.Equals(string.Empty))
            {
                if(parametrosFaltantes.Length > 0)
                {
                    parametrosFaltantes.Append(", ");
                }
                parametrosFaltantes.Append("ClaveLogueo");
            }
            if (beValidaAcceso.UsuarioServicio == null || beValidaAcceso.UsuarioServicio.Equals(string.Empty))
            {
                if (parametrosFaltantes.Length > 0)
                {
                    parametrosFaltantes.Append(", ");
                }
                parametrosFaltantes.Append("UsuarioServicio");
            }
            if (beValidaAcceso.ClaveUsuarioServicio == null || beValidaAcceso.ClaveUsuarioServicio.Equals(string.Empty))
            {
                if (parametrosFaltantes.Length > 0)
                {
                    parametrosFaltantes.Append(", ");
                }
                parametrosFaltantes.Append("ClaveUsuarioServicio");
            }
            if (parametrosFaltantes.Length > 0)
            {
                respuestaAcceso.CodigoRespuesta = Constantes.CODIGO_RESPUESTA_PARAMETROS_INCOMPLETOS;
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_PARAMETROS_INCOMPLETOS];
                respuestaAcceso.DescripcionRespuesta = string.Format(mensaje, parametrosFaltantes.ToString());
                return respuestaAcceso;
            }
            #endregion validacion de parametros
            /*
            beValidaAcceso.UsuarioLogueo = usuario;
            beValidaAcceso.ClaveLogueo = clave;
            //BEConsultaServicio beConsultaServicio = new BEConsultaServicio();
            beValidaAcceso.IdAplicacion = idAplicacion;
            beValidaAcceso.UsuarioServicio = usuarioServicio;
            beValidaAcceso.IdRol = idRol;
            beValidaAcceso.ClaveUsuarioServicio = claveUsuarioServicio;
            */

            respuestaAcceso = new BLValidarAcceso().ValidarAcceso(beValidaAcceso);

            if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaAcceso.DescripcionRespuesta = mensaje;
            }
            else
            {
                if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_ERRONEA))
                {
                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_ERRADA];
                    respuestaAcceso.DescripcionRespuesta = mensaje;
                }
                else
                {
                    if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_NO_TIENE_PERMISOS_APLICACION))
                    {
                        mensaje = ConfigurationManager.AppSettings[Constantes.MSG_USUARIO_NO_TIENE_PERMISO_APLICACION];
                        respuestaAcceso.DescripcionRespuesta = mensaje;
                    }
                    else
                    {
                        if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_INACTIVO))
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_USUARIO_INACTIVO];
                            respuestaAcceso.DescripcionRespuesta = mensaje;
                        }
                        else
                        {
                            if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_EXPIRADA))
                            {
                                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_EXPIRADA];
                                respuestaAcceso.DescripcionRespuesta = mensaje;
                            }
                            else
                            {
                                if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_DEBE_CAMBIAR_CLAVE))
                                {
                                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_USUARIO_DEBE_CAMBIAR_CLAVE];
                                    respuestaAcceso.DescripcionRespuesta = mensaje;
                                }
                                else
                                {
                                    mensaje = ConfigurationManager.AppSettings[Constantes.CODIGO_RESPUESTA_LOGUEO_EXISTOSO];
                                    respuestaAcceso.DescripcionRespuesta = mensaje;
                                }
                            }
                        }
                    }

                }

            }
            return respuestaAcceso;
        }

        [WebMethod(Description = "Devuelve la lista de roles en base a la aplicacion")]
        public BERespuestaRol ListarRol(BEConsultaServicio beConsultaServicio)//string usuarioServicio, string claveUsuarioServicio, int idAplicacion)
        {
            BERespuestaRol respuestaRol;
            string mensaje = string.Empty;
            /*
            BEConsultaServicio beConsultaServicio = new BEConsultaServicio();
            beConsultaServicio.IdAplicacion = idAplicacion;
            beConsultaServicio.UsuarioServicio = usuarioServicio;
            beConsultaServicio.ClaveUsuarioServicio = claveUsuarioServicio;
            */
            respuestaRol = new BLValidarAcceso().ListarRol(beConsultaServicio);

            if (respuestaRol.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaRol.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaRol.DescripcionRespuesta = mensaje;
            }
            return respuestaRol;

        }

        [WebMethod(Description = "Devuelve la lista de objetos para los que se tiene acceso para un determinado formulario en base al aplicativo y el rol")]
        public BERespuestaPermisoObjeto ListarPermisoObjetoPorFormulario(BEConsultaServicio beConsultaServicio)//int idAplicacion, int idRol, string nombreFormulario, string usuarioServicio, string claveUsuarioServicio)
        {
            BERespuestaPermisoObjeto respuestaPermisoObjeto;
            string mensaje = string.Empty;

            /*
            BEConsultaServicio beConsultaServicio = new BEConsultaServicio();
            beConsultaServicio.IdAplicacion = idAplicacion;
            beConsultaServicio.IdRol = idRol;
            beConsultaServicio.NombreFormulario = nombreFormulario;
            beConsultaServicio.UsuarioServicio = usuarioServicio;
            beConsultaServicio.ClaveUsuarioServicio = claveUsuarioServicio;
            */
            respuestaPermisoObjeto =  new BLValidarAcceso().ListarPermisoObjetoPorFormulario(beConsultaServicio);

            if (respuestaPermisoObjeto.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            return respuestaPermisoObjeto;
        }

        [WebMethod(Description = "Devuelve la lista de objetos para los que se tiene acceso para un determinado formulario en base al aplicativo y el Usuario")]
        public BERespuestaPermisoObjeto ListarPermisoObjetoPorFormularioxUsuario(BEConsultaServicio beConsultaServicio)//int idAplicacion, int idRol, string nombreFormulario, string usuarioServicio, string claveUsuarioServicio)
        {
            BERespuestaPermisoObjeto respuestaPermisoObjeto;
            string mensaje = string.Empty;

            /*
            BEConsultaServicio beConsultaServicio = new BEConsultaServicio();
            beConsultaServicio.IdAplicacion = idAplicacion;
            beConsultaServicio.IdRol = idRol;
            beConsultaServicio.NombreFormulario = nombreFormulario;
            beConsultaServicio.UsuarioServicio = usuarioServicio;
            beConsultaServicio.ClaveUsuarioServicio = claveUsuarioServicio;
            */
            respuestaPermisoObjeto = new BLValidarAcceso().ListarPermisoObjetoPorFormularioxUsuario(beConsultaServicio);

            if (respuestaPermisoObjeto.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            return respuestaPermisoObjeto;
        }
        [WebMethod(Description = "Devuelve la lista de objetos de tipo menu de opciones para los que se tiene acceso en base al aplicativo y el rol")]
        public BERespuestaPermisoObjeto ListarPermisoObjetoMenuOpciones(BEConsultaServicio beConsultaServicio)//int idAplicacion, int idRol, string usuarioServicio, string claveUsuarioServicio)
        {
            BERespuestaPermisoObjeto respuestaPermisoObjeto;
            string mensaje = string.Empty;
            /*
            BEConsultaServicio beConsultaServicio = new BEConsultaServicio();
            beConsultaServicio.IdAplicacion = idAplicacion;
            beConsultaServicio.IdRol = idRol;
            beConsultaServicio.UsuarioServicio = usuarioServicio;
            beConsultaServicio.ClaveUsuarioServicio = claveUsuarioServicio;
            */
            respuestaPermisoObjeto = new BLValidarAcceso().ListarPermisoObjetoMenuOpciones(beConsultaServicio);

            if (respuestaPermisoObjeto.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            return respuestaPermisoObjeto;
        }

        [WebMethod(Description = "Devuelve la lista de objetos de tipo menu de opciones para los que se tiene acceso en base al aplicativo y el Idusuario")]
        public BERespuestaPermisoObjeto ListarPermisoObjetoMenuOpcionesxUsuario(BEConsultaServicio beConsultaServicio)//int idAplicacion, int idRol, string usuarioServicio, string claveUsuarioServicio)
        {
            BERespuestaPermisoObjeto respuestaPermisoObjeto;
            string mensaje = string.Empty;

            respuestaPermisoObjeto = new BLValidarAcceso().ListarPermisoObjetoMenuOpcionesxUsuario(beConsultaServicio);

            if (respuestaPermisoObjeto.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaPermisoObjeto.DescripcionRespuesta = mensaje;
            }
            return respuestaPermisoObjeto;
        }

        [WebMethod(Description = "Actualiza la contraseña expirada del usuario con la nueva contraseña suministrada")]
        public BERespuestaActualizaClave ActualizarClaveExpirada(BEActualizaClave beActualizaClave)//string usuario, string claveAnterior, string nuevaClave, string usuarioServicio, string claveUsuarioServicio, int idAplicacion, int idRol)
        {
            BERespuestaActualizaClave respuestaActualizaClave;
            /*
            BEActualizaClave beActualizaClave = new BEActualizaClave();
            beActualizaClave.ClaveUsuarioServicio = claveUsuarioServicio;
            beActualizaClave.IdAplicacion = idAplicacion;
            beActualizaClave.IdRol = idRol;
            beActualizaClave.CodigoUsuario = usuario;
            beActualizaClave.NuevaClave = nuevaClave;
            beActualizaClave.ClaveAnterior = claveAnterior;
            beActualizaClave.UsuarioServicio = usuarioServicio;
            */
            respuestaActualizaClave = new BLValidarAcceso().ActualizarClaveExpirada(beActualizaClave);
            string mensaje = string.Empty;

            if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaActualizaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS))
                {
                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS];
                    respuestaActualizaClave.DescripcionRespuesta = mensaje;
                }
                else
                {
                    if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS))
                    {
                        mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_POR_ACTUALIZAR_REPETIDA];
                        respuestaActualizaClave.DescripcionRespuesta = mensaje;
                    }
                    else
                    {
                        if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO))
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_USUARIO_INVALIDO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                        else
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                    }
                }
            }

            return respuestaActualizaClave;
        }

        [WebMethod(Description = "Actualiza la contraseña expirada del usuario del sistema wrapup con la nueva contraseña suministrada. No tiene restricciones.")]
        public BERespuestaActualizaClave ActualizarClaveExpiradaWrapUp(BEActualizaClave beActualizaClave)//string usuario, string claveAnterior, string nuevaClave, string usuarioServicio, string claveUsuarioServicio, int idAplicacion, int idRol)
        {
            BERespuestaActualizaClave respuestaActualizaClave;
            /*
            BEActualizaClave beActualizaClave = new BEActualizaClave();
            beActualizaClave.ClaveUsuarioServicio = claveUsuarioServicio;
            beActualizaClave.IdAplicacion = idAplicacion;
            beActualizaClave.IdRol = idRol;
            beActualizaClave.CodigoUsuario = usuario;
            beActualizaClave.NuevaClave = nuevaClave;
            beActualizaClave.ClaveAnterior = claveAnterior;
            beActualizaClave.UsuarioServicio = usuarioServicio;
            */
            respuestaActualizaClave = new BLValidarAcceso().ActualizarClaveExpiradaWrapUp(beActualizaClave);
            string mensaje = string.Empty;

            if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaActualizaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS))
                {
                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS];
                    respuestaActualizaClave.DescripcionRespuesta = mensaje;
                }
                else
                {
                    if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS))
                    {
                        mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_POR_ACTUALIZAR_REPETIDA];
                        respuestaActualizaClave.DescripcionRespuesta = mensaje;
                    }
                    else
                    {
                        if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO))
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_USUARIO_INVALIDO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                        else
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                    }
                }
            }

            return respuestaActualizaClave;
        }

        [WebMethod(Description = "Cambia la contraseña del usuario con la nueva contraseña suministrada")]
        public BERespuestaActualizaClave CambiarClave(BEActualizaClave beActualizaClave)//string usuario, string claveAnterior, string nuevaClave, string usuarioServicio, string claveUsuarioServicio, int idAplicacion)
        {
            BERespuestaActualizaClave respuestaActualizaClave;
            /*
            BEActualizaClave beActualizaClave = new BEActualizaClave();
            beActualizaClave.ClaveUsuarioServicio = claveUsuarioServicio;
            beActualizaClave.IdAplicacion = idAplicacion;
            beActualizaClave.CodigoUsuario = usuario;
            beActualizaClave.NuevaClave = nuevaClave;
            beActualizaClave.ClaveAnterior = claveAnterior;
            beActualizaClave.UsuarioServicio = usuarioServicio;
            */
            respuestaActualizaClave = new BLValidarAcceso().CambiarClave(beActualizaClave);
            string mensaje = string.Empty;

            if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaActualizaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS))
                {
                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS];
                    respuestaActualizaClave.DescripcionRespuesta = mensaje;
                }
                else
                {

                    if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS))
                    {
                        mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_POR_ACTUALIZAR_REPETIDA];
                        respuestaActualizaClave.DescripcionRespuesta = mensaje;
                    }
                    else
                    {
                        if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO))
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_USUARIO_INVALIDO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                        else
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                    }
                }
            }

            return respuestaActualizaClave;
        }

        [WebMethod(Description = "Cambia la contraseña del usuario con la nueva contraseña suministrada")]
        public BERespuestaActualizaClave CambiarClaveWrapUp(BEActualizaClave beActualizaClave)//string usuario, string claveAnterior, string nuevaClave, string usuarioServicio, string claveUsuarioServicio, int idAplicacion)
        {
            BERespuestaActualizaClave respuestaActualizaClave;
            /*
            BEActualizaClave beActualizaClave = new BEActualizaClave();
            beActualizaClave.ClaveUsuarioServicio = claveUsuarioServicio;
            beActualizaClave.IdAplicacion = idAplicacion;
            beActualizaClave.CodigoUsuario = usuario;
            beActualizaClave.NuevaClave = nuevaClave;
            beActualizaClave.ClaveAnterior = claveAnterior;
            beActualizaClave.UsuarioServicio = usuarioServicio;
            */
            respuestaActualizaClave = new BLValidarAcceso().CambiarClaveWrapUp(beActualizaClave);
            string mensaje = string.Empty;

            if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaActualizaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS))
                {
                    mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_NO_CUMPLE_REQUISITOS_MINIMOS];
                    respuestaActualizaClave.DescripcionRespuesta = mensaje;
                }
                else
                {

                    if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_CLAVE_REPETIDA_13_ULTIMAS))
                    {
                        mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_POR_ACTUALIZAR_REPETIDA];
                        respuestaActualizaClave.DescripcionRespuesta = mensaje;
                    }
                    else
                    {
                        if (respuestaActualizaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_USUARIO_INVALIDO))
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_CLAVE_USUARIO_INVALIDO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                        else
                        {
                            mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                            respuestaActualizaClave.DescripcionRespuesta = mensaje;
                        }
                    }
                }
            }

            return respuestaActualizaClave;
        }

        [WebMethod(Description = "")]
        public BERespuestaEncriptaClave EncriptarPassword(BEEncriptaClave beEncriptaClave)
        {
            string mensaje = string.Empty;

            BERespuestaEncriptaClave respuestaEncriptaClave = new BLValidarAcceso().EncriptarPassword(beEncriptaClave);

            if (respuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaEncriptaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaEncriptaClave.DescripcionRespuesta = mensaje;
            }

            return respuestaEncriptaClave;
        }

        [WebMethod(Description = "")]
        public BERespuestaEncriptaClave DesencriptarPassword(BEEncriptaClave beEncriptaClave)
        {
            string mensaje = string.Empty;

            BERespuestaEncriptaClave respuestaEncriptaClave = new BLValidarAcceso().DesencriptarPassword(beEncriptaClave);

            if (respuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_NO_SE_TIENE_ACCESO_SERVICIO_WEB))
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_NO_TIENE_ACCESO_SERVICIO_WEB];
                respuestaEncriptaClave.DescripcionRespuesta = mensaje;
            }
            else
            {
                mensaje = ConfigurationManager.AppSettings[Constantes.MSG_EXITO];
                respuestaEncriptaClave.DescripcionRespuesta = mensaje;
            }

            return respuestaEncriptaClave;
        }
          [WebMethod(Description = "")]
        public List<BETipoEmpresa> ListarTipoEmpresaAplicacion(int IdAplicacion)
        {
            List<BETipoEmpresa> lstTipoEmpresa = new BLTipoEmpresa().ListarEmpresaAplicacion(IdAplicacion);
            return lstTipoEmpresa;
        }
          [WebMethod(Description = "")]
        public List<BEEmpresa> ListarEmpresaUsuario(BEUsuario oBEUsuario,int IdAplicacion)
        {
            List<BEEmpresa> lstEmpresa = new BLEmpresa().ListarEmpresaxUsuario(oBEUsuario,IdAplicacion);
            return lstEmpresa;
        }
          [WebMethod(Description = "")]
        public BEUsuario RegistrarUsuarioContratista(BEUsuario oBEUsuario,List<BEEmpresa> listaEmpresa,int IdAplicacion)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            if (oBLUsuario.InsertarUsuarioContratista(oBEUsuario, listaEmpresa, IdAplicacion))
                return oBEUsuario;
            else
                return null;
        }
        [WebMethod(Description = "")]
        public BEUsuario RecordarContraseña(string codigoUsuario)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            BEUsuario oBEUsuario = oBLUsuario.ObtenerUsuarioPorCodigoConPasswordDesencriptado(codigoUsuario);
            return oBEUsuario;
        }

        [WebMethod(Description = "")]
        public List<BEUsuario> ListaContratistaxEmpresa(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            List<BEUsuario> lstUsuarios = new BLUsuario().ListaContratistaxEmpresa(IdTipoEmpresa, IdUsuario, IdUsuarioLogueado, IdModo, IdAplicacion);
            return lstUsuarios;
        }
        [WebMethod(Description = "")]
        public List<BEEmpresa> ListaClientexContratista(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            List<BEEmpresa> lstEmpresas = new BLUsuario().ListaClientexContratista(IdTipoEmpresa, IdUsuario, IdUsuarioLogueado, IdModo, IdAplicacion);
            return lstEmpresas;
        }
        [WebMethod(Description = "")]
        public BEUsuario ActualizaUsuarioContratista(BEUsuario oBEUsuario, List<BEEmpresa> listaEmpresa, int IdAplicacion, int IdTipoCliente)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            if (oBLUsuario.ActualizarUsuarioSSEE(oBEUsuario, listaEmpresa, IdAplicacion, IdTipoCliente))
                return oBEUsuario;
            else
                return null;
        }
        [WebMethod(Description = "")]
        public int EliminaUsuarioContratista(int IdUsuario)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            BLPermisoUsuario oBLPermisoUsuario = new BLPermisoUsuario();
            oBLPermisoUsuario.EliminarTodosPermisoUsuario(IdUsuario);
            int codigoMensaje = 0;
            oBLUsuario.EliminarUsuario(IdUsuario, ref codigoMensaje);
            return codigoMensaje;
        }
        [WebMethod(Description = "")]
        public int CantidadUsuariosSSEE(String CodigoUsuario, int IdRol)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            return oBLUsuario.CantidadUsuarios(CodigoUsuario, IdRol);

        }

        [WebMethod(Description = "")]
        public List<BEEmpresa> ListarEmpresaUsuarioxTipoEmpresa(int idUsuario, int idTipo, int IdAplicacion)
        {
            List<BEEmpresa> lstEmpresa = new BLUsuario().ListarEmpresaxUsuario(idUsuario, idTipo, IdAplicacion);
            return lstEmpresa;
        }

        [WebMethod(Description = "")]
        public BEUsuario ObtenerUsuario(string codigoUsuario)
        {
            BLUsuario oBLUsuario = new BLUsuario();
            return oBLUsuario.ObtenerUsuarioPorCodigo(codigoUsuario);
        }
    }
}
