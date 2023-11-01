using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEActualizaClave : BEConsultaServicio
    {
        public int IdUsuario  { get; set; }
        public string CodigoUsuario { get; set; }
        public string NuevaClave { get; set; }
        public string ClaveAnterior { get; set; }
    }
}
