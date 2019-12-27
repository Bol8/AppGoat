using System.Collections.Generic;
using AppGoat.Domain.Entities;

namespace AppGoat.Application.Services
{
    public interface IOfferAppService
    {
        IEnumerable<Offer> GetOffers();

        Offer GetOffer(short id);

        void Add(Offer offer);

        void Edit(Offer offer);

        void Delete(short id);
    }
}