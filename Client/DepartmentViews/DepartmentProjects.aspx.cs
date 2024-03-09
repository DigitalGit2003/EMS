using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.DepartmentViews
{
    public partial class DepartmentProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridView();
            }
        }

        private void PopulateGridView()
        {
            if (Request.QueryString["deptName"] != null)
            {
                string dept_name = Request.QueryString["deptName"];
                lblDeptProjects.Text = "Projects of " + dept_name + " Department.";

                // get Projects by deptName
                ProjectServiceClient pc = new ProjectServiceClient();
                List<ProjectDTO> deptProjects = pc.getProjectsByDepartmentName(dept_name).ToList();

                if (deptProjects.Count == 0)
                {
                    lblDeptProjects.Text = "No Projects are there in " + dept_name + " Department Currently.";
                    return;
                }

                // Create a DataTable
                DataTable dtDeptProjects = new DataTable();
                dtDeptProjects.Columns.Add("Title");
                dtDeptProjects.Columns.Add("Status");

                // Add rows to the DataTable
                foreach (var deptProject in deptProjects)
                {
                    DataRow dr = dtDeptProjects.NewRow();
                    dr["Title"] = deptProject.Title;
                    dr["Status"] = deptProject.Status;
                    dtDeptProjects.Rows.Add(dr);
                }

                // Bind the DataTable to GridView
                gvDeptProjects.DataSource = dtDeptProjects;
                gvDeptProjects.DataBind();
            }
        }
    }
}