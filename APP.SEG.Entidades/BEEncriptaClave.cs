using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEEncriptaClave: BEConsultaServicio
    {
        string passwordEncriptado = string.Empty;

        public string PasswordEncriptado
        {
            get { return passwordEncriptado; }
            set { passwordEncriptado = value; }
        }
        string passwordDesencriptado = string.Empty;

        public string PasswordDesencriptado
        {
            get { return passwordDesencriptado; }
            set { passwordDesencriptado = value; }
        }


    }
}
