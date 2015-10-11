using RegistrodeTickets.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrodeTickets
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

             public void Guardar()
        {
            string postdata = "{\"Id\":1," +
            "\"N_ticket\": 1234," +
            "\"F_creacion\":\"" + DateTime.Now.ToString() + "\"," +
            "\"Estado\":\"Pendiente\"," +
            "\"Prioridad\":\"Alta\"," +
            "\"CodEmpleado\":\"12345," +
            "\"NombreEmpleado\":\"yyyyyyy\"," +
            "\"ApellidoEmpleado\":\"ttttt\"," +
            "\"CorreoEmpleado\":\"vvvvvvvv\"," +
            "\"CargoEmpleado\":\"qqqqqqqqqqq\"," +
            "\"TelefonoEmpleado\":\"8787878\"," +
            "\"AreaEmpleado\":\"casa\"," +
            "\"AsuntoTicket\":\"pcpcpcpcpcc\"," +
            "\"ObservacionTicket\":\"ppapapapapapapapa\"," +
            "\"Obs_atencion\":\"aaa\" }"; //JSON

            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:58785/GuardaTicketsREST.svc/ticket1");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string usuarioJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            GuardaTicket usuarioCreado = js.Deserialize<GuardaTicket>(usuarioJson);
            //lbl_mensaje.Text = usuarioCreado.F_creacion;
        }
    }
    
}