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
            if (!IsPostBack)
            {
                deptServiceRef.DepartmentServiceClient dc = new deptServiceRef.DepartmentServiceClient("NetTcpBinding_IDepartmentService");
                List<string> deptNames = dc.getDepartmentNames().ToList();

                ddlDepts.DataSource = deptNames;
                ddlDepts.DataBind();
            }
        }

        protected void btnAddProj_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string status = tbStatus.Text;
            string deptName = ddlDepts.SelectedValue.ToString();

            Project proj = new Project();
            proj.Title = title;
            proj.Status = status;

            projServiceRef.ProjectServiceClient pc = new projServiceRef.ProjectServiceClient("NetTcpBinding_IProjectService");
            string s = pc.addProject(proj, deptName);

            Label1.Text = s;
        }
    }
}