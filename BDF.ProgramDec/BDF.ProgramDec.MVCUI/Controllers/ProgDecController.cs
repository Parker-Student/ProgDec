using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.MVCUI.ViewModels;

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class ProgDecController : Controller
    {
        // GET: ProgDec
        public ActionResult Index()
        {
            var progdecs = ProgDecManager.Load();

            return View(progdecs);
        }

        public ActionResult Load(int id)
        {
            var progdecs = ProgDecManager.Load(id);
            return View("Index", progdecs);
        }

        // GET: ProgDec/Details/5
        public ActionResult Details(int id)
        {
            var progdec = ProgDecManager.LoadById(id);
            return View(progdec);
        }

        // GET: ProgDec/Create
        public ActionResult Create()
        {
            ProgDecProgramsStudents pps = new ProgDecProgramsStudents();

            pps.ProgDec = new BL.Models.ProgDec();
            pps.Programs = ProgramManager.Load();
            pps.Students = StudentManager.Load();


            return View(pps);
        }

        // POST: ProgDec/Create
        [HttpPost]
        public ActionResult Create(ProgDecProgramsStudents pps)
        {
            try
            {

                // TODO: Add insert logic here
                ProgDecManager.Insert(pps.ProgDec);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgDec/Edit/5
        public ActionResult Edit(int id)
        {
            ProgDecProgramsStudents pps = new ProgDecProgramsStudents();

            pps.ProgDec = ProgDecManager.LoadById(id);
            pps.Programs = ProgramManager.Load();
            pps.Students = StudentManager.Load();


            return View(pps);
           
        }

        // POST: ProgDec/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgDecProgramsStudents pps)
        {
            try
            {
                // TODO: Add update logic here
                ProgDecManager.Update(pps.ProgDec);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgDec/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Models.ProgDec progdec = ProgDecManager.LoadById(id);

            return View(progdec);
        }

        // POST: ProgDec/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BL.Models.ProgDec progdec)
        {
            try
            {
                // TODO: Add delete logic here
                ProgDecManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
