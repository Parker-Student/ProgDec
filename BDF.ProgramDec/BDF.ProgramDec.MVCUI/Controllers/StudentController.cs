using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.BL;

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students;
        // GET: Studnet
        public ActionResult Index()
        {
            students = StudentManager.Load();
            return View(students);
        }

        // GET: Studnet/Details/5
        public ActionResult Details(int id)
        {
            Student student = StudentManager.LoadById(id);
            return View(student);
        }

        // GET: Studnet/Create
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        // POST: Studnet/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                StudentManager.Insert(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studnet/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = StudentManager.LoadById(id);
            return View(student);
        }

        // POST: Studnet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                StudentManager.Update(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studnet/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = StudentManager.LoadById(id);
            return View(student);
        }

        // POST: Studnet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                StudentManager.Delete(id);
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
