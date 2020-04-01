using BDF.Bands.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDF.Bands.UI.Controllers
{
    public class BandController : Controller
    {
        BandModel[] bands = new BandModel[]
        {
            new BandModel{Id = 1, Name="Eric Clapton", Genre = "Blues", YearFounded = 1978},
            new BandModel{Id = 2, Name="Motley Crue", Genre = "Rock", YearFounded = 1982},
            new BandModel{Id = 3, Name="Norah Jones", Genre = "Jazz", YearFounded = 2005}
        };

        // GET: Band
        public ActionResult Index()
        {
            return View(bands);
        }

        private void GetBands()
        {
            
        }
    }
}