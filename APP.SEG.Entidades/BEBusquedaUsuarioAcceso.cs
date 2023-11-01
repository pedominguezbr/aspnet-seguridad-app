using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEBusquedaUsuarioAcceso : BEConsultaServicio
    {
        public int IdUsuario { get; set; }
        public int IdArea { get; set; }
    }
}
