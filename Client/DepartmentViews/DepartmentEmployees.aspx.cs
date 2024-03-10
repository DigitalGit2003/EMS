using Client.deptServiceRef;
using Client.empServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Client.DepartmentViews
{
    public partial class DepartmentEmployees : System.Web.UI.Page
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
            if (Request.QueryString["deptName"] != null)
            {
                string dept_name = Request.QueryString["deptName"];
                lblDeptEmployees.Text = "Employees of " + dept_name + " Department.";

                // get Employees by deptName
                EmployeeServiceClient ec = new EmployeeServiceClient();
                List<EmployeeDTO> deptEmployees = ec.getEmployeesByDepartmentName(dept_name).ToList();

                if(deptEmployees.Count == 0)
                {
                    lblDeptEmployees.Text = "No Employees are there in " + dept_name + " Department Currently.";
                    return;
                }

                // Create a DataTable
                DataTable dtDeptEmployees = new DataTable();
                dtDeptEmployees.Columns.Add("Name");
                dtDeptEmployees.Columns.Add("Salary");

                // Add rows to the DataTable
                foreach (var deptEmployee in deptEmployees)
                {
                    DataRow dr = dtDeptEmployees.NewRow();
                    dr["Name"] = deptEmployee.Name;
                    dr["Salary"] = deptEmployee.Salary;
                    dtDeptEmployees.Rows.Add(dr);
                }

                // Bind the DataTable to GridView
                gvDeptEmployees.DataSource = dtDeptEmployees;
                gvDeptEmployees.DataBind();
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string commandArgument = btnDelete.CommandArgument;
            string[] args = commandArgument.Split(',');

            string emp_name = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.deleteEmployee(emp_name);

            PopulateGridView();
            Label1.Text = emp_name + s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string dept_name = Request.QueryString["deptName"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string emp_name = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/EmployeeViews/UpdateEmployee.aspx?empName=" + Server.UrlEncode(emp_name) + "&deptName=" + Server.UrlEncode(dept_name));
        }
    }
}