using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace APP.SEG.Entidades
{
    public class BEMail
    {
        public string CorreoTo { get; set; }
        public string Asunto { get; set; }
        public string CuerpoMensaje { get; set; }
        /*public string Attachment { get; set; }*/
        public string CC { get; set; }
        public List<BEAdjunto> lstAdjunto { get; set; }
    }

    public class BEAdjunto
    {
        public byte[] Attachment { get; set; }
        public string nombre { get; set; }
        public string mimeType { get; set; }
    }
}
