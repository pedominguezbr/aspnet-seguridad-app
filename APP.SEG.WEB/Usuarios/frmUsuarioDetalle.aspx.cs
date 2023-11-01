using System;
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

namespace APP.SEG.WEB.Usuarios
{
    public partial class frmUsuarioDetalle : PaginaBase
    {
        private const string ID_USUARIO = "idUsuario";
        private string accion;
        private const string ID_FORMULARIO = "frmUsuarioDetalle";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                accion = Request.QueryString[Constantes.MODO] != null ? Request.QueryString[Constantes.MODO].ToString() : "";
                string idRol = Request.QueryString[ID_USUARIO] != null ? Request.QueryString[ID_USUARIO] : "";
                if (!Page.IsPostBack)
                {
                    Session.Remove(Constantes.SESION_USUARIO);

                    lbTituloPanel.Text = Constantes.ACCION_NUEVO;
                    if (accion.Length > 0)
                    {
                        if (Constantes.ACCION_VISUALIZACION.Equals(accion))
                        {
                            ObtenerDatosUsuario(Int32.Parse(idRol));
                            lbTituloPanel.Text = Constantes.ACCION_VISUALIZACION;
                            DeshabilitarControlesConsulta();
                        }
                        else if (Constantes.ACCION_EDICION.Equals(accion))
                        {
                            ObtenerDatosUsuario(Int32.Parse(idRol));
                            lbTituloPanel.Text = Constantes.ACCION_EDICION;
                            this.txtCodigo.Enabled = false;
                            if (chkPasswordCaduca.Checked)
                            {
                                txtFechaCaducidad.Enabled = true;
                                rfvFechaCaducidad.Enabled = true;
                            }
                            else
                            {
                                txtFechaCaducidad.Enabled = false;
                                rfvFechaCaducidad.Enabled = false;
                            }

                            this.chkPasswordCaduca.Attributes.Add("onclick", "javascript: habilitaFechaExpiracion('" + this.chkPasswordCaduca.ClientID + "', '" + txtFechaCaducidad.ClientID + "', '" + rfvFechaCaducidad.ClientID + "')");
                            this.chkCambiarPasswordInicio.Attributes.Add("onclick", "javascript: habilitaCambioPassword('" + this.chkCambiarPasswordInicio.ClientID + "', '" + txtPassword.ClientID + "', '" + rfvTxtPassword.ClientID + "')");

                            ClientScript.RegisterStartupScript(Page.GetType(), "scriptFechaExpiracion", "<script type='text/javascript'>habilitaFechaExpiracion('" + this.chkPasswordCaduca.ClientID + "', '" + txtFechaCaducidad.ClientID + "', '" + rfvFechaCaducidad.ClientID + "'); </script>");
                        }
                    }
                    else
                    {
                        LlenarListaEstados();
                        LlenarListaOficinas();
                        LlenarListaTiposUsuario();
                        LlenarListaAreas();
                        LlenarListaPagoTercero();
                        //this.chkPasswordCaduca.Attributes.Add("onclick", "javascript: habilitaFechaExpiracion('" + this.chkPasswordCaduca.ClientID + "', '" + txtFechaCaducidad.ClientID + "', '" + rfvFechaCaducidad.ClientID + "')");
                        this.chkPasswordCaduca.Checked = true;
                        this.chkCambiarPasswordInicio.Checked = true;
                        this.chkCambiarPasswordInicio.Enabled = false;
                        this.txtApellidoPaterno.Attributes.Add("onblur", "javascript: GenerarCodigoUsuario();");
                        this.txtNombre.Attributes.Add("onblur", "javascript: GenerarCodigoUsuario();");
                        txtFechaCaducidad.Enabled = false;
                        rfvFechaCaducidad.Enabled = false;

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
            ddlAccesoTercero.Enabled = false;
            ddlArea.Enabled = false;
            ddlEstado.Enabled = false;
            ddlOficina.Enabled = false;
            ddlTipoUsuario.Enabled = false;
            chkCambiarPasswordInicio.Enabled = false;
            chkPasswordCaduca.Enabled = false;
            txtApellidoMaterno.Enabled = false;
            txtApellidoPaterno.Enabled = false;
            txtCodigo.Enabled = false;
            txtFechaCaducidad.Enabled = false;
            txtNombre.Enabled = false;
            txtPassword.Enabled = false;
            txtFechaCaducidad.Enabled = false;
            txtCorreoElectronico.Enabled = false;
        }

        private void ObtenerDatosUsuario(int _idUsuario)
        {
            BLUsuario blUsuario = new BLUsuario();
            BEUsuario beUsuario = blUsuario.ObtenerUsuario(_idUsuario);
            txtNombre.Text = beUsuario.Nombres;
            txtApellidoPaterno.Text = beUsuario.ApellidoPaterno;
            txtApellidoMaterno.Text = beUsuario.ApellidoMaterno;
            txtCorreoElectronico.Text = beUsuario.CorreoElectronico;

            txtCodigo.Text = Convert.ToString(beUsuario.CodigoUsuario);
            if (beUsuario.FechaCaduca != null && beUsuario.FechaCaduca != DateTime.MinValue)
            {
                txtFechaCaducidad.Text = beUsuario.FechaCaduca.ToString("dd/MM/yyyy");
            }

            chkCambiarPasswordInicio.Checked = beUsuario.CambiarPasswordEnInicio;
            chkPasswordCaduca.Checked = beUsuario.PasswordCaduca;

            if (chkCambiarPasswordInicio.Checked)
            {
                this.chkCambiarPasswordInicio.Enabled = false;

                ServicioSeguridadAPP.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadAPP.ServicioSeguridad();

                string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                string passwordEncriptado = beUsuario.Password;
                int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);

                ServicioSeguridadAPP.BEEncriptaClave beEncriptaClave = new ServicioSeguridadAPP.BEEncriptaClave();
                beEncriptaClave.ClaveUsuarioServicio = passwordServicio;
                beEncriptaClave.UsuarioServicio = usuarioServicio;
                beEncriptaClave.IdAplicacion = idAplicacion;
                beEncriptaClave.PasswordEncriptado = passwordEncriptado;
                ServicioSeguridadAPP.BERespuestaEncriptaClave beRespuestaEncriptaClave = servicioSeguridad.DesencriptarPassword(beEncriptaClave);

                if (beRespuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA))
                {
                    txtPassword.Text = beRespuestaEncriptaClave.Clave;
                }
                else
                {
                    MessageBox.ShowAlert(beRespuestaEncriptaClave.DescripcionRespuesta);
                }
            }
            else
            {
                txtPassword.Text = "";
                this.txtPassword.Enabled = false;
                rfvTxtPassword.Enabled = false;
            }

