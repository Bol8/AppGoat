using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppGoat.Api.Models.ColorPromo;
using AppGoat.Application.Services;
using AppGoat.Domain.RepositoryServices;
using AppGoat.Repository.Context;
using AppGoat.Repository.Repositories;

namespace AppGoat.Api.Controllers
{
    public class ColorPromoController : Controller
    {
        private readonly IColorPromoAppService _colorPromoAppService;

        public ColorPromoController()
        {
            _colorPromoAppService = new ColorPromoAppService(new ColorPromoRepository(new GoatDb()));
        }

        // GET: ColorPromo
        public ActionResult Index()
        {
            var colors = _colorPromoAppService.GetColors();
            return View(colors);
        }

        // GET: ColorPromo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColorPromo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorPromo/Create
        [HttpPost]
        public ActionResult Create(ColorCreateViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorPromo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColorPromo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorPromo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColorPromo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
