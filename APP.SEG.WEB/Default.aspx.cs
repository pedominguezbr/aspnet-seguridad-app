using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.SEG.Helper;
using APP.SEG.Entidades;
using System.Web.Configuration;
namespace APP.SEG.WEB
{
    public partial class Defaultaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Transfer(WebConfigurationManager.AppSettings[Constantes.DIRECCION_FRM_LOGIN]);
        }
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}
