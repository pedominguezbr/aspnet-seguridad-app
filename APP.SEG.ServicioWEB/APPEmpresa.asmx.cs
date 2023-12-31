﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using APP.SEG.Entidades;
using APP.SEG.Negocio;

namespace APP.SEG.ServicioWEB
{
    /// <summary>
    /// Summary description for APPEmpresa
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class APPEmpresa : System.Web.Services.WebService
    {
        [WebMethod(Description = "Insertar Empresa")]
        public bool InsertarEmpresa(BEEmpresa oBEEmpresa) {
            BLEmpresa blEmpresa = new BLEmpresa();
            return blEmpresa.InsertarEmpresa(oBEEmpresa);
        }

        [WebMethod(Description = "Actualizar Empresa")]
        public bool ActualizarEmpresa(BEEmpresa oBEEmpresa)
        {
            BLEmpresa blEmpresa =new BLEmpresa();
            return blEmpresa.ActualizarEmpresa(oBEEmpresa);
        }

        [WebMethod(Description = "Obtiene Empresa a travez del RUC")]
        public BEEmpresa ObtenerEmpresaxRuc(string NroDocumento)
        {
            BLEmpresa blEmpresa = new BLEmpresa();
            return blEmpresa.ObtenerEmpresaxRuc(NroDocumento);
        }


    }
}
