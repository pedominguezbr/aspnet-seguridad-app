using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;

namespace APP.SEG.Negocio
{
    public class BLObjeto
    {

        public bool ActualizarObjeto(BEObjeto beObjeto)
        {
            bool respuesta = false;
            DAObjeto daObjeto = new DAObjeto();
            using (TransactionScope transaccion = new TransactionScope())
            {
                respuesta = daObjeto.ActualizarObjeto(beObjeto);
                transaccion.Complete();
            }
            return respuesta;
        }

        public bool EliminarObjeto(int idObjeto, ref int codigoError)
        {
            DAObjeto daObjeto = new DAObjeto();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daObjeto.EliminarObjeto(idObjeto, ref codigoError);
                transaccion.Complete();
            }
            return true;
        }

        public bool InsertarObjeto(BEObjeto beObjeto)
        {
            bool respuesta = false;
            DAObjeto daObjeto = new DAObjeto();
            using (TransactionScope transaccion = new TransactionScope())
            {
                respuesta = daObjeto.InsertarObjeto(beObjeto);
                transaccion.Complete();
            }
            return respuesta;
        }

        public BEObjeto ObtenerObjeto(int _idObjeto)
        {
            DAObjeto daObjeto = new DAObjeto();
            return daObjeto.ObtenerObjeto(_idObjeto); ;
        }


        public List<BEObjeto> ListarObjetoPadre(int idAplicacion, int idTipoObjeto)
        {
            DAObjeto daObjeto = new DAObjeto();
            return daObjeto.ListarObjetoPadre(idAplicacion, idTipoObjeto);
        }

        public List<BEObjeto> ListarObjetoPorAplicacionEtiquetaObjeto(BEBusquedaObjeto beBusquedaObjeto)
        {
            DAObjeto daObjeto = new DAObjeto();
            return daObjeto.ListarObjetoPorAplicacionEtiquetaObjeto(beBusquedaObjeto);
        }

        public List<BEObjeto> ListarObjetoSinPermisosAsignados(int idAplicacion, int idRol)
        {
            DAObjeto daObjeto = new DAObjeto();
            return daObjeto.ListarObjetoSinPermisosAsignados(idAplicacion, idRol);
        }
    }
}
