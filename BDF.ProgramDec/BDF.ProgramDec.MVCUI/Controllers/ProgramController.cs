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

namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class ProgramController : Controller
    {
        #region "Pre-WebAPI"
        List<Program> programs;
        // GET: Program
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                programs = ProgramManager.Load();
                ViewBag.Source = "Index";

                return View(programs);
            
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }

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
            if (Authenticate.IsAuthenticated())
            {

                ProgramDegreeTypes pdts = new ProgramDegreeTypes();

                pdts.DegreeTypes = DegreeTypeManager.Load();
                pdts.Program = new Program();

                return View(pdts);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramDegreeTypes pdts)
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

                // TODO: Add insert logic here
                ProgramManager.Insert(pdts.Program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pdts);
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                ProgramDegreeTypes pdts = new ProgramDegreeTypes();
                pdts.DegreeTypes = DegreeTypeManager.Load();
                pdts.Program = ProgramManager.LoadById(id);

                return View(pdts);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });

            }

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
            if (Authenticate.IsAuthenticated())
            {
                Program program = ProgramManager.LoadById(id);
                return View(program);
            }


            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });


            }
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
            HttpResponseMessage response = client.GetAsync("Program").Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);

            //Parse the items into a list of program
            List<Program> programs = items.ToObject<List<Program>>();

            ViewBag.Source = "Get";
            return View("Index", programs);
        }

        public ActionResult GetOne(int id)
        {
            HttpClient client = InitializeClient();


            //Do the actual call to the WebAPI
            HttpResponseMessage response = client.GetAsync("Program/" +id).Result;

            //Parse the result
            string result = response.Content.ReadAsStringAsync().Result;

            //Parse the result into generic objects
            Program program = JsonConvert.DeserializeObject<Program>(result);

            return View("Details", program);
        }

        public ActionResult Insert()
        {
            HttpClient client = InitializeClient();

            ProgramDegreeTypes pdts = GetDegreeTypes(client);
            
            pdts.Program = new Program();

            return View("Create", pdts);
        }
        [HttpPost]
        public ActionResult Insert(ProgramDegreeTypes pdts)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Program", pdts.Program).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Create", pdts);
            }
          
            
        }
        public ActionResult Update(int id)
        {
            HttpClient client = InitializeClient();

            ProgramDegreeTypes pdts = GetDegreeTypes(client);

            HttpResponseMessage response = client.GetAsync("Program/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Program program = JsonConvert.DeserializeObject<Program>(result);

            return View("Edit", pdts);

        }

        private static ProgramDegreeTypes GetDegreeTypes(HttpClient client)
        {
            ProgramDegreeTypes pdts = new ProgramDegreeTypes();
            pdts.DegreeTypes = new List<DegreeType>();
            HttpResponseMessage response = client.GetAsync("DegreeType").Result;
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            pdts.DegreeTypes = items.ToObject<List<DegreeType>>();
            return pdts;
        }

        [HttpPost]
        public ActionResult Update(ProgramDegreeTypes pdts, int id)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Program/" + id, pdts.Program).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Edit", pdts);
            }

        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Program/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Program program = JsonConvert.DeserializeObject<Program>(result);
            return View("Delete", program);
        }

        [HttpPost]
        public ActionResult Remove(int id, Program program)
        {
            try
            {
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.DeleteAsync("Program/" + id).Result;
                return RedirectToAction("Get");


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View("Delete", program);
            }
        }
        #endregion

    }


}
