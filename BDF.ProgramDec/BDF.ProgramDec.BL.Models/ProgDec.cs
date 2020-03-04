using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
    public class ProgDec
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int StudentId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ProgramName { get; set; }
        public string StudentName { get; set; }
        public string DegreeTypeName { get; set; }

    }
}
