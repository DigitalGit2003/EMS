using Client.empServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client.EmployeeViews
{
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["empName"] != null)
                {
                    string emp_name = Request.QueryString["empName"];

                    EmployeeServiceClient ec = new EmployeeServiceClient();
                    EmployeeDTO emp = ec.getEmployee(emp_name);


                    // Populate the textboxes with existing department details
                    tbName.Text = emp.Name;
                    tbSalary.Text = emp.Salary.ToString();
                }
            }
        }

        protected void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            string empName = Request.QueryString["empName"];
            string deptName = Request.QueryString["deptName"];


            string name = tbName.Text;
            int salary = int.Parse(tbSalary.Text);

            EmployeeDTO empDTO = new EmployeeDTO();
            empDTO.Name = name;
            empDTO.Salary = salary;

            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.updateEmployee(empName, empDTO);

            Response.Redirect("/DepartmentViews/DepartmentEmployees.aspx?deptName=" + Server.UrlEncode(deptName));  // needs to be changed... --> dept_name as query string param
        }
    }
}