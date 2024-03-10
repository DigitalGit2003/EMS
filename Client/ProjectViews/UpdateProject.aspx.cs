using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.ProjectViews
{
    public partial class UpdateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["projTitle"] != null)
                {
                    string proj_title = Request.QueryString["projTitle"];

                    ProjectServiceClient pc = new ProjectServiceClient();
                    ProjectDTO proj = pc.getProject(proj_title);


                    // Populate the textboxes with existing department details
                    tbTitle.Text = proj.Title;
                    tbStatus.Text = proj.Status;
                }
            }
        }

        protected void btnUpdateProj_Click(object sender, EventArgs e)
        {
            string projTitle = Request.QueryString["projTitle"];
            string deptName = Request.QueryString["deptName"];

            string title = tbTitle.Text;
            string status = tbStatus.Text;

            ProjectDTO projDTO = new ProjectDTO();
            projDTO.Title = title;
            projDTO.Status = status;

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.updateProject(title, projDTO);

            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptName=" + Server.UrlEncode(deptName));  // needs to be changed...  --> dept_name as query string param
        }
    }
}