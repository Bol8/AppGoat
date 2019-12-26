using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppGoat.Api.Controllers
{
    public class ColorPromoController : Controller
    {
        // GET: ColorPromo
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
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
