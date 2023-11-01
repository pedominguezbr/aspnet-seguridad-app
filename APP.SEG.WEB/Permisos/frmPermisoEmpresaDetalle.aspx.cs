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
namespace APP.SEG.WEB.Permisos
{
    public partial class frmPermisoEmpresaDetalle : PaginaBase
    {
        private List<BETipoEmpresa> listaTipoEmpresa;
        List<BEEmpresa> listaEmpresa;
        List<BEEmpresa> listaEmpresaSeleccionados;
        private const string ID_FORMULARIO = "frmPermisoEmpresaDetalle";
        BEAplicacion oBEAplicacion;
        protected new void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int IdAplicacion = Int32.Parse(Request.QueryString["idAplicacion"].ToString());
                BLTipoEmpresa oBLTipoEmpresa = new BLTipoEmpresa();
                listaTipoEmpresa = oBLTipoEmpresa.ListarEmpresaAplicacion(IdAplicacion);
                //ViewState[Constantes.VIEWSTATE_LISTATIPOEMPRESA_APLICACION] = listaTipoEmpresa;
                BLAplicacion oBLAplicacion = new BLAplicacion();
                oBEAplicacion = oBLAplicacion.ObtenerAplicacion(IdAplicacion);
                ViewState[Constantes.VIEWSTATE_APLICACION] = oBEAplicacion;
                CargarControlGridInicial();
                CargarTipoEmpresaxAplicacion();
                BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;
                txtNombre.Text = usuario.Nombres + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;
                txtCodigo.Text = usuario.CodigoUsuario;
            }
            else
            {
                //listaTipoEmpresa = (List<BETipoEmpresa>)(ViewState[Constantes.VIEWSTATE_LISTATIPOEMPRESA_APLICACION]);
                oBEAplicacion = (BEAplicacion)(ViewState[Constantes.VIEWSTATE_APLICACION]);
                listaEmpresa = (List<BEEmpresa>)(ViewState[Constantes.VIEWSTATE_LISTAEMPRESA]);
                listaEmpresaSeleccionados = (List<BEEmpresa>)(ViewState[Constantes.VIEWSTATE_LISTAEMPRESASELECCIONADOS]);
            }

