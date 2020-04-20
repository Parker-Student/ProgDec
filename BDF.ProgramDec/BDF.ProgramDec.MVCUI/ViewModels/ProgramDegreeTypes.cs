using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.MVCUI.ViewModels
{
    public class ProgramDegreeTypes
    {
        public Program Program { get; set; }

        public List<DegreeType> DegreeTypes { get; set; }
    }
}