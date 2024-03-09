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
                DepartmentServiceClient dc = new DepartmentServiceClient();
                List<DepartmentDTO> depts = dc.getDepartments().ToList();

                List<string> deptNames = new List<string>();
                foreach (var dept in depts)
                {
                    deptNames.Add(dept.Name);
                }

                ddlDepts.DataSource = deptNames;
                ddlDepts.DataBind();
            }
        }

        protected void btnAddEmp_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int salary = int.Parse(tbSalary.Text);
            string deptName = ddlDepts.SelectedValue.ToString();


            EmployeeDTO empDTO = new EmployeeDTO();
            empDTO.Name = name;
            empDTO.Salary = salary;


            EmployeeServiceClient ec = new EmployeeServiceClient();
            string s = ec.addEmployee(empDTO, deptName);

            Label1.Text = s;
        }
    }
}