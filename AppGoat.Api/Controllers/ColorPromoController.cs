using AppGoat.Api.Models.ColorPromo;
using AppGoat.Application.Services;
using AppGoat.Domain.Entities;
using AppGoat.Repository.Context;
using AppGoat.Repository.Repositories;
using AutoMapper;
using System;
using System.Web.Mvc;

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
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var color = Mapper.Map<ColorCreateViewModel, ColorPromo>(model);
                _colorPromoAppService.Add(color);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ColorPromo/Edit/5
        public ActionResult Edit(byte id)
        {
            var color = _colorPromoAppService.GetColor(id);
            var model = Mapper.Map<ColorPromo, ColorCreateViewModel>(color);
            return View(model);
        }

        // POST: ColorPromo/Edit/5
        [HttpPost]
        public ActionResult Edit(ColorCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var color = Mapper.Map<ColorCreateViewModel, ColorPromo>(model);
                _colorPromoAppService.Edit(color);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ColorPromo/Delete/5
        public ActionResult Delete(byte id)
        {
            var color = _colorPromoAppService.GetColor(id);
            var model = Mapper.Map<ColorPromo, ColorViewModel>(color);

            return View(model);
        }

        // POST: ColorPromo/Delete/5
        [HttpPost]
        public ActionResult Delete(ColorViewModel model)
        {
            try
            {
                _colorPromoAppService.Delete(model.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
