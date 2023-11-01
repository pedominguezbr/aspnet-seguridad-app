using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Mail;
using APP.SEG.Entidades;
using System.IO;
using System.Net.Mime;
using System.Configuration;

namespace APP.SEG.ServicioWEB
{
    /// <summary>
    /// Summary description for JLTCorreo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class JLTCorreo : System.Web.Services.WebService
    {

        /// <summary>
        /// Metodo : EnviarEmail
        /// Descripcion : Envío de un correo electrónico
        /// Autor : Ricardo Chumpitaz
        /// Fecha Creación: 20/01/12
        /// </summary>
        /// <param name="BEMail">Entidad Email</param>
        ///
        [WebMethod(Description = "Envío de un correo electrónico")]
        public bool EnviarEmail(BEMail objEmail)
        {
            MailMessage mensaje = new MailMessage();

            string[] Destinatarios = objEmail.CorreoTo.Split(';');

            foreach (string Destinatario in Destinatarios)
            {
                if (!Destinatario.Equals(String.Empty))
                {
                    mensaje.To.Add(Destinatario);
                }
            }

            if (objEmail.CC != null)
            {
                string[] CopiaA = objEmail.CC.Split(';');

                foreach (string Copia in CopiaA)
                {
                    if (!Copia.Equals(String.Empty))
                    {
                        mensaje.To.Add(Copia);
                    }
                }
            }

            mensaje.Subject = objEmail.Asunto;
            mensaje.Body = objEmail.CuerpoMensaje;
            mensaje.IsBodyHtml = true;
            foreach (BEAdjunto oBEAdjunto in objEmail.lstAdjunto)
            {
                mensaje.Attachments.Add(new Attachment(new MemoryStream(oBEAdjunto.Attachment),oBEAdjunto.nombre, oBEAdjunto.mimeType));
            }
            SmtpClient smpt = new SmtpClient();
            smpt.EnableSsl = true;
            smpt.Send(mensaje);
            mensaje.Dispose();
            return true;
        }

        [WebMethod(Description = "Envío de un correo electrónico con firma gráfica")]
        public bool EnviarEmailConFirmaWrapup(BEMail objEmail, string idFirma)
        {
            MailMessage mensaje = new MailMessage();

            string[] Destinatarios = objEmail.CorreoTo.Split(';');

            foreach (string Destinatario in Destinatarios)
            {
                if (!Destinatario.Equals(String.Empty))
                {
                    mensaje.To.Add(Destinatario);
                }
            }

            if (objEmail.CC != null)
            {
                string[] CopiaA = objEmail.CC.Split(';');

                foreach (string Copia in CopiaA)
                {
                    if (!Copia.Equals(String.Empty))
                    {
                        mensaje.To.Add(Copia);
                    }
                }
            }

            mensaje.Subject = objEmail.Asunto;

            AlternateView altView = AlternateView.CreateAlternateViewFromString(objEmail.CuerpoMensaje, null, MediaTypeNames.Text.Html);

            LinkedResource lnkRes1 = new LinkedResource(Path.GetFullPath(ConfigurationManager.AppSettings[Constantes.RUTA_FIRMA_WRAPUP]), MediaTypeNames.Image.Jpeg);
            lnkRes1.ContentId = idFirma;

            altView.LinkedResources.Add(lnkRes1);

            mensaje.Body = objEmail.CuerpoMensaje;
            mensaje.AlternateViews.Add(altView);
            mensaje.IsBodyHtml = true;

            foreach (BEAdjunto oBEAdjunto in objEmail.lstAdjunto)
            {
                mensaje.Attachments.Add(new Attachment(new MemoryStream(oBEAdjunto.Attachment), oBEAdjunto.nombre, oBEAdjunto.mimeType));
            }


            SmtpClient smpt = new SmtpClient();
            smpt.EnableSsl = true;
            smpt.Send(mensaje);
            mensaje.Dispose();
            return true;
        }

    }
}
