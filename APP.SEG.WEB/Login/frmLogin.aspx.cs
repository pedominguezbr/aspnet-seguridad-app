﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using APP.SEG.Entidades;
using APP.SEG.WEB.Util;
using System.Web.Configuration;

namespace APP.SEG.WEB.Login
{
    public partial class frmLogin : PaginaBase
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);
                    ServicioSeguridadJLT.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadJLT.ServicioSeguridad();

                    string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                    string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                    ServicioSeguridadJLT.BEConsultaServicio beConsultaServicio = new APP.SEG.WEB.ServicioSeguridadJLT.BEConsultaServicio();
                    beConsultaServicio.IdAplicacion = idAplicacion;
                    beConsultaServicio.UsuarioServicio = usuarioServicio;
                    beConsultaServicio.ClaveUsuarioServicio = passwordServicio;

                    ServicioSeguridadJLT.BERespuestaRol respuestaRol = servicioSeguridad.ListarRol(beConsultaServicio);

                    if (respuestaRol.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_EXITOSA_LISTA_ROLES))
                    {
                        Helper.Formularios.CargarDropDownList(ddlRol, respuestaRol.ListaRoles, "NombreRol", "IdRol", WebConfigurationManager.AppSettings[Constantes.ITEM_DEFAULT_COMBO_ROL]);
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = respuestaRol.DescripcionRespuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != String.Empty && txtPassword.Text != String.Empty && ddlRol.SelectedIndex > 0)
            {
                ServicioSeguridadJLT.BERespuestaAcceso respuestaAcceso = null;
                try
                {
                    int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);
                    ServicioSeguridadJLT.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadJLT.ServicioSeguridad();
                    string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                    string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                    ServicioSeguridadJLT.BEValidaAcceso beValidaAcceso = new APP.SEG.WEB.ServicioSeguridadJLT.BEValidaAcceso();
                    beValidaAcceso.UsuarioLogueo = txtUsuario.Text;
                    beValidaAcceso.ClaveLogueo = txtPassword.Text;
                    beValidaAcceso.UsuarioServicio = usuarioServicio;
                    beValidaAcceso.ClaveUsuarioServicio = passwordServicio;
                    beValidaAcceso.IdAplicacion = idAplicacion;
                    beValidaAcceso.IdRol = Convert.ToInt16(ddlRol.SelectedValue);

                    respuestaAcceso = servicioSeguridad.ValidarAcceso(beValidaAcceso);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                    NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
                    return;
                }
                if (respuestaAcceso.CodigoRespuesta == Constantes.CODIGO_RESPUESTA_LOGUEO_EXISTOSO)
                {
                    BEUsuario usuario = ConvertUsuarioServicioToUsuario(respuestaAcceso.BEUsuario);

                    Session.Add(Constantes.SESION_USUARIO_LOGIN, usuario);


                    Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_BIENVENIDO],false);
                }
                else
                {
                    if (respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_CLAVE_EXPIRADA) ||
                        respuestaAcceso.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_LOGUEO_USUARIO_DEBE_CAMBIAR_CLAVE))
                    {
                        Context.Items["usuario"] = txtUsuario.Text;
                        Context.Items["idRol"] = ddlRol.SelectedValue;
                        Server.Transfer(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_RENOVACION_CLAVE]);
                      //  Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_RENOVACION_CLAVE], true);
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = respuestaAcceso.DescripcionRespuesta;
                    }
                }
            }

        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
