using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.Negocio;
using APP.SEG.AccesoDatos;

namespace APP.SEG.Negocio
{
    public class BLTipoUsuario
    {
        public List<BETipoUsuario> ListarTipoUsuario()
        {
            DATipoUsuario daTipoUsuario = new DATipoUsuario();
            return daTipoUsuario.ListarTipoUsuario();

        }
    }
}
