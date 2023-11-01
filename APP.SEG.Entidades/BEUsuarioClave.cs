using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEUsuarioClave
    {
        public int IdClave { get; set; }
        public string ClaveRegistrada { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
        public bool EstadoClave { get; set; }
    }
}
