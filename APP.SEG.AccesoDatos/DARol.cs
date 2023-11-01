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
    public class DARol
    {
        #region Constantes
        private const string UP_ROL_INSERTAR = "up_Rol_Insertar";
        private const string NOMBRE_ROL = "NombreRol";
        private const string DESCRIPCION_ROL = "DescripcionRol";
        private const string ID_APLICACION = "IdAplicacion";
        private const string ESTADO_ROL = "EstadoRol";
        //Parametro de salida ID_ROL
        private const string ID_ROL = "IdROL";
        //paocedure actualziar rol
        private const string UP_ROL_ACTUALIZAR = "up_Rol_Actualizar";
        //procedure insertar rol

        private const string VCH_DESCRIPCION_ROL = "VchDescripcionrol";
        private const string BIT_ESTADO_ROL = "BitEstadorol";
        private const string NOMBRE_CORTO_APLICACION = "NombreCortoAplicacion";

        //procedure listar rol
        private const string UP_ROL_LISTAR = "up_Rol_Listar";
        private const string INT_ID_APLICACION = "IntIdaplicacion";
        private const string VCH_NOMBRE_ROL = "VchNombrerol";
        //procedur obtener rol
        private const string UP_ROL_OBTENER = "up_Rol_Obtener";
        private const string INT_ID_ROL = "IntIdRol";

        private const string UP_ROL_LISTAR_IDAPLICACION = "up_Rol_Listar_IdAplicacion";
        private const string UP_ROL_ELIMINAR = "up_Rol_Eliminar";
        private const string INT_CODIGO_MENSAJE = "IntCodigoMensaje";
        private const string INT_ID_USUARIO = "IntIdUsuario";
        private const string UP_ROL_LISTAR_IDUSUARIO = "up_Rol_Listar_IdUsuario";



        #endregion

        #region Variables
        private Database db;
        #endregion

        #region Constructor
        public DARol()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        #endregion

        #region Metodos

        public bool InsertarRol(BERol beRol)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_INSERTAR);
            db.AddInParameter(cmd, VCH_NOMBRE_ROL, DbType.String, beRol.NombreRol);
            db.AddInParameter(cmd, VCH_DESCRIPCION_ROL, DbType.String, beRol.DescripcionRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beRol.Aplicacion.IdAplicacion);
            db.AddInParameter(cmd, BIT_ESTADO_ROL, DbType.Int32, beRol.EstadoRol);
            db.AddOutParameter(cmd, INT_ID_ROL, DbType.Int32, Int32.MaxValue);
            db.ExecuteNonQuery(cmd);
            //beRol.IdRol = Int32.Parse(db.GetParameterValue(cmd, INT_ID_ROL).ToString());

            if (db.GetParameterValue(cmd, INT_ID_ROL) != null && db.GetParameterValue(cmd, INT_ID_ROL) != DBNull.Value)
            {
                beRol.IdRol = Convert.ToInt16(db.GetParameterValue(cmd, INT_ID_ROL).ToString());
            }
            return true;
        }

        public bool ActualizarRol(BERol beRol, ref int codigoMensaje)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_ACTUALIZAR);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, beRol.IdRol);
            db.AddInParameter(cmd, VCH_NOMBRE_ROL, DbType.String, beRol.NombreRol);
            db.AddInParameter(cmd, VCH_DESCRIPCION_ROL, DbType.String, beRol.DescripcionRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beRol.Aplicacion.IdAplicacion);
            db.AddInParameter(cmd, BIT_ESTADO_ROL, DbType.Int32, beRol.EstadoRol);
            db.AddOutParameter(cmd, INT_CODIGO_MENSAJE, DbType.Int32, 0);
            db.ExecuteNonQuery(cmd);

            if (db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != null && db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != DBNull.Value)
            {
                codigoMensaje = Convert.ToInt16(db.GetParameterValue(cmd, INT_CODIGO_MENSAJE).ToString());
            }
            return true;
        }

        public bool EliminarRol(BERol beRol, ref int codigoMensaje)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_ELIMINAR);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int16, beRol.IdRol);
            db.AddOutParameter(cmd, INT_CODIGO_MENSAJE, DbType.Int16, 0);
            db.ExecuteNonQuery(cmd);


            if (db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != null && db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != DBNull.Value)
            {
                codigoMensaje = Convert.ToInt16(db.GetParameterValue(cmd, INT_CODIGO_MENSAJE).ToString());
            }
            return true;
        }

        public List<BERol> ListarRol(BEBusquedaRol beBusquedaRol)
        {
            List<BERol> listaRol = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_LISTAR);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beBusquedaRol.CodigoAplicativo);
            db.AddInParameter(cmd, VCH_NOMBRE_ROL, DbType.String, beBusquedaRol.NombreRol);

            listaRol = new List<BERol>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BERol beRol = new BERol();
                    beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beRol.NombreRol = dr[NOMBRE_ROL].ToString();
                    beRol.DescripcionRol = dr[DESCRIPCION_ROL].ToString();
                    beRol.Aplicacion = new BEAplicacion();
                    beRol.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beRol.Aplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beRol.EstadoRol = Convert.ToBoolean(dr[ESTADO_ROL].ToString());
                    listaRol.Add(beRol);

                }
            }

            return listaRol;
        }

        public BERol ObtenerRol(int idRol)
        {
            BERol beRol = null;

            //Configurando el stored procedure
            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_OBTENER);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, idRol);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                //Recorremos los resultados del stored procedure
                if (dr.Read())
                {
                    //Llenamos el objeto beRol
                    beRol = new BERol();
                    beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beRol.NombreRol = dr[NOMBRE_ROL].ToString();
                    beRol.DescripcionRol = dr[DESCRIPCION_ROL].ToString();
                    beRol.Aplicacion = new BEAplicacion();
                    beRol.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beRol.EstadoRol = Convert.ToBoolean(dr[ESTADO_ROL].ToString());
                }
            }

            return beRol;
        }

        public List<BERol> ListarRolesPorAplicacion(int idAplicacion)
        {
            List<BERol> listaRol = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_LISTAR_IDAPLICACION);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, idAplicacion);

            listaRol = new List<BERol>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BERol beRol = new BERol();
                    beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beRol.NombreRol = dr[NOMBRE_ROL].ToString();
                    beRol.DescripcionRol = dr[DESCRIPCION_ROL].ToString();
                    beRol.Aplicacion = new BEAplicacion();
                    beRol.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    //beRol.Aplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    beRol.EstadoRol = Convert.ToBoolean(dr[ESTADO_ROL].ToString());
                    listaRol.Add(beRol);

                }
            }

            return listaRol;
        }

        public List<BERol> ListarRolesPorUsuario(int idUsuario)
        {
            List<BERol> listaRol = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_ROL_LISTAR_IDUSUARIO);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, idUsuario);

            listaRol = new List<BERol>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BERol beRol = new BERol();
                    beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beRol.NombreRol = dr[NOMBRE_ROL].ToString();
                    beRol.Aplicacion = new BEAplicacion();
                    beRol.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());

                    listaRol.Add(beRol);

                }
            }

            return listaRol;
        }

        #endregion

    }
}
