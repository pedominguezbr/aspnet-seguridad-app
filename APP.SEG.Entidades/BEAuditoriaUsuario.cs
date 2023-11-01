﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.SEG.Entidades
{
    public class BEAuditoriaUsuario
    {
        public int IdAuditoria { get; set; }
        public int IdUsuarioAfectado { get; set; }
        public int IdUsuarioAfectador { get; set; }
        public int IdTipoOperacion { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaHora { get; set; }
        public bool EstadoAuditoria { get; set; }
    }
}
