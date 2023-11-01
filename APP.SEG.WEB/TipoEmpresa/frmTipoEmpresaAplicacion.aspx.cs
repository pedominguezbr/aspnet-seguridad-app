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
    public partial class frmTipoEmpresaAplicacion : PaginaBase
    {
        private const string ID_FORMULARIO = "frmTipoEmpresaAplicacion";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BETipoEmpresa TipoEmpresa = Session[Constantes.SESION_TIPOEMPRESAS] as BETipoEmpresa;
                    txtTipoEmpresa.Text = TipoEmpresa.NomTipoEmpresa;
                    CargarDatosGridView();
                }
                CargarPermisosObjetosFormulario(ID_FORMULARIO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void CargarDatosGridView()
        {
            BLAplicacion oBLAplicacion = new BLAplicacion();
            List<BEAplicacion> listaAplicacion = new List<BEAplicacion>();
            listaAplicacion = oBLAplicacion.ListarAplicacion();

            BLTipoEmpresa oBLTipoEmpresa = new BLTipoEmpresa();
            List<BETipoEmpresa> listaTipoEmpresa = new List<BETipoEmpresa>();

            BETipoEmpresa TipoEmpresa = Session[Constantes.SESION_TIPOEMPRESAS] as BETipoEmpresa;

            listaTipoEmpresa = oBLTipoEmpresa.ListarAplicacionxTipoEmpresa(TipoEmpresa.IdTipoEmpresa);

            int ContadorAplicacion = listaAplicacion.Count;
            for (int i = 0; i < ContadorAplicacion; i++ )
            {
                if (listaTipoEmpresa.Count > 0)
                {
                    int encontro = listaTipoEmpresa.FindIndex(x => x.BEAplicacion.IdAplicacion == listaAplicacion[i].IdAplicacion);
                    if (encontro == -1)
                    {
                        listaAplicacion[i].EstadoAplicacionEmpresa = false;
                    }
                    else
                    {
                        listaAplicacion[i].EstadoAplicacionEmpresa = true;
                    }
                }
                else
                {
                    listaAplicacion[i].EstadoAplicacionEmpresa = false;
                }
            }

            dgvAplicaciones.DataSource = listaAplicacion;
            dgvAplicaciones.DataBind();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            List<int> ListaAplicativo = new List<int>();
            foreach (GridViewRow fila in dgvAplicaciones.Rows)
            {
                CheckBox objCheck = ((CheckBox)fila.FindControl("chkTieneAcceso"));
                HiddenField objHidden = ((HiddenField)fila.FindControl("hdIdAplicacion"));

                if (objCheck.Checked)
                {
                    ListaAplicativo.Add(Int32.Parse(objHidden.Value));
                }
            }

            BETipoEmpresa TipoEmpresa = Session[Constantes.SESION_TIPOEMPRESAS] as BETipoEmpresa;

            BLTipoEmpresa oBLTipoEmpresa = new BLTipoEmpresa();
            oBLTipoEmpresa.AsignarPermisosAplicativoxTipoEmpresa(ListaAplicativo, TipoEmpresa.IdTipoEmpresa);

            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_TIPOEMPRESA_BUSCAR], false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_TIPOEMPRESA_BUSCAR], false);
        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
