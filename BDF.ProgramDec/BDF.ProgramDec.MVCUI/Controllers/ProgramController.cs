using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.MVCUI.ViewModels;
using System.IO;

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class ProgramController : Controller
    {
        List<Program> programs;
        // GET: Program
        public ActionResult Index()
        {
            programs = ProgramManager.Load();
            return View(programs);
        }

        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            var programs = ProgramManager.Load();
            return PartialView(programs);
        }

        // GET: Program/Details/5
        public ActionResult Details(int id)
        {
            Program program = ProgramManager.LoadById(id);
            return View(program);
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            ProgramDegreeTypes pdts = new ProgramDegreeTypes();

            pdts.DegreeTypes = DegreeTypeManager.Load();
            pdts.Program = new Program();

            return View(pdts);
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramDegreeTypes pdts)
        {
            try
            {
                if(pdts.File != null)
                {
                    pdts.Program.ImagePath = pdts.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdts.File.FileName));
                    if (!System.IO.File.Exists(target))
                    {
                        pdts.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File Already Exists...";
                    }
                }

                // TODO: Add insert logic here
                ProgramManager.Insert(pdts.Program);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pdts);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            ProgramDegreeTypes pdts = new ProgramDegreeTypes();
            pdts.DegreeTypes = DegreeTypeManager.Load();
            pdts.Program = ProgramManager.LoadById(id); 

            return View(pdts);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramDegreeTypes pdts)
        {
            try
            {
                if (pdts.File != null)
                {
                    pdts.Program.ImagePath = pdts.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(pdts.File.FileName));
                    if (!System.IO.File.Exists(target))
                    {
                        pdts.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                    else
                    {
                        ViewBag.Message = "File Already Exists...";
                    }
                }
                // TODO: Add update logic here
                ProgramManager.Update(pdts.Program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pdts);
            }
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int id)
        {
            Program program = ProgramManager.LoadById(id);
            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Program program)
        {
            try
            {
                ProgramManager.Delete(id);
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
