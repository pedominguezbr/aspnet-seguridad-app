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
    public class DAOficina
    {
        #region Constantes

        private const string UP_OFICINA_LISTAR = "up_Oficina_Listar";
        private const string ID_OFICINA = "IDOFICINA";
        private const string NOMBRE_OFICINA = "NombreOficina";
        private const string DESCRIPCION_OFICINA = "DescripcionOficina";
        private const string ESTADO_OFICINA = "EstadoOficina";
        private const string INT_ID_OFICINA = "IntIdoficina";

        #endregion

        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DAOficina()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos

        //Se agrego el parametro BEOficina beOficina
        public List<BEOficina> ListarOficina()
        {
            List<BEOficina> listaOficina = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OFICINA_LISTAR);
            //db.AddInParameter(cmd, INT_ID_OFICINA, DbType.Int32, beOficina.IdOficina);
            listaOficina = new List<BEOficina>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEOficina BeOficina = new BEOficina();
                    BeOficina.IdOficina = Int32.Parse(dr[ID_OFICINA].ToString());
                    BeOficina.NombreOficina = dr[NOMBRE_OFICINA].ToString();
                    BeOficina.DescripcionOficina = dr[DESCRIPCION_OFICINA].ToString();
                    BeOficina.EstadoOficina = Boolean.Parse(dr[ESTADO_OFICINA].ToString());
                    listaOficina.Add(BeOficina);
                }
            }

            return listaOficina;
        }
        #endregion

    }
}
