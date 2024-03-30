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
                if (Request.QueryString["projId"] != null)
                {
                    string proj_id = Request.QueryString["projId"];

                    ProjectServiceClient pc = new ProjectServiceClient();
                    ProjectDTO proj = pc.getProject(int.Parse(proj_id));


                    // Populate the textboxes with existing department details
                    tbTitle.Text = proj.Title;
                    tbStatus.Text = proj.Status;
                }
            }
        }

        protected void btnUpdateProj_Click(object sender, EventArgs e)
        {
            string proj_id = Request.QueryString["projId"];
            string dept_id = Request.QueryString["deptId"];

            string title = tbTitle.Text;
            string status = tbStatus.Text;

            ProjectDTO projDTO = new ProjectDTO();
            projDTO.Title = title;
            projDTO.Status = status;

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.updateProject(int.Parse(proj_id), projDTO);

            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
    }
}