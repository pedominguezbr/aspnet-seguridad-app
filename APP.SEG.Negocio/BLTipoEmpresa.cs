﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;
namespace APP.SEG.Negocio
{
    public class BLTipoEmpresa
    {
        private DATipoEmpresa oDATipoEmpresa;
        public BLTipoEmpresa()
        {
            oDATipoEmpresa = new DATipoEmpresa();
        }
        public List<BETipoEmpresa> ListarEmpresaAplicacion(int IdAplicacion)
        {
            return oDATipoEmpresa.ListarEmpresaAplicacion(IdAplicacion);
        }

        public List<BETipoEmpresa> BuscarTipoEmpresa(BETipoEmpresa oBETipoEmpresa)
        {
            return oDATipoEmpresa.BuscarTipoEmpresa(oBETipoEmpresa);
        }
        public bool EliminarTipoEmpresa(int idTipoEmpresa, ref int codigoMensaje)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDATipoEmpresa.EliminarTipoEmpresa(idTipoEmpresa, ref codigoMensaje);
                transaccion.Complete();
                return true;
            }
        }
        public BETipoEmpresa ObtenerTipoEmpresa(int idTipoempresa)
        {
            return oDATipoEmpresa.ObtenerTipoEmpresa(idTipoempresa);
        }
        public bool InsertarTipoEmpresa(BETipoEmpresa oBETipoEmpresa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDATipoEmpresa.InsertarTipoEmpresa(oBETipoEmpresa);
                transaccion.Complete();
                return true;
            }
        }
        public bool ActualizarTipoEmpresa(BETipoEmpresa oBETipoEmpresa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDATipoEmpresa.ActualizarTipoEmpresa(oBETipoEmpresa);
                transaccion.Complete();
                return true;
            }
        }
        public List<BETipoEmpresa> ListarTipoEmpresaPorUsuario(int IdUsuario)
        {
            return oDATipoEmpresa.ListarTipoEmpresaPorUsuario(IdUsuario);
        }

        public List<BETipoEmpresa> ListarAplicacionxTipoEmpresa(int IdTipoEmpresa)
        {
            return oDATipoEmpresa.ListarAplicacionxTipoEmpresa(IdTipoEmpresa);
        }

        public bool AsignarPermisosAplicativoxTipoEmpresa(List<int> ListaIdAplicacion, int IdTipoEmpresa)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                oDATipoEmpresa.AsignarPermisosAplicativoxTipoEmpresa(ListaIdAplicacion,IdTipoEmpresa);
                transaccion.Complete();
                return true;
            }
        }
    }
}
