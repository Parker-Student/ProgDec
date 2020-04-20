using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.PL;

namespace BDF.ProgramDec.BL
{
    public static class ProgDecManager
    {
        public static int Insert(out int id, 
                                 int progDecId,
                                 int studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec newrow = new tblProgDec();

                    newrow.ProgramId = progDecId;
                    newrow.StudentId = studentId;
                    newrow.ChangeDate = DateTime.Now;
                    newrow.Id = dc.tblProgDecs.Any() ? dc.tblProgDecs.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;

                    dc.tblProgDecs.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(ProgDec progDec)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, 
                                    progDec.ProgramId, 
                                    progDec.StudentId);
                progDec.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, 
                                 int progDecId,
                                 int studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec updaterow = (from dt in dc.tblProgDecs
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    updaterow.ProgramId = progDecId;
                    updaterow.StudentId = studentId;
                    updaterow.ChangeDate = DateTime.Now;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(ProgDec progDec)
        {
            return Update(progDec.Id,
                          progDec.ProgramId,
                          progDec.StudentId);
        }
        public static int Delete(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec deleterow = (from dt in dc.tblProgDecs
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    dc.tblProgDecs.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ProgDec> Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    List<ProgDec> progDecs = new List<ProgDec>();

                    var progdecs = (from pd in dc.tblProgDecs
                                    join s in dc.tblStudents on pd.StudentId equals s.Id
                                    join p in dc.tblPrograms on pd.ProgramId equals p.Id
                                    join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                                    orderby s.LastName
                                    select new
                                    {
                                        ProgDecId = pd.Id,
                                        ProgramId = p.Id,
                                        StudentId = s.Id,
                                        pd.ChangeDate,
                                        ProgramName = p.Description,
                                        s.FirstName,
                                        s.LastName,
                                        DegreeTypeName = dt.Description
                                    }).ToList();



                    progdecs.ForEach(p => progDecs.Add(new Models.ProgDec
                    {
                        
                            Id = p.ProgDecId,
                            ProgramId = p.ProgramId,
                            StudentId = p.StudentId,
                            ProgramName = p.ProgramName,
                            DegreeTypeName = p.DegreeTypeName,
                            StudentName = p.LastName + ", " + p.FirstName,
                            ChangeDate = p.ChangeDate
                        }));
                    return progDecs;
                }
                   
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static ProgDec LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    var progdec = (from pd in dc.tblProgDecs
                                    join s in dc.tblStudents on pd.StudentId equals s.Id
                                    join p in dc.tblPrograms on pd.ProgramId equals p.Id
                                    join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                                   where pd.Id == id
                                    select new
                                    {
                                        ProgDecId = pd.Id,
                                        ProgramId = p.Id,
                                        StudentId = s.Id,
                                        pd.ChangeDate,
                                        ProgramName = p.Description,
                                        s.FirstName,
                                        s.LastName,
                                        DegreeTypeName = dt.Description
                                    }).FirstOrDefault();

                    if (progdec != null)
                    {
                        Models.ProgDec progDec = new Models.ProgDec
                        {
                            Id = progdec.ProgDecId,
                            ProgramId = progdec.ProgramId,
                            StudentId = progdec.StudentId,
                            ProgramName = progdec.ProgramName,
                            DegreeTypeName = progdec.DegreeTypeName,
                            StudentName = progdec.LastName + ", " + progdec.FirstName,
                            ChangeDate = progdec.ChangeDate
                        };

                        return progDec;
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
