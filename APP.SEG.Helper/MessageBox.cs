using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace APP.SEG.Helper
{
    public class MessageBox
    {
//        private static Hashtable m_executingPages = new Synchronized(new Hashtable());
        private static Hashtable m_executingPages = Hashtable.Synchronized(new Hashtable());
        private MessageBox()
        {
        }

        public static void Show(string sMessage)
        {
            // If this is the first time a page has called this method then
            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                // Attempt to cast HttpHandler as a Page.
                Page executingPage = HttpContext.Current.Handler as Page;

                if (executingPage != null)
                {
                    // Create a Queue to hold one or more messages.
                    Queue messageQueue = new Queue();

                    // Add our message to the Queue
                    messageQueue.Enqueue(sMessage);

                    // Add our message queue to the hash table. Use our page reference
                    // (IHttpHandler) as the key.
                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    // Wire up Unload event so that we can inject some JavaScript for the alerts.
                    executingPage.Unload += ExecutingPage_Unload;


                }
            }
            else
            {
                // If were here then the method has allready been called from the executing Page.
                // We have allready created a message queue and stored a reference to it in our hastable.
                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                // Add our message to the Queue
                queue.Enqueue(sMessage);
            }
        }


        // Our page has finished rendering so lets output the JavaScript to produce the alert's
        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            // Get our message queue from the hashtable
            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                // How many messages have been registered?
                int iMsgCount = queue.Count;

                // Use StringBuilder to build up our client slide JavaScript.
                sb.Append("<script language='javascript'>");

                // Loop round registered messages
                string sMsg = null;
                while (System.Math.Max(System.Threading.Interlocked.Decrement(ref iMsgCount), iMsgCount + 1) > 0)
                {
                    sMsg = (string)queue.Dequeue();
                    //sMsg = sMsg.Replace( "\\n");
                    sMsg = sMsg.Replace("\"", "'");
                    sb.Append("alert( \"" + sMsg + "\" );");
                }

                // Close our JS
                sb.Append("</script>");

                // Were done, so remove our page reference from the hashtable
                m_executingPages.Remove(HttpContext.Current.Handler);

                // Write the JavaScript to the end of the response stream.
                HttpContext.Current.Response.Write(sb.ToString());
            }
        }

        /// <summary>
        /// Función que muestra una alerta personalizada asociado a una página específica
        /// </summary>
        /// <param name="currentPage">Control Page de la página donde se desea mostrar la alerta</param>
        /// <param name="message">contenido del mensaje a mostrar</param>
        public static void ShowAlert(Page currentPage, string message, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            if (url != null)
            {
                sb.Append(string.Format("self.location=\"{0}\";", url.ToLower().Replace(currentPage.AppRelativeTemplateSourceDirectory.ToLower(), "")));
            }
            currentPage.ClientScript.RegisterStartupScript(typeof(MessageBox), "showalert", sb.ToString(), true);
        }

        /// <summary>
        /// Función que muestra una alerta personalizada
        /// </summary>
        /// <param name="message">contenido del mensaje a mostrar</param>
        public static void ShowAlert(string message)
        {
            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
                ShowAlert(currentPage, message, null);
        }

        public static void ShowAlertRedirect(string message, string urlRedirect)
        {
            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
                ShowAlert(currentPage, message, urlRedirect);
        }

    }
}
