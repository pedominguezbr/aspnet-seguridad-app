﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using APP.SEG.Entidades;
using System.Data;

namespace APP.SEG.AccesoDatos
{
    public class DAArea
    {
        #region Constantes
        private const string UP_AREA_LISTAR = "up_AreaListar";
        private const string ID_AREA = "IdArea";
        private const string NOMBRE_CORTO_AREA = "NombreCortoArea";
        private const string NOMBRE_LARGO_AREA = "NombreLargoArea";
        private const string DESCRIPCION_AREA = "DescripcionArea";
        private const string ESTADO_AREA = "EstadoArea";
        #endregion

        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DAArea()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos

        public List<BEArea> ListarArea()
        {
            List<BEArea> listaArea = null;
            DbCommand cmd = db.GetStoredProcCommand(UP_AREA_LISTAR);
            listaArea = new List<BEArea>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEArea beArea = new BEArea();
                    beArea.IdArea = Int32.Parse(dr[ID_AREA].ToString());
                    beArea.NombreCortoArea = dr[NOMBRE_CORTO_AREA].ToString();
                    beArea.NombreLargoArea = dr[NOMBRE_LARGO_AREA].ToString();
                    beArea.DescripcionArea = dr[DESCRIPCION_AREA].ToString();
                    beArea.EstadoArea = Boolean.Parse(dr[ESTADO_AREA].ToString());
                    listaArea.Add(beArea);
                }
            }
            return listaArea;

        }
        #endregion
    }

}