            LlenarListaEstados();
            ddlEstado.SelectedValue = Convert.ToInt32(beUsuario.EstadoUsuario).ToString();

            LlenarListaPagoTercero();
            ddlAccesoTercero.SelectedValue = beUsuario.PagoTercero.ToString();

            LlenarListaTiposUsuario();
            ddlTipoUsuario.SelectedValue = beUsuario.TipoUsuario.IdTipoUsuario.ToString();

            LlenarListaOficinas();
            ddlOficina.SelectedValue = beUsuario.Oficina.IdOficina.ToString();

            LlenarListaAreas();
            ddlArea.SelectedValue = beUsuario.Area.IdArea.ToString();

            Session[Constantes.SESION_USUARIO] = null;
            Session.Add(Constantes.SESION_USUARIO, beUsuario);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {


                BEUsuario beusuario;
                if (Session[Constantes.SESION_USUARIO] != null)
                {
                    beusuario = (BEUsuario)Session[Constantes.SESION_USUARIO];
                }
                else
                {
                    beusuario = new BEUsuario();
                }


                if (chkPasswordCaduca.Checked)
                {
                    if (beusuario.IdUsuario != 0)
                    {
                        if (Convert.ToDateTime(txtFechaCaducidad.Text).Date < DateTime.Now.Date)
                        {
                            MessageBox.ShowAlert(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_FECHA_CADUCIDAD_DEBE_SER_MAYOR_FECHA_ACTUAL]);
                            return;
                        }
                    }
                }


