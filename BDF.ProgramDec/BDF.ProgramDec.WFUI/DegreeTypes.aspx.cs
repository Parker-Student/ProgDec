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
            if(!IsPostBack)  // if not the first time here
            {
                degreeTypes = DegreeTypeManager.Load();
                Rebind();

                Session["degreetypes"] = degreeTypes;

                ddlDegreeTypes_SelectedIndexChanged(sender, e);
            }
            else
            {
                degreeTypes = (List<DegreeType>)Session["degreetypes"];
            }
            
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
                Rebind();

                ddlDegreeTypes.SelectedIndex = degreeTypes.Count - 1;
                ddlDegreeTypes_SelectedIndexChanged(sender, e);

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
                int index = ddlDegreeTypes.SelectedIndex;

                degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];

                degreeType.Description = txtDescription.Text;

                int results = DegreeTypeManager.Update(degreeType);

                // Update the degreeTypes 
                degreeTypes[ddlDegreeTypes.SelectedIndex] = degreeType;
                Response.Write("Updated " + results.ToString() + " rows...");
                Rebind();

                ddlDegreeTypes.SelectedIndex = index;
                ddlDegreeTypes_SelectedIndexChanged(sender, e);


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void Rebind()
        {
            // Clear out the binding to the ddl
            ddlDegreeTypes.DataSource = null;

            // Rebind to the ddl
            ddlDegreeTypes.DataSource = degreeTypes;

            // Designate the field/property that will be displayed
            ddlDegreeTypes.DataTextField = "Description";

            // Designate the field/property that is the primary key.
            ddlDegreeTypes.DataValueField = "Id";

            // Do the binding
            ddlDegreeTypes.DataBind();

            txtDescription.Text = string.Empty;


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];
                int results = DegreeTypeManager.Delete(degreeType.Id);
                degreeTypes.Remove(degreeType);
                Response.Write("Delete " + results.ToString() + " rows...");
                Rebind();
                ddlDegreeTypes.SelectedIndex = 0;
                ddlDegreeTypes_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlDegreeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            degreeType = degreeTypes[ddlDegreeTypes.SelectedIndex];
            txtDescription.Text = degreeType.Description;

        }
    }
}