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
    public class BLPermisoUsuario
    {
        public List<BERol> ListarPermisoUsuario(BEBusquedaPermisoUsuario beBusquedaPermisoUsuario)
        {
            DAPermisoUsuario daPermisoUsuario = new DAPermisoUsuario();
            return daPermisoUsuario.ListarPermisoUsuario(beBusquedaPermisoUsuario);
        }

        public List<BEAplicacion> ListarAplicativo(BEBusquedaPermisoUsuario beBusquedaPermisoUsuario)
        {
            throw new NotImplementedException();
        }

        public bool InsertarPermisoUsuario(BEPermisoUsuario bePermisousuario)
        {
            DAPermisoUsuario daPermisousuario = new DAPermisoUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daPermisousuario.InsertarPermisoUsuario(bePermisousuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool EliminarPermisoUsuario(int idPermisoUsuario)
        {
            DAPermisoUsuario daPermisousuario = new DAPermisoUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daPermisousuario.EliminarPermisoUsuario(idPermisoUsuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool EliminarTodosPermisoUsuario(int idUsuario)
        {
            DAPermisoUsuario daPermisousuario = new DAPermisoUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daPermisousuario.EliminarTodosPermisoUsuario(idUsuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool CopiarPermisoUsuario(string codigoUsuarioPorCopiar, int idUsuario)
        {
            DAPermisoUsuario daPermisousuario = new DAPermisoUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                bool respuesta = daPermisousuario.CopiarPermisoUsuario(codigoUsuarioPorCopiar, idUsuario);
                transaccion.Complete();
                return respuesta;
            }
        }
    }
}
