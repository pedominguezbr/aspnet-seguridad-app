using System;
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

    public class DAAplicacion
    {
        #region Constantes
        private const string UP_APLICACION_LISTAR = "up_Aplicacion_Listar";
        private const string UP_APLICACION_LISTARNOMBRECORTO_USUARIO = "up_Aplicacion_Listar_NombreCorto_Usuario";
        private const string INT_ID_APLICACION = "IntIdaplicacion";
        private const string ID_APLICACION = "IdAplicacion";
        private const string NOMBRE_CORTO_APLICACION = "NombreCortoAplicacion";
        private const string NOMBRE_LARGO_APLICACION = "NombreLargoAplicacion";
        private const string DESCRIPCION_APLICACION = "DescripcionAplicacion";
        private const string ESTADO_APLICACION = "EstadoAplicacion";
        private const string UP_APLICACION_LISTAR_NOMBRECORTO = "up_Aplicacion_Listar_NombreCorto";
        private const string UP_OBTENER_APLICACION = "up_Obtener_Aplicacion";
        private const string UP_APLICACION_LISTAR_IDUSUARIO = "up_Aplicacion_Listar_IdUsuario";
        private const string INT_ID_USUARIO = "IntIdUsuario";
        private const string INT_IDUSUARIO = "IdUsuario";
        private const string VCH_ETIQUETA_OBJETO = "VchEtiquetaobjeto";
        private const string UP_APLICACION_LISTAR_IDAPLICACION = "up_Aplicacion_Listar_IdAplicacion";
        #endregion
        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DAAplicacion()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos

        public List<BEAplicacion> ListarAplicacion()
        {
            List<BEAplicacion> listaAplicacion = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_APLICACION_LISTAR);
            listaAplicacion = new List<BEAplicacion>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEAplicacion beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beAplicacion.NombreLargoAplicacion = dr[NOMBRE_LARGO_APLICACION].ToString();
                    beAplicacion.DescripcionAplicacion = dr[DESCRIPCION_APLICACION].ToString();
                    beAplicacion.EstadoAplicacion = Convert.ToBoolean(dr[ESTADO_APLICACION].ToString());
                    listaAplicacion.Add(beAplicacion);

                }
            }

            return listaAplicacion;
        }

        public List<BEAplicacion> ListarAplicacionPorNombre(string nombreAplicacion)
        {
            List<BEAplicacion> listaAplicacion = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_APLICACION_LISTAR_NOMBRECORTO);
            db.AddInParameter(cmd, NOMBRE_CORTO_APLICACION, DbType.String, nombreAplicacion + "%");

            listaAplicacion = new List<BEAplicacion>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEAplicacion beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beAplicacion.NombreLargoAplicacion = dr[NOMBRE_LARGO_APLICACION].ToString();
                    beAplicacion.DescripcionAplicacion = dr[DESCRIPCION_APLICACION].ToString();
                    beAplicacion.EstadoAplicacion = Convert.ToBoolean(dr[ESTADO_APLICACION].ToString());
                    listaAplicacion.Add(beAplicacion);
                }
            }

            return listaAplicacion;
        }
        public List<BEAplicacion> ListarAplicacionPorNombreYUsuario(string nombreAplicacion, int Idusuario)
        {
             List<BEAplicacion> listaAplicacion = null;

             DbCommand cmd = db.GetStoredProcCommand(UP_APLICACION_LISTARNOMBRECORTO_USUARIO);
            db.AddInParameter(cmd, NOMBRE_CORTO_APLICACION, DbType.String, nombreAplicacion + "%");
            db.AddInParameter(cmd, INT_IDUSUARIO, DbType.Int32, Idusuario);
            listaAplicacion = new List<BEAplicacion>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEAplicacion beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beAplicacion.NombreLargoAplicacion = dr[NOMBRE_LARGO_APLICACION].ToString();
                    beAplicacion.DescripcionAplicacion = dr[DESCRIPCION_APLICACION].ToString();
                    beAplicacion.EstadoAplicacion = Convert.ToBoolean(dr[ESTADO_APLICACION].ToString());
                    listaAplicacion.Add(beAplicacion);
                }
            }

            return listaAplicacion;
        }

        public BEAplicacion ObtenerAplicacion(int idAplicacion)
        {
            BEAplicacion beAplicacion = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OBTENER_APLICACION);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int16, idAplicacion);

            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                if (dr.Read())
                {
                    beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beAplicacion.NombreLargoAplicacion = dr[NOMBRE_LARGO_APLICACION].ToString();
                    beAplicacion.DescripcionAplicacion = dr[DESCRIPCION_APLICACION].ToString();
                    beAplicacion.EstadoAplicacion = Convert.ToBoolean(dr[ESTADO_APLICACION].ToString());
                }
            }

            return beAplicacion;
        }

        public List<BEAplicacion> ListarAplicacionPorUsuario(int idUsuario)
        {
            List<BEAplicacion> listaAplicacion = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_APLICACION_LISTAR_IDUSUARIO);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int16, idUsuario);

            listaAplicacion = new List<BEAplicacion>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEAplicacion beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();

                    listaAplicacion.Add(beAplicacion);
                }
            }
            return listaAplicacion;
        }


        public List<BEAplicacion> ListarAplicacionPorIdAplicacion(int idAplicacion)
        {
            List<BEAplicacion> listaAplicacion = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_APLICACION_LISTAR_IDAPLICACION);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int16, idAplicacion);

            listaAplicacion = new List<BEAplicacion>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEAplicacion beAplicacion = new BEAplicacion();
                    //beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beAplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beAplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();

                    listaAplicacion.Add(beAplicacion);
                }
            }
            return listaAplicacion;
        }

        #endregion
    }
}
