using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using System.Web.Configuration;
using System.Text;

namespace APP.SEG.WEB
{
    public partial class APPSeguridad : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarMenuOpciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try
            {
                //Eliminamos datos de la session
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();

                //Redirigimos a la pantalla de Login
                Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_LOGIN], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }


        private void cargarMenuOpciones()
        {
            StringBuilder cadenaMenu = new StringBuilder();

            if (Session[Constantes.SESION_OPCIONES_MENU] != null)
            {
                List<ServicioSeguridadAPP.BEObjeto> lista = Session[Constantes.SESION_OPCIONES_MENU] as List<ServicioSeguridadAPP.BEObjeto>;

                List<ServicioSeguridadAPP.BEObjeto> listaObjetosPadres = lista.FindAll(
                delegate(ServicioSeguridadAPP.BEObjeto bk)
                {
                    return bk.IdObjetoPadre.Equals(-1) && bk.EstadoPermisoObjeto;
                }
                );

                foreach (ServicioSeguridadAPP.BEObjeto objeto in listaObjetosPadres)
                {
                    cadenaMenu.Append(string.Format("<li><a>{0}</a>\n", objeto.EtiquetaObjeto));

                    List<ServicioSeguridadAPP.BEObjeto> listaObjetosHijos = lista.FindAll(
                    delegate(ServicioSeguridadAPP.BEObjeto bk)
                    {
                        return bk.IdObjetoPadre.Equals(objeto.IdObjeto) && bk.EstadoPermisoObjeto;
                    }
                    );
                    cadenaMenu.Append("\t<ul class=\"listav links\"  style=\"display: none; \">\n");
                    foreach (ServicioSeguridadAPP.BEObjeto objetoHijo in listaObjetosHijos)
                    {
                        cadenaMenu.Append(string.Format("\t\t<li><a id=\"ctl00_HyperLink{0}\" href=\"{1}\">{2}</a></li>\n", objetoHijo.IdObjeto, "../" + objetoHijo.UrlObjeto, objetoHijo.EtiquetaObjeto));
                    }
                    cadenaMenu.Append("\t</ul>\n");
                    cadenaMenu.Append("</li>\n");
                }

                ltrMenuOpciones.Text = cadenaMenu.ToString();
            }
            else
            {
                Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_LOGIN], false);
            }

        }

        protected void lnkCambiarPassword_Click(object sender, EventArgs e)
        {

            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_RENOVACION_CLAVE], false);

        }

    }
}
