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
        public static int Insert(out int id, string description, int programId, string imagePath)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram newrow = new tblProgram();
                    newrow.Id = dc.tblPrograms.Any() ? dc.tblPrograms.Max(dt => dt.Id) + 1 : 1;
                    newrow.Description = description;
                    newrow.DegreeTypeId = programId;
                    newrow.ImagePath = imagePath;
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
                int result = Insert(out id, program.Description, program.DegreeTypeId, program.ImagePath);
                program.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, string description, int degreeTypeId, string imagePath)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblProgram updaterow = (from dt in dc.tblPrograms
                                            where dt.Id == id
                                            select dt).FirstOrDefault();
                    updaterow.ImagePath = imagePath;
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
                          program.DegreeTypeId,
                          program.ImagePath);
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
                    List<Program> results = new List<Program>();

                    var programs = (from p in dc.tblPrograms
                                    join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                                    orderby p.Description
                                    select new
                                    {
                                        p.Id,
                                        p.DegreeTypeId,
                                        p.Description,
                                        DegreeName = dt.Description,
                                        p.ImagePath
                                    }).ToList();

                    programs.ForEach(pdt => results.Add(new Program
                    {

                        Id = pdt.Id,
                        DegreeTypeId = pdt.DegreeTypeId,
                        Description = pdt.Description,
                        DegreeName = pdt.DegreeName,
                        ImagePath = pdt.ImagePath
                    }));


                    return results;
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
                    var pdt = (from p in dc.tblPrograms
                               join dt in dc.tblDegreeTypes on p.DegreeTypeId equals dt.Id
                               where p.Id == id
                               select new
                               {
                                   p.Id,
                                   p.DegreeTypeId,
                                   p.Description,
                                   DegreeName = dt.Description,
                                   p.ImagePath
                               }).FirstOrDefault();

                    if (pdt != null)
                    {
                        Program program = new Program
                        {
                            Id = pdt.Id,
                            DegreeTypeId = pdt.DegreeTypeId,
                            Description = pdt.Description,
                            DegreeName = pdt.DegreeName,
                            ImagePath = pdt.ImagePath
                        };
                        return program;
                    }
                    else
                    {
                        throw new Exception("Row was not found.");

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