                //BEUsuario beusuario = new BEUsuario();
                beusuario.Nombres = txtNombre.Text;
                beusuario.ApellidoMaterno = txtApellidoMaterno.Text;
                beusuario.ApellidoPaterno = txtApellidoPaterno.Text;
                beusuario.CorreoElectronico = txtCorreoElectronico.Text;
                beusuario.CodigoUsuario = txtCodigo.Text.Trim();
                beusuario.TipoUsuario = new BETipoUsuario();
                beusuario.TipoUsuario.IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                beusuario.Area = new BEArea();
                beusuario.Area.IdArea = Convert.ToInt32(ddlArea.SelectedValue);
                beusuario.IdArea = Convert.ToInt32(ddlArea.SelectedValue);
                beusuario.Oficina = new BEOficina();
                beusuario.Oficina.IdOficina = Convert.ToInt32(ddlOficina.SelectedValue);
                //beusuario.RequierePassword = chkRequierePassword.Checked;
                beusuario.CambiarPasswordEnInicio = chkCambiarPasswordInicio.Checked;
                if (chkCambiarPasswordInicio.Checked)
                {
                    ServicioSeguridadAPP.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadAPP.ServicioSeguridad();

                    string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                    string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                    string passwordDesencriptado = txtPassword.Text.Trim();
                    int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);

                    ServicioSeguridadAPP.BEEncriptaClave beEncriptaClave = new ServicioSeguridadAPP.BEEncriptaClave();
                    beEncriptaClave.ClaveUsuarioServicio = passwordServicio;
                    beEncriptaClave.UsuarioServicio = usuarioServicio;
                    beEncriptaClave.IdAplicacion = idAplicacion;
                    beEncriptaClave.PasswordDesencriptado = passwordDesencriptado;
                    ServicioSeguridadAPP.BERespuestaEncriptaClave beRespuestaEncriptaClave = servicioSeguridad.EncriptarPassword(beEncriptaClave);

