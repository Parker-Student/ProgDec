using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.MVCUI.ViewModels;
using System.IO;
using BDF.ProgramDec.MVCUI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BDF.StudentDec.MVCUI.Controllers
{
    public class StudentController : Controller
    {
        #region "Pre-WebAPI"
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

        #endregion
     
        
        #region "WebAPI"
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50409/api/");
            return client;
        }

        public ActionResult Get()
        {
            HttpClient client = InitializeClient();


            //Do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Student").Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            //Parse the items into a list of student
            List<Student> students = items.ToObject<List<Student>>();

            ViewBag.Source = "Get";
            return View("Index", students);
        }

        public ActionResult GetOne(int id)
        {
            HttpClient client = InitializeClient();


            //Do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Student/" + id).Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            Student student = JsonConvert.DeserializeObject<Student>(result);

            return View("Details", student);
        }

        public ActionResult Insert()
        {
            HttpClient client = InitializeClient();

            Student student = new Student();

            return View("Create", student);
        }
        [HttpPost]
        public ActionResult Insert(Student student)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Student", student).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Create", student);
            }


        }
        public ActionResult Update(int id)
        {
            HttpClient client = InitializeClient();


            HttpResponseMessage response = client.GetAsync("Student/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Student student = JsonConvert.DeserializeObject<Student>(result);

            return View("Edit", student);

        }

        

        [HttpPost]
        public ActionResult Update(Student student, int id)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Student/" + id, student).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Edit", student);
            }

        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Student/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Student student = JsonConvert.DeserializeObject<Student>(result);
            return View("Delete", student);
        }

        [HttpPost]
        public ActionResult Remove(int id, Student student)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Student/" + id).Result;
                return RedirectToAction("Get");


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Delete", student);
            }
        }
        #endregion
    }
}
