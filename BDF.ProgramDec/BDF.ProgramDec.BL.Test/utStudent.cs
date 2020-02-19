using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
using System.Collections.Generic;

namespace BDF.ProgramDec.BL.Test
{
    [TestClass]
    public class utStudent
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
            List<Student> students = StudentManager.Load();
            Assert.AreEqual(4, students.Count);
        }

        public void InsertTest()
        {
            Student student = new Student { FirstName = "Toby",
                                               LastName = "Flenderson",
                                               StudentId = "776677887"};
            Assert.AreNotEqual(0, StudentManager.Insert(student));
        }

        public void UpdateTest()
        {
            Student student = StudentManager.LoadById(5);
            student.LastName = "Updated";
            Assert.IsTrue(StudentManager.Update(student) > 0);
        }

        public void DeleteTest()
        {
            Assert.IsTrue(StudentManager.Delete(5) > 0);
        }
    }
}
