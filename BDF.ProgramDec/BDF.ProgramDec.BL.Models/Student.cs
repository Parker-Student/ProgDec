using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [DisplayName("Student ID")]

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
