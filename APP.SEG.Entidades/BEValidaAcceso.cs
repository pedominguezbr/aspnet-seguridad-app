﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEValidaAcceso : BEConsultaServicio
    {
        public string UsuarioLogueo { get; set; }
        public string ClaveLogueo { get; set; }
    }
}
