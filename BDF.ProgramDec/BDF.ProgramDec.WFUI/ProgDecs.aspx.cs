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
    public partial class ProgDecs : System.Web.UI.Page
    {
        List<Student> students;
        List<ProgDec> progDecs;
        ProgDec progDec;
        List<Program> programs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                students = StudentManager.Load();
                progDecs = ProgDecManager.Load();
                programs = ProgramManager.Load();
                Rebind();

                Session["students"] = students;
                Session["progdecs"] = progDecs;
                Session["programs"] = programs;

                ddlChangeDate_SelectedIndexChanged(sender, e);
            }
            else
            {
                students = (List<Student>)Session["students"];
                progDecs = (List<ProgDec>)Session["progdecs"];
                programs = (List<Program>)Session["programs"];
            }
        }

        private void Rebind()
        {
            //clear out the binding to the ddl
            ddlChangeDate.DataSource = null;
            //rebind to the ddl
            ddlChangeDate.DataSource = progDecs;
            //designate the field/property that will be displayed
            ddlChangeDate.DataTextField = "ChangeDate";
            //designate the field/property that is the primary key
            ddlChangeDate.DataValueField = "ID";
            //do the binding
            ddlChangeDate.DataBind();


            //clear out the binding to the ddl
            ddlStudents.DataSource = null;
            //rebind to the ddl
            ddlStudents.DataSource = students;
            //designate the field/property that will be displayed
            ddlStudents.DataTextField = "FullNameFirst";
            //designate the field/property that is the primary key
            ddlStudents.DataValueField = "ID";
            //do the binding
            ddlStudents.DataBind();


            //clear out the binding to the ddl
            ddlPrograms.DataSource = null;
            //rebind to the ddl
            ddlPrograms.DataSource = programs;
            //designate the field/property that will be displayed
            ddlPrograms.DataTextField = "Description";
            //designate the field/property that is the primary key
            ddlPrograms.DataValueField = "ID";
            //do the binding
            ddlPrograms.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                progDec = new ProgDec();
                progDec.ProgramId = programs[ddlPrograms.SelectedIndex].Id;
                progDec.StudentId = students[ddlStudents.SelectedIndex].Id;

                int results = ProgDecManager.Insert(progDec);
                Response.Write("Inserted " + results + " rows.");

                progDecs.Add(progDec);

                Rebind();

                if (results > 0)
                {
                    ddlChangeDate.SelectedValue = progDec.Id.ToString();
                }
                ddlChangeDate_SelectedIndexChanged(sender, e);
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
                progDec = progDecs[ddlChangeDate.SelectedIndex];
                progDec.ProgramId = programs[ddlPrograms.SelectedIndex].Id;
                progDec.StudentId = students[ddlStudents.SelectedIndex].Id;

                int results = ProgDecManager.Update(progDec);
                Response.Write("Updated " + results + " rows.");
                Rebind();

                if (results > 0)
                {
                    ddlChangeDate.SelectedValue = progDec.Id.ToString();
                }
                ddlChangeDate_SelectedIndexChanged(sender, e);

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
                progDec = progDecs[ddlChangeDate.SelectedIndex];

                int results = ProgDecManager.Update(progDec);
                Response.Write("Updated " + results + " rows.");

                progDecs.Remove(progDec);

                Rebind();
                ddlChangeDate_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }


        protected void ddlProgramDeclarations_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void ddlChangeDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            progDec = progDecs[ddlChangeDate.SelectedIndex];
            ddlStudents.SelectedValue = progDec.StudentId.ToString();
            ddlPrograms.SelectedValue = progDec.ProgramId.ToString();
        }
    }
}