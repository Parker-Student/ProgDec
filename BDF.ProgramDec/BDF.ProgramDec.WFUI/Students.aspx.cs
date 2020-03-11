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
    public partial class Students : System.Web.UI.Page
    {
        List<Student> students;
        Student student;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                students = StudentManager.Load();
                Rebind();

                Session["students"] = students;

                ddlStudents_SelectedIndexChanged(sender, e);
            }
            else
            {
                students = (List<Student>)Session["students"];
            }
        }

        private void Rebind()
        {
            //clear out the binding to the ddl
            ddlStudents.DataSource = null;

            //rebind the ddl
            ddlStudents.DataSource = students;

            ddlStudents.DataTextField = "FullNameFirst";

            //designate the field/property that is the primary key
            ddlStudents.DataValueField = "ID";

            //do the binding
            ddlStudents.DataBind();

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtStudentId.Text = string.Empty;
        }

        protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            student = students[ddlStudents.SelectedIndex];
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtStudentId.Text = student.StudentId;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                student = new Student();

                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.StudentId = txtStudentId.Text;

                int results = StudentManager.Insert(student);

                students.Add(student);

                Response.Write("Inserted " + results + " rows.");

                Rebind();

                if (results > 0)
                {
                    ddlStudents.SelectedValue = student.Id.ToString();
                }

                ddlStudents_SelectedIndexChanged(sender, e);

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
                student = students[ddlStudents.SelectedIndex];
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.StudentId = txtStudentId.Text;

                int results = StudentManager.Update(student);
                Response.Write("Updated " + results + " rows.");
                Rebind();

                if (results > 0)
                {
                    ddlStudents.SelectedValue = student.Id.ToString();
                }
                ddlStudents_SelectedIndexChanged(sender, e);
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
                student = students[ddlStudents.SelectedIndex];

                int results = StudentManager.Delete(student.Id);
                Response.Write("Deleted " + results + " rows.");

                students.Remove(student);
                Rebind();
                ddlStudents_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}