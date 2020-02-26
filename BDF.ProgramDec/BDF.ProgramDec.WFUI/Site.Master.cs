using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDF.ProgramDec.WFUI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the programs
            List<Program> programs = ProgramManager.Load();

            // Bind the data to the data repeater
            dpPrograms.DataSource = programs;
            dpPrograms.DataBind();
        }
    }
}