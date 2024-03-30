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
                if (Request.QueryString["empId"] != null)
                {
                    string emp_id = Request.QueryString["empId"];

                    EmployeeServiceClient ec = new EmployeeServiceClient();
                    EmployeeDTO emp = ec.getEmployee(int.Parse(emp_id));


                    // Populate the textboxes with existing department details
                    tbName.Text = emp.Name;
                    tbSalary.Text = emp.Salary.ToString();
                }
            }
        }

        protected void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            string emp_id = Request.QueryString["empId"];
            string dept_id = Request.QueryString["deptId"];


            string name = tbName.Text;
            int salary = int.Parse(tbSalary.Text);

            EmployeeDTO empDTO = new EmployeeDTO();
            empDTO.Name = name;
            empDTO.Salary = salary;

            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.updateEmployee(int.Parse(emp_id), empDTO);

            Response.Redirect("/DepartmentViews/DepartmentEmployees.aspx?deptId=" + Server.UrlEncode(dept_id));
        }
    }
}