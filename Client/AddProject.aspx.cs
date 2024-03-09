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
            if (!IsPostBack)
            {
                deptServiceRef.DepartmentServiceClient dc = new deptServiceRef.DepartmentServiceClient("NetTcpBinding_IDepartmentService");
                List<DepartmentDTO> depts = dc.getDepartments().ToList();

                List<string> deptNames = new List<string>();
                foreach(var dept in depts)
                {
                    deptNames.Add(dept.Name);
                }

                ddlDepts.DataSource = deptNames;
                ddlDepts.DataBind();
            }
        }

        protected void btnAddProj_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string status = tbStatus.Text;
            string deptName = ddlDepts.SelectedValue.ToString();

            ProjectDTO projDTO = new ProjectDTO();
            projDTO.Title = title;
            projDTO.Status = status;

            projServiceRef.ProjectServiceClient pc = new projServiceRef.ProjectServiceClient("NetTcpBinding_IProjectService");
            string s = pc.addProject(projDTO, deptName);

            Label1.Text = s;
        }
    }
}