using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace APP.SEG.AccesoDatos
{
    public class DATipoObjeto
    {
        #region Constantes
        private const string USP_TIPO_OBJETO_LISTAR = "up_TipoObjeto_Listar";
        private const string ID_TIPO_OBJETO = "IdTipoObjeto";
        private const string NOMRE_TIPO_OBJETO = "NombreTipoObjeto";
        private const string DESCRIPCION_TIPO_OBJETO = "DescripcionTipoObjeto";
        private const string ICONO_TIPO_OBJETO = "IconoTipoObjeto";
        private const string ESTADO_TIPO_OBJETO = "EstadoTipoObjeo";
        #endregion

        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DATipoObjeto()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos

        public List<BETipoObjeto> ListarTipoObjeto()
        {
            List<BETipoObjeto> listaTipoObjeto = new List<BETipoObjeto>();

            DbCommand cmd = db.GetStoredProcCommand(USP_TIPO_OBJETO_LISTAR);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BETipoObjeto beTipoObjeto = new BETipoObjeto();
                    beTipoObjeto.IdTipoObjeto = Int32.Parse(dr[ID_TIPO_OBJETO].ToString());
                    beTipoObjeto.NombreTipoObjeto = dr[NOMRE_TIPO_OBJETO].ToString();
                    beTipoObjeto.DescripcionTipoObjeto = dr[DESCRIPCION_TIPO_OBJETO].ToString();
                    beTipoObjeto.IconoTipoObjeto = dr[ICONO_TIPO_OBJETO].ToString();
                    beTipoObjeto.EstadoTipoObjeo = Boolean.Parse(dr[ESTADO_TIPO_OBJETO].ToString());
                    listaTipoObjeto.Add(beTipoObjeto);
                }

            }

            return listaTipoObjeto;
        }
        #endregion

    }
}
