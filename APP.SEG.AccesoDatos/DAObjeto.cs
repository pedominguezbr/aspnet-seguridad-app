using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using APP.SEG.Entidades;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace APP.SEG.AccesoDatos
{
    public class DAObjeto
    {
        #region Constantes

        private const string ID_OBJETO = "IdObjeto";
        private const string NOMBRE_FISICO_OBJETO = "NombreFisicoObjeto";
        private const string DECRIPCION_OBJETO = "DescripcionObjeto";
        private const string ETIQUETA_OBJETO = "EtiquetaObjeto";
        private const string URL_OBJETO = "UrlObjeto";
        private const string ID_OBJETO_PADRE = "IdObjetoPadre";
        private const string ID_APLICACION = "IdAplicacion";
        private const string ESTADO_OBJETO = "EstadoObjeto";
        private const string ID_TIPO_OBJETO = "IdTipoObjeto";


        private const string UP_PARAM_INT_ID_APLICACION = "IntIdaplicacion";
        //Actualizar Objeto
        private const string UP_OBJETO_ACTUALIZAR = "up_Objeto_Actualizar";
        private const string INT_ID_OBJETO = "IntIdobjeto";
        private const string VCH_NOMBRE_FISICO_OBJETO = "VchNombreFisicoObjeto";
        private const string VCH_DESCRIPCION_OBJETO = "VchDescripcionobjeto";
        private const string VCH_ETIQUETA_OBJETO = "VchEtiquetaobjeto";
        private const string INT_ID_TIPO_OBJETO = "IntIdtipoobjeto";
        private const string VCH_URL_OBJETO = "VchUrlobjeto";
        private const string INT_ID_OBJETO_PADRE = "IntIdobjetopadre";
        private const string INT_ID_APLICACION = "IntIdaplicacion";
        private const string BIT_ESTADO_OBJETO = "BitEstadoobjeto";
        // Eliminar Objeto
        private const string UP_OBJETO_ELIMINAR = "up_Objeto_Eliminar";
        //Insertar Objeto
        private const string UP_OBJETO_INSERTAR = "up_Objeto_Insertar";
        //Listar objeto

        private const string UP_OBJETO_LISTAR_PADRES = "up_Objeto_Listar_Padres";
        //recuperar objeto AGREGADO EL 17/05/2011
        private const string UP_OBJETO_OBTENER = "up_Objeto_Obtener";
        private const string UP_OBJETO_LISTAR_IDAPLICACION_ETIQUETA_OBJETO = "up_Objeto_Listar_IdAplicacion_Etiqueta_Objeto";

        private const string INT_CODIGO_MENSAJE = "IntCodigoMensaje";
        private const string UP_OBJETO_LISTAR_PERMISOS_NO_ASIGNADOS = "up_Objeto_Listar_Permisos_No_Asignados";
        private const string INT_ID_ROL = "IntIdRol";
        private const string UP_OBJETO_OBTENER_HIJOS = "up_Objeto_Obtener_Hijos";


        #endregion Fin Constantes de la Clase

        #region Variables
        private Database db;
        #endregion Fin Variables locales

        #region Constructor
        public DAObjeto()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }
        #endregion

        #region Métodos
        public bool ActualizarObjeto(BEObjeto beObjeto)
        {

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_ACTUALIZAR);
            db.AddInParameter(cmd, VCH_NOMBRE_FISICO_OBJETO, DbType.String, beObjeto.NombreFisicoObjeto);
            db.AddInParameter(cmd, VCH_DESCRIPCION_OBJETO, DbType.String, beObjeto.DescripcionObjeto);
            db.AddInParameter(cmd, VCH_ETIQUETA_OBJETO, DbType.String, beObjeto.EtiquetaObjeto);
            db.AddInParameter(cmd, INT_ID_TIPO_OBJETO, DbType.Int32, beObjeto.TipoObjeto.IdTipoObjeto);
            db.AddInParameter(cmd, VCH_URL_OBJETO, DbType.String, beObjeto.UrlObjeto);
            if (beObjeto.IdObjetoPadre == -1)
            {
                db.AddInParameter(cmd, INT_ID_OBJETO_PADRE, DbType.Int32, DBNull.Value);
            }
            else
            {
                db.AddInParameter(cmd, INT_ID_OBJETO_PADRE, DbType.Int32, beObjeto.IdObjetoPadre);
            }
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beObjeto.Aplicacion.IdAplicacion);
            db.AddInParameter(cmd, BIT_ESTADO_OBJETO, DbType.Int32, beObjeto.EstadoObjeto);
            db.AddInParameter(cmd, INT_ID_OBJETO, DbType.Int32, beObjeto.IdObjeto);
            db.AddOutParameter(cmd, INT_CODIGO_MENSAJE, DbType.Int16, 0);
            db.ExecuteNonQuery(cmd);

            int codigoError = 0;
            if (db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != DBNull.Value)
            {
                codigoError = Int32.Parse(db.GetParameterValue(cmd, INT_CODIGO_MENSAJE).ToString());
            }
            if (codigoError == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EliminarObjeto(int idObjeto, ref int codigoError)
        {
            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_ELIMINAR);
            db.AddInParameter(cmd, INT_ID_OBJETO, DbType.Int32, idObjeto);
            db.AddOutParameter(cmd, INT_CODIGO_MENSAJE, DbType.Int32, codigoError);
            db.ExecuteNonQuery(cmd);

            if (db.GetParameterValue(cmd, INT_CODIGO_MENSAJE) != DBNull.Value)
            {
                codigoError = Int32.Parse(db.GetParameterValue(cmd, INT_CODIGO_MENSAJE).ToString());
            }

            return true;
        }

        public bool InsertarObjeto(BEObjeto beObjeto)
        {

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_INSERTAR);
            db.AddOutParameter(cmd, INT_ID_OBJETO, DbType.Int32, beObjeto.IdObjeto);
            db.AddInParameter(cmd, VCH_NOMBRE_FISICO_OBJETO, DbType.String, beObjeto.NombreFisicoObjeto);
            db.AddInParameter(cmd, VCH_DESCRIPCION_OBJETO, DbType.String, beObjeto.DescripcionObjeto);
            db.AddInParameter(cmd, VCH_ETIQUETA_OBJETO, DbType.String, beObjeto.EtiquetaObjeto);
            db.AddInParameter(cmd, INT_ID_TIPO_OBJETO, DbType.Int32, beObjeto.TipoObjeto.IdTipoObjeto);
            db.AddInParameter(cmd, VCH_URL_OBJETO, DbType.String, beObjeto.UrlObjeto);
            if (beObjeto.IdObjetoPadre == -1)
            {
                db.AddInParameter(cmd, INT_ID_OBJETO_PADRE, DbType.Int32, DBNull.Value);
            }
            else
            {
                db.AddInParameter(cmd, INT_ID_OBJETO_PADRE, DbType.Int32, beObjeto.IdObjetoPadre);
            }
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beObjeto.Aplicacion.IdAplicacion);
            db.AddInParameter(cmd, BIT_ESTADO_OBJETO, DbType.Int32, beObjeto.EstadoObjeto);
            db.ExecuteNonQuery(cmd);

            beObjeto.IdObjeto = Int32.Parse(db.GetParameterValue(cmd, INT_ID_OBJETO).ToString());

            if (beObjeto.IdObjeto == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<BEObjeto> ListarObjetoPorAplicacionEtiquetaObjeto(BEBusquedaObjeto beBusquedaObjeto)
        {
            List<BEObjeto> listaObjetos = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_LISTAR_IDAPLICACION_ETIQUETA_OBJETO);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, beBusquedaObjeto.IdAplicacion);
            db.AddInParameter(cmd, VCH_ETIQUETA_OBJETO, DbType.String, beBusquedaObjeto.EtiquetaObjeto);


            listaObjetos = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    // este es el mio
                    BEObjeto beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Int32.Parse(dr[ID_OBJETO].ToString());
                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DECRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    beObjeto.TipoObjeto = new BETipoObjeto();
                    beObjeto.TipoObjeto.IdTipoObjeto = Int32.Parse(dr[ID_TIPO_OBJETO].ToString());
                    //beObjeto.TipoObjeto.IdTipoObjeto = Int32.Parse(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    if (dr[ID_OBJETO_PADRE] == DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = Int32.Parse(dr[ID_OBJETO_PADRE].ToString());
                    }
                    beObjeto.Aplicacion = new BEAplicacion();
                    beObjeto.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beObjeto.EstadoObjeto = Boolean.Parse(dr[ESTADO_OBJETO].ToString());
                    listaObjetos.Add(beObjeto);
                }
            }
            return listaObjetos;
        }

        public BEObjeto ObtenerObjeto(int idObjeto)
        {
            BEObjeto beObjeto = null;

            //DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_LISTAR_IDAPLICACION);
            //db.AddInParameter(cmd, UP_PARAM_INT_ID_APLICACION, DbType.Int32, _idObjeto);
            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_OBTENER);
            db.AddInParameter(cmd, INT_ID_OBJETO, DbType.Int32, idObjeto);
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                beObjeto = new BEObjeto();
                //Recorremos los resultados del stored procedure
                while (dr.Read())
                {
                    //beObjeto.IdAplicacion=Convert.ToInt32(dr[ID_APLICACION]);
                    beObjeto.IdObjeto = Int32.Parse(dr[ID_OBJETO].ToString());
                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DECRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    beObjeto.TipoObjeto = new BETipoObjeto();
                    beObjeto.TipoObjeto.IdTipoObjeto = Int32.Parse(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.UrlObjeto = (dr[URL_OBJETO].ToString());
                    if (dr[ID_OBJETO_PADRE] == DBNull.Value)
                    {
                        beObjeto.IdObjetoPadre = -1;
                    }
                    else
                    {
                        beObjeto.IdObjetoPadre = Int32.Parse(dr[ID_OBJETO_PADRE].ToString());
                    }
                    //beObjeto.IdObjetoPadre = Int32.Parse(dr[ID_OBJETO_PADRE].ToString());
                    beObjeto.Aplicacion = new BEAplicacion();
                    beObjeto.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beObjeto.EstadoObjeto = Convert.ToBoolean(dr[ESTADO_OBJETO]);
                }

            }

            return beObjeto;

        }

        public List<BEObjeto> ListarObjetoPadre(int idAplicacion, int idTipoObjeto)
        {
            List<BEObjeto> listaObjetos = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_LISTAR_PADRES);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int32, idAplicacion);
            db.AddInParameter(cmd, INT_ID_TIPO_OBJETO, DbType.Int32, idTipoObjeto);
            listaObjetos = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    BEObjeto beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Int32.Parse(dr[ID_OBJETO].ToString());
                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    beObjeto.DescripcionObjeto = dr[DECRIPCION_OBJETO].ToString();
                    beObjeto.EtiquetaObjeto = dr[ETIQUETA_OBJETO].ToString();
                    beObjeto.TipoObjeto = new BETipoObjeto();
                    beObjeto.TipoObjeto.IdTipoObjeto = Int32.Parse(dr[ID_TIPO_OBJETO].ToString());
                    beObjeto.UrlObjeto = dr[URL_OBJETO].ToString();
                    //beObjeto.IdObjetoPadre = Int32.Parse(dr[ID_OBJETO_PADRE].ToString());
                    beObjeto.Aplicacion = new BEAplicacion();
                    beObjeto.Aplicacion.IdAplicacion = Int32.Parse(dr[ID_APLICACION].ToString());
                    beObjeto.EstadoObjeto = Boolean.Parse(dr[ESTADO_OBJETO].ToString());
                    listaObjetos.Add(beObjeto);
                }
            }
            return listaObjetos;
        }

        public List<BEObjeto> ListarObjetoSinPermisosAsignados(int idAplicacion, int idRol)
        {
            List<BEObjeto> listaObjetos = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_LISTAR_PERMISOS_NO_ASIGNADOS);
            db.AddInParameter(cmd, INT_ID_APLICACION, DbType.Int16, idAplicacion);
            db.AddInParameter(cmd, INT_ID_ROL, DbType.Int16, idRol);
            listaObjetos = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    // este es el mio
                    BEObjeto beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Int32.Parse(dr[ID_OBJETO].ToString());
                    beObjeto.NombreFisicoObjeto = dr[NOMBRE_FISICO_OBJETO].ToString();
                    listaObjetos.Add(beObjeto);
                }
            }

            return listaObjetos;
        }


        public List<BEObjeto> ListarObjetosHijos(int idObjeto)
        {
            List<BEObjeto> listaObjetos = null;

            DbCommand cmd = db.GetStoredProcCommand(UP_OBJETO_OBTENER_HIJOS);
            db.AddInParameter(cmd, INT_ID_OBJETO, DbType.Int16, idObjeto);

            listaObjetos = new List<BEObjeto>();
            using (IDataReader dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    // este es el mio
                    BEObjeto beObjeto = new BEObjeto();
                    beObjeto.IdObjeto = Int32.Parse(dr[ID_OBJETO].ToString());
                    listaObjetos.Add(beObjeto);
                }
            }
            return listaObjetos;
        }
        #endregion Fin Métodos

    }
}
