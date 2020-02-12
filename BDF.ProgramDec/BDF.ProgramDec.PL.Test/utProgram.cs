using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.PL;
using System.Linq;

namespace BDF.ProgramDec.PL.Test
{
    [TestClass]
    public class utProgram
    {
        [TestMethod]
        public void LoadTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            // SELECT * FROM tblProgram - LINQ SQL
            var results = from Program in dc.tblPrograms
                          select Program;

            int expected = 17;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Make a new Program
                tblProgram newrow = new tblProgram();

                // Set the column values
                newrow.Id = -99;
                newrow.Description = "My new shiny program";
                newrow.DegreeTypeId = 3;

                // Add the row
                dc.tblPrograms.Add(newrow);

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
                // SELECT * FROM tblProgram WHERE  Id = -99
                tblProgram row = (from dt in dc.tblPrograms
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    // Change values
                    row.Description = "New Description";
                    row.DegreeTypeId = 2;
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
                tblProgram row = (from dt in dc.tblPrograms
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblPrograms.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

    }
}
