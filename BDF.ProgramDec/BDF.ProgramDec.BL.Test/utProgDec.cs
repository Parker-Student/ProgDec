using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
using System.Collections.Generic;

namespace BDF.ProgramDec.BL.Test
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
            List<ProgDec> progDecs = ProgDecManager.Load();
            Assert.AreEqual(5, progDecs.Count);
        }

        public void InsertTest()
        {
            ProgDec progDec = new ProgDec { ProgramId = 12, StudentId = 5 };
            Assert.AreNotEqual(0, ProgDecManager.Insert(progDec));
        }

        public void UpdateTest()
        {
            ProgDec progDec = ProgDecManager.LoadById(6);
            progDec.ProgramId = 13;
            Assert.IsTrue(ProgDecManager.Update(progDec) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(ProgDecManager.Delete(5) > 0);
        }
    }
}
