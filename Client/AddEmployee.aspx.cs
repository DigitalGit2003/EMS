using Client.deptServiceRef;
using Client.empServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                deptServiceRef.DepartmentServiceClient dc = new deptServiceRef.DepartmentServiceClient("NetTcpBinding_IDepartmentService");
                List<string> deptNames = dc.getDepartmentNames().ToList();

                ddlDepts.DataSource = deptNames;
                ddlDepts.DataBind();
            }
        }

        protected void btnAddEmp_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int salary = int.Parse(tbSalary.Text);
            string deptName = ddlDepts.SelectedValue.ToString();


            Employee emp = new Employee();
            emp.Name = name;
            emp.Salary = salary;


            empServiceRef.EmployeeServiceClient ec = new empServiceRef.EmployeeServiceClient("NetTcpBinding_IEmployeeService");
            string s = ec.addEmployee(emp, deptName);

            Label1.Text = s;
        }
    }
}