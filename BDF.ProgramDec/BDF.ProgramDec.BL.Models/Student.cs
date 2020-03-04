using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }

        // Calculated Full Name
        public string FullNameFirst
        {
            get { return FirstName + " " + LastName; }
        }

        public string FullNameLast
        {
            get { return LastName + ", " + FirstName; }
        }

    }
}
