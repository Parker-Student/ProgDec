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
                                 int programId,
                                 int studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec newrow = new tblProgDec();

                    newrow.ProgramId = programId;
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

        public static int Insert(ProgDec program)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, 
                                    program.ProgramId, 
                                    program.StudentId);
                program.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, 
                                 int programId,
                                 int studentId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgDec updaterow = (from dt in dc.tblProgDecs
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    updaterow.ProgramId = programId;
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

        public static int Update(ProgDec program)
        {
            return Update(program.Id,
                          program.ProgramId,
                          program.StudentId);
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
                    List<ProgDec> programs = new List<ProgDec>();
                    foreach (tblProgDec p in dc.tblProgDecs)
                    {
                        programs.Add(new ProgDec
                        {
                            Id = p.Id,
                            ProgramId = p.ProgramId,
                            StudentId = p.StudentId,
                            ChangeDate = p.ChangeDate
                        });
                    }
                    return programs;
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
                    tblProgDec row = (from p in dc.tblProgDecs
                                      where p.Id == id
                                      select p).FirstOrDefault();

                    if (row != null)
                        return new ProgDec
                        {
                            Id = row.Id,
                            ProgramId = row.ProgramId,
                            StudentId = row.StudentId,
                            ChangeDate = row.ChangeDate
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
