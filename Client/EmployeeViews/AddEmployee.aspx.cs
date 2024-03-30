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
            
        }

        protected void btnAddEmp_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int salary = int.Parse(tbSalary.Text);
            string dept_id = Request.QueryString["deptId"];


            EmployeeDTO empDTO = new EmployeeDTO();
            empDTO.Name = name;
            empDTO.Salary = salary;


            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.addEmployee(empDTO, int.Parse(dept_id));

            Label1.Text = s;
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }
}