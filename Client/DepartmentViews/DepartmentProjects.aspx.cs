using Client.deptServiceRef;
using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
            if (Request.QueryString["deptId"] != null)
            {
                string dept_id = Request.QueryString["deptId"];
                DepartmentServiceClient dc = new DepartmentServiceClient();
                DepartmentDTO d = dc.getDepartment(int.Parse(dept_id));
                lblDeptProjects.Text = "Projects of " + d.Name + " Department.";

                // get Projects by deptId
                ProjectServiceClient pc = new ProjectServiceClient();
                List<ProjectDTO> deptProjects = pc.getProjectsByDepartmentId(int.Parse(dept_id)).ToList();

                if (deptProjects.Count == 0)
                {
                    lblDeptProjects.Text = "No Projects are there in " + d.Name + " Department Currently.";
                    return;
                }

                // Create a DataTable
                DataTable dtDeptProjects = new DataTable();
                dtDeptProjects.Columns.Add("ProjId");
                dtDeptProjects.Columns.Add("Title");
                dtDeptProjects.Columns.Add("Status");

                // Add rows to the DataTable
                foreach (var deptProject in deptProjects)
                {
                    DataRow dr = dtDeptProjects.NewRow();
                    dr["ProjId"] = deptProject.ProjectId;
                    dr["Title"] = deptProject.Title;
                    dr["Status"] = deptProject.Status;
                    dtDeptProjects.Rows.Add(dr);
                }

                // Bind the DataTable to GridView
                gvDeptProjects.DataSource = dtDeptProjects;
                gvDeptProjects.DataBind();
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.deleteProject(int.Parse(proj_id));

            PopulateGridView();
            ProjectDTO proj = pc.getProject(int.Parse(proj_id));
            Label1.Text = proj.Title + " " + s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/UpdateProject.aspx?projId=" + Server.UrlEncode(proj_id) + "&deptId=" + Server.UrlEncode(dept_id));
        }

        protected void btnAddEmployees_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];

            Button btnAddEmployees = (Button)sender;
            GridViewRow row = (GridViewRow)btnAddEmployees.NamingContainer;

            string commandArgument = btnAddEmployees.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/AddEmployees.aspx?projId=" + Server.UrlEncode(proj_id) + "&deptId=" + Server.UrlEncode(dept_id));
        }

        protected void btnViewEmployees_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];

            Button btnViewEmployees = (Button)sender;
            GridViewRow row = (GridViewRow)btnViewEmployees.NamingContainer;

            string commandArgument = btnViewEmployees.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/ViewEmployees.aspx?projId=" + Server.UrlEncode(proj_id) + "&deptId=" + Server.UrlEncode(dept_id));
        }
    }
}