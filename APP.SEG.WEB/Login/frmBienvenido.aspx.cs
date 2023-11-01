﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using APP.SEG.Entidades;
using System.Web.Configuration;

namespace APP.SEG.WEB.Login
{
    public partial class frmBienvenido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session[Constantes.SESION_USUARIO_LOGIN] != null)
                    {

                        BEUsuario usuario = Session[Constantes.SESION_USUARIO_LOGIN] as BEUsuario;

                        int idRol = usuario.PermisoUsuario.BERol.IdRol;
                        int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);
                        string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                        string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                        ServicioSeguridadJLT.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadJLT.ServicioSeguridad();

                        ServicioSeguridadJLT.BEConsultaServicio beConsultaServicio = new ServicioSeguridadJLT.BEConsultaServicio();
                        beConsultaServicio.IdAplicacion = idAplicacion;
                        beConsultaServicio.IdRol = idRol;
                        beConsultaServicio.UsuarioServicio = usuarioServicio;
                        beConsultaServicio.ClaveUsuarioServicio = passwordServicio;

                        ServicioSeguridadJLT.BERespuestaPermisoObjeto respuestaPermisoObjeto = servicioSeguridad.ListarPermisoObjetoMenuOpciones(beConsultaServicio);
                        List<ServicioSeguridadJLT.BEObjeto> listaOpcionesMenu;

                        listaOpcionesMenu = respuestaPermisoObjeto.ListaObjetos.Cast<ServicioSeguridadJLT.BEObjeto>().ToList();

                        Session.Add(Constantes.SESION_OPCIONES_MENU, listaOpcionesMenu);


                        lbNombreUsuario.Text = usuario.Nombres + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
