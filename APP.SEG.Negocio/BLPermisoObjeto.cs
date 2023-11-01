using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;
using System.Configuration;
namespace APP.SEG.Negocio
{
    public class BLPermisoObjeto
    {

        public List<BEObjeto> ListarPermisoObjeto(BEBusquedaPermisoObjeto beBusquedaPermisoObjeto)
        {
            DAPermisoObjeto daPermisoObjeto = new DAPermisoObjeto();
            return daPermisoObjeto.ListarPermisoObjeto(beBusquedaPermisoObjeto);
        }

        public bool InsertarPermisoObjeto(BEPermisoObjeto bePermisoObjeto, bool permisosHijos)
        {
            bool respuesta = false;

            DAPermisoObjeto daPermisoObjeto = new DAPermisoObjeto();
            using (TransactionScope transaccion = new TransactionScope())
            {
                respuesta = daPermisoObjeto.InsertarPermisoObjeto(bePermisoObjeto);

                if (respuesta && permisosHijos)
                {
                    List<BEObjeto> listaHijos = new DAObjeto().ListarObjetosHijos(bePermisoObjeto.BEObjeto.IdObjeto);
                    foreach (BEObjeto objeto in listaHijos)
                    {
                        bePermisoObjeto.BEObjeto.IdObjeto = objeto.IdObjeto;
                        daPermisoObjeto.InsertarPermisoObjetoSinValidacion(bePermisoObjeto);
                    }
                }

                transaccion.Complete();
            }
            return respuesta;
        }

        public bool EliminarPermisoObjeto(int idPermisoObjeto)
        {
            bool respuesta = false;

            DAPermisoObjeto daPermisoObjeto = new DAPermisoObjeto();
            using (TransactionScope transaccion = new TransactionScope())
            {
                respuesta = daPermisoObjeto.EliminarPermisoObjeto(idPermisoObjeto);
                transaccion.Complete();
            }
            return respuesta;
        }

    }
}
