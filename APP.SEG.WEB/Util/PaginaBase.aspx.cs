using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Entidades;
using APP.SEG.Helper;
using System.Web.Configuration;

namespace APP.SEG.WEB.Util
{
    public partial class PaginaBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public BEUsuario ConvertUsuarioServicioToUsuario(ServicioSeguridadAPP.BEUsuario usuarioServicio)
        {
            BEUsuario usuario = new BEUsuario();
            try
            {
                usuario.ApellidoMaterno = usuarioServicio.ApellidoMaterno;
                usuario.ApellidoPaterno = usuarioServicio.ApellidoPaterno;
                usuario.Area = new BEArea();
                if (usuarioServicio.Area != null)
                {
                    usuario.Area.IdArea = usuarioServicio.Area.IdArea;
                }
                usuario.CambiarPasswordEnInicio = usuarioServicio.CambiarPasswordEnInicio;
                usuario.CodigoUsuario = usuarioServicio.CodigoUsuario;
                usuario.EstadoUsuario = usuarioServicio.EstadoUsuario;
                usuario.FechaCaduca = usuarioServicio.FechaCaduca;
                usuario.FechaCreacion = usuarioServicio.FechaCreacion;
                usuario.IdArea = usuarioServicio.IdArea;
                usuario.IdUsuario = usuarioServicio.IdUsuario;
                usuario.Nombres = usuarioServicio.Nombres;
                usuario.Oficina = new BEOficina();
                if (usuarioServicio.Oficina != null)
                {
                    usuario.Oficina.IdOficina = usuarioServicio.Oficina.IdOficina;
                }
                usuario.PagoTercero = usuarioServicio.PagoTercero;
                usuario.Password = usuarioServicio.Password;
                usuario.PasswordCaduca = usuarioServicio.PasswordCaduca;
                //usuario.PermisoUsuario = new BEPermisoUsuario();
                //usuario.PermisoUsuario = usuarioServicio.PermisoUsuario.;
                usuario.RequierePassword = usuarioServicio.RequierePassword;
                usuario.TipoUsuario = new BETipoUsuario();
                if (usuarioServicio.TipoUsuario != null)
                {
                    usuario.TipoUsuario.IdTipoUsuario = usuarioServicio.TipoUsuario.IdTipoUsuario;
                }
                //usuario.UsuarioCreacion = usuarioServicio.RequierePassword;

                usuario.PermisoUsuario = new BEPermisoUsuario();
                usuario.PermisoUsuario.BERol = new BERol();
                usuario.PermisoUsuario.BERol.IdRol = usuarioServicio.PermisoUsuario.BERol.IdRol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return usuario;
        }

        public void CargarPermisosObjetosFormulario(string idFormulario)
        {
            BEUsuario usuario = Session[Constantes.SESION_USUARIO_LOGIN] as BEUsuario;

            if (usuario != null)
            {
                int idRol = usuario.PermisoUsuario.BERol.IdRol;
                int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);
                string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                ServicioSeguridadAPP.BEConsultaServicio beConsultaServicio = new ServicioSeguridadAPP.BEConsultaServicio();
                beConsultaServicio.IdAplicacion = idAplicacion;
                beConsultaServicio.IdRol = idRol;
                beConsultaServicio.NombreFormulario = idFormulario;
                beConsultaServicio.UsuarioServicio = usuarioServicio;
                beConsultaServicio.ClaveUsuarioServicio = passwordServicio;

                ServicioSeguridadAPP.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadAPP.ServicioSeguridad();
                ServicioSeguridadAPP.BERespuestaPermisoObjeto respuestaPermisoObjeto = servicioSeguridad.ListarPermisoObjetoPorFormulario(beConsultaServicio);
                List<ServicioSeguridadAPP.BEObjeto> lista;

                lista = respuestaPermisoObjeto.ListaObjetos.Cast<ServicioSeguridadAPP.BEObjeto>().ToList();
                int cantidad = lista.Count;

                ContentPlaceHolder contenedor = (ContentPlaceHolder)Master.FindControl("MainContent");

                ServicioSeguridadAPP.BEObjeto objetoFormularioPadre = lista.Find(
                delegate(ServicioSeguridadAPP.BEObjeto bk)
                {
                    return bk.NombreFisicoObjeto.Equals(idFormulario);
                }
                );
                bool formularioTienePermisos = false;
                if (objetoFormularioPadre != null)
                {
                    formularioTienePermisos = objetoFormularioPadre.EstadoPermisoObjeto;
                }
                if (formularioTienePermisos)
                {
                    foreach (ServicioSeguridadAPP.BEObjeto objeto in lista)
                    {
                        if (objeto.TipoObjeto.IdTipoObjeto != Constantes.CODIGO_TIPO_OBJETO_FORMULARIO && objeto.TipoObjeto.IdTipoObjeto != Constantes.CODIGO_TIPO_OBJETO_OPCION_MENU)
                        {
                            Control control = contenedor.FindControl(objeto.NombreFisicoObjeto);
                            if (control != null)
                            {
                                switch (objeto.TipoObjeto.IdTipoObjeto)
                                {
                                    case Constantes.CODIGO_TIPO_OBJETO_BOTON://boton
                                        Button boton = (Button)control;
                                        boton.Enabled = objeto.EstadoPermisoObjeto;
                                        break;
                                    case Constantes.CODIGO_TIPO_OBJETO_LISTA_DESPLEGABLE://lista desplegable
                                        DropDownList dropDownList = (DropDownList)control;
                                        dropDownList.Enabled = objeto.EstadoPermisoObjeto;
                                        break;
                                    case Constantes.CODIGO_TIPO_OBJETO_CHECK_BOX://Checkbox
                                        CheckBox checkBox = (CheckBox)control;
                                        checkBox.Enabled = objeto.EstadoPermisoObjeto;
                                        break;
                                    case Constantes.CODIGO_TIPO_OBJETO_RADIO://Radio
                                        RadioButton radioButton = (RadioButton)control;
                                        radioButton.Enabled = objeto.EstadoPermisoObjeto;
                                        break;
                                    case Constantes.CODIGO_TIPO_OBJETO_CAJA_TEXTO://textbox
                                        TextBox textBox = (TextBox)control;
                                        textBox.Enabled = objeto.EstadoPermisoObjeto;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //CambiarHabilitacionTodosLosControles(false);
                    Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_ACCESO_RESTRINGIDO]);
                }
            }
            else
            {
                Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_LOGIN]);
            }
        }

        private void CambiarHabilitacionTodosLosControles(bool habilitado)
        {
            ContentPlaceHolder contenedor = (ContentPlaceHolder)Master.FindControl("MainContent");

            foreach (Control ctrl in contenedor.Controls)
            {
                if (ctrl is TextBox)

                    ((TextBox)ctrl).Enabled = habilitado;

                else if (ctrl is Button)

                    ((Button)ctrl).Enabled = habilitado;

                else if (ctrl is RadioButton)

                    ((RadioButton)ctrl).Enabled = habilitado;

                else if (ctrl is ImageButton)

                    ((ImageButton)ctrl).Enabled = habilitado;

                else if (ctrl is CheckBox)

                    ((CheckBox)ctrl).Enabled = habilitado;

                else if (ctrl is DropDownList)

                    ((DropDownList)ctrl).Enabled = habilitado;

                else if (ctrl is HyperLink)

                    ((HyperLink)ctrl).Enabled = habilitado;

            }
        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

    }
}
