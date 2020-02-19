using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.PL;
using System.Linq;

namespace BDF.ProgramDec.PL.Test
{
    [TestClass]
    public class utProgDec
    {

        [TestMethod]
        public void RunAll()
        {
            LoadTest();
            InsertTest();
            UpdateTest();
            DeleteTest();
        }

        public void LoadTest()
        {
            ProgDecEntities dc = new ProgDecEntities();

            // SELECT * FROM tblProgDec - LINQ SQL
            var results = from progdec in dc.tblProgDecs
                          select progdec;

            int expected = 5;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        public void InsertTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Make a new progdec
                tblProgDec newrow = new tblProgDec();

                // Set the column values
                newrow.Id = -99;
                newrow.ProgramId = 4;
                newrow.StudentId = 3;
                newrow.ChangeDate = DateTime.Now;

                // Add the row
                dc.tblProgDecs.Add(newrow);

                // Save the Changes
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        public void UpdateTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Get the record that I want to update
                // SELECT * FROM tblProgDec WHERE  Id = -99
                tblProgDec row = (from dt in dc.tblProgDecs
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    // Change values
                    row.ProgramId = 2;
                    row.StudentId = 4;
                    row.ChangeDate = DateTime.Now;

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

   
        public void DeleteTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                tblProgDec row = (from dt in dc.tblProgDecs
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblProgDecs.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

    }
}
