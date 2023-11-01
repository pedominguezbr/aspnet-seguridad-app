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
    public class BLTipoObjeto
    {
        public List<BETipoObjeto> ListarTipoObjeto()
        {
            DATipoObjeto daTipoObjeto = new DATipoObjeto();
            return daTipoObjeto.ListarTipoObjeto();
        }
    }
}
