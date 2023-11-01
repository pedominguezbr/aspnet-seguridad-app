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
    public class DAPermisoUsuario
    {
        #region Constantes

        private const string UP_PERMISO_USUARIO_INSERTAR = "up_Permisousuario_Insertar";
        private const string INT_ID_PERMISO_USUARIO = "IntIdpermisousuario";
        private const string INT_ID_USUARIO = "IntIdusuario";
        private const string INT_ID_ROL = "IntIdrol";
        private const string INT_ID_APLICACION = "IntIdaplicacion";
        private const string INT_ID_USUARIO_CREACION = "IntIdusuariocreacion";
        private const string DTM_FECHA_CREACION = "DtmFechacreacion";
        private const string BIT_ESTADO = "BitEstado";
        //PROCEDURE LISTAR PERMISO USUARIO
        private const string UP_PERMISO_USUARIO_LISTAR = "up_PermisoUsuario_Listar";
        private const string NOMBRE_ROL = "NombreRol";
        private const string DESCRIPCION_ROL = "DescripcionRol";
        private const string ID_APLICACION = "IdAplicacion";
        private const string ESTADO_ROL = "EstadoRol";
        private const string NOMBRE_CORTO_APLICACION = "NombreCortoAplicacion";
        private const string NOMBRE_LARGO_APLICACION = "NombreLargoAplicacion";
        private const string DESCRIPCION_APLICACION = "DescripcionAplicacion";
        private const string ESTADO_APLICACION = "EstadoAplicacion";
        private const string ID_PERMISO_USUARIO = "IdPermisoUsuario";
        private const string ESTADO = "Estado";
        private const string ID_USUARIO = "IdUsuario";
        private const string ID_ROL = "IdRol";
        private const string UP_PERMISOUSUARIO_ELIMINAR = "up_Permisousuario_Eliminar";
        private const string UP_PERMISOUSUARIO_COPIAR = "up_PermisoUsuario_Copiar";
        private const string UP_PERMISOUSUARIO_ELIMINAR_TODOS = "up_Permisousuario_EliminarTodos";
        private const string VCH_CODIGO_USUARIO_COPIAR = "VchCodigoUsuarioCopiar";
        private const string INT_CODIGO_ERROR = "IntCodigoError";


        #endregion

        #region Variables

        private Database db;

        #endregion

        #region Constructor
        public DAPermisoUsuario()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Metodos

        public List<BERol> ListarPermisoUsuario(BEBusquedaPermisoUsuario beBusquedaPermisoUsuario)
        {
            List<BERol> listaRol = new List<BERol>();

            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISO_USUARIO_LISTAR);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, beBusquedaPermisoUsuario.IdUsuario);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beBusquedaPermisoUsuario.IdAplicacion);

            listaRol = new List<BERol>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BERol beRol = new BERol();
                    beRol.BePermisoUsuario = new BEPermisoUsuario();
                    beRol.BePermisoUsuario.IdPermisoUsuario = Int32.Parse(dr[ID_PERMISO_USUARIO].ToString());
                    beRol.BePermisoUsuario.Estado = Convert.ToBoolean(dr[ESTADO]);
                    beRol.Usuario = new BEUsuario();
                    beRol.Usuario.IdUsuario = Int32.Parse(dr[ID_USUARIO].ToString());
                    beRol.IdRol = Int32.Parse(dr[ID_ROL].ToString());
                    beRol.NombreRol = dr[NOMBRE_ROL].ToString();
                    beRol.DescripcionRol = dr[DESCRIPCION_ROL].ToString();
                    beRol.Aplicacion = new BEAplicacion();
                    beRol.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beRol.EstadoRol = Boolean.Parse(dr[ESTADO_ROL].ToString());
                    //beRol.Aplicacion.NombreCortoAplicacion = dr[NOMBRE_CORTO_APLICACION].ToString();
                    //beRol.Aplicacion.NombreLargoAplicacion = dr[NOMBRE_LARGO_APLICACION].ToString();
                    //beRol.Aplicacion.DescripcionAplicacion = dr[DESCRIPCION_APLICACION].ToString();
                    //beRol.Aplicacion.EstadoAplicacion = Boolean.Parse(dr[ESTADO_APLICACION].ToString());
                    listaRol.Add(beRol);
                }
            }

            return listaRol;
        }

        public List<BEAplicacion> ListarAplicacion(BEBusquedaPermisoUsuario beBusquedaPermisoUsuario)
        {
            List<BEAplicacion> listaAplicacion = new List<BEAplicacion>();
            return listaAplicacion;

        }

        public bool InsertarPermisoUsuario(BEPermisoUsuario bePermisousuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISO_USUARIO_INSERTAR);

            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, bePermisousuario.beUsuario.IdUsuario);
            db.AddOutParameter(cmd, INT_ID_PERMISO_USUARIO, DbType.Int32, bePermisousuario.IdPermisoUsuario);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int32, bePermisousuario.BERol.IdRol);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, bePermisousuario.BEAplicacion.IdAplicacion);
            db.AddInParameter(cmd, INT_ID_USUARIO_CREACION, DbType.Int32, bePermisousuario.IdUsuarioCreacion);
            db.AddInParameter(cmd, DTM_FECHA_CREACION, DbType.DateTime, bePermisousuario.FechaCreacion);
            db.AddInParameter(cmd, BIT_ESTADO, DbType.Boolean, bePermisousuario.Estado);

            db.ExecuteNonQuery(cmd);

            bePermisousuario.IdPermisoUsuario = Int32.Parse(db.GetParameterValue(cmd, INT_ID_USUARIO).ToString());

            return true;
        }

        public bool EliminarPermisoUsuario(int idPermisoUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOUSUARIO_ELIMINAR);
            db.AddInParameter(cmd, INT_ID_PERMISO_USUARIO, DbType.Int32, idPermisoUsuario);

            db.ExecuteNonQuery(cmd);

            return true;
        }

        public bool EliminarTodosPermisoUsuario(int idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOUSUARIO_ELIMINAR_TODOS);
            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, idUsuario);
            db.ExecuteNonQuery(cmd);

            return true;
        }

        public bool CopiarPermisoUsuario(string codigoUsuarioPorCopiar, int idUsuario)
        {
            int codigoError = 0;
            DbCommand cmd = db.GetStoredProcCommand(UP_PERMISOUSUARIO_COPIAR);

            db.AddInParameter(cmd, INT_ID_USUARIO, DbType.Int32, idUsuario);
            db.AddOutParameter(cmd, INT_CODIGO_ERROR, DbType.Int32, codigoError);
            db.AddInParameter(cmd, VCH_CODIGO_USUARIO_COPIAR, DbType.String, codigoUsuarioPorCopiar);

            db.ExecuteNonQuery(cmd);

            codigoError = Convert.ToInt16(db.GetParameterValue(cmd, INT_CODIGO_ERROR).ToString());
            if (codigoError == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}
