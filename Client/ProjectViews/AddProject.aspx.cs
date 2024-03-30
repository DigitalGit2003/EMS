using Client.deptServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAddProj_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string status = tbStatus.Text;
            string dept_id = Request.QueryString["deptId"];

            ProjectDTO projDTO = new ProjectDTO();
            projDTO.Title = title;
            projDTO.Status = status;

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.addProject(projDTO, int.Parse(dept_id));

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }
}