using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.PL;

namespace BDF.ProgramDec.BL
{
    public static class ProgDecAdvisorManager
    {
        public static void Delete(int progdecId, int advisorId)
        {
            using(ProgDecEntities dc = new ProgDecEntities())
            {
                tblProgDecAdvisor pda = dc.tblProgDecAdvisors.FirstOrDefault(p => p.ProgDecId == progdecId && p.AdvisorId == advisorId);

                if(pda != null)
                {
                    dc.tblProgDecAdvisors.Remove(pda);
                    dc.SaveChanges();
                }

            }

        }

        public static void Add(int progdecId, int advisorId)
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                tblProgDecAdvisor pda = new tblProgDecAdvisor();
                pda.Id = dc.tblProgDecAdvisors.Any() ? dc.tblProgDecAdvisors.Max(p => p.Id) + 1 : 1;
                pda.ProgDecId = progdecId;
                pda.AdvisorId = advisorId;

                dc.tblProgDecAdvisors.Add(pda);
                dc.SaveChanges();
            }

            }
    }
}
