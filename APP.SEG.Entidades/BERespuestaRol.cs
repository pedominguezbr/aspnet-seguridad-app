using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BERespuestaRol
    {
        private string codigoRespuesta;
        private string descripcionRespuesta;
        private List<BERol> listaRoles;


        public string CodigoRespuesta
        {
            get { return codigoRespuesta; }
            set { codigoRespuesta = value; }
        }

        public string DescripcionRespuesta
        {
            get { return descripcionRespuesta; }
            set { descripcionRespuesta = value; }
        }

        public List<BERol> ListaRoles
        {
            get { return listaRoles; }
            set { listaRoles = value; }
        }
    }
}
