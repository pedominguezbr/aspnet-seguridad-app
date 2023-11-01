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
    public class DATipoUsuario
    {
        #region Constantes
        private const string TIPO_USUARIO_LISTAR = "up_Tipousuario_Listar";
        private const string INT_ID_TIPO_USUARIO = "IntIdtipousuario";
        private const string ID_TIPO_USUARIO = "IdTipoUsuario";
        private const string NOMBRE_TIPO_USUARIO = "NombreTipoUsuario";
        private const string DESCRIPCION_TIPO_USUARIO = "DescripcionTipoUsuario";
        private const string ESTADO_TIPO_USUARIO = "EstadoTipoUsuario";
        #endregion

        #region Variables

        private Database db;

        #endregion Fin Variables locales

        #region Constructor
        public DATipoUsuario()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos
        public List<BETipoUsuario> ListarTipoUsuario()
        {
            List<BETipoUsuario> listaTipoUsuario = new List<BETipoUsuario>();
            //BETipoUsuario beTipoUsuario = new BETipoUsuario();
            DbCommand cmd = db.GetStoredProcCommand(TIPO_USUARIO_LISTAR);
            //db.AddInParameter(cmd, INT_ID_TIPO_USUARIO, DbType.Int32, beTipoUsuario.IdTipoUsuario);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BETipoUsuario beTipoUsuario = new BETipoUsuario();
                    beTipoUsuario.IdTipoUsuario = Int32.Parse(dr[ID_TIPO_USUARIO].ToString());
                    beTipoUsuario.NombreTipoUsuario = dr[NOMBRE_TIPO_USUARIO].ToString();
                    beTipoUsuario.DescripcionTipoUsuario = dr[DESCRIPCION_TIPO_USUARIO].ToString();
                    beTipoUsuario.EstadoTipoUsuario = Boolean.Parse(dr[ESTADO_TIPO_USUARIO].ToString());
                    listaTipoUsuario.Add(beTipoUsuario);
                }
            }

            return listaTipoUsuario;
        }
        #endregion

    }
}
