using BDF.ProgramDec.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BDF.ProgramDec.BL.Test
{
    [TestClass]
    public class utProgram
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
            List<Program> programs = ProgramManager.Load();
            Assert.AreEqual(17, programs.Count);
        }

        public void InsertTest()
        {
            Program program = new Program { Description = "Basketweaving", DegreeTypeId = 3 };
            Assert.AreNotEqual(0, ProgramManager.Insert(program));
        }

        public void UpdateTest()
        {
            Program program = ProgramManager.LoadById(18);
            program.Description = "Updated";
            Assert.IsTrue(ProgramManager.Update(program) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(ProgramManager.Delete(18) > 0);
        }
    }
}
