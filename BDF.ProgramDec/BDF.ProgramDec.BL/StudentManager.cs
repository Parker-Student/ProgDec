using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.BL
{
    public class StudentManager
    {
        public static int Insert(string firstName, string lastName, string studentId)
        {
            return 0;
        }

        public static int Insert(Student student)
        {
            return Insert(student.FirstName, student.LastName, student.StudentId);
        }


        public static int Update(int id, string firstName, string lastName, string studentId)
        {
            return 0;
        }

        public static int Update(Student student)
        {
            return Update(student.Id, student.FirstName, student.LastName, student.StudentId);
        }
        public static int Delete(int id)
        {
            return 0;
        }

        public static List<Student> Load()
        {
            return new List<Student>();
        }
        public static Student LoadById()
        {
            return new Student();
        }
    }
}
