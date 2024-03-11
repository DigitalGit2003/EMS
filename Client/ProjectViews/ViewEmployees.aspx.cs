using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.ProjectViews
{
    public partial class ViewEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        private void PopulateGridView()
        {
            string proj_title = Request.QueryString["projTitle"];
            lblViewEmployees.Text = "Employees for " + proj_title + " Project.";

            ProjectServiceClient pc = new ProjectServiceClient();
            List<string> projEmployees = pc.viewEmployees(proj_title).ToList();

            if (projEmployees.Count == 0)
            {
                lblViewEmployees.Text = "Employees are working for " + proj_title + " Project Currently.";
                return;
            }

            // Create a DataTable
            DataTable dtProjEmployees = new DataTable();
            dtProjEmployees.Columns.Add("Name");

            // Add rows to the DataTable
            foreach (var projEmployee in projEmployees)
            {
                DataRow dr = dtProjEmployees.NewRow();
                dr["Name"] = projEmployee;
                dtProjEmployees.Rows.Add(dr);
            }

            // Bind the DataTable to GridView
            gvProjEmployees.DataSource = dtProjEmployees;
            gvProjEmployees.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string proj_title = Request.QueryString["projTitle"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string emp_name = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            // write action method to remove emp_name from ProjectEmployees table...
            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.removeEmployeeFromProject(proj_title, emp_name);

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];
            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptName=" + Server.UrlEncode(dept_name));
        }
    }
}