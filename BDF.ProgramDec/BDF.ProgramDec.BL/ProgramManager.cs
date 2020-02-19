using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.PL;

namespace BDF.ProgramDec.BL
{
    public static class ProgramManager
    {
        public static int Insert(out int id, string description, int programId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram newrow = new tblProgram();

                    newrow.Description = description;
                    newrow.DegreeTypeId = programId;
                    newrow.Id = dc.tblPrograms.Any() ? dc.tblPrograms.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;

                    dc.tblPrograms.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Program program)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, program.Description, program.DegreeTypeId);
                program.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, string description, int degreeTypeId)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram updaterow = (from dt in dc.tblPrograms
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    updaterow.Description = description;
                    updaterow.DegreeTypeId = degreeTypeId;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Program program)
        {
            return Update(program.Id,
                          program.Description,
                          program.DegreeTypeId);
        }
        public static int Delete(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram deleterow = (from dt in dc.tblPrograms
                                            where dt.Id == id
                                            select dt).FirstOrDefault();

                    dc.tblPrograms.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Program> Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    List<Program> programs = new List<Program>();
                    foreach (tblProgram p in dc.tblPrograms)
                    {
                        programs.Add(new Program
                        {
                            Id = p.Id,
                            DegreeTypeId = p.DegreeTypeId,
                            Description = p.Description
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

        public static Program LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram row = (from p in dc.tblPrograms
                                      where p.Id == id
                                      select p).FirstOrDefault();

                    if (row != null)
                        return new Program
                        {
                            Id = row.Id,
                            DegreeTypeId = row.DegreeTypeId,
                            Description = row.Description
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
