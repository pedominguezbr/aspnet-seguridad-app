using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEBusquedaPermisoUsuario
    {
        public int IdUsuario { get; set; }
        public string NombreAplicacion { get; set; }
        public int IdAplicacion { get; set; }
        public BEPermisoUsuario BePermisoUsuario { get; set; }
    }
}
