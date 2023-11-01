using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using APP.SEG.Entidades;
using APP.SEG.Helper;
using System.Web.Configuration;
using APP.SEG.Negocio;
using APP.SEG.WEB.Util;

namespace APP.SEG.WEB.TipoEmpresa
{
    public partial class frmTipoEmpresaDetalle : PaginaBase
    {
        private const string ID_TIPOEMPRESA = "IdTipoEmpresa";
        private string accion;
        private const string ID_FORMULARIO = "frmTipoEmpresaDetalle";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                accion = Request.QueryString[Constantes.MODO] != null ? Request.QueryString[Constantes.MODO].ToString() : "";
                string idTipoEmpresa = Request.QueryString[ID_TIPOEMPRESA] != null ? Request.QueryString[ID_TIPOEMPRESA] : "";
                if (!Page.IsPostBack)
                {
                    Session.Remove(Constantes.SESION_TIPOEMPRESAS);
                    LlenarListaEstados();

                    lbTituloPanel.Text = Constantes.ACCION_NUEVO;
                    if (accion.Length > 0)
                    {
                        if (Constantes.ACCION_VISUALIZACION.Equals(accion))
                        {
                            ObtenerDatosTipoEmpresa(Int32.Parse(idTipoEmpresa));
                            lbTituloPanel.Text = Constantes.ACCION_VISUALIZACION;
                            DeshabilitarControlesConsulta();
                        }
                        else if (Constantes.ACCION_EDICION.Equals(accion))
                        {
                            ObtenerDatosTipoEmpresa(Int32.Parse(idTipoEmpresa));
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

            ddlEstado.Enabled = false;


        }

        private void ObtenerDatosTipoEmpresa(int _idTipoEmpresa)
        {
            BLTipoEmpresa blTipoEmpresa = new BLTipoEmpresa();
            BETipoEmpresa beTipoEmpresa = blTipoEmpresa.ObtenerTipoEmpresa(_idTipoEmpresa);
            txtRazonSocial.Text = beTipoEmpresa.NomTipoEmpresa;

            ddlEstado.SelectedValue = Convert.ToInt32(beTipoEmpresa.EstadoTipoEmpresa).ToString();

            Session[Constantes.SESION_TIPOEMPRESAS] = null;
            Session.Add(Constantes.SESION_TIPOEMPRESAS, beTipoEmpresa);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BETipoEmpresa oBETipoEmpresa;
                if (Session[Constantes.SESION_TIPOEMPRESAS] != null)
                {
                    oBETipoEmpresa = (BETipoEmpresa)Session[Constantes.SESION_TIPOEMPRESAS];
                }
                else
                {
                    oBETipoEmpresa = new BETipoEmpresa();
                }
                oBETipoEmpresa.NomTipoEmpresa = txtRazonSocial.Text;

                if (Convert.ToInt32(ddlEstado.SelectedValue) == 1)
                {
                    oBETipoEmpresa.EstadoTipoEmpresa = true;
                }
                else
                {
                    oBETipoEmpresa.EstadoTipoEmpresa = false;
                }

                BLTipoEmpresa BLTipoEmpresa = new BLTipoEmpresa();
                string mensaje;
                if (oBETipoEmpresa.IdTipoEmpresa != 0)
                {
                    BLTipoEmpresa.ActualizarTipoEmpresa(oBETipoEmpresa);
                    mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_TIPOEMPRESA_ACTUALIZADO_EXITOSAMENTE];
                    MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_TIPOEMPRESA_BUSCAR]);
                }
                else
                {
                    BLTipoEmpresa.InsertarTipoEmpresa(oBETipoEmpresa);
                    if (oBETipoEmpresa.IdTipoEmpresa == -1)
                    {
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_USUARIO_CODIGO_REPETIDO];
                        MessageBox.ShowAlert(mensaje);
                    }
                    else
                    {
                        Session.Add(Constantes.SESION_TIPOEMPRESAS, oBETipoEmpresa);
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_TIPOEMPRESA_REGISTRADO_EXITOSAMENTE];
                        //MessageBox.ShowAlertRedirect(mensaje, "frmUsuarioBuscar.aspx");
                        MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_TIPOEMPRESA_BUSCAR]);

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

            ddlEstado.SelectedIndex = 0;


        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {

            if (Session[Constantes.SESION_TIPOEMPRESAS] != null)
            {
                Session[Constantes.SESION_TIPOEMPRESAS] = null;
            }
            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_TIPOEMPRESA_BUSCAR], false);

        }
        private void LlenarListaEstados()
        {
            ddlEstado.Items.Insert(0, new ListItem("Seleccione", "-1"));
            ddlEstado.Items.Insert(1, new ListItem(Constantes.TEXTO_ESTADO_ACTIVO, Constantes.VALUE_ESTADO_ACTIVO));
            ddlEstado.Items.Insert(2, new ListItem(Constantes.TEXTO_ESTADO_INACTIVO, Constantes.VALUE_ESTADO_INACTIVO));
        }



    }
}
