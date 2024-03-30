using Client.empServiceRef;
using Client.projServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeDTO = Client.projServiceRef.EmployeeDTO;

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
            string proj_id = Request.QueryString["projId"];
            lblViewEmployees.Text = "Employees for " + proj_id + " Project.";

            ProjectServiceClient pc = new ProjectServiceClient();
            List<EmployeeDTO> projEmployees = pc.viewEmployees(int.Parse(proj_id)).ToList();

            if (projEmployees.Count == 0)
            {
                lblViewEmployees.Text = "Employees are working for " + proj_id + " Project Currently.";
                return;
            }

            // Create a DataTable
            DataTable dtProjEmployees = new DataTable();
            dtProjEmployees.Columns.Add("EmpId");
            dtProjEmployees.Columns.Add("Name");

            // Add rows to the DataTable
            foreach (var projEmployee in projEmployees)
            {
                DataRow dr = dtProjEmployees.NewRow();
                dr["EmpId"] = projEmployee.EmployeeId;
                dr["Name"] = projEmployee.Name;
                dtProjEmployees.Rows.Add(dr);
            }

            // Bind the DataTable to GridView
            gvProjEmployees.DataSource = dtProjEmployees;
            gvProjEmployees.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string proj_id = Request.QueryString["projId"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string emp_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            // write action method to remove emp_id from ProjectEmployees table...
            ProjectServiceClient pc = new ProjectServiceClient();
            string s = pc.removeEmployeeFromProject(int.Parse(proj_id), int.Parse(emp_id));

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];
            Response.Redirect("/DepartmentViews/DepartmentProjects.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
    }
}