using System;
using System.Globalization;
using AppGoat.Wcf.Contracts;

namespace AppGoat.Wcf.WCF
{

    public class OfferService : IOfferService
    {
        public Offer GetOffer(int id)
        {
            return new Offer
            {
                Name = "AAAA"
            };
        }

        public Response CreateOffer(Offer offer)
        {
           return new Response
           {
               Code = 1,
               Date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
               Description = "Ok"
           };
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
