using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEPermisoUsuario : BEPermiso
    {
        public BEUsuario beUsuario { get; set; }
        public int IdPermisoUsuario { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

    }
}
