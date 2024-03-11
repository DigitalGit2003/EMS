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


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_title = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.deleteProject(proj_title);

            PopulateGridView();
            Label1.Text = proj_title + s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_title = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/UpdateProject.aspx?projTitle=" + Server.UrlEncode(proj_title) + "&deptName=" + Server.UrlEncode(dept_name));
        }

        protected void btnAddEmployees_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];

            Button btnAddEmployees = (Button)sender;
            GridViewRow row = (GridViewRow)btnAddEmployees.NamingContainer;

            string commandArgument = btnAddEmployees.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_title = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/AddEmployees.aspx?projTitle=" + Server.UrlEncode(proj_title) + "&deptName=" + Server.UrlEncode(dept_name));
        }

        protected void btnViewEmployees_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];

            Button btnViewEmployees = (Button)sender;
            GridViewRow row = (GridViewRow)btnViewEmployees.NamingContainer;

            string commandArgument = btnViewEmployees.CommandArgument;
            string[] args = commandArgument.Split(',');

            string proj_title = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/ProjectViews/ViewEmployees.aspx?projTitle=" + Server.UrlEncode(proj_title) + "&deptName=" + Server.UrlEncode(dept_name));
        }
    }
}