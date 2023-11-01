using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BERespuestaActualizaClave
    {
        private string codigoRespuesta;
        private string descripcionRespuesta;
        private BEUsuario beUsuario;

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
        public BEUsuario BEUsuario
        {
            get { return beUsuario; }
            set { beUsuario = value; }
        }
    }
}
