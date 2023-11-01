using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BERespuestaEncriptaClave
    {

        private string codigoRespuesta;
        private string descripcionRespuesta;
        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

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


    }
}
