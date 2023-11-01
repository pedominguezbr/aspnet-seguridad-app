using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using System.Transactions;
using System.Configuration;

using APP.SEG.Helper;

namespace APP.SEG.Negocio
{
    public class BLUsuario
    {

        public bool ActualizarUsuario(BEUsuario beUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daUsuario.ActualizarUsuario(beUsuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool ActualizarUsuarioSSEE(BEUsuario beUsuario, List<BEEmpresa> listaEmpresa, int IdAplicacion, int IdTipoCliente)
        {
            DAUsuario daUsuario = new DAUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daUsuario.ActualizarUsuarioSSEE(beUsuario, listaEmpresa, IdAplicacion, IdTipoCliente);
                transaccion.Complete();
                return true;
            }
        }

        public bool EliminarUsuario(int idUsuario, ref int codigoUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daUsuario.EliminarUsuario(idUsuario, ref codigoUsuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool InsertarUsuario(BEUsuario beUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                daUsuario.InsertarUsuario(beUsuario);
                transaccion.Complete();
                return true;
            }
        }

        public bool InsertarUsuarioContratista(BEUsuario beUsuario, List<BEEmpresa> listaEmpresa,int IdAplicacion)
        {

            DAUsuario daUsuario = new DAUsuario();
            using (TransactionScope transaccion = new TransactionScope())
            {
                // El password sera el mismo del codigo de Usuario.
                beUsuario.Password = Encrypt.EncriptarContrasenha(beUsuario.CodigoUsuario);
                daUsuario.InsertarUsuarioContratista(beUsuario, listaEmpresa, IdAplicacion);
                beUsuario.Password = beUsuario.CodigoUsuario;
                transaccion.Complete();
                return true;
            }

        }

        public List<BEUsuario> ListarUsuario(BEBusquedaUsuario beBusquedaUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ListarUsuario(beBusquedaUsuario);
        }

        public BEUsuario ObtenerUsuario(int idUsuario)
        {

            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ObtenerUsuario(idUsuario);
        }
        public List<BEUsuario> BuscarUsuario(BEUsuario beUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.BuscarUsuario(beUsuario);
        }

        public BEUsuario ObtenerUsuarioPorCodigo(string codigoUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ObtenerUsuarioPorCodigo(codigoUsuario);
        }

        public BEUsuario ObtenerUsuarioPorCodigoConPasswordDesencriptado(string codigoUsuario)
        {
            DAUsuario daUsuario = new DAUsuario();
            BEUsuario usuario = daUsuario.ObtenerUsuarioPorCodigo(codigoUsuario);
            string claveDesencriptada = Encrypt.DesencriptarContrasenha(usuario.Password);
            usuario.Password = claveDesencriptada;
            return usuario;
        }

        public List<BEEmpresa> ListarEmpresaxUsuario(int IdUsuario, int IdTipoEmpresa,int IdAplicacion)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ListarEmpresaxUsuario(IdUsuario, IdTipoEmpresa,IdAplicacion);
        }
        public List<BEUsuario> ListaContratistaxEmpresa(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ListaContratistaxEmpresa(IdTipoEmpresa, IdUsuario, IdUsuarioLogueado, IdModo, IdAplicacion);
        }
        public List<BEEmpresa> ListaClientexContratista(int IdTipoEmpresa, int IdUsuario, int IdUsuarioLogueado, int IdModo, int IdAplicacion)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.ListaClientexContratista(IdTipoEmpresa, IdUsuario, IdUsuarioLogueado, IdModo, IdAplicacion);
        }

        public int CantidadUsuarios(String CodigoUsuario, int IdRol)
        {
            DAUsuario daUsuario = new DAUsuario();
            return daUsuario.CantidadUsuarios(CodigoUsuario, IdRol);
        }

    }
}
