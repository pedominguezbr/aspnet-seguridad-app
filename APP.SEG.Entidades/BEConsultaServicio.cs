using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEConsultaServicio
    {
        public string UsuarioServicio { get; set; }
        public string ClaveUsuarioServicio { get; set; }
        public int IdAplicacion { get; set; }
        public int IdRol { get; set; }
        public string NombreFormulario { get; set; }
        public int IdUsuario { get; set; }
    }
}
