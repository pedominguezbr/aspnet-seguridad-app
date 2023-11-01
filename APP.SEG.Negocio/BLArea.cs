using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APP.SEG.Entidades;
using APP.SEG.AccesoDatos;
using APP.SEG.Negocio;

namespace APP.SEG.Negocio
{
    public class BLArea
    {

        public List<BEArea> ListarArea()
        {
            DAArea daArea = new DAArea();
            return daArea.ListarArea();
        }
    }
}
