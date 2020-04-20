using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.MVCUI.ViewModels
{
    public class ProgDecProgramsStudents
    {

        public BL.Models.ProgDec ProgDec { get; set; }
        public List<BL.Models.Program> Programs { get; set;}
        public List<BL.Models.Student> Students { get; set; }

    }
}