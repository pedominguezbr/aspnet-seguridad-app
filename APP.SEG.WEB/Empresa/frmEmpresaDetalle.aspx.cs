﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using APP.SEG.Helper;
using APP.SEG.Entidades;
using APP.SEG.Negocio;
using APP.SEG.AccesoDatos;
using System.Configuration;
using System.Web.Configuration;
using APP.SEG.WEB.Util;


namespace APP.SEG.WEB.Empresa
{
    public partial class frmEmpresaDetalle : PaginaBase
    {
        private const string ID_EMPRESA = "IdEmpresa";
        private string accion;
        private const string ID_FORMULARIO = "frmEmpresaDetalle";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                accion = Request.QueryString[Constantes.MODO] != null ? Request.QueryString[Constantes.MODO].ToString() : "";
                string idEmpresa = Request.QueryString[ID_EMPRESA] != null ? Request.QueryString[ID_EMPRESA] : "";
                if (!Page.IsPostBack)
                {
                    Session.Remove(Constantes.SESION_EMPRESAS);
                    LlenarListaEstados();
                    LlenarListaTipoEmpresa();
                    lbTituloPanel.Text = Constantes.ACCION_NUEVO;
                    if (accion.Length > 0)
                    {
                        if (Constantes.ACCION_VISUALIZACION.Equals(accion))
                        {
                            ObtenerDatosEmpresa(Int32.Parse(idEmpresa));
                            lbTituloPanel.Text = Constantes.ACCION_VISUALIZACION;
                            DeshabilitarControlesConsulta();
                        }
                        else if (Constantes.ACCION_EDICION.Equals(accion))
                        {
                            ObtenerDatosEmpresa(Int32.Parse(idEmpresa));
                            lbTituloPanel.Text = Constantes.ACCION_EDICION;

                        }
                    }
                    else
                    {
                        //LlenarListaEstados();



                    }
                }
                if (!Constantes.ACCION_VISUALIZACION.Equals(accion))
                {
                    //ClientScript.RegisterStartupScript(Page.GetType(), "scriptFechaExpiracion", "<script type='text/javascript'>habilitaFechaExpiracion('" + this.chkPasswordCaduca.ClientID + "', '" + txtFechaCaducidad.ClientID + "', '" + rfvFechaCaducidad.ClientID + "'); </script>");
                }
                CargarPermisosObjetosFormulario(ID_FORMULARIO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void DeshabilitarControlesConsulta()
        {
            btnLimpiar.Enabled = false;
            btnLimpiar.Visible = false;
            btnGuardar.Enabled = false;
            btnGuardar.Visible = false;
            txtRazonSocial.Enabled = false;
            txtRuc.Enabled = false;
            txtTelefono.Enabled = false;
            ddlEstado.Enabled = false;
            ddlTipoEmpresa.Enabled = false;

        }

        private void ObtenerDatosEmpresa(int _idEmpresa)
        {
            BLEmpresa blEmpresa = new BLEmpresa();
            BEEmpresa beEmpresa = blEmpresa.ObtenerEmpresa(_idEmpresa);
            txtRazonSocial.Text = beEmpresa.NomEmpresa;
            txtRuc.Text = beEmpresa.Ruc;
            txtTelefono.Text = beEmpresa.Telefono;
            ddlEstado.SelectedValue = Convert.ToInt32(beEmpresa.EstadoEmpresa).ToString();
            ddlTipoEmpresa.SelectedValue = Convert.ToInt32(beEmpresa.BETipoEmpresa.IdTipoEmpresa).ToString();
            Session[Constantes.SESION_EMPRESAS] = null;
            Session.Add(Constantes.SESION_EMPRESAS, beEmpresa);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BEEmpresa oBEEmpresa;
                if (Session[Constantes.SESION_EMPRESAS] != null)
                {
                    oBEEmpresa = (BEEmpresa)Session[Constantes.SESION_EMPRESAS];
                }
                else
                {
                    oBEEmpresa = new BEEmpresa();
                }
                oBEEmpresa.NomEmpresa = txtRazonSocial.Text;
                oBEEmpresa.Ruc = txtRuc.Text;
                oBEEmpresa.BETipoEmpresa = new BETipoEmpresa();
                oBEEmpresa.BETipoEmpresa.IdTipoEmpresa = Int32.Parse(ddlTipoEmpresa.SelectedValue);
                if (Convert.ToInt32(ddlEstado.SelectedValue) == 1)
                {
                    oBEEmpresa.EstadoEmpresa = true;
                }
                else
                {
                    oBEEmpresa.EstadoEmpresa = false;
                }
                oBEEmpresa.Telefono = txtTelefono.Text;
                BLEmpresa BLEmpresa = new BLEmpresa();
                string mensaje;
                if (oBEEmpresa.IdEmpresa != 0)
                {
                    BLEmpresa.ActualizarEmpresa(oBEEmpresa);
                    mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_EMPRESA_ACTUALIZADO_EXITOSAMENTE];
                    MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_EMPRESA_BUSCAR]);
                }
                else
                {
                    BLEmpresa.InsertarEmpresa(oBEEmpresa);
                    if (oBEEmpresa.IdEmpresa == -1)
                    {
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_USUARIO_CODIGO_REPETIDO];
                        MessageBox.ShowAlert(mensaje);
                    }
                    else
                    {
                        Session.Add(Constantes.SESION_EMPRESAS, oBEEmpresa);
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_EMPRESA_REGISTRADO_EXITOSAMENTE];
                        //MessageBox.ShowAlertRedirect(mensaje, "frmUsuarioBuscar.aspx");
                        MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_EMPRESA_BUSCAR]);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtRazonSocial.Text = String.Empty;
            txtRuc.Text = String.Empty;
            txtTelefono.Text = String.Empty;

            ddlTipoEmpresa.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;


        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {

            if (Session[Constantes.SESION_EMPRESAS] != null)
            {
                Session[Constantes.SESION_EMPRESAS] = null;
            }
            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_EMPRESA_BUSCAR], false);

        }
        private void LlenarListaEstados()
        {
            ddlEstado.Items.Insert(0, new ListItem("Seleccione", "-1"));
            ddlEstado.Items.Insert(1, new ListItem(Constantes.TEXTO_ESTADO_ACTIVO, Constantes.VALUE_ESTADO_ACTIVO));
            ddlEstado.Items.Insert(2, new ListItem(Constantes.TEXTO_ESTADO_INACTIVO, Constantes.VALUE_ESTADO_INACTIVO));
        }
        private void LlenarListaTipoEmpresa()
        {
            List<BETipoEmpresa> lista = new List<BETipoEmpresa>();
            BLTipoEmpresa blTipoEmpresa = new BLTipoEmpresa();
            BETipoEmpresa obETipoEmpresa = new BETipoEmpresa();
            obETipoEmpresa.NomTipoEmpresa = String.Empty;
            lista = blTipoEmpresa.BuscarTipoEmpresa(obETipoEmpresa);
            Helper.Formularios.CargarDropDownList(ddlTipoEmpresa, lista, "NomTipoEmpresa", "IdTipoEmpresa", "Seleccione");
        }
    }
}
