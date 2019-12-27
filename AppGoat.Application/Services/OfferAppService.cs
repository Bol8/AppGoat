using System;
using System.Collections.Generic;
using AppGoat.Domain.Entities;
using AppGoat.Domain.RepositoryServices;

namespace AppGoat.Application.Services
{
    public class OfferAppService : IOfferAppService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferAppService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IEnumerable<Offer> GetOffers()
        {
            return _offerRepository.GetElements();
        }

        public Offer GetOffer(short id)
        {
            return _offerRepository.GetElement(id);
        }

        public void Add(Offer offer)
        {
            try
            {
                _offerRepository.Add(offer);
                _offerRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Edit(Offer offer)
        {
            try
            {
                _offerRepository.Edit(offer);
                _offerRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(short id)
        {
            try
            {
                _offerRepository.Delete(id);
                _offerRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}