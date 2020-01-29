using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.BL
{
    public static class ProgramManager
    {
        public static int Insert(string description, int degreeTypeId)
        {
            return 0;
        }

        public static int Insert(Program program)
        {
            return Insert(program.Description, program.DegreeTypeId);
        }


        public static int Update(int id, string description, int degreeTypeId)
        {
            return 0;
        }

        public static int Update(Program program)
        {
            return Update(program.Id, program.Description, program.DegreeTypeId);
        }
        public static int Delete(int id)
        {
            return 0;
        }

        public static List<Program> Load()
        {
            return new List<Program>();
        }
        public static Program LoadById()
        {
            return new Program();
        }
    }
}
