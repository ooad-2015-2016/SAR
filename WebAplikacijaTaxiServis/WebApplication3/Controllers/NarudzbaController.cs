using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class NarudzbaController : Controller
    {
        // GET: Narudzba
        public ActionResult Index()
        {
            return View();
        }

        // GET: Narudzba/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Narudzba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Narudzba/Create
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

        // GET: Narudzba/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Narudzba/Edit/5
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

        // GET: Narudzba/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Narudzba/Delete/5
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
