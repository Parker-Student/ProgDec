using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.PL;

namespace BDF.ProgramDec.BL
{
    public static class DegreeTypeManager
    {
        public static int Insert(out int id, string description)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType newrow = new tblDegreeType();

                    newrow.Description = description;
                    newrow.Id = dc.tblDegreeTypes.Any() ? dc.tblDegreeTypes.Max(dt => dt.Id) + 1 : 1;
                    id = newrow.Id;

                    //if(dc.tblDegreeTypes.Any())
                    //{
                    //    newrow.Id = dc.tblDegreeTypes.Max(dt => dt.Id) + 1;
                    //}
                    //else
                    //{
                    //    newrow.Id = 1;
                    //}

                    dc.tblDegreeTypes.Add(newrow);
                    return dc.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(DegreeType degreeType)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, degreeType.Description);
                degreeType.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int Update(int id, string description)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType updaterow = (from dt in dc.tblDegreeTypes
                                               where dt.Id == id
                                               select dt).FirstOrDefault();

                    updaterow.Description = description;
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(DegreeType degreeType)
        {
            return Update(degreeType.Id, degreeType.Description);
        }
        public static int Delete(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType deleterow = (from dt in dc.tblDegreeTypes
                                               where dt.Id == id
                                               select dt).FirstOrDefault();

                    dc.tblDegreeTypes.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DegreeType> Load()
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    List<DegreeType> degreeTypes = new List<DegreeType>();
                    foreach(tblDegreeType dt in dc.tblDegreeTypes)
                    {
                        degreeTypes.Add(new DegreeType
                        {
                            Id = dt.Id,
                            Description = dt.Description
                        });
                    }
                    return degreeTypes;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DegreeType LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblDegreeType row = (from dt in dc.tblDegreeTypes
                                         where dt.Id == id
                                         select dt).FirstOrDefault();

                    if (row != null)
                        return new DegreeType { Id = row.Id, Description = row.Description };
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
