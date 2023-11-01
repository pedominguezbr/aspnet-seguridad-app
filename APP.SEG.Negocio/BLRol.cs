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
    public class BLRol
    {

        public bool InsertarRol(BERol beRol)
        {
            DARol daRol = new DARol();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daRol.InsertarRol(beRol);
                //Finalizamos la transacción
                transaccion.Complete();
                return true;
            }
        }


        public bool ActualizarRol(BERol beRol, ref int codigoMensaje)
        {
            DARol daRol = new DARol();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daRol.ActualizarRol(beRol, ref codigoMensaje);
                //Finalizamos la transacción
                transaccion.Complete();
                return true;
            }
        }

        public bool EliminarRol(BERol beRol, ref int codigoMensaje)
        {
            DARol daRol = new DARol();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daRol.EliminarRol(beRol, ref codigoMensaje);
                //Finalizamos la transacción
                transaccion.Complete();
                return true;
            }
        }

        public List<BERol> ListarRol(BEBusquedaRol beBusquedaRol)
        {
            DARol daRol = new DARol();
            return daRol.ListarRol(beBusquedaRol);
        }

        public BERol ObtenerRol(int _idRol)
        {
            DARol daRol = new DARol();
            BERol beRol = new BERol();
            beRol = daRol.ObtenerRol(_idRol);
            return beRol;
        }

        public List<BERol> ListarRolesPorUsuario(int idUsuario)
        {
            DARol daRol = new DARol();
            return daRol.ListarRolesPorUsuario(idUsuario);
        }

        public List<BERol> ListarRolesPorAplicacion(int idAplicacion)
        {
            DARol daRol = new DARol();
            return daRol.ListarRolesPorAplicacion(idAplicacion);
        }
    }
}
