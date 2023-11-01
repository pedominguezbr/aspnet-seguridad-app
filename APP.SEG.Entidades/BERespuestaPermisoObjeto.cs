using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BERespuestaPermisoObjeto
    {
        private string codigoRespuesta;
        private string descripcionRespuesta;
        private List<BEObjeto> listaObjetos;


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

        public List<BEObjeto> ListaObjetos
        {
            get { return listaObjetos; }
            set { listaObjetos = value; }
        }
    }
}
