using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.PL;
using System.Linq;

namespace BDF.ProgramDec.PL.Test
{
    [TestClass]
    public class utDegreeType
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

            // SELECT * FROM tblDegreeType - LINQ SQL
            var results = from degreetype in dc.tblDegreeTypes
                          select degreetype;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        public void InsertTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                // Make a new degreetype
                tblDegreeType newrow = new tblDegreeType();

                // Set the column values
                newrow.Id = -99;
                newrow.Description = "My new shiny degree type";

                // Add the row
                dc.tblDegreeTypes.Add(newrow);

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
                // SELECT * FROM tblDegreeType WHERE  Id = -99
                tblDegreeType row = (from dt in dc.tblDegreeTypes
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if(row != null)
                {
                    // Change values
                    row.Description = "New Description";
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
        
 
        public void DeleteTest()
        {
            using (ProgDecEntities dc = new ProgDecEntities())
            {
                tblDegreeType row = (from dt in dc.tblDegreeTypes
                                     where dt.Id == -99
                                     select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblDegreeTypes.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

    }
}
