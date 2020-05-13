using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;


namespace BDF.ProgDec.API.Controllers
{
    public class ProgDecController : ApiController
    {
        // GET: api/ProgDec
        public IEnumerable<ProgramDec.BL.Models.ProgDec> Get()
        {
            List<ProgramDec.BL.Models.ProgDec> progDecs = ProgDecManager.Load();
            return progDecs;
        }

        // GET: api/ProgDec/5
        public ProgramDec.BL.Models.ProgDec Get(int id)
        {
            ProgramDec.BL.Models.ProgDec progDec = ProgDecManager.LoadById(id);
            return progDec;
        }

        // POST: api/ProgDec
        public void Post([FromBody]ProgramDec.BL.Models.ProgDec progDec)
        {
            ProgDecManager.Insert(progDec);

        }

        // PUT: api/ProgDec/5
        public void Put(int id, [FromBody]ProgramDec.BL.Models.ProgDec progDec)
        {
            ProgDecManager.Update(progDec);
        }

        // DELETE: api/ProgDec/5
        public void Delete(int id)
        {
            ProgDecManager.Delete(id);
        }
    }
}
