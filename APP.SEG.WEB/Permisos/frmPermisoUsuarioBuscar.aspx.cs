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
    public partial class frmPermisoUsuarioBuscar : PaginaBase
    {
        private const string ID_FORMULARIO = "frmPermisoUsuarioBuscar";

        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;
                    txtNombre.Text = usuario.Nombres + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno;
                    txtCodigo.Text = usuario.CodigoUsuario;
                    //Cargamos los datos de los controles de la pantalla
                    CargarDatosControles();

                    CargarTreeView(usuario);
                }
                CargarPermisosObjetosFormulario(ID_FORMULARIO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void CargarTreeView(BEUsuario usuario)
        {
            tvAplicacionesUsuario.Nodes.Clear();
            List<BEAplicacion> listaAplicaciones = new BLAplicacion().ListarAplicacionPorUsuario(usuario.IdUsuario);
            List<BERol> listaRoles = new BLRol().ListarRolesPorUsuario(usuario.IdUsuario);
            TreeNode nodo = null;
            TreeNode nodoHijo = null;
            foreach (BEAplicacion aplicacion in listaAplicaciones)
            {
                nodo = new TreeNode();
                nodo.Value = aplicacion.IdAplicacion.ToString();
                nodo.Text = aplicacion.NombreCortoAplicacion;
                //nodo.SelectAction = TreeNodeSelectAction.Select;
                nodo.NavigateUrl = string.Format("{0}?idAplicacion=" + aplicacion.IdAplicacion.ToString() + "&idUsuario=" + usuario.IdUsuario, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_PERMISO_USUARIO_DETALLE]);
                tvAplicacionesUsuario.Nodes.Add(nodo);

                List<BERol> listaRolesAplicacion = listaRoles.FindAll(
                delegate(BERol bk)
                {
                    return bk.Aplicacion.IdAplicacion.Equals(aplicacion.IdAplicacion);
                }
                );

                foreach (BERol rol in listaRolesAplicacion)
                {
                    nodoHijo = new TreeNode();
                    nodoHijo.Value = rol.IdRol.ToString();
                    nodoHijo.Text = rol.NombreRol;
                    nodoHijo.SelectAction = TreeNodeSelectAction.None;
                    nodo.ChildNodes.Add(nodoHijo);
                }
            }
            tvAplicacionesUsuario.ExpandAll();
        }

        private void CargarDatosControles()
        {
            List<BEAplicacion> listaAplicacion = new List<BEAplicacion>();
            BEAplicacion beAplicacion = new BEAplicacion();
            beAplicacion.NombreLargoAplicacion = "none";
            beAplicacion.DescripcionAplicacion = "none";

            listaAplicacion.Add(beAplicacion);

            dgvAplicaciones.DataSource = listaAplicacion;
            dgvAplicaciones.DataBind();
            dgvAplicaciones.Rows[0].Visible = false;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_USUARIO_BUSCAR],false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;

                BLPermisoUsuario blPermisoUsuario = new BLPermisoUsuario();
                bool copiaExitosa = blPermisoUsuario.CopiarPermisoUsuario(txtCodigoUsuarioCopiar.Text.Trim(), usuario.IdUsuario);
                if (copiaExitosa)
                {
                    MessageBox.ShowAlert(WebConfigurationManager.AppSettings[Constantes.MSG_COPIA_PERMISOS_EXITOSA]);
                    CargarTreeView(usuario);
                }
                else
                {
                    MessageBox.ShowAlert(string.Format(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_COPIA_PERMISOS], txtCodigoUsuarioCopiar.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void btnAplicativoBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje;
                string nombreAplicacion = txtAplicativo.Text.Trim();
                BLAplicacion blAplicacion = new BLAplicacion();
                List<BEAplicacion> listaAplicaciones = blAplicacion.ListarAplicacionPorNombre(nombreAplicacion);

                if (listaAplicaciones.Count > 0)
                {
                    mensaje = WebConfigurationManager.AppSettings[Constantes.TITULO_RESULTADO_BUSQUEDA] + listaAplicaciones.Count;
                }
                else
                {
                    mensaje = WebConfigurationManager.AppSettings[Constantes.TITULO_RESULTADO_BUSQUEDA_CERO];
                }
                MostrarMensajeResultados(mensaje);
                dgvAplicaciones.DataSource = listaAplicaciones;
                dgvAplicaciones.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected void dgvAplicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BEUsuario usuario = Session[Constantes.SESION_USUARIO] as BEUsuario;

                int idAplicacion = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == Constantes.COMANDO_AGREGAR_ROL)
                {
                    Response.Redirect(string.Format("{0}?idAplicacion=" + idAplicacion + "&idUsuario=" + usuario.IdUsuario, WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_PERMISO_USUARIO_DETALLE]),false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(WebConfigurationManager.AppSettings[Constantes.MSG_ERROR_GENERAL]);
                NetLogger.WriteLog(ELogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void MostrarMensajeResultados(String Mensaje)
        {
            lbResultados.CssClass = this.lbResultados.CssClass + " displayShow";
            lbResultados.Text = Mensaje;
            lbResultados.Visible = true;
        }

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
