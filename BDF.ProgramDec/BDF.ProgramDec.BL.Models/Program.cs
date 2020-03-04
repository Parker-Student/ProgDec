using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DegreeTypeId { get; set; }
        public string DegreeTypeName { get; set; }
    }
}
