using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using System.Web.Configuration;
using APP.SEG.Negocio;
using APP.SEG.Entidades;
using APP.SEG.WEB.Util;

namespace APP.SEG.WEB.Objetos
{
    public partial class frmObjetoDetalle : PaginaBase
    {
        private const string ID_OBJETO = "idObjeto";
        private string accion;
        private const string ID_FORMULARIO = "frmObjetoDetalle";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Extraemos los parametros de consulta
                accion = Request.QueryString[Constantes.MODO] != null ? Request.QueryString[Constantes.MODO].ToString() : "";
                string idObjeto = Request.QueryString[ID_OBJETO] != null ? Request.QueryString[ID_OBJETO] : "";

                int idObjetoPadre = Convert.ToInt16(Request.QueryString["idObjetoPadre"]);
                int idAplicacionSeleccionada = Convert.ToInt16(Request.QueryString["idAplicacionSeleccionada"]);

                if (!IsPostBack)
                {
                    Session.Remove(Constantes.SESION_OBJETO);

                    //Cargamos los datos de los controles de la pantalla
                    lbTituloPanel.Text = Constantes.ACCION_NUEVO;

                    HabilitarControlesConsulta();
                    //Cargamos los datos del Rol para los casos de consulta y edición
                    if (accion.Length > 0)
                    {
                        if (Constantes.ACCION_VISUALIZACION.Equals(accion))
                        {
                            ObtenerDatosObjeto(Int32.Parse(idObjeto));
                            lbTituloPanel.Text = Constantes.ACCION_VISUALIZACION;
                            DeshabilitarControlesConsulta();
                        }
                        else if (Constantes.ACCION_EDICION.Equals(accion))
                        {
                            ObtenerDatosObjeto(Int32.Parse(idObjeto));
                            lbTituloPanel.Text = Constantes.ACCION_EDICION;
                            //HabilitarControlesConsulta();
                        }
                    }
                    else
                    {

                        txtCodigo.Enabled = false;
                        txtCodigo.Visible = false;
                        lbTituloCodigo.Visible = false;

                        if (idAplicacionSeleccionada != -1)
                        {
                            CargarDatosControles(-1, -1);
                            ddlAplicativo.SelectedValue = idAplicacionSeleccionada.ToString();
                        }
                        else
                        {
                            if (idObjetoPadre != -1)
                            {
                                BEObjeto objetoPadre = new BLObjeto().ObtenerObjeto(idObjetoPadre);

                                int idAplicacionPadre = objetoPadre.Aplicacion.IdAplicacion;
                                int idTipoObjetoPadre = objetoPadre.TipoObjeto.IdTipoObjeto;

                                int idTipoObjeto = -1;
                                if (idTipoObjetoPadre == Constantes.CODIGO_TIPO_OBJETO_FORMULARIO)
                                {
                                    idTipoObjeto = Constantes.CODIGO_TIPO_OBJETO_BOTON;
                                }
                                else
                                {
                                    if (idTipoObjetoPadre == Constantes.CODIGO_TIPO_OBJETO_OPCION_MENU)
                                    {
                                        idTipoObjeto = Constantes.CODIGO_TIPO_OBJETO_FORMULARIO;
                                    }
                                    else
                                    {
                                        idTipoObjeto = idTipoObjetoPadre;
                                    }
                                }

                                CargarDatosControles(idAplicacionPadre, idTipoObjeto);


                                ddlAplicativo.SelectedValue = idAplicacionPadre.ToString();
                                ddlTipoObjeto.SelectedValue = idTipoObjeto.ToString();
                                ddlObjetoPadre.SelectedValue = idObjetoPadre.ToString();
                            }
                            else
                            {
                                CargarDatosControles(-1, -1);
                            }
                        }
                    }
                }
                CargarPermisosObjetosFormulario(ID_FORMULARIO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void ObtenerDatosObjeto(int _idObjeto)
        {
            BLObjeto blObjeto = new BLObjeto();
            BEObjeto beObjeto = blObjeto.ObtenerObjeto(_idObjeto);
            txtCodigo.Text = beObjeto.IdObjeto.ToString();
            txtNombre.Text = beObjeto.NombreFisicoObjeto;
            txtDescripcion.Text = beObjeto.DescripcionObjeto;
            txtEtiqueta.Text = beObjeto.EtiquetaObjeto;
            txtURL.Text = beObjeto.UrlObjeto;
            ddlAplicativo.SelectedValue = beObjeto.Aplicacion.IdAplicacion.ToString();
            if (beObjeto.EstadoObjeto)
            {
                ddlEstado.SelectedValue = Constantes.BOOL_ESTADO_ACTIVO.ToString();
            }
            else
            {
                ddlEstado.SelectedValue = Constantes.BOOL_ESTADO_INACTIVO.ToString();
            }
            if (beObjeto.TipoObjeto.IdTipoObjeto != -1)
            {
                ddlTipoObjeto.SelectedValue = beObjeto.TipoObjeto.IdTipoObjeto.ToString();
            }

            CargarDatosControles(beObjeto.Aplicacion.IdAplicacion, beObjeto.TipoObjeto.IdTipoObjeto);

            if (beObjeto.IdObjetoPadre != -1)
            {
                ddlObjetoPadre.SelectedValue = beObjeto.IdObjetoPadre.ToString();
            }
            Session[Constantes.SESION_OBJETO] = null;
            Session.Add(Constantes.SESION_OBJETO, beObjeto);
        }

        private void HabilitarControlesConsulta()
        {
            btnLimpiar.Enabled = true;
            btnLimpiar.Visible = true;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtEtiqueta.Enabled = true;
            txtURL.Enabled = true;
            txtCodigo.Enabled = false;
            ddlAplicativo.Enabled = true;
            ddlEstado.Enabled = true;
            ddlTipoObjeto.Enabled = true;
            ddlObjetoPadre.Enabled = true;
        }

        private void DeshabilitarControlesConsulta()
        {
            btnLimpiar.Enabled = false;
            btnLimpiar.Visible = false;
            btnGuardar.Enabled = false;
            btnGuardar.Visible = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtEtiqueta.Enabled = false;
            txtURL.Enabled = false;
            txtCodigo.Enabled = false;
            ddlAplicativo.Enabled = false;
            ddlEstado.Enabled = false;
            ddlTipoObjeto.Enabled = false;
            ddlObjetoPadre.Enabled = false;
        }

        private void CargarDatosControles(int idAplicacion, int idTipoObjeto)
        {

            BLAplicacion blAplicacion = new BLAplicacion();
            Formularios.CargarDropDownList(ddlAplicativo,
                                           blAplicacion.ListarAplicacion(),
                                           Constantes.TEXTO_DDL_APLICATIVO,
                                           Constantes.VALUE_DDL_APLICATIVO,
                                           Constantes.DEFAULT_DDL_APLICATIVO);
            BLTipoObjeto blTipoObjeto = new BLTipoObjeto();
            Formularios.CargarDropDownList(ddlTipoObjeto,
                                           blTipoObjeto.ListarTipoObjeto(),
                                           Constantes.TEXTO_DDL_TIPO_OBJETO,
                                           Constantes.VALUE_DDL_TIPO_OBJETO,
                                           Constantes.DEFAULT_DDL_TIPO_OBJETO);
            BLObjeto blObjeto = new BLObjeto();
            Formularios.CargarDropDownList(ddlObjetoPadre,
                                           blObjeto.ListarObjetoPadre(idAplicacion, idTipoObjeto),
                                           Constantes.TEXTO_DDL_OBJETO_PADRE,
                                           Constantes.VALUE_DDL_OBJETO_PADRE,
                                           Constantes.DEFAULT_DDL_OBJETO_PADRE);
            Formularios.CargarDdlEstados(ddlEstado, String.Empty);

            txtDescripcion.Attributes.Add("onkeypress", "return verificaLongitudTexto(this,150);");
            txtDescripcion.Attributes.Add("onblur", "return cortarLongitudTexto(this,150);");
            string mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_TEXTO_MUY_LARGO];
            txtDescripcion.Attributes.Add("onpaste", "return cortarLongitudTexto_OnPaste(this,150,'" + mensaje + "');");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BEObjeto beObjeto;
                if (Session[Constantes.SESION_OBJETO] != null)
                    beObjeto = (BEObjeto)Session[Constantes.SESION_OBJETO];
                else

                    beObjeto = new BEObjeto();

                beObjeto.NombreFisicoObjeto = txtNombre.Text.Trim();
                beObjeto.DescripcionObjeto = txtDescripcion.Text.Trim();
                beObjeto.EtiquetaObjeto = txtEtiqueta.Text.Trim();
                beObjeto.Aplicacion = new BEAplicacion();
                beObjeto.Aplicacion.IdAplicacion = Int32.Parse(ddlAplicativo.SelectedValue);
                beObjeto.TipoObjeto = new BETipoObjeto();
                beObjeto.TipoObjeto.IdTipoObjeto = Int32.Parse(ddlTipoObjeto.SelectedValue);
                if (ddlObjetoPadre.SelectedIndex == 0)
                {
                    beObjeto.IdObjetoPadre = -1;
                }
                else
                {
                    beObjeto.IdObjetoPadre = Int32.Parse(ddlObjetoPadre.SelectedValue);
                }
                if (Convert.ToInt32(ddlEstado.SelectedValue) == Constantes.BOOL_ESTADO_ACTIVO)
                {
                    beObjeto.EstadoObjeto = true;
                }
                else
                {
                    beObjeto.EstadoObjeto = false;
                }
                beObjeto.UrlObjeto = txtURL.Text.Trim();
                BLObjeto blobjeto = new BLObjeto();

                bool exito = false;

                if (beObjeto.IdObjeto == 0)
                {
                    exito = blobjeto.InsertarObjeto(beObjeto);
                    if (exito)
                    {
                        MessageBox.ShowAlertRedirect(WebConfigurationManager.AppSettings[Constantes.MSG_OBJETO_REGISTRADO_EXITOSAMENTE], WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_OBJETO_BUSCAR]);
                    }
                    else
                    {
                        MessageBox.ShowAlert(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_ACTUALIZAR_OBJETO_REPETIDO]);
                    }
                }
                else
                {
                    beObjeto.IdObjeto = Int32.Parse(txtCodigo.Text);
                    exito = blobjeto.ActualizarObjeto(beObjeto);
                    if (exito)
                    {
                        MessageBox.ShowAlertRedirect(WebConfigurationManager.AppSettings[Constantes.MSG_OBJETO_ACTUALIZADO_EXITOSAMENTE], WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_OBJETO_BUSCAR]);
                    }
                    else
                    {
                        MessageBox.ShowAlert(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_ACTUALIZAR_OBJETO_REPETIDO]);
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
            try
            {
                txtNombre.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                txtEtiqueta.Text = String.Empty;
                txtURL.Text = String.Empty;
                ddlAplicativo.SelectedIndex = 0;
                ddlEstado.SelectedValue = Constantes.VALUE_ESTADO_ACTIVO;
                ddlTipoObjeto.SelectedIndex = 0;

                Formularios.CargarDropDownList(ddlObjetoPadre,
                               new List<BEObjeto>(),
                               Constantes.TEXTO_DDL_OBJETO_PADRE,
                               Constantes.VALUE_DDL_OBJETO_PADRE,
                               Constantes.DEFAULT_DDL_OBJETO_PADRE);
                ddlObjetoPadre.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session[Constantes.SESION_OBJETO] != null)
                {
                    Session[Constantes.SESION_OBJETO] = null;
                }
                //Redireccionamos a la pantalla de búsqeuda de roles
                Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_OBJETO_BUSCAR],false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void ddlAplicativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLObjeto blObjeto = new BLObjeto();
                if (Convert.ToInt16(ddlAplicativo.SelectedValue) != -1 &&
                    Convert.ToInt16(ddlTipoObjeto.SelectedValue) != -1)
                {
                    Formularios.CargarDropDownList(ddlObjetoPadre,
                                                   blObjeto.ListarObjetoPadre(Convert.ToInt16(ddlAplicativo.SelectedValue), Convert.ToInt16(ddlTipoObjeto.SelectedValue)),
                                                   Constantes.TEXTO_DDL_OBJETO_PADRE,
                                                   Constantes.VALUE_DDL_OBJETO_PADRE,
                                                   Constantes.DEFAULT_DDL_OBJETO_PADRE);
                }
                else
                {
                    Formularios.CargarDropDownList(ddlObjetoPadre,
                                   blObjeto.ListarObjetoPadre(-1, -1),
                                   Constantes.TEXTO_DDL_OBJETO_PADRE,
                                   Constantes.VALUE_DDL_OBJETO_PADRE,
                                   Constantes.DEFAULT_DDL_OBJETO_PADRE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void ddlTipoObjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLObjeto blObjeto = new BLObjeto();
                if (Convert.ToInt16(ddlAplicativo.SelectedValue) != -1 &&
                    Convert.ToInt16(ddlTipoObjeto.SelectedValue) != -1)
                {
                    Formularios.CargarDropDownList(ddlObjetoPadre,
                                                   blObjeto.ListarObjetoPadre(Convert.ToInt16(ddlAplicativo.SelectedValue), Convert.ToInt16(ddlTipoObjeto.SelectedValue)),
                                                   Constantes.TEXTO_DDL_OBJETO_PADRE,
                                                   Constantes.VALUE_DDL_OBJETO_PADRE,
                                                   Constantes.DEFAULT_DDL_OBJETO_PADRE);
                }
                else
                {
                    Formularios.CargarDropDownList(ddlObjetoPadre,
                                   blObjeto.ListarObjetoPadre(-1, -1),
                                   Constantes.TEXTO_DDL_OBJETO_PADRE,
                                   Constantes.VALUE_DDL_OBJETO_PADRE,
                                   Constantes.DEFAULT_DDL_OBJETO_PADRE);
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
