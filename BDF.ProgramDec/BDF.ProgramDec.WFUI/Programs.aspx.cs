using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;


namespace BDF.ProgramDec.WFUI
{
    public partial class Programs : System.Web.UI.Page
    {
        List<Program> programs;
        List<DegreeType> degreeTypes;
        Program program;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                programs = ProgramManager.Load();
                degreeTypes = DegreeTypeManager.Load();
                Rebind();

                Session["programs"] = programs;
                Session["degreetypes"] = degreeTypes;

                ddlPrograms_SelectedIndexChanged(sender, e);
            }
            else
            {
                programs = (List<Program>)Session["programs"];
                degreeTypes = (List<DegreeType>)Session["degreetypes"];
            }
        }

        protected void ddlPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            program = programs[ddlPrograms.SelectedIndex];
            txtDescription.Text = program.Description;
            ddlDegreeTypes.SelectedValue = program.DegreeTypeId.ToString();
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

            // Clear out the binding to the ddl
            ddlPrograms.DataSource = null;

            // Rebind to the ddl
            ddlPrograms.DataSource = programs;

            // Designate the field/property that will be displayed
            ddlPrograms.DataTextField = "Description";

            // Designate the field/property that is the primary key.
            ddlPrograms.DataValueField = "Id";

            // Do the binding
            ddlPrograms.DataBind();

            txtDescription.Text = string.Empty;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                program = new Program();
                program.Description = txtDescription.Text;
                program.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = ProgramManager.Insert(program);
                Response.Write("Inserted " + results + " rows...");

                programs.Add(program);

                Rebind();

                if (results > 0)
                {
                    ddlPrograms.SelectedValue = program.Id.ToString();
                }
                ddlPrograms_SelectedIndexChanged(sender, e);

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
                program = programs[ddlPrograms.SelectedIndex];

                program.Description = txtDescription.Text;
                program.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = ProgramManager.Update(program);
                Response.Write("Updated " + results + " rows...");
                Rebind();

                if (results > 0)
                {
                    ddlPrograms.SelectedValue = program.Id.ToString();
                }
                ddlPrograms_SelectedIndexChanged(sender, e);
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
                program = programs[ddlPrograms.SelectedIndex];

                int results = ProgramManager.Delete(program.Id);
                Response.Write("Deleted " + results + " rows...");
                programs.Remove(program);
                Rebind();
                ddlPrograms_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}