using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using System.Web.Configuration;
namespace APP.SEG.WEB.Util
{
    public partial class Encriptar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrptar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = true;
                txtResultado.Text = string.Empty;
                if (ValidarClave(txtClave.Text.Trim()) == true)
                {
                    ServicioSeguridadAPP.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadAPP.ServicioSeguridad();

                    string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                    string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                    string passwordEncriptado = txtValor.Text.Trim();
                    int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);

                    ServicioSeguridadAPP.BEEncriptaClave beEncriptaClave = new ServicioSeguridadAPP.BEEncriptaClave();
                    beEncriptaClave.ClaveUsuarioServicio = passwordServicio;
                    beEncriptaClave.UsuarioServicio = usuarioServicio;
                    beEncriptaClave.IdAplicacion = idAplicacion;
                    beEncriptaClave.PasswordDesencriptado = passwordEncriptado;
                    ServicioSeguridadAPP.BERespuestaEncriptaClave beRespuestaEncriptaClave = servicioSeguridad.EncriptarPassword(beEncriptaClave);
                    lblMensaje.Text = string.Empty;
                    if (beRespuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA))
                    {
                        txtResultado.Text = beRespuestaEncriptaClave.Clave;

                    }
                    else
                    {
                        MessageBox.ShowAlert(beRespuestaEncriptaClave.DescripcionRespuesta);
                    }
                }
                else
                {
                    txtResultado.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message + Environment.NewLine + ex.StackTrace;
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        bool ValidarClave(string claveIngreso)
        {
            string Clave = WebConfigurationManager.AppSettings[Constantes.CLAVE_PAGINA_ENCRYPTAR];

            if (claveIngreso.ToLower() == Clave.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnDesEncriptar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = true;
                txtResultado.Text = string.Empty;
                if (ValidarClave(txtClave.Text.Trim()) == true)
                {
                    ServicioSeguridadAPP.ServicioSeguridad servicioSeguridad = new APP.SEG.WEB.ServicioSeguridadAPP.ServicioSeguridad();

                    string usuarioServicio = WebConfigurationManager.AppSettings[Constantes.USUARIO_SERVICIO];
                    string passwordServicio = WebConfigurationManager.AppSettings[Constantes.PASSWORD_SERVICIO];

                    string passwordEncriptado = txtValor.Text.Trim();
                    int idAplicacion = Convert.ToInt16(WebConfigurationManager.AppSettings[Constantes.ID_APLICACION]);

                    ServicioSeguridadAPP.BEEncriptaClave beEncriptaClave = new ServicioSeguridadAPP.BEEncriptaClave();
                    beEncriptaClave.ClaveUsuarioServicio = passwordServicio;
                    beEncriptaClave.UsuarioServicio = usuarioServicio;
                    beEncriptaClave.IdAplicacion = idAplicacion;
                    beEncriptaClave.PasswordEncriptado = passwordEncriptado;
                    ServicioSeguridadAPP.BERespuestaEncriptaClave beRespuestaEncriptaClave = servicioSeguridad.DesencriptarPassword(beEncriptaClave);
                    lblMensaje.Text = string.Empty;
                    if (beRespuestaEncriptaClave.CodigoRespuesta.Equals(Constantes.CODIGO_RESPUESTA_DESENCRIPTACION_EXITOSA))
                    {
                        txtResultado.Text = beRespuestaEncriptaClave.Clave;
                    }
                    else
                    {
                        MessageBox.ShowAlert(beRespuestaEncriptaClave.DescripcionRespuesta);
                    }
                }
                else
                {
                    txtResultado.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message + Environment.NewLine + ex.StackTrace;
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
