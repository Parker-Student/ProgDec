using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class DegreeTypeController : Controller
    {
        List<DegreeType> degreeTypes;
        // GET: DegreeType
        public ActionResult Index()
        {
            ViewBag.Title = "Degree Types";
            degreeTypes = DegreeTypeManager.Load();
            return View(degreeTypes);
        }

        // GET: DegreeType/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";

            DegreeType degreeType = new DegreeType();
            degreeType = DegreeTypeManager.LoadById(id);
            return View(degreeType);
        }

        // GET: DegreeType/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            DegreeType degreeType = new DegreeType();
            return View(degreeType);
        }

        // POST: DegreeType/Create
        [HttpPost]
        public ActionResult Create(DegreeType degreeType)
        {
            try
            {
                // TODO: Add insert logic here
                DegreeTypeManager.Insert(degreeType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DegreeType/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            DegreeType degreeType = new DegreeType();
            degreeType = DegreeTypeManager.LoadById(id);
            return View(degreeType);
            
        }

        // POST: DegreeType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DegreeType degreeType)
        {
            try
            {
                // TODO: Add update logic here
                DegreeTypeManager.Update(degreeType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DegreeType/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";

            DegreeType degreeType = new DegreeType();
            degreeType = DegreeTypeManager.LoadById(id);
            return View(degreeType);
          
        }

        // POST: DegreeType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DegreeType degreeType)
        {
            try
            {
                DegreeTypeManager.Delete(id);

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
