using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    // Se agregó la herencia :BEPermisoObjeto
    public class BEObjeto : BEPermisoObjeto
    {
        public BETipoObjeto TipoObjeto { get; set; }
        public BEAplicacion Aplicacion { get; set; }
        public int IdObjeto { get; set; }
        public string NombreFisicoObjeto { get; set; }
        public string DescripcionObjeto { get; set; }
        public string EtiquetaObjeto { get; set; }
        public string UrlObjeto { get; set; }
        public int? IdObjetoPadre { get; set; }
        public bool EstadoObjeto { get; set; }
   }
}