                    if (beRespuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA))
                    {
                        beusuario.Password = beRespuestaEncriptaClave.Clave;
                    }
                    else
                    {
                        MessageBox.ShowAlert(beRespuestaEncriptaClave.DescripcionRespuesta);
                    }
                }
                else
                {
                    beusuario.Password = "";
                }
                beusuario.PasswordCaduca = chkPasswordCaduca.Checked;
                if (chkPasswordCaduca.Checked)
                {
                    if (beusuario.IdUsuario != 0)
                    {
                        beusuario.FechaCaduca = Convert.ToDateTime(txtFechaCaducidad.Text);
                    }
                }

                if (Convert.ToInt32(ddlEstado.SelectedValue) == 1)
                {
                    beusuario.EstadoUsuario = true;
                }
                else
                {
                    beusuario.EstadoUsuario = false;
                }
                beusuario.PagoTercero = Convert.ToInt32(ddlAccesoTercero.SelectedValue);
                string mensaje = "";

                BLUsuario blUsuario = new BLUsuario();
                if (beusuario.IdUsuario != 0)
                {
                    blUsuario.ActualizarUsuario(beusuario);
                    mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_USUARIO_ACTUALIZADO_EXITOSAMENTE];
                    MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_USUARIO_BUSCAR]);
                }
                else
                {
                    blUsuario.InsertarUsuario(beusuario);
                    if (beusuario.IdUsuario == -1)
                    {
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_USUARIO_CODIGO_REPETIDO];
                        MessageBox.ShowAlert(mensaje);
                    }
                    else
                    {
                        Session.Add(Constantes.SESION_USUARIO, beusuario);
                        mensaje = WebConfigurationManager.AppSettings[Constantes.MSG_USUARIO_REGISTRADO_EXITOSAMENTE];
                        //MessageBox.ShowAlertRedirect(mensaje, "frmUsuarioBuscar.aspx");
                        MessageBox.ShowAlertRedirect(mensaje, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FISICA_FRM_PERMISO_USUARIO_BUSCAR]);

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

            txtNombre.Text = String.Empty;
            txtApellidoPaterno.Text = String.Empty;
            txtApellidoMaterno.Text = String.Empty;
            if (txtCodigo.Enabled)
            {
                txtCodigo.Text = String.Empty;
            }
            txtPassword.Text = String.Empty;
            txtFechaCaducidad.Text = String.Empty;
            txtCorreoElectronico.Text = String.Empty;
            ddlAccesoTercero.SelectedIndex = 0;
            ddlArea.SelectedIndex = 0;
            ddlOficina.SelectedIndex = 0;
            ddlTipoUsuario.SelectedIndex = 0;
            ddlEstado.SelectedValue = Constantes.VALUE_ESTADO_ACTIVO;
            chkPasswordCaduca.Checked = true;
            //chkRequierePassword.Checked = false;
            if (!chkCambiarPasswordInicio.Enabled)
            {
                chkCambiarPasswordInicio.Checked = true;
            }
            else
            {
                chkCambiarPasswordInicio.Checked = false;
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

            if (Session[Constantes.SESION_USUARIO] != null)
            {
                Session[Constantes.SESION_USUARIO] = null;
            }
            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_USUARIO_BUSCAR], false);

        }

        private void LlenarListaOficinas()
        {
            List<BEOficina> lista = new List<BEOficina>();
            BLOficina blOficina = new BLOficina();
            lista = blOficina.ListarOficina();

            Helper.Formularios.CargarDropDownList(ddlOficina, lista, "NombreOficina", "idoficina", null);
        }

        private void LlenarListaEstados()
        {
            Formularios.CargarDdlEstados(ddlEstado, String.Empty);
            //ddlEstado.Items.Add(new ListItem(Constantes.VALUE_ESTADO_ACTIVO, ConfigurationManager.AppSettings[Constantes.TEXTO_ESTADO_ACTIVO].ToString()));
            //ddlEstado.Items.Add(new ListItem(Constantes.VALUE_ESTADO_INACTIVO, ConfigurationManager.AppSettings[Constantes.TEXTO_ESTADO_INACTIVO].ToString()));
        }
        private void LlenarListaTiposUsuario()
        {
            List<BETipoUsuario> lista = new List<BETipoUsuario>();
            BLTipoUsuario blTipoUsuario = new BLTipoUsuario();
            lista = blTipoUsuario.ListarTipoUsuario();

            Helper.Formularios.CargarDropDownList(ddlTipoUsuario, lista, "NombreTipoUsuario", "IdTipoUsuario", null);
        }
        private void LlenarListaAreas()
        {
            List<BEArea> lista = new List<BEArea>();
            BLArea blArea = new BLArea();
            lista = blArea.ListarArea();

            Helper.Formularios.CargarDropDownList(ddlArea, lista, "NombreCortoArea", "IdArea", null);
        }
        private void LlenarListaPagoTercero()
        {
            Formularios.CargarDdlPagoTercero(ddlAccesoTercero, Constantes.DEFAULT_DDL_PAGO_TERCERO);
            //ddlAccesoTercero.Items.Add(new ListItem("SI", ConfigurationManager.AppSettings["SI"].ToString()));
            //ddlAccesoTercero.Items.Add(new ListItem("NO", ConfigurationManager.AppSettings["NO"].ToString()));
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string area = Convert.ToString(ddlArea.SelectedValue);
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
