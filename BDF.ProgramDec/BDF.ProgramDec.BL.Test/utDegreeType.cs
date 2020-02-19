using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
using System.Collections.Generic;

namespace BDF.ProgramDec.BL.Test
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
            List<DegreeType> degreeTypes = DegreeTypeManager.Load();
            Assert.AreEqual(3, degreeTypes.Count);
        }

        public void InsertTest()
        {
            DegreeType degreeType = new DegreeType { Description = "Bachelors" };
            Assert.AreNotEqual(0, DegreeTypeManager.Insert(degreeType));
        }

        public void UpdateTest()
        {
            DegreeType degreeType = DegreeTypeManager.LoadById(4);
            degreeType.Description = "Updated";
            Assert.IsTrue(DegreeTypeManager.Update(degreeType) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(DegreeTypeManager.Delete(4) > 0);
        }
    }
}
