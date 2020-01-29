using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.BL
{
    public class ProgDecManager
    {
        public static int Insert(int programId, int studentId)
        {
            return 0;
        }

        public static int Insert(ProgDec progDec)
        {
            return Insert(progDec.ProgramId, progDec.StudentId);
        }


        public static int Update(int id, int programId, int studentId)
        {
            return 0;
        }

        public static int Update(ProgDec progDec)
        {
            return Update(progDec.Id, progDec.ProgramId, progDec.StudentId);
        }
        public static int Delete(int id)
        {
            return 0;
        }

        public static List<ProgDec> Load()
        {
            return new List<ProgDec>();
        }
        public static ProgDec LoadById()
        {
            return new ProgDec();
        }
    }
}
