using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.BL
{
    public static class DegreeTypeManager
    {
        public static int Insert(string description)
        {
            return 0;
        }

        public static int Insert(DegreeType degreeType)
        {
            return Insert(degreeType.Description);
        }


        public static int Update(int id, string description)
        {
            return 0;
        }

        public static int Update(DegreeType degreeType)
        {
            return Update(degreeType.Id, degreeType.Description);
        }
        public static int Delete(int id)
        {
            return 0;
        }

        public static List<DegreeType> Load()
        {
            return new List<DegreeType>();

        }

        public static DegreeType LoadById()
        {
            return new DegreeType();
        }

    }
}
