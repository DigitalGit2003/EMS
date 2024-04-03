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
            if (Request.QueryString["deptId"] != null)
            {
                string dept_id = Request.QueryString["deptId"];
                DepartmentServiceClient dc = new DepartmentServiceClient();
                DepartmentDTO d = dc.getDepartment(int.Parse(dept_id));
                lblDeptEmployees.Text = "Employees of " + d.Name + " Department.";

                // get Employees by deptId
                EmployeeServiceClient ec = new EmployeeServiceClient();
                List<EmployeeDTO> deptEmployees = ec.getEmployeesByDepartmentId(int.Parse(dept_id)).ToList();

                if(deptEmployees.Count == 0)
                {
                    lblDeptEmployees.Text = "No Employees are there in " + d.Name + " Department Currently.";
                    return;
                }

                // Create a DataTable
                DataTable dtDeptEmployees = new DataTable();
                dtDeptEmployees.Columns.Add("EmpId");
                dtDeptEmployees.Columns.Add("Name");
                dtDeptEmployees.Columns.Add("Salary");

                // Add rows to the DataTable
                foreach (var deptEmployee in deptEmployees)
                {
                    DataRow dr = dtDeptEmployees.NewRow();
                    dr["EmpId"] = deptEmployee.EmployeeId;
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

            string emp_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.deleteEmployee(int.Parse(emp_id));

            PopulateGridView();
            Label1.Text = emp_id + s;
            Label1.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string dept_id = Request.QueryString["deptId"];

            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string commandArgument = btnUpdate.CommandArgument;
            string[] args = commandArgument.Split(',');

            string emp_id = args[0];
            int rowIndex = Convert.ToInt32(args[1]);

            Response.Redirect("/EmployeeViews/UpdateEmployee.aspx?empId=" + Server.UrlEncode(emp_id) + "&deptId=" + Server.UrlEncode(dept_id));
        }
    }
}