            txtAplicativo.Text = oBEAplicacion.NombreCortoAplicacion;
            CargarPermisosObjetosFormulario(ID_FORMULARIO);
        }

        protected void CargarTipoEmpresaxAplicacion()
        {
            ddlTipoEmpresa.DataSource = listaTipoEmpresa;
            ddlTipoEmpresa.DataTextField = "NomTipoEmpresa";
            ddlTipoEmpresa.DataValueField = "IdTipoEmpresa";
            ddlTipoEmpresa.DataBind();
        }

        protected void CargarControlGridInicial()
        {
            listaEmpresa = new List<BEEmpresa>();
            BEEmpresa oBEEmpresa = new BEEmpresa();
            oBEEmpresa.IdEmpresa = 0;
            oBEEmpresa.NomEmpresa = "None";
            listaEmpresa.Add(oBEEmpresa);
            dgvEmpresa.DataSource = listaEmpresa;
            dgvEmpresa.DataBind();
            dgvEmpresa.Rows[0].Visible = false;
            gvEmpresasSeleccionadas.DataSource = listaEmpresa;
            gvEmpresasSeleccionadas.DataBind();
            gvEmpresasSeleccionadas.Rows[0].Visible = false;
            ViewState[Constantes.VIEWSTATE_LISTAEMPRESA] = listaEmpresa;
            ViewState[Constantes.VIEWSTATE_LISTAEMPRESASELECCIONADOS] = listaEmpresa;
        }

        protected void gvEmpresasSeleccionadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int IdEmpresa = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == Constantes.COMANDO_ANULAR)
                {
                    listaEmpresaSeleccionados.RemoveAll(x => x.IdEmpresa == IdEmpresa);

                    BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;
                    int idUsuario = usuario.IdUsuario;
                    BLEmpresa oBLEmpresa = new BLEmpresa();
                    oBLEmpresa.EliminarEmpresaxUsuario(idUsuario, IdEmpresa, oBEAplicacion.IdAplicacion);

                    if (listaEmpresaSeleccionados.Count == 0)
                    {
                        BEEmpresa oBEEmpresa = new BEEmpresa();
                        oBEEmpresa.IdEmpresa = 0;
                        oBEEmpresa.NomEmpresa = "None";
                        listaEmpresaSeleccionados.Add(oBEEmpresa);
                        gvEmpresasSeleccionadas.DataSource = listaEmpresaSeleccionados;
                        gvEmpresasSeleccionadas.DataBind();
                        gvEmpresasSeleccionadas.Rows[0].Visible = false;
                        ViewState[Constantes.VIEWSTATE_LISTAEMPRESASELECCIONADOS] = listaEmpresaSeleccionados;
                    }
                    else
                    {
                        CargarDgvEmpresaSeleccionada();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
        protected void CargarDgvEmpresa()
        {
            dgvEmpresa.DataSource = listaEmpresa;
            dgvEmpresa.DataBind();
            ViewState[Constantes.VIEWSTATE_LISTAEMPRESA] = listaEmpresa;
        }

        protected void CargarDgvEmpresaSeleccionada()
        {
            gvEmpresasSeleccionadas.DataSource = listaEmpresaSeleccionados;
            gvEmpresasSeleccionadas.DataBind();
            ViewState[Constantes.VIEWSTATE_LISTAEMPRESASELECCIONADOS] = listaEmpresaSeleccionados;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BEEmpresa oBEEmpresa = new BEEmpresa();

                oBEEmpresa.NomEmpresa = txtBuscarEmpresa.Text;
                oBEEmpresa.BETipoEmpresa = new BETipoEmpresa();
                oBEEmpresa.BETipoEmpresa.IdTipoEmpresa = Int32.Parse(ddlTipoEmpresa.SelectedValue);

                BLEmpresa oBLEmpresa = new BLEmpresa();

                listaEmpresa = oBLEmpresa.BuscarEmpresaxTipoEmpresa(oBEEmpresa);

                BLUsuario oBLUsuario = new BLUsuario();

                BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;

                listaEmpresaSeleccionados = oBLUsuario.ListarEmpresaxUsuario(usuario.IdUsuario, Int32.Parse(ddlTipoEmpresa.SelectedValue), oBEAplicacion.IdAplicacion);


                CargarDgvEmpresa();

                CargarDgvEmpresaSeleccionada();
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void ddlTipoEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlGridInicial();

        }

        protected void dgvEmpresa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                    this.dgvEmpresa.PageIndex = e.NewPageIndex;

                    foreach (GridViewRow ItemGrid in this.dgvEmpresa.Rows)
                    {
                        CheckBox objCheck = ((CheckBox)ItemGrid.FindControl("ckSelect"));
                        HiddenField objHidden = ((HiddenField)ItemGrid.FindControl("hdIDEmpresa"));
                        int indice = listaEmpresa.FindIndex(delegate(BEEmpresa oEmpresa) { return oEmpresa.IdEmpresa == Int32.Parse(objHidden.Value); });


                            listaEmpresa[indice].checkValor = objCheck.Checked;

                    }

                    ViewState[Constantes.VIEWSTATE_LISTAEMPRESA] = listaEmpresa;

                    CargarDgvEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

             listaEmpresaSeleccionados.RemoveAll(x=>x.IdEmpresa == 0);




            if (dgvEmpresa.Rows.Count > 0)
            {

                foreach (GridViewRow ItemGrid in this.dgvEmpresa.Rows)
                {
                    CheckBox objCheck = ((CheckBox)ItemGrid.FindControl("ckSelect"));
                    HiddenField objHidden = ((HiddenField)ItemGrid.FindControl("hdIDEmpresa"));

                    if (objCheck.Checked)
                    {

                        int encontro = listaEmpresaSeleccionados.FindIndex(x => x.IdEmpresa == Int32.Parse(objHidden.Value));
                        if (encontro == -1)
                        {
                            int indice = listaEmpresa.FindIndex(delegate(BEEmpresa oEmpresa) { return oEmpresa.IdEmpresa == Int32.Parse(objHidden.Value); });
                            BEEmpresa oEmpresaAux = new BEEmpresa();
                            oEmpresaAux.IdEmpresa = Int32.Parse(objHidden.Value);
                            oEmpresaAux.NomEmpresa = ItemGrid.Cells[1].Text;
                            listaEmpresaSeleccionados.Add(oEmpresaAux);

                            BLEmpresa oBLEmpresa = new BLEmpresa();
                            BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;
                            oBLEmpresa.InsertarEmpresaUsuario(Int32.Parse(objHidden.Value), usuario.IdUsuario, oBEAplicacion.IdAplicacion);
                            listaEmpresa.RemoveAt(indice);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page),
                            "Mensaje",
                            "alert('Registro ya esta en la Grilla')", true);
                        }
                    }
                }
                ViewState[Constantes.VIEWSTATE_LISTAEMPRESA] = listaEmpresa;
                CargarDgvEmpresa();
                CargarDgvEmpresaSeleccionada();
            }

            if (listaEmpresa.Count == 0)
            {
                BEEmpresa oBEEmpresa = new BEEmpresa();
                oBEEmpresa.IdEmpresa = 0;
                oBEEmpresa.NomEmpresa = "None";
                listaEmpresa.Add(oBEEmpresa);
                dgvEmpresa.DataSource = listaEmpresa;
                dgvEmpresa.DataBind();
                dgvEmpresa.Rows[0].Visible = false;
                ViewState[Constantes.VIEWSTATE_LISTAEMPRESA] = listaEmpresa;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           /* BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;


            if (gvEmpresasSeleccionadas.Rows.Count > 1)
            {
                int IdUsuario = usuario.IdUsuario;
                BLEmpresa oBLEmpresa = new BLEmpresa();
                oBLEmpresa.EliminarEmpresaxUsuario(IdUsuario);
                foreach (GridViewRow ItemGrid in this.gvEmpresasSeleccionadas.Rows)
                {
                    HiddenField objHidden = ((HiddenField)ItemGrid.FindControl("hdIDEmpresa"));
                    oBLEmpresa.InsertarEmpresaUsuario(Int32.Parse(objHidden.Value), IdUsuario);
                }
            }
            * */
        }

        protected void btnSalir02_Click(object sender, EventArgs e)
        {
            Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_EMPRESA_PERMISO_BUSCAR], false);
        }
    }



}
