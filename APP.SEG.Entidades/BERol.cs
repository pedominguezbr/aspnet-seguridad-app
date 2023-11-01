﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BERol
    {
        public BEUsuario Usuario { get; set; }
        public BEPermisoUsuario BePermisoUsuario { get; set; }
        public BEAplicacion Aplicacion { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
        public bool EstadoRol { get; set; }

        public BERol(){
            IdRol = 0;
        }
  }
}
