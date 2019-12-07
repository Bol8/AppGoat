using AppGoat.Application.Services;
using AppGoat.Domain.Entities;
using AppGoat.Repository.Context;
using AppGoat.Repository.Repositories;
using System;
using System.Linq;
using System.Web.Http;

namespace AppGoat.Api.Controllers
{
    public class OfferApiController : ApiController
    {
        private readonly IOfferAppService _offerAppService;

        public OfferApiController()
        {
            _offerAppService = new OfferAppService(new OfferRepository(new GoatDb()));
        }

        // GET: api/OfferApi
        public IHttpActionResult Get()
        {
            try
            {
                var offers = _offerAppService.GetOffers().ToList();

                if (!offers.Any())
                    return NotFound();

                return Ok(offers);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // GET: api/OfferApi/5
        public Offer Get(int id)
        {
            var offer = _offerAppService.GetOffer(id);
            return offer;
        }

        // POST: api/OfferApi
        public IHttpActionResult Post(Offer offer)
        {
            try
            {
                _offerAppService.Add(offer);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // PUT: api/OfferApi/5
        public IHttpActionResult Put(Offer offer)
        {
            try
            {
                _offerAppService.Edit(offer);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/OfferApi/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _offerAppService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
