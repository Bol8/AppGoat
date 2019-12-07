using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AppGoat.Wcf.Contracts;

namespace AppGoat.Wcf.SOAP
{
    /// <summary>
    /// Descripción breve de SoapOfferService
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://goatapi.somee.com/SOAP/SoapOfferService.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapOfferService : WebService
    {
        [WebMethod]
        public Offer GetOffer(int id)
        {
            return new Offer
            {
                Name = "Offer1"
            };
        }

        [WebMethod]
        public Response CreateOffer(Offer offer)
        {
            return new Response
            {
                Code = 1,
                Description = "ok"
            };
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
