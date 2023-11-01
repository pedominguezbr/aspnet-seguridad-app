using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    [Serializable()]
    public class BEAplicacion
    {
        public int IdAplicacion{get;set;}
        public string NombreCortoAplicacion { get; set; }
        public string NombreLargoAplicacion { get; set; }
        public string DescripcionAplicacion { get; set; }
        public bool EstadoAplicacion { get; set; }
        public bool EstadoAplicacionEmpresa { get; set; }

    }
}
