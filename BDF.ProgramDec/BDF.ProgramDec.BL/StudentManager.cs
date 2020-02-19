using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.PL;

namespace BDF.ProgramDec.BL
{
    public static class StudentManager
    {
        public static int Insert(out int id,
                                 string firstName,
                                 string lastName,
                                 string studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblStudent newrow = new tblStudent();

                    newrow.FirstName = firstName;
                    newrow.LastName = lastName;
                    newrow.StudentId = studentId;
                    newrow.Id = dc.tblStudents.Any() ? dc.tblStudents.Max(s => s.Id) + 1 : 1;
                    id = newrow.Id;

                    dc.tblStudents.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Student student)
        {
            try
            {
                int id = 0;
                int result = Insert(out id,
                                    student.FirstName,
                                    student.LastName,
                                    student.StudentId);
                student.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id,
                                 string firstName,
                                 string lastName,
                                 string studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblStudent updaterow = (from s in dc.tblStudents
                                            where s.Id == id
                                            select s).FirstOrDefault();

                    updaterow.FirstName = firstName;
                    updaterow.LastName = lastName;
                    updaterow.StudentId = studentId;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Student student)
        {
            return Update(student.Id,
                          student.FirstName,
                          student.LastName,
                          student.StudentId);
        }
        public static int Delete(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblStudent deleterow = (from s in dc.tblStudents
                                            where s.Id == id
                                            select s).FirstOrDefault();

                    dc.tblStudents.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Student> Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    List<Student> students = new List<Student>();
                    foreach (tblStudent s in dc.tblStudents)
                    {
                        students.Add(new Student
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            StudentId = s.StudentId
                        });
                    }
                    return students;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Student LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblStudent row = (from s in dc.tblStudents
                                      where s.Id == id
                                      select s).FirstOrDefault();

                    if (row != null)
                        return new Student
                        {
                            Id = row.Id,
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                            StudentId = row.StudentId
                        };
                    else
                        throw new Exception("Row was not found.");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
