using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.PL;
using System.Linq;

namespace BDF.ProgramDec.PL.Test
{
    [TestClass]
    public class utStudent
    {
        [TestMethod]
        public void LoadTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            // SELECT * FROM tblStudent - LINQ SQL
            var results = from student in dc.tblStudents
                          select student;

            int expected = 4;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Make a new student
                tblStudent newrow = new tblStudent();

                // Set the column values
                newrow.Id = -99;
                newrow.FirstName = "Brian";
                newrow.LastName = "Foote";
                newrow.StudentId= "123456789";

                // Add the row
                dc.tblStudents.Add(newrow);

                // Save the Changes
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Get the record that I want to update
                // SELECT * FROM tblStudent WHERE  Id = -99
                tblStudent row = (from dt in dc.tblStudents
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    // Change values
                    row.FirstName = "Brian";
                    row.LastName = "Bishop";
                    row.StudentId = "9876543212";
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

        [TestMethod]

        public void DeleteTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                tblStudent row = (from dt in dc.tblStudents
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblStudents.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

    }
}
