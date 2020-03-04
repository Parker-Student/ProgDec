using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BDF.ProgramDec.BL.Models;
using BDF.ProgramDec.BL;

namespace BDF.ProgramDec.WFUI
{
    public partial class DegreeTypes : System.Web.UI.Page
    {
        List<DegreeType> degreeTypes;
        DegreeType degreeType;

        protected void Page_Load(object sender, EventArgs e)
        {
            degreeTypes = new List<DegreeType>();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                degreeType = new DegreeType();

                degreeType.Description = txtDescription.Text;

                // Add to the database
                int results = DegreeTypeManager.Insert(degreeType);

                // Add to the list
                degreeTypes.Add(degreeType);

                Response.Write("Inserted " + results.ToString() + " rows...");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlDegreeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}