using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;
namespace APP.SEG.Negocio
{
    public class BLEmpresa
    {
        private DAEmpresa oDAEmpresa;

        public BLEmpresa()
        {
            oDAEmpresa = new DAEmpresa();
        }

        public List<BEEmpresa> ListarEmpresaxUsuario(BEUsuario oBEUsuario,int IdAplicacion)
        {
            return oDAEmpresa.ListarEmpresaxUsuario(oBEUsuario,IdAplicacion);
        }
        public List<BEEmpresa> BuscarEmpresa(BEEmpresa oBEEmpresa)
        {
            return oDAEmpresa.BuscarEmpresa(oBEEmpresa);
        }
        public List<BEEmpresa> BuscarEmpresaxTipoEmpresa(BEEmpresa oBEEmpresa)
        {
            return oDAEmpresa.BuscarEmpresaxTipoEmpresa(oBEEmpresa);
        }
        public bool EliminarEmpresa(int idEmpresa, ref int codigoMensaje)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDAEmpresa.EliminarEmpresa(idEmpresa, ref codigoMensaje);
                transaccion.Complete();
                return true;
            }
        }

        public BEEmpresa ObtenerEmpresa(int idEmpresa)
        {
            return oDAEmpresa.ObtenerEmpresa(idEmpresa);
        }

        public bool ActualizarEmpresa(BEEmpresa oBEEmpresa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDAEmpresa.ActualizarEmpresa(oBEEmpresa);
                transaccion.Complete();
                return true;
            }
        }
        public bool InsertarEmpresa(BEEmpresa oBEEmpresa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDAEmpresa.InsertarEmpresa(oBEEmpresa);
                transaccion.Complete();
                return true;
            }
        }

        public bool EliminarEmpresaxUsuario(int IdUsuario, int IdEmpresa, int IdAplicacion)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDAEmpresa.EliminarEmpresaxUsuario(IdUsuario, IdEmpresa,IdAplicacion);
                transaccion.Complete();
                return true;
            }
        }

        public bool InsertarEmpresaUsuario(int IdEmpresa, int IdUsuario, int IdAplicacion)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDAEmpresa.InsertarEmpresaUsuario(IdEmpresa, IdUsuario, IdAplicacion);
                transaccion.Complete();
                return true;
            }
        }

        public BEEmpresa ObtenerEmpresaxRuc(string NroDocumento)
        {
            return oDAEmpresa.ObtenerEmpresaxRuc(NroDocumento);
        }
    }
}
