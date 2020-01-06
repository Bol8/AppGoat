using AppGoat.Api.Models.Offer;
using AppGoat.Application.Constants;
using AppGoat.Application.Services;
using AppGoat.Application.Utils.Notifications;
using AppGoat.Domain.Entities;
using AppGoat.Repository.Context;
using AppGoat.Repository.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppGoat.Api.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferAppService _offerAppService;
        private GoatDb db = new GoatDb();

        public OfferController()
        {
            _offerAppService = new OfferAppService(new OfferRepository(db));
        }

        // GET: Offer
        public ActionResult Index()
        {
            try
            {
                var offers = _offerAppService.GetOffers();
                var model = Mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewModel>>(offers);
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: Offer/Details/5
        public ActionResult Details(short id)
        {
            var offer = _offerAppService.GetOffer(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            var model = new OfferCreateViewModel(db.Colors);
            return View(model);
        }

        // POST: Offer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.LoadCollections(db.Colors);
                    return View(model);
                }

                var offer = Mapper.Map<OfferCreateViewModel, Offer>(model);
                _offerAppService.Add(offer);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                model.LoadCollections(db.Colors);
                return View(model);
            }
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(short id)
        {
            var offer = _offerAppService.GetOffer(id);
            if (offer == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Offer, OfferCreateViewModel>(offer);
            model.LoadCollections(db.Colors);

            return View(model);
        }

        // POST: Offer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfferCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.LoadCollections(db.Colors);
                    return View(model);
                }

                var offer = Mapper.Map<OfferCreateViewModel, Offer>(model);
                _offerAppService.Edit(offer);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                model.LoadCollections(db.Colors);
                return View(model);
            }
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(short id)
        {
            var offer = _offerAppService.GetOffer(id);
            if (offer == null)
            {
                return HttpNotFound();
            }

            return View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            try
            {
                _offerAppService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Conflict);
            }
        }

        public async Task<ActionResult> PublishAsync(short id)
        {
            try
            {
                var offer = _offerAppService.GetOffer(id);
                var appCenter = new AppCenter(new Dictionary<Guid, string>
                {
                    {new Guid("2cb316d8-9029-4333-9002-427da5b51e73"), "Android"}
                });

                var res = await appCenter.SendPushNotificationAsync(offer.Name, offer.Description, null);
            }
            catch (Exception e)
            {
                return await Task.FromResult<ActionResult>(new HttpStatusCodeResult(HttpStatusCode.Conflict));
            }

            return await Task.FromResult<ActionResult>(RedirectToAction("Index"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
